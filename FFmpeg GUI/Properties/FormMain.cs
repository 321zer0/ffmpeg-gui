using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FFmpeg_GUI.Properties
{
    public partial class FormMain : Form
    {
        MediaFile[] InputFiles;
        string OutputFile = "";
        int CurrentFile = 0;

        string GeneralArguments = "";
        string SpecificArguments = "";

        string Line = "";
        string Output = "";

        TimeSpan Duration = TimeSpan.FromSeconds(0);
        TimeSpan Processed = TimeSpan.FromSeconds(0);
        TimeSpan Remaining = TimeSpan.FromSeconds(0);
        TimeSpan Elapsed = TimeSpan.FromSeconds(0);

        double Speed = 0.0;
        int SpeedFPS = 0;

        System.Timers.Timer Timer;

        Process ProcessFFmpeg;
        bool Exited = true;

        [STAThread]
        static public void Main()
        {
            Application.Run(new FormMain());
        }

        public FormMain()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }


        private void Cron()
        {
            try
            {
                if(this != null)
                {
                    this.Invoke(new Action(() =>
                    {
                        BuildArguments();
                        DisplayStatus();
                    }));
                }
            }
            catch
            {
                Environment.Exit(0);
            }



            //FFmpeg process was terminated externally
            if (Exited && Output != "")
            {
                Timer.Stop();
                Environment.Exit(11);
            }
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            ComboBoxAudioCodec.SelectedIndex = 0;
            ComboBoxVideoCodec.SelectedIndex = 1;
            ComboBoxVideoRotation.SelectedIndex = 2;

            Timer = new System.Timers.Timer(1000);
            Timer.Elapsed += (s, f) =>
            {
                Elapsed = TimeSpan.FromSeconds(Elapsed.TotalSeconds + 1);
                Cron();
            };

            Timer.Start();
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            Open.Multiselect = true;

            if (Open.ShowDialog() == DialogResult.OK)
            {
                InputFiles = new MediaFile[Open.FileNames.Length];

                for (int i = 0; i < Open.FileNames.Length; i++)
                {
                    //Store MediaFile instance of the media file
                    InputFiles[i] = new MediaFile(Open.FileNames[i]);
                    //InputFiles[i].ShowMediaInfo();
                }

                TextBoxTargetPath.Text = new FileInfo(Open.FileNames[0]).Directory.FullName;

                if (TextBoxTargetPath.Text != "" && (CheckBoxVideo.Checked == true || CheckBoxAudio.Checked == true))
                {
                    ButtonConvert.Enabled = true;
                }

            }
        }

        private void ButtonBrowsePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowNewFolderButton = false;

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxTargetPath.Text = f.SelectedPath;

                if (InputFiles != null && (CheckBoxVideo.Checked == true || CheckBoxAudio.Checked == true))
                {
                    ButtonConvert.Enabled = true;
                }
            }
        }

        private void CheckBoxVideo_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableButtonConvert(sender);
        }

        private void CheckBoxAudio_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableButtonConvert(sender);
        }

        private void EnableDisableButtonConvert(object sender)
        {
            if (((CheckBox)sender).Checked && InputFiles != null && TextBoxTargetPath.Text != "")
            {
                ButtonConvert.Enabled = true;
            }

            if (!((CheckBox)sender).Checked && (CheckBoxAudio.Checked == false || InputFiles == null || TextBoxTargetPath.Text == ""))
            {
                GeneralArguments = "";
                ButtonConvert.Enabled = false;
            }
        }

        private void StartFFmpegProcess()
        {
            ProcessFFmpeg = new Process();
            ProcessFFmpeg.ErrorDataReceived += FFmpegDataReceived;
            ProcessFFmpeg.OutputDataReceived += FFmpegDataReceived;

            ProcessFFmpeg.StartInfo.FileName = "ffmpeg.exe";
            ProcessFFmpeg.StartInfo.Arguments = SpecificArguments;

            ProcessFFmpeg.StartInfo.UseShellExecute = false;
            ProcessFFmpeg.StartInfo.RedirectStandardOutput = true;
            ProcessFFmpeg.StartInfo.RedirectStandardError = true;
            ProcessFFmpeg.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ProcessFFmpeg.StartInfo.CreateNoWindow = true;

            Exited = false;

            ProcessFFmpeg.Start();
            ProcessFFmpeg.BeginOutputReadLine();
            ProcessFFmpeg.BeginErrorReadLine();

            Elapsed = TimeSpan.FromSeconds(0);

            ProcessFFmpeg.WaitForExit();

            try
            {
                if (ProcessFFmpeg.HasExited)
                {
                    Exited = true;
                }
            }
            catch
            {

            }

        }

        private void FFmpegDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
            {
                return;
            }


            Line = e.Data;
            Output += Line + "\n";



            if (Line.Length < 1)
            {
                return;
            }


            ////Get Amount of Time Processed
            //if (Line.Contains("time=") && Line.Contains("speed="))
            //{
            //    String[] TimeReached = Line.Substring(Line.IndexOf("time=") + "time=".Length, 8).Split(':');

            //    int Seconds = (int)double.Parse(TimeReached[2]);
            //    int Minutes = int.Parse(TimeReached[1]);
            //    int Hours = int.Parse(TimeReached[0]);

            //    Processed = new TimeSpan(Hours, Minutes, Seconds);
            //}



            try
            {
                String[] Parts = Line.Split(' ');


                //Get Amount of Time Processed
                if (Line.Contains("time="))
                {
                    for (int i = 0; i < Parts.Length; i++)
                    {
                        if (Parts[i].Contains("time="))
                        {
                            String[] TimeReached = Parts[i].Replace("time=", "").Split(':');

                            int Seconds = 0;

                            int Hours = int.Parse(TimeReached[0]);
                            int Minutes = int.Parse(TimeReached[1]);

                            if (TimeReached[2].Contains("."))
                            {
                                Seconds = int.Parse(TimeReached[2].Split('.')[0]);
                            }
                            else
                            {
                                Seconds = int.Parse(TimeReached[2]);
                            }

                            Processed = new TimeSpan(Hours, Minutes, Seconds);
                            break;
                        }
                    }
                }


                Speed = -1;


                //Get Processing Speed
                if (Line.Contains("speed="))
                {
                    for (int i = 0; i < Parts.Length; i++)
                    {
                        if (Parts[i].Contains("speed="))
                        {
                            Speed = double.Parse(Parts[i].Replace("speed=", "").Replace("x", ""));
                            break;
                        }
                    }
                }


                //Get Processing Speed in FPS
                if (Line.Contains("fps="))
                {
                    for (int i = 0; i < Parts.Length; i++)
                    {
                        if (Parts[i].Contains("fps="))
                        {
                            SpeedFPS = int.Parse(Parts[i + 1]);
                            
                            if(Speed == -1)
                            {
                                Speed = SpeedFPS / InputFiles[CurrentFile].VideoStream.Framerate;
                            }

                            break;
                        }
                    }
                }



                //Last resort to calculate Speed if not obtained above



            }
            catch
            {
                //Split operation failed as Line did not contain any <space> character
                //OR we tried accessing an item that was out of range             
            }

        }

        private void BuildArguments()
        {
            GeneralArguments = "";

            //No Source File(s) Or Target Path
            if (InputFiles == null || InputFiles.Length == 0 || TextBoxTargetPath.Text == "")
            {
                GeneralArguments = "";
                return;
            }


            //No Video & No Audio
            if (CheckBoxVideo.Checked == false && CheckBoxAudio.Checked == false)
            {
                GeneralArguments = "";
                return;
            }


            //Selection Start
            if (CheckBoxEnableSelection.Checked == true)
            {
                GeneralArguments += "-ss " + TextBoxStartHour.Text + ":" + TextBoxStartMinute.Text + ":" + TextBoxStartSecond.Text + "." + TextBoxStartMillisecond.Text + " ";
            }

            //Source File
            GeneralArguments += "-y -i <INPUT>";



            //Selection Duration
            if (CheckBoxEnableSelection.Checked == true)
            {
                GeneralArguments += " -t " + TextBoxEndHour.Text + ":" + TextBoxEndMinute.Text + ":" + TextBoxEndSecond.Text + "." + TextBoxStartMillisecond.Text;
            }


            //File Size (in bytes) [To be implemented]
            //then we need to ignore bitrate settings for audio & video
            //Argument += " -fs 4096";


            //No Video
            if (CheckBoxVideo.Checked == false)
            {
                GeneralArguments += " -vn";
            }
            //Video
            else
            {
                //Codec
                switch (ComboBoxVideoCodec.SelectedIndex)
                {
                    case 0:
                        GeneralArguments += " -c:v copy";
                        break;

                    case 1:
                        GeneralArguments += " -c:v libx264";
                        break;
                }


                //Bit Rate
                if (ComboBoxVideoCodec.SelectedIndex != 0 && CheckBoxVideoBitrate.Checked == true)
                {
                    GeneralArguments += " -b:v " + TextBoxVideoBitrate.Text + "k";
                }


                //Resolution
                //Keep or change aspect ratio feature???  [To be implemented]
                if (ComboBoxVideoCodec.SelectedIndex != 0 && CheckBoxVideoResolution.Checked == true)
                {
                    GeneralArguments += " -s " + TextBoxVideoResolutionWidth.Text + "x" + TextBoxVideoResolutionHeight.Text;
                }


                //Rotation
                if (ComboBoxVideoCodec.SelectedIndex != 0 && CheckBoxVideoRotation.Checked == true)
                {
                    GeneralArguments += " -filter:v " + "\"" + "transpose=" + ComboBoxVideoRotation.SelectedIndex.ToString() + "\"";
                }


                //Crop [To be implemented]
                //if (ComboBoxVideoCodec.SelectedIndex != 0)
                //{
                //    Argument += "-croptop 88 -cropbottom 88 -cropleft 360 -cropright 360";
                //}


                //Pad [To be implemented]
                //if (ComboBoxVideoCodec.SelectedIndex != 0)
                //{
                //    Argument += "-padtop 120  -padbottom 120 -padright 0 -padright 0 -padcolor 000000";
                //}


                //Frame Rate [To be implemented]
                //if (ComboBoxVideoCodec.SelectedIndex != 0)
                //{
                //    Argument += " -r 25";
                //}


                //Set speed: (x2 in this case) [To be implemented]
                //if (ComboBoxVideoCodec.SelectedIndex != 0)
                //{
                //    Argument += " -filter:v " + "\"" + "setpts = (1 / 2) * PTS" + "\"";
                //}


                //Set pixel format [To be implemented]
                //if (ComboBoxVideoCodec.SelectedIndex != 0)
                //{
                //     Argument += " -pix_fmt yuv420p";
                //}



                //Encoder Params
                if (ComboBoxVideoCodec.SelectedIndex != 0)
                {
                    GeneralArguments += " -profile:v high -preset slow";
                }


            }


            //No Audio
            if (CheckBoxAudio.Checked == false)
            {
                GeneralArguments += " -an";
            }
            //Audio
            else
            {
                //Codec
                switch (ComboBoxAudioCodec.SelectedIndex)
                {
                    case 0:
                        GeneralArguments += " -c:a copy";
                        break;

                    case 1:
                        GeneralArguments += " -c:a aac";
                        break;

                    case 2:
                        GeneralArguments += " -c:a libmp3lame";
                        break;

                    case 3:
                        GeneralArguments += " -c:a flac";
                        break;
                }


                //Bit Rate
                if (ComboBoxAudioCodec.SelectedIndex != 0 && CheckBoxAudioBitrate.Checked == true)
                {
                    GeneralArguments += " -b:a " + TextBoxAudioBitrate.Text + "k";
                }


                //Keep audio at Same Quality [To be implemented]
                //


                //Sample Rate
                if (ComboBoxAudioCodec.SelectedIndex != 0 && CheckBoxAudioSamplingRate.Checked == true)
                {
                    GeneralArguments += " -ar " + TextBoxAudioSamplingRate.Text;
                }


                //Volume
                if (ComboBoxAudioCodec.SelectedIndex != 0 && CheckBoxAudioVolumeMultiplier.Checked == true)
                {
                    GeneralArguments += " -filter:a " + "\"" + "volume=" + TextBoxAudioVolumeMultiplier.Text + "\"";
                }


                //5.1 to Stereo [To be implemented]
                //if (ComboBoxAudioCodec.SelectedIndex != 0 && CheckBoxAudioToStereo.IsChecked == true)
                //{
                //    GeneralArguments += " -filter:a " + "\"" + "pan=stereo|FL=FC+0.30*FL+0.30*BL|FR=FC+0.30*FR+0.30*BR" + "\"";
                //}


                //Set audio pitch [To be implemented]
                //

            }


            //Optimize for Web Streaming
            GeneralArguments += " -movflags faststart <OUTPUT>";
        }

        private void StartBatch()
        {
            string Extension = "";



            for (int i = 0; i < InputFiles.Length; i++)
            {
                CurrentFile = i;

                this.Invoke((Action)(() =>
                {
                    this.Text = "FFmpeg GUI Frontend - Status: " + (CurrentFile + 1).ToString() + " of " + InputFiles.Length.ToString();

                    if (CheckBoxVideo.Checked == true)
                    {
                        Extension = ".mp4";
                    }
                    else
                    {
                        switch (ComboBoxAudioCodec.SelectedIndex)
                        {
                            case 0:
                                if (InputFiles[CurrentFile].AudioStream[0].Codec == "aac")
                                {
                                    Extension = ".m4a";
                                }
                                else
                                {
                                    Extension = "." + InputFiles[CurrentFile].AudioStream[0].Codec;
                                }
                                break;

                            case 1:
                                Extension = ".m4a";
                                break;

                            case 2:
                                Extension = ".mp3";
                                break;

                            case 3:
                                Extension = ".flac";
                                break;
                        }
                    }
                    
                    
                    if (Environment.OSVersion.ToString().ToLower().Contains("microsoft") || Environment.OSVersion.ToString().ToLower().Contains("windows"))
                    {
                        OutputFile = TextBoxTargetPath.Text + "\\" + System.IO.Path.GetFileNameWithoutExtension(InputFiles[CurrentFile].Filename) + "_converted" + Extension;
                    }
                    else
                    {
                        OutputFile = TextBoxTargetPath.Text + "/" + System.IO.Path.GetFileNameWithoutExtension(InputFiles[CurrentFile].Filename) + "_converted" + Extension;
                    }

                }));


                SpecificArguments = GeneralArguments;
                SpecificArguments = SpecificArguments.Replace("<INPUT>", "\"" + InputFiles[CurrentFile].Filename + "\"");
                SpecificArguments = SpecificArguments.Replace("<OUTPUT>", "\"" + OutputFile + "\"");

                StartFFmpegProcess();

                while (!Exited)
                {
                    //Wait till end of Process
                }
            }

        }

        private void DisplayStatus()
        {
            if (InputFiles != null && InputFiles.Length != 0)
            {
                LabelCurrentFile.Text = "Current File: " + System.IO.Path.GetFileName(InputFiles[CurrentFile].Filename);
                //TextBoxCommand.Text = "ffmpeg " + GeneralArguments;

                double fSize = 0;
                double oSize = InputFiles[CurrentFile].FileSize;
                double delta = 0;

                if (oSize >= 1024 * 1024 * 1024)
                {
                    LabelOriginalSize.Text = "Original Size: " + Math.Round(oSize / 1024 / 1024 / 1024, 1).ToString() + " GB";
                }
                else if (oSize >= 1024 * 1024)
                {
                    LabelOriginalSize.Text = "Original Size: " + Math.Round(oSize / 1024 / 1024, 1).ToString() + " MB";
                }
                else if (oSize >= 1024)
                {
                    LabelOriginalSize.Text = "Original Size: " + Math.Round(oSize / 1024, 1).ToString() + " KB";
                }

                if (CheckBoxEnableSelection.Checked == true && !string.IsNullOrEmpty(TextBoxEndHour.Text) && !string.IsNullOrEmpty(TextBoxEndMinute.Text) && !string.IsNullOrEmpty(TextBoxEndSecond.Text))
                {
                    Duration = new TimeSpan(int.Parse(TextBoxEndHour.Text), int.Parse(TextBoxEndMinute.Text), int.Parse(TextBoxEndSecond.Text));
                }
                else
                {
                    Duration = InputFiles[CurrentFile].Duration;
                }

                if (CheckBoxAudio.Checked == true && !string.IsNullOrEmpty(TextBoxAudioBitrate.Text) && InputFiles[CurrentFile].AudioStream[0] != null)
                {
                    if (ComboBoxAudioCodec.SelectedIndex == 0)
                    {
                        fSize += InputFiles[CurrentFile].AudioStream[0].Bitrate * Duration.TotalSeconds;
                    }
                    else
                    {
                        fSize += int.Parse(TextBoxAudioBitrate.Text) * Duration.TotalSeconds;
                    }
                }


                if (CheckBoxVideo.Checked == true && !string.IsNullOrEmpty(TextBoxVideoBitrate.Text) && InputFiles[CurrentFile].VideoStream != null)
                {
                    if (ComboBoxVideoCodec.SelectedIndex == 0)
                    {
                        fSize += InputFiles[CurrentFile].VideoStream.Bitrate * Duration.TotalSeconds;
                    }
                    else
                    {
                        fSize += int.Parse(TextBoxVideoBitrate.Text) * Duration.TotalSeconds;
                    }
                }

                fSize = fSize / 8 * 1024;
                delta = (oSize - fSize) / oSize * 100;

                string msg = "smaller";

                if (delta < 0)
                {
                    msg = "bigger";
                    delta = -delta;
                }

                if (fSize >= 1024 * 1024 * 1024)
                {
                    LabelFinalSize.Text = "Final Size: " + Math.Round(fSize / 1024 / 1024 / 1024, 1).ToString() + " GB" +
                                               " (" + Math.Round(delta, 1).ToString() + " %  " + msg + ")";
                }
                else if (fSize >= 1024 * 1024)
                {
                    LabelFinalSize.Text = "Final Size: " + Math.Round(fSize / 1024 / 1024, 1).ToString() + " MB" +
                                               " (" + Math.Round(delta, 1).ToString() + " %  " + msg + ")";
                }
                else if (fSize >= 1024)
                {
                    LabelFinalSize.Text = "Final Size: " + Math.Round(fSize / 1024, 1).ToString() + " KB" +
                                               " (" + Math.Round(delta, 1).ToString() + " %  " + msg + ")";
                }
            }

            if (Exited)
            {
                LabelProcessed.Text = "Processed: N/A";
                LabelProcessingSpeed.Text = "Processing Speed: N/A";
                LabelTimeElapsed.Text = "Time Elapsed: N/A";
                LabelTimeRemaining.Text = "Time Remaining: N/A";
            }
            else
            {
                try
                {
                    LabelProcessed.Text = "Processed: " + Processed.ToString() + "     of     " + new TimeSpan(Duration.Hours, Duration.Minutes, Duration.Seconds).ToString();

                    LabelProcessingSpeed.Text = "Processing Speed: " + SpeedFPS.ToString() + " fps (" + Math.Round(Speed, 2).ToString() + "x)";

                    LabelTimeElapsed.Text = "Time Elapsed: " + Elapsed.ToString();

                    Remaining = TimeSpan.FromSeconds((int)((Duration - Processed).TotalSeconds / Speed));
                    LabelTimeRemaining.Text = "Time Remaining: " + Remaining.ToString();

                    ProgressBarProgress.Value = (int)((Processed.TotalSeconds / Duration.TotalSeconds) * 100);
                    LabelProgress.Text = ProgressBarProgress.Value.ToString() + " %";
                }
                catch
                {
                    //Prevent division by error from bringing us down in case speed = 0
                }
            }
        }

        private bool ValidateParameters()
        {
            //Add Validation here for parameters typed in by user [To be implemented]
            return true;
        }



        private void ButtonConvert_Click(object sender, EventArgs e)
        {
            if (!ValidateParameters())
            {
                return;
            }

            TimeSpan StartTime = TimeSpan.FromMilliseconds((int.Parse(TextBoxStartHour.Text) * 3600 * 1000) + (int.Parse(TextBoxStartMinute.Text) * 60 * 1000) + (int.Parse(TextBoxStartSecond.Text) * 1000) + int.Parse(TextBoxStartMillisecond.Text));
            TimeSpan DurationTime = TimeSpan.FromMilliseconds((int.Parse(TextBoxEndHour.Text) * 3600 * 1000) + (int.Parse(TextBoxEndMinute.Text) * 60 * 1000) + (int.Parse(TextBoxEndSecond.Text) * 1000) + int.Parse(TextBoxEndMillisecond.Text));

            TimeSpan EndTime = StartTime + DurationTime;

            if (CheckBoxEnableSelection.Checked && InputFiles != null && InputFiles.Length != 0)
            {
                foreach (MediaFile MediaFile in InputFiles)
                {
                    if (EndTime > MediaFile.Duration)
                    {
                        CheckBoxEnableSelection.Checked = false;

                        System.Windows.Forms.MessageBox.Show("The selection cannot be applied because the file \"" + MediaFile.Filename + "\" is outside the selection range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        TabControl.SelectedIndex = 0;
                        return;
                    }
                }
            }

            ButtonConvert.Enabled = false;
            ButtonBrowse.Enabled = false;
            ButtonBrowsePath.Enabled = false;

            CheckBoxVideo.Enabled = false;
            CheckBoxAudio.Enabled = false;

            new Thread(new ThreadStart(StartBatch)).Start();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //Don't leave FFmpeg running in background when user closes the GUI
                if (!ProcessFFmpeg.HasExited)
                {
                    if (MessageBox.Show("Are you sure to cancel the conversion process?", "Cancel Process", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Timer.Stop();

                        ProcessFFmpeg.Kill();
                        ProcessFFmpeg.Close();

                        Environment.Exit(0);
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            catch
            {

            }
        }

        private void ComboBoxAudioCodec_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            if (ComboBoxAudioCodec.SelectedIndex == 0)
            {
                CheckBoxAudioBitrate.Enabled = false;
                CheckBoxAudioSamplingRate.Enabled = false;
                //CheckBoxAudioToStereo.Enabled = false;
                CheckBoxAudioVolumeMultiplier.Enabled = false;

                CheckBoxAudioBitrate.Checked = false;
                CheckBoxAudioSamplingRate.Checked = false;
                //CheckBoxAudioToStereo.Checked = false;
                CheckBoxAudioVolumeMultiplier.Checked = false;
            }
            else
            {
                CheckBoxAudioBitrate.Enabled = true;
                CheckBoxAudioSamplingRate.Enabled = true;
                //heckBoxAudioToStereo.Enabled = true;
                CheckBoxAudioVolumeMultiplier.Enabled = true;

                CheckBoxAudioBitrate.Checked = true;
            }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void ComboBoxVideoCodec_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //try
            //{
            if (ComboBoxVideoCodec.SelectedIndex == 0)
            {
                CheckBoxVideoBitrate.Enabled = false;
                CheckBoxVideoResolution.Enabled = false;
                CheckBoxVideoRotation.Enabled = false;
                TextBoxVideoResolutionWidth.Enabled = false;
                TextBoxVideoResolutionHeight.Enabled = false;

                CheckBoxVideoBitrate.Checked = false;
                CheckBoxVideoResolution.Checked = false;
                CheckBoxVideoRotation.Checked = false;
                CheckBoxAudioVolumeMultiplier.Checked = false;
            }
            else
            {
                CheckBoxVideoBitrate.Enabled = true;
                CheckBoxVideoResolution.Enabled = true;
                CheckBoxVideoRotation.Enabled = true;

                CheckBoxVideoBitrate.Checked = true;
            }
            //}
            //catch (Exception ex)
            //{

            //}
        }

        private void CheckBoxAudioBitrate_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxAudioBitrate.Enabled = ((CheckBox)sender).Checked;
        }

        private void CheckBoxAudioSamplingRate_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxAudioSamplingRate.Enabled = ((CheckBox)sender).Checked;
        }

        private void CheckBoxAudioVolumeMultiplier_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxAudioVolumeMultiplier.Enabled = ((CheckBox)sender).Checked;
        }

        private void CheckBoxVideoResolution_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxVideoResolutionWidth.Enabled = ((CheckBox)sender).Checked;
            TextBoxVideoResolutionHeight.Enabled = ((CheckBox)sender).Checked;
        }

        private void CheckBoxVideoBitrate_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxVideoBitrate.Enabled = ((CheckBox)sender).Checked;
        }

        private void CheckBoxVideoRotation_CheckedChanged(object sender, EventArgs e)
        {
            ComboBoxVideoRotation.Enabled = ((CheckBox)sender).Checked;
        }


        private void CheckBoxEnableSelection_CheckedChanged(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked)
            {
                return;
            }

            TimeSpan StartTime = TimeSpan.FromMilliseconds((int.Parse(TextBoxStartHour.Text) * 3600 * 1000) + (int.Parse(TextBoxStartMinute.Text) * 60 * 1000) + (int.Parse(TextBoxStartSecond.Text) * 1000) + int.Parse(TextBoxStartMillisecond.Text));
            TimeSpan DurationTime = TimeSpan.FromMilliseconds((int.Parse(TextBoxEndHour.Text) * 3600 * 1000) + (int.Parse(TextBoxEndMinute.Text) * 60 * 1000) + (int.Parse(TextBoxEndSecond.Text) * 1000) + int.Parse(TextBoxEndMillisecond.Text));

            TimeSpan EndTime = StartTime + DurationTime;

            if (InputFiles != null && InputFiles.Length != 0)
            {
                foreach (MediaFile MediaFile in InputFiles)
                {
                    if (EndTime > MediaFile.Duration)
                    {
                        CheckBoxEnableSelection.Checked = false;

                        System.Windows.Forms.MessageBox.Show("The selection cannot be applied because the file \"" + MediaFile.Filename + "\" is outside the selection range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;
                    }
                }
            }
        }
    }

}
