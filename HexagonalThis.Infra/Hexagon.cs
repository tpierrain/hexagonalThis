using System;
using System.Linq;
using HexagonalThis.Tests.Domain;

namespace HexagonalThis.Tests.Infra
{
    public class Hexagon : IProvideVerses
    {
        private readonly IKnowLotsOfPoetry poetryProvider;

        public string GiveMeVerses(int numberOfVerse)
        {
            var poem = this.poetryProvider.FindRandomPoem();
            var lines = poem.Split(new []{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            return string.Join("\r\n", lines.Take(numberOfVerse));
        }

        public Hexagon(IKnowLotsOfPoetry poetryProvider)
        {
            this.poetryProvider = poetryProvider;
        }
    }
}