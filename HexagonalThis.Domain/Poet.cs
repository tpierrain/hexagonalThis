using System;
using System.Linq;

namespace HexagonalThis.Tests.Domain
{
    public class Poet : IProvideVerses
    {
        private readonly IKnowLotsOfPoetry poetryProvider;

        public Poet()
        {
            this.poetryProvider = new HardCodedPoetryProvider();
        }

        public Poet(IKnowLotsOfPoetry poetryProvider)
        {
            this.poetryProvider = poetryProvider;
        }

        public string GiveMeVerses(int numberOfVerse)
        {
            var poem = this.poetryProvider.FindRandomPoem();
            var lines = poem.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            return string.Join("\r\n", lines.Take(numberOfVerse));
        }

        private class HardCodedPoetryProvider : IKnowLotsOfPoetry
        {
            public string FindRandomPoem()
            {
                return "Souvent, pour s\'amuser, les hommes d\'équipage";
            }
        }
    }
}