using System;
using System.Collections.Generic;
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

        private void btnProcess_Click(object sender, EventArgs e)
        {
            mainUIHandler.Process();
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

        public DialogResult ShowMessageBox(string message, MessageBoxIcon icon, MessageBoxButtons buttons)
        {
            if (InvokeRequired)
            {
                DialogResult result = DialogResult.Cancel;
                Invoke((MethodInvoker)delegate { result = MessageBox.Show(this, message, Text, buttons, icon); });
                return result;
            }
            else
            {
                return MessageBox.Show(this, message, Text, buttons, icon);
            }
        }

        public void DisplayProcessResult(List<DetectionResult> detectionResults)
        {
            Invoke((MethodInvoker)delegate
            {
                if (detectionResults == null || detectionResults.Count == 0)
                {
                    ShowMessageBox("The face do not appear in the video.", MessageBoxIcon.Information, MessageBoxButtons.OK);
                }
                else
                {
                    FaceComparatorForm faceComparatorForm = new FaceComparatorForm();
                    faceComparatorForm.FaceOriginImageSource = mainUIHandler.ImageInputPath;
                    faceComparatorForm.LoadDetectionResults(detectionResults);
                    faceComparatorForm.ShowDialog(this);
                }
            });
        }

        #endregion Implements IMainUserInterface Interface
    }
}