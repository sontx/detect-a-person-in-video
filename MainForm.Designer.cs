namespace detect_a_person_in_video
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVideoInput = new System.Windows.Forms.TextBox();
            this.txtFaceInput = new System.Windows.Forms.TextBox();
            this.btnVideoInput = new System.Windows.Forms.Button();
            this.btnFaceInput = new System.Windows.Forms.Button();
            this.openVideoFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFaceFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pbxFaceInput = new System.Windows.Forms.PictureBox();
            this.playerVideoInput = new AxWMPLib.AxWindowsMediaPlayer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFaceInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerVideoInput)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Video Input:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Face Input:";
            // 
            // txtVideoInput
            // 
            this.txtVideoInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoInput.Location = new System.Drawing.Point(82, 12);
            this.txtVideoInput.Name = "txtVideoInput";
            this.txtVideoInput.Size = new System.Drawing.Size(673, 20);
            this.txtVideoInput.TabIndex = 2;
            // 
            // txtFaceInput
            // 
            this.txtFaceInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFaceInput.Location = new System.Drawing.Point(82, 42);
            this.txtFaceInput.Name = "txtFaceInput";
            this.txtFaceInput.Size = new System.Drawing.Size(673, 20);
            this.txtFaceInput.TabIndex = 2;
            // 
            // btnVideoInput
            // 
            this.btnVideoInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVideoInput.Location = new System.Drawing.Point(761, 10);
            this.btnVideoInput.Name = "btnVideoInput";
            this.btnVideoInput.Size = new System.Drawing.Size(41, 23);
            this.btnVideoInput.TabIndex = 3;
            this.btnVideoInput.Text = "...";
            this.btnVideoInput.UseVisualStyleBackColor = true;
            this.btnVideoInput.Click += new System.EventHandler(this.btnVideoInput_Click);
            // 
            // btnFaceInput
            // 
            this.btnFaceInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFaceInput.Location = new System.Drawing.Point(761, 39);
            this.btnFaceInput.Name = "btnFaceInput";
            this.btnFaceInput.Size = new System.Drawing.Size(41, 23);
            this.btnFaceInput.TabIndex = 3;
            this.btnFaceInput.Text = "...";
            this.btnFaceInput.UseVisualStyleBackColor = true;
            this.btnFaceInput.Click += new System.EventHandler(this.btnFaceInput_Click);
            // 
            // openVideoFileDialog
            // 
            this.openVideoFileDialog.Filter = "Video files (*.mp4, *.mov, *.wmv)|*.mp4;*.mov;*.wmv";
            // 
            // openFaceFileDialog
            // 
            this.openFaceFileDialog.Filter = "Image files |*.jpeg; *.jpg; *.png; *.bmp;*.gif";
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(808, 10);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(56, 52);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(429, 3);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(421, 551);
            this.txtLog.TabIndex = 5;
            // 
            // pbxFaceInput
            // 
            this.pbxFaceInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxFaceInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxFaceInput.Image = global::detect_a_person_in_video.Properties.Resources.logo;
            this.pbxFaceInput.Location = new System.Drawing.Point(3, 3);
            this.pbxFaceInput.Name = "pbxFaceInput";
            this.pbxFaceInput.Size = new System.Drawing.Size(414, 269);
            this.pbxFaceInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxFaceInput.TabIndex = 6;
            this.pbxFaceInput.TabStop = false;
            // 
            // playerVideoInput
            // 
            this.playerVideoInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerVideoInput.Enabled = true;
            this.playerVideoInput.Location = new System.Drawing.Point(3, 278);
            this.playerVideoInput.Name = "playerVideoInput";
            this.playerVideoInput.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("playerVideoInput.OcxState")));
            this.playerVideoInput.Size = new System.Drawing.Size(414, 270);
            this.playerVideoInput.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.pbxFaceInput, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.playerVideoInput, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 551);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtLog, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(11, 77);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(853, 557);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 646);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnFaceInput);
            this.Controls.Add(this.btnVideoInput);
            this.Controls.Add(this.txtFaceInput);
            this.Controls.Add(this.txtVideoInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detect A Person In A Video";
            ((System.ComponentModel.ISupportInitialize)(this.pbxFaceInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerVideoInput)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVideoInput;
        private System.Windows.Forms.TextBox txtFaceInput;
        private System.Windows.Forms.Button btnVideoInput;
        private System.Windows.Forms.Button btnFaceInput;
        private System.Windows.Forms.OpenFileDialog openVideoFileDialog;
        private System.Windows.Forms.OpenFileDialog openFaceFileDialog;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.PictureBox pbxFaceInput;
        private AxWMPLib.AxWindowsMediaPlayer playerVideoInput;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

