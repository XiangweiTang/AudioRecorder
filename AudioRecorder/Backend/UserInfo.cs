using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AudioRecorder
{
    class UserInfo
    {
        public string UserId { get; private set; } = new Guid().ToString();
        public byte Age { get; set; } = 0;
        public string Gender { get; set; } = "U";
        public string Dialect { get; set; } = "U";
        public UserInfo(params string[] args)
        {
            UserId = Guid.NewGuid().ToString();
        }
        public void LoadId(string userId)
        {
            UserId = userId;
        }
    }

    class UserInfoLine : Line
    {
        UserInfo Ui = null;
        string Index = "";
        string Transcript = "";
        public UserInfoLine(string line) : base(line)
        {

        }
        public UserInfoLine(UserInfo ui, int index, string transcript)
        {
            Ui = ui;
            Index = index.ToString("000000");
            Transcript = transcript;
        }
        public string OutputFilePath(string rootFolder) => Path.Combine(rootFolder, Ui.UserId, Index + ".wav");
        protected override IEnumerable<string> OutputParts()
        {
            yield return Index;
            yield return Ui.UserId;
            yield return Ui.Age.ToString();
            yield return Ui.Gender;
            yield return Ui.Dialect;
            yield return Transcript;
        }
        protected override void SplitParts()
        {
            var split = OriginalLine.Split('\t');
            Index = split[0];
            Ui.LoadId(split[1]);
            Ui.Age = byte.Parse(split[2]);
            Ui.Gender = split[3];
            Ui.Dialect = split[4];
            Transcript = split[5];
        }
    }
}
