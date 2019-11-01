using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AudioRecorder
{
    class Trans
    {
        public string CurrentTrans => TransArray[CurrentIndex];
        public int Length => TransArray.Length;
        public int CurrentIndex { get; private set; } = 0;
        
        private readonly string[] TransArray = new string[1] { "" };
        public Trans(IEnumerable<string> transList, bool shuffle=false)
        {
            TransArray = shuffle ? transList.Shuffle() : transList.ToArray();
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
        public void JumpToLastIndex()
        {
            CurrentIndex = Length - 1;
            ValidateIndex();
        }
        public void JumpToFirstIndex()
        {
            CurrentIndex = 0;
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
