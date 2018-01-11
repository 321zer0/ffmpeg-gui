using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFmpeg_GUI
{
    public class AudioStream
    {
        public int Index
        {
            get;
            private set;
        }

        public string Codec
        {
            get;
            private set;
        }

        public int Bitrate
        {
            get;
            private set;
        }

        public int SamplingFrequency
        {
            get;
            private set;
        }

        public string ChannelCount
        {
            get;
            private set;
        }


        public AudioStream(int index, string codec, int bitrate, int samplingFrequency, string channelCount)
        {
            Index = index;
            Codec = codec;
            Bitrate = bitrate;
            SamplingFrequency = samplingFrequency;
            ChannelCount = channelCount;
        }


    }
}
