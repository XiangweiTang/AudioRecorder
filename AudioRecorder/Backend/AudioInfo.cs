using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecorder
{
    struct AudioInfo
    {
        public int BitsPerSample { get; }
        public int Channel { get; }
        public int SampleRate { get; }
        public int ByteRate => (BitsPerSample * Channel * SampleRate) >> 3;
        public int BlockAlign => (BitsPerSample * Channel) >> 3;
    }
}
