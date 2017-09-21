using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FFmpeg_GUI
{
    class VideoStream
    {
        private int _Index;
        private int _AbsoluteIndex;

        private string _Codec;
        private int _Bitrate;
        private Point _Resolution;
        private int _FrameRate;

        public int Index
        {
            get
            {
                return _Index;
            }
        }

        public int AbsoluteIndex
        {
            get
            {
                return _AbsoluteIndex;
            }
        }

        public string Codec
        {
            get
            {
                return _Codec;
            }
        }

        public int Bitrate
        {
            get
            {
                return _Bitrate;
            }
        }

       
        public Point Resolution
        {
            get
            {
                return _Resolution;
            }
        }

        public int FrameRate
        {
            get
            {
                return _FrameRate;
            }
        }



        public VideoStream(int index, int absoluteIndex, string codec, int bitrate, Point resolution, int frameRate)
        {
            _Index = index;
            _AbsoluteIndex = absoluteIndex;
            _Codec = codec;
            _Bitrate = bitrate;
            _Resolution = resolution;
            _FrameRate = frameRate;
        }

        


    }
}
