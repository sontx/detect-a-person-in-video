using detect_a_person_in_video.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace detect_a_person_in_video
{
    class MainUIHandler
    {
        private readonly IMainUserInterface mainUserInterface;
        private readonly VisionService visionService;
        private readonly string outputFacesDir;

        public string VideoInputPath
        {
            get { return visionService.VideoInputPath; }
            set
            {
                visionService.VideoInputPath = value;
                mainUserInterface.DisplayVideoInput(value);
            }
        }

        public string ImageInputPath
        {
            get { return visionService.ImageInputPath; }
            set
            {
                visionService.ImageInputPath = value;
                mainUserInterface.DisplayFaceInput(value);
            }
        }

        public int SkipTime { get; set; } = 1000;

        public MainUIHandler(IMainUserInterface mainUserInterface)
        {
            this.mainUserInterface = mainUserInterface;
            visionService = new VisionService();
            visionService.FaceApiSubscriptionKey = Resources.face_api_subscription_key;
            visionService.VideoApiSubscriptionKey = Resources.video_api_subscription_key;
            visionService.Logable = mainUserInterface;
            outputFacesDir = Resources.output_dir_name;
            if (!Directory.Exists(outputFacesDir))
                Directory.CreateDirectory(outputFacesDir);
        }

        public async void Process()
        {
            if (visionService.ImageInputPath == null || !File.Exists(visionService.ImageInputPath))
            {
                mainUserInterface.ShowMessageBox("Face input is empty or do not exists!", MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
            }
            else if (visionService.VideoInputPath == null || !File.Exists(visionService.VideoInputPath))
            {
                mainUserInterface.ShowMessageBox("Video input is empty or do not exists!", MessageBoxIcon.Exclamation, MessageBoxButtons.OK);
            }
            else
            {
                var result = await StartDetectAsync();
                if (result.Success)
                    mainUserInterface.DisplayProcessResult(result.DetectionResults);
                else
                    mainUserInterface.ShowMessageBox(result.ErrorMessage, MessageBoxIcon.Error, MessageBoxButtons.OK);
            }
        }

        private void CleanOutputFacesDirectory()
        {
            var files = Directory.GetFiles(outputFacesDir);
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }

        private Task<ProcessResult> StartDetectAsync()
        {
            return Task.Run(async () =>
            {
                ProcessResult processResult = new ProcessResult();
                processResult.Success = false;
                try
                {
                    CleanOutputFacesDirectory();

                    var highlights = await visionService.DetectFacesAsync();

                    if (highlights != null)
                    {
                        var facesList = await visionService.ExportToImagesAsync(highlights, outputFacesDir);
                        if (facesList != null)
                        {
                            mainUserInterface.WriteLog(string.Format("Exported {0} faces to {1}.", facesList.Count, outputFacesDir));
                            var detectionResults = await visionService.VerifyFacesAsync(outputFacesDir);
                            if (detectionResults != null)
                            {
                                processResult.DetectionResults = detectionResults;
                                processResult.Success = true;
                            }
                        }
                        else
                        {
                            processResult.ErrorMessage = "Can not export to " + outputFacesDir;
                        }
                    }
                }
                catch (Exception ex)
                {
                    processResult.ErrorMessage = ex.Message;
                }
                return processResult;
            });
        }

        private class ProcessResult
        {
            public bool Success { get; set; }
            public string ErrorMessage { get; set; }
            public List<DetectionResult> DetectionResults { get; set; }
        }
    }
}
