using System;
using System.Runtime.InteropServices;

namespace AudioRecorder
{
    internal static class MciCommands
    {
        private const string Alias = "sound";
        [DllImport("winmm.dll")]
        private extern static void mciSendString(string cmdString, string returnString, int cchReturn, int callBack);
        public static void RunMci(string cmdString)
        {
            mciSendString(cmdString, "", 0, 0);
        }
        public static void MciOpen()
        {
            RunMci($"open new type waveaudio alias {Alias}");
        }
        public static void MciSet(int bitsPerSample, int channel, int samplesPerSec, int bytesPerSec, int align)
        {
            RunMci($"set {Alias} bitspersample {bitsPerSample} channels {channel} samplespersec {samplesPerSec} bytespersec {bytesPerSec} alignment {align}");
        }

        public static void MciRecord()
        {
            RunMci($"record {Alias}");
        }
        public static void MciSave(string filePath)
        {
            RunMci($"save {Alias} {filePath}");
        }
        public static void MciClose()
        {
            RunMci($"close {Alias}");
        }
        public static void MciPreRecord(AudioInfo ai)
        {
            MciOpen();
            MciSet(ai.BitsPerSample, ai.Channel, ai.SampleRate, ai.ByteRate, ai.BlockAlign);
        }
        public static void MciPostRecord(string filePath)
        {
            MciSave(filePath);
            MciClose();
        }
    }
}
