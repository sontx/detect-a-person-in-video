using System.Windows.Forms;

namespace detect_a_person_in_video.UserControls
{
    public partial class FaceControl : UserControl
    {
        public string FaceName
        {
            get { return labFaceName.Text; }
            set { labFaceName.Text = value; }
        }

        public string FaceImageSource
        {
            get { return pbxFaceImage.ImageLocation; ; }
            set { pbxFaceImage.ImageLocation = value; }
        }

        public FaceControl()
        {
            InitializeComponent();
        }
    }
}
