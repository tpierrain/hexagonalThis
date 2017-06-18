namespace HexagonalThis.Domain
{
    public class PoetryReader : IRequestVerses
    {
        private IObtainPoems poetryLibrary;

        public PoetryReader()
        {
        }

        public PoetryReader(IObtainPoems poetryLibrary)
        {
            this.poetryLibrary = poetryLibrary;
        }

        public string GiveMeSomePoetry()
        {
            if (this.poetryLibrary != null)
            {
                return this.poetryLibrary.GetAPoem();
            }

            return "If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)";
        }
    }
}