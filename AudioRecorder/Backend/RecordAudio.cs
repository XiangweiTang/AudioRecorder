using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioRecorder
{
    static class RecordAudio
    {
        public static void PreRecord(AudioInfo ai)
        {            
            MciCommands.MciOpen();
            MciCommands.MciSet(ai.BitsPerSample, ai.Channel, ai.SampleRate, ai.ByteRate, ai.BlockAlign);
        }

        public static void Record()
        {
            MciCommands.MciRecord();
        }

        public static void PostRecord(UserInfo ui, string audioRootFolder, string transRootFolder, Trans trans)
        {
            string audioPath = Path.Combine(audioRootFolder, ui.UserId, trans.CurrentIndex.ToString("000000") + ".wav");
            if (File.Exists(audioPath))
                File.Delete(audioPath);
            MciCommands.MciSave(audioPath);
            MciCommands.MciClose();

            string transPath = Path.Combine(transRootFolder, ui.UserId, trans.CurrentIndex.ToString("000000") + ".txt");
            if (File.Exists(transPath))
                File.Delete(transPath);
            string content = string.Join("\t", OutputTransParts(ui, trans));
            File.WriteAllText(transPath, content);
        }

        private static IEnumerable<string> OutputTransParts(UserInfo ui, Trans trans)
        {
            yield return trans.CurrentIndex.ToString("000000");
            yield return ui.UserId;
            yield return ui.Age.ToString();
            yield return ui.Gender;
            yield return ui.Dialect;
            yield return trans.CurrentTrans;
        }
    }
}
