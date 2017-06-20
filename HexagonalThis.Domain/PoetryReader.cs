namespace HexagonalThis.Domain
{
    public class PoetryReader : IRequestVerses
    {
        private readonly IObtainPoems poetryLibrary;

        public PoetryReader() : this(new HardCodedPoetryLibrary())
        {
        }

        public PoetryReader(IObtainPoems poetryLibrary)
        {
            this.poetryLibrary = poetryLibrary;
        }

        public string GiveMeSomePoetry()
        {
            return this.poetryLibrary.GetMeAPoem();
        }

        private class HardCodedPoetryLibrary : IObtainPoems
        {
            public string GetMeAPoem()
            {
                return "I want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)";
            }
        }
    }
}