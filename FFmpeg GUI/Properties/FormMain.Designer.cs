namespace FFmpeg_GUI.Properties
{
    partial class FormMain
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPageInput = new System.Windows.Forms.TabPage();
            this.ButtonBrowsePath = new System.Windows.Forms.Button();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.TextBoxTargetPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TabPageVideo = new System.Windows.Forms.TabPage();
            this.ComboBoxVideoRotation = new System.Windows.Forms.ComboBox();
            this.TextBoxVideoResolutionHeight = new System.Windows.Forms.TextBox();
            this.TextBoxVideoResolutionWidth = new System.Windows.Forms.TextBox();
            this.TextBoxVideoBitrate = new System.Windows.Forms.TextBox();
            this.CheckBoxVideoRotation = new System.Windows.Forms.CheckBox();
            this.CheckBoxVideoResolution = new System.Windows.Forms.CheckBox();
            this.CheckBoxVideoBitrate = new System.Windows.Forms.CheckBox();
            this.ComboBoxVideoCodec = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckBoxVideo = new System.Windows.Forms.CheckBox();
            this.TabPageAudio = new System.Windows.Forms.TabPage();
            this.TextBoxAudioVolumeMultiplier = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxAudioSamplingRate = new System.Windows.Forms.TextBox();
            this.TextBoxAudioBitrate = new System.Windows.Forms.TextBox();
            this.CheckBoxAudioVolumeMultiplier = new System.Windows.Forms.CheckBox();
            this.CheckBoxAudioSamplingRate = new System.Windows.Forms.CheckBox();
            this.CheckBoxAudioBitrate = new System.Windows.Forms.CheckBox();
            this.ComboBoxAudioCodec = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CheckBoxAudio = new System.Windows.Forms.CheckBox();
            this.TabPageStatus = new System.Windows.Forms.TabPage();
            this.ButtonConvert = new System.Windows.Forms.Button();
            this.CheckBoxEnableSelection = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TextBoxStartHour = new System.Windows.Forms.TextBox();
            this.TextBoxStartMinute = new System.Windows.Forms.TextBox();
            this.TextBoxStartSecond = new System.Windows.Forms.TextBox();
            this.TextBoxEndHour = new System.Windows.Forms.TextBox();
            this.TextBoxEndMinute = new System.Windows.Forms.TextBox();
            this.TextBoxEndSecond = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TextBoxStartMillisecond = new System.Windows.Forms.TextBox();
            this.TextBoxEndMillisecond = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.LabelCurrentFile = new System.Windows.Forms.Label();
            this.LabelOriginalSize = new System.Windows.Forms.Label();
            this.LabelFinalSize = new System.Windows.Forms.Label();
            this.LabelProcessed = new System.Windows.Forms.Label();
            this.LabelProcessingSpeed = new System.Windows.Forms.Label();
            this.LabelTimeElapsed = new System.Windows.Forms.Label();
            this.LabelTimeRemaining = new System.Windows.Forms.Label();
            this.LabelProgress = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.ProgressBarProgress = new System.Windows.Forms.ProgressBar();
            this.TabControl.SuspendLayout();
            this.TabPageInput.SuspendLayout();
            this.TabPageVideo.SuspendLayout();
            this.TabPageAudio.SuspendLayout();
            this.TabPageStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPageInput);
            this.TabControl.Controls.Add(this.TabPageVideo);
            this.TabControl.Controls.Add(this.TabPageAudio);
            this.TabControl.Controls.Add(this.TabPageStatus);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(708, 588);
            this.TabControl.TabIndex = 0;
            // 
            // TabPageInput
            // 
            this.TabPageInput.Controls.Add(this.label17);
            this.TabPageInput.Controls.Add(this.label16);
            this.TabPageInput.Controls.Add(this.TextBoxEndMillisecond);
            this.TabPageInput.Controls.Add(this.TextBoxStartMillisecond);
            this.TabPageInput.Controls.Add(this.label15);
            this.TabPageInput.Controls.Add(this.label14);
            this.TabPageInput.Controls.Add(this.label13);
            this.TabPageInput.Controls.Add(this.label12);
            this.TabPageInput.Controls.Add(this.TextBoxEndSecond);
            this.TabPageInput.Controls.Add(this.TextBoxEndMinute);
            this.TabPageInput.Controls.Add(this.TextBoxEndHour);
            this.TabPageInput.Controls.Add(this.TextBoxStartSecond);
            this.TabPageInput.Controls.Add(this.TextBoxStartMinute);
            this.TabPageInput.Controls.Add(this.TextBoxStartHour);
            this.TabPageInput.Controls.Add(this.label11);
            this.TabPageInput.Controls.Add(this.label9);
            this.TabPageInput.Controls.Add(this.CheckBoxEnableSelection);
            this.TabPageInput.Controls.Add(this.ButtonBrowsePath);
            this.TabPageInput.Controls.Add(this.ButtonBrowse);
            this.TabPageInput.Controls.Add(this.TextBoxTargetPath);
            this.TabPageInput.Controls.Add(this.label2);
            this.TabPageInput.Controls.Add(this.label1);
            this.TabPageInput.Location = new System.Drawing.Point(4, 29);
            this.TabPageInput.Name = "TabPageInput";
            this.TabPageInput.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageInput.Size = new System.Drawing.Size(700, 411);
            this.TabPageInput.TabIndex = 0;
            this.TabPageInput.Text = "Input";
            this.TabPageInput.UseVisualStyleBackColor = true;
            // 
            // ButtonBrowsePath
            // 
            this.ButtonBrowsePath.Location = new System.Drawing.Point(607, 81);
            this.ButtonBrowsePath.Name = "ButtonBrowsePath";
            this.ButtonBrowsePath.Size = new System.Drawing.Size(75, 29);
            this.ButtonBrowsePath.TabIndex = 5;
            this.ButtonBrowsePath.Text = "...";
            this.ButtonBrowsePath.UseVisualStyleBackColor = true;
            this.ButtonBrowsePath.Click += new System.EventHandler(this.ButtonBrowsePath_Click);
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(118, 28);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(75, 29);
            this.ButtonBrowse.TabIndex = 4;
            this.ButtonBrowse.Text = "...";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // TextBoxTargetPath
            // 
            this.TextBoxTargetPath.Enabled = false;
            this.TextBoxTargetPath.Location = new System.Drawing.Point(118, 82);
            this.TextBoxTargetPath.Name = "TextBoxTargetPath";
            this.TextBoxTargetPath.Size = new System.Drawing.Size(465, 26);
            this.TextBoxTargetPath.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Save Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File(s):";
            // 
            // TabPageVideo
            // 
            this.TabPageVideo.Controls.Add(this.ComboBoxVideoRotation);
            this.TabPageVideo.Controls.Add(this.TextBoxVideoResolutionHeight);
            this.TabPageVideo.Controls.Add(this.TextBoxVideoResolutionWidth);
            this.TabPageVideo.Controls.Add(this.TextBoxVideoBitrate);
            this.TabPageVideo.Controls.Add(this.CheckBoxVideoRotation);
            this.TabPageVideo.Controls.Add(this.CheckBoxVideoResolution);
            this.TabPageVideo.Controls.Add(this.CheckBoxVideoBitrate);
            this.TabPageVideo.Controls.Add(this.ComboBoxVideoCodec);
            this.TabPageVideo.Controls.Add(this.label7);
            this.TabPageVideo.Controls.Add(this.label6);
            this.TabPageVideo.Controls.Add(this.label5);
            this.TabPageVideo.Controls.Add(this.label4);
            this.TabPageVideo.Controls.Add(this.CheckBoxVideo);
            this.TabPageVideo.Location = new System.Drawing.Point(4, 29);
            this.TabPageVideo.Name = "TabPageVideo";
            this.TabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageVideo.Size = new System.Drawing.Size(700, 538);
            this.TabPageVideo.TabIndex = 1;
            this.TabPageVideo.Text = "Video";
            this.TabPageVideo.UseVisualStyleBackColor = true;
            // 
            // ComboBoxVideoRotation
            // 
            this.ComboBoxVideoRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxVideoRotation.Enabled = false;
            this.ComboBoxVideoRotation.FormattingEnabled = true;
            this.ComboBoxVideoRotation.Items.AddRange(new object[] {
            "90° Counter Clockwise & Vertical Flip",
            "90° Clockwise",
            "90° Counter Clockwise",
            "90° Clockwise & Vertical Flip"});
            this.ComboBoxVideoRotation.Location = new System.Drawing.Point(454, 111);
            this.ComboBoxVideoRotation.Name = "ComboBoxVideoRotation";
            this.ComboBoxVideoRotation.Size = new System.Drawing.Size(223, 28);
            this.ComboBoxVideoRotation.TabIndex = 13;
            // 
            // TextBoxVideoResolutionHeight
            // 
            this.TextBoxVideoResolutionHeight.Location = new System.Drawing.Point(599, 40);
            this.TextBoxVideoResolutionHeight.MaxLength = 4;
            this.TextBoxVideoResolutionHeight.Name = "TextBoxVideoResolutionHeight";
            this.TextBoxVideoResolutionHeight.Size = new System.Drawing.Size(53, 26);
            this.TextBoxVideoResolutionHeight.TabIndex = 12;
            this.TextBoxVideoResolutionHeight.Text = "480";
            // 
            // TextBoxVideoResolutionWidth
            // 
            this.TextBoxVideoResolutionWidth.Location = new System.Drawing.Point(484, 40);
            this.TextBoxVideoResolutionWidth.MaxLength = 4;
            this.TextBoxVideoResolutionWidth.Name = "TextBoxVideoResolutionWidth";
            this.TextBoxVideoResolutionWidth.Size = new System.Drawing.Size(53, 26);
            this.TextBoxVideoResolutionWidth.TabIndex = 11;
            this.TextBoxVideoResolutionWidth.Text = "854";
            // 
            // TextBoxVideoBitrate
            // 
            this.TextBoxVideoBitrate.Location = new System.Drawing.Point(112, 112);
            this.TextBoxVideoBitrate.MaxLength = 5;
            this.TextBoxVideoBitrate.Name = "TextBoxVideoBitrate";
            this.TextBoxVideoBitrate.Size = new System.Drawing.Size(69, 26);
            this.TextBoxVideoBitrate.TabIndex = 10;
            this.TextBoxVideoBitrate.Text = "800";
            // 
            // CheckBoxVideoRotation
            // 
            this.CheckBoxVideoRotation.AutoSize = true;
            this.CheckBoxVideoRotation.Location = new System.Drawing.Point(329, 114);
            this.CheckBoxVideoRotation.Name = "CheckBoxVideoRotation";
            this.CheckBoxVideoRotation.Size = new System.Drawing.Size(100, 24);
            this.CheckBoxVideoRotation.TabIndex = 9;
            this.CheckBoxVideoRotation.Text = "Rotation:";
            this.CheckBoxVideoRotation.UseVisualStyleBackColor = true;
            this.CheckBoxVideoRotation.CheckedChanged += new System.EventHandler(this.CheckBoxVideoRotation_CheckedChanged);
            // 
            // CheckBoxVideoResolution
            // 
            this.CheckBoxVideoResolution.AutoSize = true;
            this.CheckBoxVideoResolution.Checked = true;
            this.CheckBoxVideoResolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxVideoResolution.Location = new System.Drawing.Point(329, 42);
            this.CheckBoxVideoResolution.Name = "CheckBoxVideoResolution";
            this.CheckBoxVideoResolution.Size = new System.Drawing.Size(115, 24);
            this.CheckBoxVideoResolution.TabIndex = 8;
            this.CheckBoxVideoResolution.Text = "Resolution:";
            this.CheckBoxVideoResolution.UseVisualStyleBackColor = true;
            this.CheckBoxVideoResolution.CheckedChanged += new System.EventHandler(this.CheckBoxVideoResolution_CheckedChanged);
            // 
            // CheckBoxVideoBitrate
            // 
            this.CheckBoxVideoBitrate.AutoSize = true;
            this.CheckBoxVideoBitrate.Checked = true;
            this.CheckBoxVideoBitrate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxVideoBitrate.Location = new System.Drawing.Point(20, 114);
            this.CheckBoxVideoBitrate.Name = "CheckBoxVideoBitrate";
            this.CheckBoxVideoBitrate.Size = new System.Drawing.Size(86, 24);
            this.CheckBoxVideoBitrate.TabIndex = 7;
            this.CheckBoxVideoBitrate.Text = "Bitrate:";
            this.CheckBoxVideoBitrate.UseVisualStyleBackColor = true;
            this.CheckBoxVideoBitrate.CheckedChanged += new System.EventHandler(this.CheckBoxVideoBitrate_CheckedChanged);
            // 
            // ComboBoxVideoCodec
            // 
            this.ComboBoxVideoCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxVideoCodec.FormattingEnabled = true;
            this.ComboBoxVideoCodec.Items.AddRange(new object[] {
            "Copy",
            "H.264 /AVC"});
            this.ComboBoxVideoCodec.Location = new System.Drawing.Point(81, 38);
            this.ComboBoxVideoCodec.Name = "ComboBoxVideoCodec";
            this.ComboBoxVideoCodec.Size = new System.Drawing.Size(165, 28);
            this.ComboBoxVideoCodec.TabIndex = 6;
            this.ComboBoxVideoCodec.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxVideoCodec_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Codec:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(568, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "H:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "W:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "kbps";
            // 
            // CheckBoxVideo
            // 
            this.CheckBoxVideo.AutoSize = true;
            this.CheckBoxVideo.Checked = true;
            this.CheckBoxVideo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxVideo.Location = new System.Drawing.Point(20, 259);
            this.CheckBoxVideo.Name = "CheckBoxVideo";
            this.CheckBoxVideo.Size = new System.Drawing.Size(132, 24);
            this.CheckBoxVideo.TabIndex = 0;
            this.CheckBoxVideo.Text = "Include Video";
            this.CheckBoxVideo.UseVisualStyleBackColor = true;
            this.CheckBoxVideo.CheckedChanged += new System.EventHandler(this.CheckBoxVideo_CheckedChanged);
            // 
            // TabPageAudio
            // 
            this.TabPageAudio.Controls.Add(this.TextBoxAudioVolumeMultiplier);
            this.TabPageAudio.Controls.Add(this.label8);
            this.TabPageAudio.Controls.Add(this.TextBoxAudioSamplingRate);
            this.TabPageAudio.Controls.Add(this.TextBoxAudioBitrate);
            this.TabPageAudio.Controls.Add(this.CheckBoxAudioVolumeMultiplier);
            this.TabPageAudio.Controls.Add(this.CheckBoxAudioSamplingRate);
            this.TabPageAudio.Controls.Add(this.CheckBoxAudioBitrate);
            this.TabPageAudio.Controls.Add(this.ComboBoxAudioCodec);
            this.TabPageAudio.Controls.Add(this.label3);
            this.TabPageAudio.Controls.Add(this.label10);
            this.TabPageAudio.Controls.Add(this.CheckBoxAudio);
            this.TabPageAudio.Location = new System.Drawing.Point(4, 29);
            this.TabPageAudio.Name = "TabPageAudio";
            this.TabPageAudio.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageAudio.Size = new System.Drawing.Size(700, 538);
            this.TabPageAudio.TabIndex = 2;
            this.TabPageAudio.Text = "Audio";
            this.TabPageAudio.UseVisualStyleBackColor = true;
            // 
            // TextBoxAudioVolumeMultiplier
            // 
            this.TextBoxAudioVolumeMultiplier.Enabled = false;
            this.TextBoxAudioVolumeMultiplier.Location = new System.Drawing.Point(497, 119);
            this.TextBoxAudioVolumeMultiplier.MaxLength = 4;
            this.TextBoxAudioVolumeMultiplier.Name = "TextBoxAudioVolumeMultiplier";
            this.TextBoxAudioVolumeMultiplier.Size = new System.Drawing.Size(69, 26);
            this.TextBoxAudioVolumeMultiplier.TabIndex = 28;
            this.TextBoxAudioVolumeMultiplier.Text = "3.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(570, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Hertz";
            // 
            // TextBoxAudioSamplingRate
            // 
            this.TextBoxAudioSamplingRate.Enabled = false;
            this.TextBoxAudioSamplingRate.Location = new System.Drawing.Point(482, 48);
            this.TextBoxAudioSamplingRate.MaxLength = 5;
            this.TextBoxAudioSamplingRate.Name = "TextBoxAudioSamplingRate";
            this.TextBoxAudioSamplingRate.Size = new System.Drawing.Size(69, 26);
            this.TextBoxAudioSamplingRate.TabIndex = 26;
            this.TextBoxAudioSamplingRate.Text = "44100";
            // 
            // TextBoxAudioBitrate
            // 
            this.TextBoxAudioBitrate.Enabled = false;
            this.TextBoxAudioBitrate.Location = new System.Drawing.Point(115, 119);
            this.TextBoxAudioBitrate.MaxLength = 5;
            this.TextBoxAudioBitrate.Name = "TextBoxAudioBitrate";
            this.TextBoxAudioBitrate.Size = new System.Drawing.Size(69, 26);
            this.TextBoxAudioBitrate.TabIndex = 22;
            this.TextBoxAudioBitrate.Text = "128";
            // 
            // CheckBoxAudioVolumeMultiplier
            // 
            this.CheckBoxAudioVolumeMultiplier.AutoSize = true;
            this.CheckBoxAudioVolumeMultiplier.Location = new System.Drawing.Point(332, 121);
            this.CheckBoxAudioVolumeMultiplier.Name = "CheckBoxAudioVolumeMultiplier";
            this.CheckBoxAudioVolumeMultiplier.Size = new System.Drawing.Size(159, 24);
            this.CheckBoxAudioVolumeMultiplier.TabIndex = 21;
            this.CheckBoxAudioVolumeMultiplier.Text = "Volume Multiplier:";
            this.CheckBoxAudioVolumeMultiplier.UseVisualStyleBackColor = true;
            this.CheckBoxAudioVolumeMultiplier.CheckedChanged += new System.EventHandler(this.CheckBoxAudioVolumeMultiplier_CheckedChanged);
            // 
            // CheckBoxAudioSamplingRate
            // 
            this.CheckBoxAudioSamplingRate.AutoSize = true;
            this.CheckBoxAudioSamplingRate.Location = new System.Drawing.Point(332, 49);
            this.CheckBoxAudioSamplingRate.Name = "CheckBoxAudioSamplingRate";
            this.CheckBoxAudioSamplingRate.Size = new System.Drawing.Size(144, 24);
            this.CheckBoxAudioSamplingRate.TabIndex = 20;
            this.CheckBoxAudioSamplingRate.Text = "Sampling Rate:";
            this.CheckBoxAudioSamplingRate.UseVisualStyleBackColor = true;
            this.CheckBoxAudioSamplingRate.CheckedChanged += new System.EventHandler(this.CheckBoxAudioSamplingRate_CheckedChanged);
            // 
            // CheckBoxAudioBitrate
            // 
            this.CheckBoxAudioBitrate.AutoSize = true;
            this.CheckBoxAudioBitrate.Location = new System.Drawing.Point(20, 121);
            this.CheckBoxAudioBitrate.Name = "CheckBoxAudioBitrate";
            this.CheckBoxAudioBitrate.Size = new System.Drawing.Size(86, 24);
            this.CheckBoxAudioBitrate.TabIndex = 19;
            this.CheckBoxAudioBitrate.Text = "Bitrate:";
            this.CheckBoxAudioBitrate.UseVisualStyleBackColor = true;
            this.CheckBoxAudioBitrate.CheckedChanged += new System.EventHandler(this.CheckBoxAudioBitrate_CheckedChanged);
            // 
            // ComboBoxAudioCodec
            // 
            this.ComboBoxAudioCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxAudioCodec.FormattingEnabled = true;
            this.ComboBoxAudioCodec.Items.AddRange(new object[] {
            "Copy",
            "AAC",
            "MP3",
            "FLAC"});
            this.ComboBoxAudioCodec.Location = new System.Drawing.Point(84, 45);
            this.ComboBoxAudioCodec.Name = "ComboBoxAudioCodec";
            this.ComboBoxAudioCodec.Size = new System.Drawing.Size(165, 28);
            this.ComboBoxAudioCodec.TabIndex = 18;
            this.ComboBoxAudioCodec.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxAudioCodec_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Codec:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(206, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "kbps";
            // 
            // CheckBoxAudio
            // 
            this.CheckBoxAudio.AutoSize = true;
            this.CheckBoxAudio.Checked = true;
            this.CheckBoxAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxAudio.Location = new System.Drawing.Point(20, 259);
            this.CheckBoxAudio.Name = "CheckBoxAudio";
            this.CheckBoxAudio.Size = new System.Drawing.Size(132, 24);
            this.CheckBoxAudio.TabIndex = 0;
            this.CheckBoxAudio.Text = "Include Audio";
            this.CheckBoxAudio.UseVisualStyleBackColor = true;
            this.CheckBoxAudio.CheckedChanged += new System.EventHandler(this.CheckBoxAudio_CheckedChanged);
            // 
            // TabPageStatus
            // 
            this.TabPageStatus.Controls.Add(this.ProgressBarProgress);
            this.TabPageStatus.Controls.Add(this.label26);
            this.TabPageStatus.Controls.Add(this.LabelProgress);
            this.TabPageStatus.Controls.Add(this.LabelTimeRemaining);
            this.TabPageStatus.Controls.Add(this.LabelTimeElapsed);
            this.TabPageStatus.Controls.Add(this.LabelProcessingSpeed);
            this.TabPageStatus.Controls.Add(this.LabelProcessed);
            this.TabPageStatus.Controls.Add(this.LabelFinalSize);
            this.TabPageStatus.Controls.Add(this.LabelOriginalSize);
            this.TabPageStatus.Controls.Add(this.LabelCurrentFile);
            this.TabPageStatus.Controls.Add(this.ButtonConvert);
            this.TabPageStatus.Location = new System.Drawing.Point(4, 29);
            this.TabPageStatus.Name = "TabPageStatus";
            this.TabPageStatus.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageStatus.Size = new System.Drawing.Size(700, 555);
            this.TabPageStatus.TabIndex = 3;
            this.TabPageStatus.Text = "Status";
            this.TabPageStatus.UseVisualStyleBackColor = true;
            // 
            // ButtonConvert
            // 
            this.ButtonConvert.Enabled = false;
            this.ButtonConvert.Location = new System.Drawing.Point(253, 467);
            this.ButtonConvert.Name = "ButtonConvert";
            this.ButtonConvert.Size = new System.Drawing.Size(195, 56);
            this.ButtonConvert.TabIndex = 0;
            this.ButtonConvert.Text = "Convert";
            this.ButtonConvert.UseVisualStyleBackColor = true;
            this.ButtonConvert.Click += new System.EventHandler(this.ButtonConvert_Click);
            // 
            // CheckBoxEnableSelection
            // 
            this.CheckBoxEnableSelection.AutoSize = true;
            this.CheckBoxEnableSelection.Location = new System.Drawing.Point(12, 211);
            this.CheckBoxEnableSelection.Name = "CheckBoxEnableSelection";
            this.CheckBoxEnableSelection.Size = new System.Drawing.Size(155, 24);
            this.CheckBoxEnableSelection.TabIndex = 6;
            this.CheckBoxEnableSelection.Text = "Enable Selection";
            this.CheckBoxEnableSelection.UseVisualStyleBackColor = true;
            this.CheckBoxEnableSelection.CheckedChanged += new System.EventHandler(this.CheckBoxEnableSelection_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Duration:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 8;
            this.label11.Text = "Start:";
            // 
            // TextBoxStartHour
            // 
            this.TextBoxStartHour.Location = new System.Drawing.Point(88, 279);
            this.TextBoxStartHour.MaxLength = 2;
            this.TextBoxStartHour.Name = "TextBoxStartHour";
            this.TextBoxStartHour.Size = new System.Drawing.Size(31, 26);
            this.TextBoxStartHour.TabIndex = 9;
            this.TextBoxStartHour.Text = "00";
            this.TextBoxStartHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxStartMinute
            // 
            this.TextBoxStartMinute.Location = new System.Drawing.Point(138, 279);
            this.TextBoxStartMinute.MaxLength = 2;
            this.TextBoxStartMinute.Name = "TextBoxStartMinute";
            this.TextBoxStartMinute.Size = new System.Drawing.Size(31, 26);
            this.TextBoxStartMinute.TabIndex = 10;
            this.TextBoxStartMinute.Text = "00";
            this.TextBoxStartMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxStartSecond
            // 
            this.TextBoxStartSecond.Location = new System.Drawing.Point(191, 279);
            this.TextBoxStartSecond.MaxLength = 2;
            this.TextBoxStartSecond.Name = "TextBoxStartSecond";
            this.TextBoxStartSecond.Size = new System.Drawing.Size(31, 26);
            this.TextBoxStartSecond.TabIndex = 11;
            this.TextBoxStartSecond.Text = "00";
            this.TextBoxStartSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxEndHour
            // 
            this.TextBoxEndHour.Location = new System.Drawing.Point(88, 329);
            this.TextBoxEndHour.MaxLength = 2;
            this.TextBoxEndHour.Name = "TextBoxEndHour";
            this.TextBoxEndHour.Size = new System.Drawing.Size(31, 26);
            this.TextBoxEndHour.TabIndex = 12;
            this.TextBoxEndHour.Text = "00";
            this.TextBoxEndHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxEndMinute
            // 
            this.TextBoxEndMinute.Location = new System.Drawing.Point(138, 329);
            this.TextBoxEndMinute.MaxLength = 2;
            this.TextBoxEndMinute.Name = "TextBoxEndMinute";
            this.TextBoxEndMinute.Size = new System.Drawing.Size(31, 26);
            this.TextBoxEndMinute.TabIndex = 13;
            this.TextBoxEndMinute.Text = "00";
            this.TextBoxEndMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxEndSecond
            // 
            this.TextBoxEndSecond.Location = new System.Drawing.Point(191, 329);
            this.TextBoxEndSecond.MaxLength = 2;
            this.TextBoxEndSecond.Name = "TextBoxEndSecond";
            this.TextBoxEndSecond.Size = new System.Drawing.Size(31, 26);
            this.TextBoxEndSecond.TabIndex = 14;
            this.TextBoxEndSecond.Text = "01";
            this.TextBoxEndSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 282);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(123, 331);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 20);
            this.label13.TabIndex = 16;
            this.label13.Text = ":";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(175, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 20);
            this.label14.TabIndex = 17;
            this.label14.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(175, 282);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 20);
            this.label15.TabIndex = 18;
            this.label15.Text = ":";
            // 
            // TextBoxStartMillisecond
            // 
            this.TextBoxStartMillisecond.Location = new System.Drawing.Point(239, 279);
            this.TextBoxStartMillisecond.MaxLength = 3;
            this.TextBoxStartMillisecond.Name = "TextBoxStartMillisecond";
            this.TextBoxStartMillisecond.Size = new System.Drawing.Size(37, 26);
            this.TextBoxStartMillisecond.TabIndex = 19;
            this.TextBoxStartMillisecond.Text = "000";
            this.TextBoxStartMillisecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TextBoxEndMillisecond
            // 
            this.TextBoxEndMillisecond.Location = new System.Drawing.Point(239, 329);
            this.TextBoxEndMillisecond.MaxLength = 3;
            this.TextBoxEndMillisecond.Name = "TextBoxEndMillisecond";
            this.TextBoxEndMillisecond.Size = new System.Drawing.Size(37, 26);
            this.TextBoxEndMillisecond.TabIndex = 20;
            this.TextBoxEndMillisecond.Text = "000";
            this.TextBoxEndMillisecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(225, 283);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(13, 20);
            this.label16.TabIndex = 21;
            this.label16.Text = ".";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(225, 335);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 20);
            this.label17.TabIndex = 22;
            this.label17.Text = ".";
            // 
            // LabelCurrentFile
            // 
            this.LabelCurrentFile.AutoSize = true;
            this.LabelCurrentFile.Location = new System.Drawing.Point(18, 27);
            this.LabelCurrentFile.Name = "LabelCurrentFile";
            this.LabelCurrentFile.Size = new System.Drawing.Size(125, 20);
            this.LabelCurrentFile.TabIndex = 1;
            this.LabelCurrentFile.Text = "Current File: N/A";
            // 
            // LabelOriginalSize
            // 
            this.LabelOriginalSize.AutoSize = true;
            this.LabelOriginalSize.Location = new System.Drawing.Point(18, 76);
            this.LabelOriginalSize.Name = "LabelOriginalSize";
            this.LabelOriginalSize.Size = new System.Drawing.Size(131, 20);
            this.LabelOriginalSize.TabIndex = 2;
            this.LabelOriginalSize.Text = "Original Size: N/A";
            // 
            // LabelFinalSize
            // 
            this.LabelFinalSize.AutoSize = true;
            this.LabelFinalSize.Location = new System.Drawing.Point(18, 125);
            this.LabelFinalSize.Name = "LabelFinalSize";
            this.LabelFinalSize.Size = new System.Drawing.Size(112, 20);
            this.LabelFinalSize.TabIndex = 3;
            this.LabelFinalSize.Text = "Final Size: N/A";
            // 
            // LabelProcessed
            // 
            this.LabelProcessed.AutoSize = true;
            this.LabelProcessed.Location = new System.Drawing.Point(18, 174);
            this.LabelProcessed.Name = "LabelProcessed";
            this.LabelProcessed.Size = new System.Drawing.Size(118, 20);
            this.LabelProcessed.TabIndex = 4;
            this.LabelProcessed.Text = "Processed: N/A";
            // 
            // LabelProcessingSpeed
            // 
            this.LabelProcessingSpeed.AutoSize = true;
            this.LabelProcessingSpeed.Location = new System.Drawing.Point(18, 222);
            this.LabelProcessingSpeed.Name = "LabelProcessingSpeed";
            this.LabelProcessingSpeed.Size = new System.Drawing.Size(172, 20);
            this.LabelProcessingSpeed.TabIndex = 5;
            this.LabelProcessingSpeed.Text = "Processing Speed: N/A";
            // 
            // LabelTimeElapsed
            // 
            this.LabelTimeElapsed.AutoSize = true;
            this.LabelTimeElapsed.Location = new System.Drawing.Point(18, 274);
            this.LabelTimeElapsed.Name = "LabelTimeElapsed";
            this.LabelTimeElapsed.Size = new System.Drawing.Size(139, 20);
            this.LabelTimeElapsed.TabIndex = 6;
            this.LabelTimeElapsed.Text = "Time Elapsed: N/A";
            // 
            // LabelTimeRemaining
            // 
            this.LabelTimeRemaining.AutoSize = true;
            this.LabelTimeRemaining.Location = new System.Drawing.Point(18, 328);
            this.LabelTimeRemaining.Name = "LabelTimeRemaining";
            this.LabelTimeRemaining.Size = new System.Drawing.Size(157, 20);
            this.LabelTimeRemaining.TabIndex = 7;
            this.LabelTimeRemaining.Text = "Time Remaining: N/A";
            // 
            // LabelProgress
            // 
            this.LabelProgress.AutoSize = true;
            this.LabelProgress.Location = new System.Drawing.Point(643, 405);
            this.LabelProgress.Name = "LabelProgress";
            this.LabelProgress.Size = new System.Drawing.Size(36, 20);
            this.LabelProgress.TabIndex = 8;
            this.LabelProgress.Text = "0 %";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(18, 405);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(76, 20);
            this.label26.TabIndex = 9;
            this.label26.Text = "Progress:";
            // 
            // ProgressBarProgress
            // 
            this.ProgressBarProgress.Location = new System.Drawing.Point(100, 395);
            this.ProgressBarProgress.Name = "ProgressBarProgress";
            this.ProgressBarProgress.Size = new System.Drawing.Size(537, 41);
            this.ProgressBarProgress.TabIndex = 10;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 588);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FFmpeg GUI Frontend";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.TabControl.ResumeLayout(false);
            this.TabPageInput.ResumeLayout(false);
            this.TabPageInput.PerformLayout();
            this.TabPageVideo.ResumeLayout(false);
            this.TabPageVideo.PerformLayout();
            this.TabPageAudio.ResumeLayout(false);
            this.TabPageAudio.PerformLayout();
            this.TabPageStatus.ResumeLayout(false);
            this.TabPageStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPageInput;
        private System.Windows.Forms.TabPage TabPageVideo;
        private System.Windows.Forms.TabPage TabPageAudio;
        private System.Windows.Forms.TabPage TabPageStatus;
        private System.Windows.Forms.Button ButtonBrowsePath;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.TextBox TextBoxTargetPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonConvert;
        private System.Windows.Forms.CheckBox CheckBoxVideo;
        private System.Windows.Forms.CheckBox CheckBoxAudio;
        private System.Windows.Forms.ComboBox ComboBoxVideoCodec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextBoxVideoBitrate;
        private System.Windows.Forms.CheckBox CheckBoxVideoRotation;
        private System.Windows.Forms.CheckBox CheckBoxVideoResolution;
        private System.Windows.Forms.CheckBox CheckBoxVideoBitrate;
        private System.Windows.Forms.ComboBox ComboBoxVideoRotation;
        private System.Windows.Forms.TextBox TextBoxAudioBitrate;
        private System.Windows.Forms.CheckBox CheckBoxAudioVolumeMultiplier;
        private System.Windows.Forms.CheckBox CheckBoxAudioSamplingRate;
        private System.Windows.Forms.CheckBox CheckBoxAudioBitrate;
        private System.Windows.Forms.ComboBox ComboBoxAudioCodec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TextBoxVideoResolutionHeight;
        private System.Windows.Forms.TextBox TextBoxVideoResolutionWidth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TextBoxAudioSamplingRate;
        private System.Windows.Forms.TextBox TextBoxAudioVolumeMultiplier;
        private System.Windows.Forms.CheckBox CheckBoxEnableSelection;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TextBoxEndMillisecond;
        private System.Windows.Forms.TextBox TextBoxStartMillisecond;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TextBoxEndSecond;
        private System.Windows.Forms.TextBox TextBoxEndMinute;
        private System.Windows.Forms.TextBox TextBoxEndHour;
        private System.Windows.Forms.TextBox TextBoxStartSecond;
        private System.Windows.Forms.TextBox TextBoxStartMinute;
        private System.Windows.Forms.TextBox TextBoxStartHour;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ProgressBar ProgressBarProgress;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label LabelProgress;
        private System.Windows.Forms.Label LabelTimeRemaining;
        private System.Windows.Forms.Label LabelTimeElapsed;
        private System.Windows.Forms.Label LabelProcessingSpeed;
        private System.Windows.Forms.Label LabelProcessed;
        private System.Windows.Forms.Label LabelFinalSize;
        private System.Windows.Forms.Label LabelOriginalSize;
        private System.Windows.Forms.Label LabelCurrentFile;
    }
}