namespace detect_a_person_in_video.UserControls
{
    partial class FaceControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbxFaceImage = new System.Windows.Forms.PictureBox();
            this.labFaceName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFaceImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxFaceImage
            // 
            this.pbxFaceImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxFaceImage.Location = new System.Drawing.Point(3, 3);
            this.pbxFaceImage.Name = "pbxFaceImage";
            this.pbxFaceImage.Size = new System.Drawing.Size(144, 121);
            this.pbxFaceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFaceImage.TabIndex = 0;
            this.pbxFaceImage.TabStop = false;
            // 
            // labFaceName
            // 
            this.labFaceName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labFaceName.Location = new System.Drawing.Point(3, 124);
            this.labFaceName.Name = "labFaceName";
            this.labFaceName.Size = new System.Drawing.Size(144, 23);
            this.labFaceName.TabIndex = 1;
            this.labFaceName.Text = "...";
            this.labFaceName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FaceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbxFaceImage);
            this.Controls.Add(this.labFaceName);
            this.Name = "FaceControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFaceImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxFaceImage;
        private System.Windows.Forms.Label labFaceName;
    }
}
