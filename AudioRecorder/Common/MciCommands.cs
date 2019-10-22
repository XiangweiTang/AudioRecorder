using System.Runtime.InteropServices;

namespace AudioRecorder
{
    internal static class MciCommands
    {
        public static string FilePath { get; set; } = "";
        private const string Alias = "sound";
        [DllImport("winmm.dll")]
        extern static void mciSendString(string cmdString, string returnString, int cchReturn, int callBack);
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
        public static void MciSave()
        {
            RunMci($"save {Alias} {FilePath}");
        }
        public static void MciClose()
        {
            RunMci($"close {Alias}");
        }
    }
}
