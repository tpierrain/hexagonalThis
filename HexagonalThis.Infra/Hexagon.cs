using System;
using System.Linq;
using HexagonalThis.Tests.Domain;

namespace HexagonalThis.Tests.Infra
{
    public class Hexagon : IProvideVerses
    {
        private readonly IKnowLotsOfPoetry poetryProvider;
        private Poet poet;

        public string GiveMeVerses(int numberOfVerse)
        {
            return this.poet.GiveMeVerses(numberOfVerse);
        }

        public Hexagon(IKnowLotsOfPoetry poetryProvider)
        {
            this.poet = new Poet(poetryProvider);
            this.poetryProvider = poetryProvider;
        }
    }
}