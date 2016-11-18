using System;
using System.Windows.Forms;

namespace detect_a_person_in_video
{
    public partial class MainForm : Form, IMainUserInterface
    {
        private MainUIHandler mainUIHandler;

        public MainForm()
        {
            InitializeComponent();
            mainUIHandler = new MainUIHandler(this);
        }

        private void btnVideoInput_Click(object sender, EventArgs e)
        {
            if (openVideoFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openVideoFileDialog.FileName;
                txtVideoInput.Text = fileName;
                mainUIHandler.VideoInputPath = fileName;   
            }
        }

        private void btnFaceInput_Click(object sender, EventArgs e)
        {
            if (openFaceFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = openFaceFileDialog.FileName;
                txtFaceInput.Text = fileName;
                mainUIHandler.ImageInputPath = fileName;          
            }
        }

        private void WriteLog(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
        }

        #region Implements IMainUserInterface Interface

        public void WriteLog(object obj)
        {
            string message = obj != null ? obj.ToString() : "NULL";
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate { WriteLog(message); });
            else
                WriteLog(message);
        }

        public void DisplayFaceInput(string imagePath)
        {
            pbxFaceInput.ImageLocation = imagePath;
        }

        public void DisplayVideoInput(string videoPath)
        {
            playerVideoInput.URL = videoPath;
        }

        #endregion

    }
}
