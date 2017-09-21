using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace FFmpeg_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[,] InputFiles;
        string OutputFile = "";
        string CurrentFile = "";
        
        string GeneralArguments = "";
        string SpecificArguments = "";
       
        string Line = "";
        string Output = "";

        TimeSpan Duration = TimeSpan.FromSeconds(0);
        TimeSpan Processed = TimeSpan.FromSeconds(0);
        TimeSpan Remaining = TimeSpan.FromSeconds(0);

        double Speed = 0.0;
       
        Process ProcessFFmpeg;
        Process ProcessFFprobe;

        bool Exited = true;



        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Tick += (s, e) =>
            {
                Cron();
            };

            Timer.Start();
        }


        private void Cron()
        {
            BuildArguments();
            DisplayStatus();


            //Interrupted
            if (Exited && Output != "")
            {
                System.Windows.Application.Current.Shutdown();
            }
        }



        private string GetAudioCodec(string InputFile)
        {
            ProcessFFprobe = new Process();
            string Codec = "";

            ProcessFFprobe.StartInfo.FileName = "ffprobe.exe";
            ProcessFFprobe.StartInfo.Arguments = "-v error -select_streams a:0 -show_entries stream=codec_name -of default=noprint_wrappers=1:nokey=1 " + "\"" + InputFile + "\"";

            ProcessFFprobe.StartInfo.UseShellExecute = false;
            ProcessFFprobe.StartInfo.RedirectStandardOutput = true;
            ProcessFFprobe.StartInfo.RedirectStandardError = true;
            ProcessFFprobe.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            ProcessFFprobe.StartInfo.CreateNoWindow = true;

            ProcessFFprobe.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
            {
                if (e.Data != null)
                {
                    Codec = e.Data;
                }

            };

            ProcessFFprobe.Start();
            ProcessFFprobe.BeginOutputReadLine();
            ProcessFFprobe.WaitForExit();

            return Codec;
        }


      

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog Open = new OpenFileDialog();
            Open.Multiselect = true;

            if (Open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                InputFiles = new string[Open.FileNames.Length, 2];

                for (int i = 0; i < Open.FileNames.Length; i++)
                {
                    //Save Filename along with audio codec
                    InputFiles[i, 0] = Open.FileNames[i];
                    InputFiles[i, 1] = GetAudioCodec(Open.FileNames[i]);
                }


                if (TextBoxTargetPath.Text != "" && (CheckBoxVideo.IsChecked == true || CheckBoxAudio.IsChecked == true))
                {
                    ButtonConvert.IsEnabled = true;
                }

            }
        }

        private void ButtonBrowsePath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowNewFolderButton = false;

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBoxTargetPath.Text = f.SelectedPath;

                if (InputFiles != null && (CheckBoxVideo.IsChecked == true || CheckBoxAudio.IsChecked == true))
                {
                    ButtonConvert.IsEnabled = true;
                }


            }
        }

        private void CheckBoxVideo_Checked(object sender, RoutedEventArgs e)
        {
            GroupBoxVideo.IsEnabled = true;

            if (InputFiles != null && TextBoxTargetPath.Text != "")
            {
                ButtonConvert.IsEnabled = true;
            }
        }

        private void CheckBoxVideo_Unchecked(object sender, RoutedEventArgs e)
        {
            GroupBoxVideo.IsEnabled = false;

            if (CheckBoxAudio.IsChecked == false || InputFiles == null || TextBoxTargetPath.Text == "")
            {
                GeneralArguments = "";
                ButtonConvert.IsEnabled = false;
            }
        }

        private void CheckBoxAudio_Checked(object sender, RoutedEventArgs e)
        {
            GroupBoxAudio.IsEnabled = true;

            if (InputFiles != null && TextBoxTargetPath.Text != "")
            {
                ButtonConvert.IsEnabled = true;
            }
        }

        private void CheckBoxAudio_Unchecked(object sender, RoutedEventArgs e)
        {
            GroupBoxAudio.IsEnabled = false;

            if (CheckBoxVideo.IsChecked == false || InputFiles == null || TextBoxTargetPath.Text == "")
            {
                GeneralArguments = "";
                ButtonConvert.IsEnabled = false;
            }
        }


        private void StartFFmpegProcess()
        {
            ProcessFFmpeg = new Process();
            ProcessFFmpeg.ErrorDataReceived += DataReceived;
            ProcessFFmpeg.OutputDataReceived += DataReceived;

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

        private void DataReceived(object sender, DataReceivedEventArgs e)
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


            //Get Amount Processed
            if (Line.Contains("time=") & Line.Contains("speed="))
            {
                String[] TimeReached = Line.Substring(Line.IndexOf("time=") + "time=".Length, 8).Split(':');

                int Seconds = (int)double.Parse(TimeReached[2]);
                int Minutes = int.Parse(TimeReached[1]);
                int Hours = int.Parse(TimeReached[0]);

                Processed = TimeSpan.FromSeconds((Hours * 3600) + (Minutes * 60) + Seconds);
            }



            try
            {
                String[] Parts = Line.Split(' ');


                //Get Duration
                if (Line.Contains("Duration:"))
                {
                    String[] MediaDuration = Parts[3].Replace(",", "").Split(':');

                    int Seconds = (int)double.Parse(MediaDuration[2]);
                    int Minutes = int.Parse(MediaDuration[1]);
                    int Hours = int.Parse(MediaDuration[0]);

                    Duration = TimeSpan.FromSeconds((Hours * 3600) + (Minutes * 60) + Seconds);
                }



                //Get Audio Codec //Using ffprobe to retrieve audio codec information
                //if (Line.Contains("Stream #") && Line.Contains("Audio: "))
                //{
                //    AudioCodec = Parts[7];
                //}



                //Get Speed
                if (Line.Contains("speed="))
                {
                    for (int i = 0; i < Parts.Length; i++)
                    {
                        if (Parts[i].Contains("speed="))
                        {
                            Speed = double.Parse(Parts[i].Replace("speed=", "").Replace("x", ""));
                        }
                    }
                }

            }
            catch
            {
                //Split operation failed as Line did not contain any <space> character
                //OR we tried accessing an item that was out of range             
            }

        }


        private void DisplayStatus()
        {
            TextBoxCommand.Text = "ffmpeg " + GeneralArguments;

            if (Exited)
            {
                TextBlockCurrentFile.Text = "Current File: N/A";
                TextBlockProcessed.Text = "Processed: N/A";
                TextBlockSpeed.Text = "Speed: N/A";
                TextBlockTimeRemaining.Text = "Time Remaining: N/A";
            }
            else
            {
                try
                {
                    TextBlockCurrentFile.Text = "Current File: " + CurrentFile;

                    TextBlockProcessed.Text = "Processed: " + Processed.ToString() + "     of     " + Duration.ToString();

                    TextBlockSpeed.Text = "Speed: " + Speed.ToString() + "x";

                    Remaining = TimeSpan.FromSeconds((int)((Duration - Processed).TotalSeconds / Speed));
                    TextBlockTimeRemaining.Text = "Time Remaining: " + Remaining.ToString();

                    ProgressBarProgress.Value = (int)((Processed.TotalSeconds / Duration.TotalSeconds) * 100);
                    TextBlockProgress.Text = ProgressBarProgress.Value.ToString() + " %";
                }
                catch
                {
                    //Prevent division by error from bringing us down in case speed = 0
                }
            }
        }



        private void BuildArguments()
        {
            GeneralArguments = "";

            //No Source File(s)
            if (InputFiles == null)
            {
                GeneralArguments = "";
                return;
            }


            //No Target Path
            if (TextBoxTargetPath.Text == "")
            {
                GeneralArguments = "";
                return;
            }


            //No Video & No Audio
            if (CheckBoxVideo.IsChecked == false && CheckBoxAudio.IsChecked == false)
            {
                GeneralArguments = "";
                return;
            }


            //Selection Start => No Video Copy [To be implemented]
            //if (ComboBoxVideoCodec.SelectedIndex != 0 && SelectionSelected)
            //{
            //    //Argument += "-ss 01:00 ";
            //}


            //Source File
            GeneralArguments += "-y -i <INPUT>";


            //Selection Start => With Video Copy [To be implemented]
            //if (ComboBoxVideoCodec.SelectedIndex == 0 && SelectionSelected)
            //{
            //    //Argument += " -ss 01:00";
            //}


            //selection End [To be implemented]
            //if (SelectionSelected)
            //{
            //    Argument += " -to 02:00";
            //}


            //File Size (in bytes) [To be implemented]
            //then we need to ignore bitrate settings for audio & video
            //Argument += " -fs 4096";


            //No Video
            if (CheckBoxVideo.IsChecked == false)
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
                if (ComboBoxVideoCodec.SelectedIndex != 0 && CheckBoxVideoBitrate.IsChecked == true)
                {
                    GeneralArguments += " -b:v " + TextBoxVideoBitrate.Text + "k";
                }


                //Resolution
                //Keep or change aspect ratio feature???  [To be implemented]
                if (ComboBoxVideoCodec.SelectedIndex != 0 && CheckBoxVideoResolution.IsChecked == true)
                {
                    GeneralArguments += " -s " + TextBoxVideoResolutionWidth.Text + "x" + TextBoxVideoResolutionHeight.Text;
                }


                //Rotation
                if (ComboBoxVideoCodec.SelectedIndex != 0 && CheckBoxVideoRotation.IsChecked == true)
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
            if (CheckBoxAudio.IsChecked == false)
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
                if (ComboBoxAudioCodec.SelectedIndex != 0 && CheckBoxAudioBitrate.IsChecked == true)
                {
                    GeneralArguments += " -b:a " + TextBoxAudioBitrate.Text + "k";
                }


                //Keep audio at Same Quality [To be implemented]
                //


                //Sample Rate
                if (ComboBoxAudioCodec.SelectedIndex != 0 && CheckBoxAudioSamplingRate.IsChecked == true)
                {
                    GeneralArguments += " -ar " + TextBoxAudioSamplingRate.Text;
                }


                //Volume
                if (ComboBoxAudioCodec.SelectedIndex != 0 && CheckBoxAudioVolumeMultiplier.IsChecked == true)
                {
                    GeneralArguments += " -filter:a " + "\"" + "volume=" + TextBoxAudioVolumeMultiplier.Text + "\"";
                }


                //5.1 to Stereo
                if (ComboBoxAudioCodec.SelectedIndex != 0 && CheckBoxAudioToStereo.IsChecked == true)
                {
                    GeneralArguments += " -filter:a " + "\"" + "pan=stereo|FL=FC+0.30*FL+0.30*BL|FR=FC+0.30*FR+0.30*BR" + "\"";
                }


                //Set audio pitch [To be implemented]
                //

            }


            //Optimize for Web Streaming
            GeneralArguments += " -movflags faststart <OUTPUT>";
        }








        private void StartBatch()
        {
            string Extension = "";
            int FilesCount = InputFiles.GetUpperBound(0) + 1;

            for (int i = 0; i < FilesCount; i++)
            {

                this.Dispatcher.Invoke((Action)(() =>
                {
                    GroupBoxStatus.Header = "Status: " + (i + 1).ToString() + " of " + FilesCount.ToString();


                    if (CheckBoxVideo.IsChecked == true)
                    {
                        Extension = ".mp4";
                    }
                    else
                    {
                        switch (ComboBoxAudioCodec.SelectedIndex)
                        {
                            case 0:
                                if (InputFiles[i, 1] == "aac")
                                {
                                    Extension = ".m4a";
                                }
                                else
                                {
                                    Extension = "." + InputFiles[i, 1];
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

                    CurrentFile = InputFiles[i, 0];
                    OutputFile = TextBoxTargetPath.Text + "\\" + System.IO.Path.GetFileNameWithoutExtension(CurrentFile) + "_converted" + Extension;

                }));


                SpecificArguments = GeneralArguments;
                SpecificArguments = SpecificArguments.Replace("<INPUT>", "\"" + CurrentFile + "\"");
                SpecificArguments = SpecificArguments.Replace("<OUTPUT>", "\"" + OutputFile + "\"");


                StartFFmpegProcess();

                while (!Exited)
                {
                    //Wait till end of Process
                }

            }

        }



        private bool ValidateParameters()
        {
            //Add Validation here for parameters typed in by user [To be implemented]
            return true;
        }


        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateParameters())
            {
                return;
            }

            ButtonConvert.IsEnabled = false;
            ButtonBrowse.IsEnabled = false;
            ButtonBrowsePath.IsEnabled = false;

            CheckBoxVideo.IsEnabled = false;
            CheckBoxAudio.IsEnabled = false;

            GroupBoxVideo.IsEnabled = false;
            GroupBoxAudio.IsEnabled = false;

            new Thread(new ThreadStart(StartBatch)).Start();
        }



        private void WindowMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                //Don't leave FFmpeg running in background when user closes the GUI
                if (!ProcessFFmpeg.HasExited)
                {
                    ProcessFFmpeg.Kill();
                    ProcessFFmpeg.Close();
                }
            }
            catch
            {

            }
        }


    }


}




