using System.Collections.Generic;
using System.Linq;

namespace AudioRecorder
{
    class Trans
    {
        public string CurrentTrans => TransArray[CurrentIndex];
        public int Length => TransArray.Length;
        public int CurrentIndex { get; private set; } = 0;
        
        private readonly string[] TransArray = new string[1] { "" };
        public Trans(IEnumerable<string> transList)
        {
            TransArray = transList.ToArray();
            if (TransArray.Length == 0)
                TransArray = new string[1] { "" };
        }
        public void ChangeIndex(int i)
        {
            CurrentIndex += i;
            ValidateIndex();
        }
        public void SetIndex(int i)
        {
            CurrentIndex = i;
            ValidateIndex();
        }
        private void ValidateIndex()
        {
            if (CurrentIndex < 0)
                CurrentIndex = 0;
            if (CurrentIndex >= TransArray.Length)
                CurrentIndex = TransArray.Length - 1;
        }
    }
}
