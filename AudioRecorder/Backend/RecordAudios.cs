using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecorder
{
    class RecordAudios
    {
        AudioInfo Ai { get; set; }
        UserInfo Ui { get; set; }
        public void PreRecordSingleAudio()
        {
            MciCommands.MciOpen();
            MciCommands.MciSet(Ai.BitsPerSample, Ai.Channel, Ai.SampleRate, Ai.ByteRate, Ai.BlockAlign);            
        }

        public void RecordSingleAudio()
        {            
            MciCommands.MciRecord();
        }

        public void PostRecordSingleAudio(string rootFolder, int index, string transcript)
        {
            UserInfoLine line = new UserInfoLine(Ui, index, transcript);
            MciCommands.FilePath = line.OutputFilePath(rootFolder);
            MciCommands.MciSave();
            MciCommands.MciClose();
        }
    }
}
