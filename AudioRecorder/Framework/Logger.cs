using System;
using System.Text;
using System.IO;

namespace AudioRecorder
{
    static internal class Logger
    {
        public static string LogPath { get; set; } = "Log.txt";
        private static readonly object O = new object();
        public static void WriteLine(string message)
        {
            string content = $"{DateTime.Now.ToStringLog()}\t{message}";
            using(StreamWriter sw=new StreamWriter(LogPath, true, Encoding.Unicode))
            {
                sw.WriteLine(content);
            }
        }
        public static void WriteLineWithLock(string message)
        {
            lock (O)
            {
                WriteLine(message);
            }
        }

        public static void WriteLine(ArException e)
        {
            WriteLine(e.ToString());
        }

        public static void WriteLineWithLock(ArException e)
        {
            WriteLineWithLock(e.ToString());
        }
    }
}
