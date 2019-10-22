namespace AudioRecorder
{
    static internal class Sanity
    {
        public static void Requires(bool valid, string message)
        {
            if (!valid)
                throw new ArException(message);
        }

        public static void Requires(bool valid)
        {
            Requires(valid, "An ArException is thrown.");
        }
    }
}
