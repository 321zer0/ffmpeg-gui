using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpeg_GUI
{
    class AudioStream
    {
        private int _Index;
        private int _AbsoluteIndex;

        private string _Codec;
        private int _Bitrate;
        private int _SamplingFrequency;
        private int _Channels;

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

        public int SamplingFrequency
        {
            get
            {
                return _SamplingFrequency;
            }
        }

        public int Channels
        {
            get
            {
                return _Channels;
            }
        }



        public AudioStream(int index, int absoluteIndex, string codec, int bitrate, int samplingFrequency, int channels)
        {
            _Index = index;
            _AbsoluteIndex = absoluteIndex;
            _Codec = codec;
            _Bitrate = bitrate;
            _SamplingFrequency = samplingFrequency;
            _Channels = channels;
        }


    }
}
