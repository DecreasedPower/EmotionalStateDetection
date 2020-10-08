namespace EmotionalStateDetection
{
    partial class MainScreenForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialogDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.panelParameters = new System.Windows.Forms.Panel();
            this.labelInterval = new System.Windows.Forms.Label();
            this.checkBoxScreenshot = new System.Windows.Forms.CheckBox();
            this.labelDirectory = new System.Windows.Forms.Label();
            this.buttonDirectory = new System.Windows.Forms.Button();
            this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
            this.textBoxDirectory = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonDetect = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.backgroundWorkerShooting = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDetection = new System.ComponentModel.BackgroundWorker();
            this.notifyIconCapturing = new System.Windows.Forms.NotifyIcon(this.components);
            this.panelImage = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panelParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelParameters
            // 
            this.panelParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelParameters.Controls.Add(this.labelInterval);
            this.panelParameters.Controls.Add(this.checkBoxScreenshot);
            this.panelParameters.Controls.Add(this.labelDirectory);
            this.panelParameters.Controls.Add(this.buttonDirectory);
            this.panelParameters.Controls.Add(this.numericUpDownInterval);
            this.panelParameters.Controls.Add(this.textBoxDirectory);
            this.panelParameters.Location = new System.Drawing.Point(434, 12);
            this.panelParameters.Name = "panelParameters";
            this.panelParameters.Size = new System.Drawing.Size(223, 73);
            this.panelParameters.TabIndex = 20;
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(-3, 7);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(59, 13);
            this.labelInterval.TabIndex = 10;
            this.labelInterval.Text = "Интервал:";
            // 
            // checkBoxScreenshot
            // 
            this.checkBoxScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxScreenshot.AutoSize = true;
            this.checkBoxScreenshot.Checked = true;
            this.checkBoxScreenshot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxScreenshot.Location = new System.Drawing.Point(0, 51);
            this.checkBoxScreenshot.Name = "checkBoxScreenshot";
            this.checkBoxScreenshot.Size = new System.Drawing.Size(144, 17);
            this.checkBoxScreenshot.TabIndex = 16;
            this.checkBoxScreenshot.Text = "Делать снимки экрана";
            this.checkBoxScreenshot.UseVisualStyleBackColor = true;
            // 
            // labelDirectory
            // 
            this.labelDirectory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDirectory.Location = new System.Drawing.Point(-3, 32);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(96, 13);
            this.labelDirectory.TabIndex = 11;
            this.labelDirectory.Text = "Путь сохранения:";
            // 
            // buttonDirectory
            // 
            this.buttonDirectory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonDirectory.Location = new System.Drawing.Point(197, 25);
            this.buttonDirectory.Name = "buttonDirectory";
            this.buttonDirectory.Size = new System.Drawing.Size(26, 20);
            this.buttonDirectory.TabIndex = 9;
            this.buttonDirectory.Text = "...";
            this.buttonDirectory.UseVisualStyleBackColor = true;
            this.buttonDirectory.Click += new System.EventHandler(this.buttonDirectory_Click);
            // 
            // numericUpDownInterval
            // 
            this.numericUpDownInterval.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownInterval.Location = new System.Drawing.Point(91, 0);
            this.numericUpDownInterval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownInterval.Name = "numericUpDownInterval";
            this.numericUpDownInterval.Size = new System.Drawing.Size(132, 20);
            this.numericUpDownInterval.TabIndex = 6;
            this.numericUpDownInterval.ValueChanged += new System.EventHandler(this.numericUpDownInterval_ValueChanged);
            // 
            // textBoxDirectory
            // 
            this.textBoxDirectory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxDirectory.Location = new System.Drawing.Point(94, 25);
            this.textBoxDirectory.Name = "textBoxDirectory";
            this.textBoxDirectory.ReadOnly = true;
            this.textBoxDirectory.Size = new System.Drawing.Size(100, 20);
            this.textBoxDirectory.TabIndex = 8;
            this.textBoxDirectory.Text = "C:\\";
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelButtons.Controls.Add(this.buttonDetect);
            this.panelButtons.Controls.Add(this.buttonStart);
            this.panelButtons.Location = new System.Drawing.Point(553, 258);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(108, 58);
            this.panelButtons.TabIndex = 19;
            // 
            // buttonDetect
            // 
            this.buttonDetect.Enabled = false;
            this.buttonDetect.Location = new System.Drawing.Point(0, 32);
            this.buttonDetect.Name = "buttonDetect";
            this.buttonDetect.Size = new System.Drawing.Size(108, 23);
            this.buttonDetect.TabIndex = 13;
            this.buttonDetect.Text = "Распознать";
            this.buttonDetect.UseVisualStyleBackColor = true;
            this.buttonDetect.Click += new System.EventHandler(this.buttonDetect_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(0, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(108, 23);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "Начать запись";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // backgroundWorkerShooting
            // 
            this.backgroundWorkerShooting.WorkerSupportsCancellation = true;
            this.backgroundWorkerShooting.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerShooting_DoWork);
            // 
            // backgroundWorkerDetection
            // 
            this.backgroundWorkerDetection.WorkerSupportsCancellation = true;
            this.backgroundWorkerDetection.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDetection_DoWork);
            // 
            // notifyIconCapturing
            // 
            this.notifyIconCapturing.Text = "notifyIcon1";
            this.notifyIconCapturing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconCapturing_MouseClick);
            // 
            // panelImage
            // 
            this.panelImage.Controls.Add(this.pictureBoxImage);
            this.panelImage.Location = new System.Drawing.Point(12, 12);
            this.panelImage.Name = "panelImage";
            this.panelImage.Size = new System.Drawing.Size(410, 308);
            this.panelImage.TabIndex = 18;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(410, 308);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            // 
            // MainScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 332);
            this.Controls.Add(this.panelParameters);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelImage);
            this.MaximumSize = new System.Drawing.Size(692, 371);
            this.MinimumSize = new System.Drawing.Size(692, 371);
            this.Name = "MainScreenForm";
            this.Text = "Emotional State Detection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreenForm_FormClosing);
            this.Load += new System.EventHandler(this.MainScreenForm_Load);
            this.Resize += new System.EventHandler(this.MainScreenForm_Resize);
            this.panelParameters.ResumeLayout(false);
            this.panelParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogDirectory;
        private System.Windows.Forms.Panel panelParameters;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.CheckBox checkBoxScreenshot;
        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.Button buttonDirectory;
        private System.Windows.Forms.NumericUpDown numericUpDownInterval;
        private System.Windows.Forms.TextBox textBoxDirectory;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonDetect;
        private System.Windows.Forms.Button buttonStart;
        private System.ComponentModel.BackgroundWorker backgroundWorkerShooting;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDetection;
        private System.Windows.Forms.NotifyIcon notifyIconCapturing;
        private System.Windows.Forms.Panel panelImage;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}

