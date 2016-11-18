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

        private Task<ProcessResult> StartDetectAsync()
        {
            return Task.Run(async () =>
            {
                var highlights = await visionService.DetectFacesAsync();
                ProcessResult processResult = new ProcessResult();
                processResult.Success = false;
                if (highlights != null)
                {
                    string outputDir = "E:\\output";
                    var facesList = await visionService.ExportToImagesAsync(highlights, outputDir);
                    if (facesList != null)
                    {
                        mainUserInterface.WriteLog(string.Format("Exported {0} faces to {1}.", facesList.Count, outputDir));
                        processResult.Success = true;
                    }
                    else
                        mainUserInterface.ShowMessageBox("Can not export to " + outputDir, MessageBoxIcon.Error, MessageBoxButtons.OK);
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
