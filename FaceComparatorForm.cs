using detect_a_person_in_video.UserControls;
using System.Collections.Generic;
using System.Windows.Forms;

namespace detect_a_person_in_video
{
    public partial class FaceComparatorForm : Form
    {
        public string FaceOriginImageSource
        {
            get { return fctlOrigin.FaceImageSource; }
            set { fctlOrigin.FaceImageSource = value; }
        }

        public void LoadDetectionResults(List<DetectionResult> detectionResults)
        {
            foreach (var detectionResult in detectionResults)
            {
                var faceControl = new FaceControl();
                faceControl.FaceImageSource = detectionResult.ExtractFrame;
                int faceFrameSeconds = FaceImageHelper.ExtractSecondsInFaceImageName(detectionResult.ExtractFrame);
                faceControl.FaceName = string.Format("{0}s, {1}%", faceFrameSeconds, detectionResult.Confidence * 100);
                flpResult.Controls.Add(faceControl);
            }
        }

        public FaceComparatorForm()
        {
            InitializeComponent();
        }
    }
}