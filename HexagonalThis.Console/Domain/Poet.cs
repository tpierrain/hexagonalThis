using System;
using System.Linq;

namespace HexagonalThis.ConsoleApp.Domain
{
    public class Poet : IProvideVerses
    {
        private IKnowABunchOfPoetry poetryLibrary;

        public Poet()
        {
        }

        // constructor
        public Poet(IKnowABunchOfPoetry poetryLibrary)
        {
            this.poetryLibrary = poetryLibrary;
        }

        public string GiveMeSomePoetry()
        {
            if (poetryLibrary != null)
            {
                return poetryLibrary.GetPoem();
            }

            return "If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)";
        }

        public string GiveMeLinesOfPoetry(int numberOfLine)
        {
            var verses = this.poetryLibrary.GetPoem();
            var splitLines = verses.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            return string.Join("\r\n", splitLines.Take(numberOfLine));
        }
    }
}