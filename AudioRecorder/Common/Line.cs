using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioRecorder
{
    abstract class Line
    {
        public string OriginalLine { get; }
        public Line() { }
        public Line(string line)
        {
            OriginalLine = line;
            SplitParts();
        }
        public string Output => string.Join("\t", OutputParts());
        protected abstract IEnumerable<string> OutputParts();
        protected abstract void SplitParts();
    }
}
