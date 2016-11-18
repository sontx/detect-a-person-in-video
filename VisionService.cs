﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Video;
using Microsoft.ProjectOxford.Video.Contract;
using System.IO;
using System.Diagnostics;
using Accord.Video.FFMPEG;
using System.Drawing;
using System.Runtime.InteropServices;

namespace detect_a_person_in_video
{
    class VisionService
    {
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117
        }

        public ILogable Logable { get; set; }
        public string VideoInputPath { get; set; }
        public string ImageInputPath { get; set; }
        public string VideoApiSubscriptionKey { get; set; }
        public string FaceApiSubscriptionKey { get; set; }
        public TimeSpan QueryWaitTime { get; private set; } = TimeSpan.FromSeconds(20);
        private readonly float dpi;

        public VisionService()
        {
            dpi = GetDpi();
        }

        private float GetDpi()
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

            return ScreenScalingFactor;
        }

        private Bitmap GetBitmap(VideoFileReader reader, ref long currentFrame, int timeInSeconds)
        {
            long framesToSkip = reader.FrameRate * timeInSeconds - currentFrame;
            for (int i = 0; i < framesToSkip; ++i)
            {
                var bitmap = reader.ReadVideoFrame();
                if (bitmap != null)
                    bitmap.Dispose();
            }
            currentFrame += framesToSkip;
            return reader.ReadVideoFrame();
        }

        private Bitmap CropBitmap(Bitmap bitmap, Rect rect)
        {
            return bitmap.Clone(new Rectangle((int)(rect.Left * bitmap.Width), (int)(rect.Top * bitmap.Height), 
                (int)(rect.Width * bitmap.Width), (int)(rect.Height * bitmap.Height)), bitmap.PixelFormat);
        }

        public Task<List<string>> ExportToImagesAsync(IEnumerable<FrameHighlight> frameHighlights, string outputDir)
        {
            return Task.Run(() =>
            {
                List<string> facesList = new List<string>();
                using (VideoFileReader reader = new VideoFileReader())
                {
                    reader.Open(VideoInputPath);
                    long currentFrame = 0;
                    int lastTime = -1;
                    foreach (var frameHighlight in frameHighlights)
                    {   
                        int frameTime = (int)frameHighlight.Time;
                        if (lastTime < frameTime)
                        {
                            using (var frameImage = GetBitmap(reader, ref currentFrame, frameTime))
                            {
                                for (int i = 0; i < frameHighlight.HighlightRects.Length; ++i)
                                {
                                    var rect = frameHighlight.HighlightRects[i];
                                    if (!rect.IsEmpty)
                                    {
                                        using (var faceImage = CropBitmap(frameImage, rect))
                                        {
                                            string faceFilePath = Path.Combine(outputDir, string.Format("{0}_{1}.png", currentFrame, i));
                                            faceImage.Save(faceFilePath);
                                            facesList.Add(faceFilePath);
                                        }
                                    }
                                }
                            }
                            lastTime = frameTime;
                        }
                    }
                }
                return facesList;
            });
        }

        public Task<IEnumerable<FrameHighlight>> DetectFacesAsync()
        {
            return Task.Run(() =>
            {
                return DetectFaces(VideoApiSubscriptionKey, VideoInputPath);
            });
        }

        private IEnumerable<FrameHighlight> DetectFaces(string subscriptionKey, string filePath)
        {
            Logable.WriteLog("Start face tracking");
            VideoServiceClient client = new VideoServiceClient(subscriptionKey);
            
            client.Timeout = TimeSpan.FromMinutes(10);

            using (FileStream originalStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                // Creates a video operation of face tracking
                Logable.WriteLog("Start uploading video");
                Operation operation = client.CreateOperationAsync(originalStream, new FaceDetectionOperationSettings()).Result;
                Logable.WriteLog("Uploading video done");

                // Starts querying service status
                OperationResult result = client.GetOperationResultAsync(operation).Result;
                while (result.Status != OperationStatus.Succeeded && result.Status != OperationStatus.Failed)
                {
                    Logable.WriteLog(string.Format("Server status: {0}, wait {1} seconds...", result.Status, QueryWaitTime.TotalSeconds));
                    Task.Delay(QueryWaitTime).Wait();
                    result = client.GetOperationResultAsync(operation).Result;
                }
                Logable.WriteLog("Finish processing with server status: " + result.Status);

                // Processing finished, checks result
                if (result.Status == OperationStatus.Succeeded)
                {
                    // Gets output JSON
                    Logable.WriteLog("Downloading result done");
                    Debug.WriteLine(JsonHelper.FormatJson<FaceTracking>(result.ProcessingResult));
                    var frameHighlights = GetHighlights(result.ProcessingResult).ToList();
                    return frameHighlights;
                }
                else
                {
                    // Failed
                    Logable.WriteLog("Fail reason: " + result.Message);
                }
            }
            return null;
        }
        
        /// <summary>
        /// This method parses the JSON output, and converts to a sequence of time frames with highlight regions.  
        /// One highlight region reprensents a tracked face in the frame.
        /// </summary>
        /// <param name="json">JSON output of face tracking result.</param>
        /// <returns>Sequence of time frames with highlight regions.</returns>
        private IEnumerable<FrameHighlight> GetHighlights(string json)
        {
            FaceTracking faceTrackingResult = JsonHelper.FromJson<FaceTracking>(json);

            if (faceTrackingResult.FacesDetected == null) yield break;

            float timescale = (float)faceTrackingResult.Timescale;

            Rect invisibleRect = new Rect(new Point(0, 0), new Size(0, 0));  // Uses this rectangle if a specific face is not showing in one frame

            foreach (Fragment<FaceEvent> fragment in faceTrackingResult.Fragments)
            {
                FaceEvent[][] events = fragment.Events;
                if (events == null || events.Length == 0)
                {
                    // If 'Events' is empty, there isn't any face detected in this fragment
                    Rect[] rects = new Rect[faceTrackingResult.FacesDetected.Length];
                    for (int i = 0; i < rects.Length; i++) rects[i] = invisibleRect;

                    yield return new FrameHighlight() { Time = fragment.Start / timescale, HighlightRects = rects };
                }
                else
                {
                    long interval = fragment.Interval.GetValueOrDefault();
                    long start = fragment.Start;
                    int i = 0;
                    foreach (FaceEvent[] evt in events)
                    {
                        Rect[] rects = faceTrackingResult.FacesDetected.Select(face =>
                        {
                            FaceEvent faceRect = evt.FirstOrDefault(x => x.Id == face.FaceId);
                            if (faceRect == null) return invisibleRect;

                            // Creates highlight region at the location of the tracked face
                            return new Rect(new Point(faceRect.X * dpi, faceRect.Y * dpi), 
                                new Size(faceRect.Width * dpi, faceRect.Height * dpi));
                        }).ToArray();

                        yield return new FrameHighlight() { Time = (start + interval * i) / timescale, HighlightRects = rects };

                        i++;
                    }
                }
            }
        }
    }
}
