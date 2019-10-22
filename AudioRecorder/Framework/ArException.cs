using System;

namespace AudioRecorder
{
    internal class ArException : Exception
    {
        public ArException() : base() { }
        public ArException(string message) : base(message)
        {

        }
    }
}
