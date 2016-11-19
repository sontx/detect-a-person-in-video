namespace detect_a_person_in_video
{
    partial class FaceComparatorForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaceComparatorForm));
            this.flpResult = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fctlOrigin = new detect_a_person_in_video.UserControls.FaceControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpResult
            // 
            this.flpResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpResult.Location = new System.Drawing.Point(0, 147);
            this.flpResult.Name = "flpResult";
            this.flpResult.Size = new System.Drawing.Size(724, 443);
            this.flpResult.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fctlOrigin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(724, 147);
            this.panel1.TabIndex = 1;
            // 
            // fctlOrigin
            // 
            this.fctlOrigin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctlOrigin.FaceImageSource = null;
            this.fctlOrigin.FaceName = "Origin Face";
            this.fctlOrigin.Location = new System.Drawing.Point(5, 5);
            this.fctlOrigin.Name = "fctlOrigin";
            this.fctlOrigin.Size = new System.Drawing.Size(714, 137);
            this.fctlOrigin.TabIndex = 0;
            // 
            // FaceComparatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 590);
            this.Controls.Add(this.flpResult);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FaceComparatorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compare Result";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpResult;
        private System.Windows.Forms.Panel panel1;
        private UserControls.FaceControl fctlOrigin;
    }
}