using HexagonalThis.Domain;

namespace HexagonalThis.Infra
{
    public class Hexagon : IProvideVerses
    {
        private readonly Poet poet;

        public string GiveMeVerses(int numberOfVerse)
        {
            return poet.GiveMeVerses(numberOfVerse);
        }

        public Hexagon(IKnowLotsOfPoetry poetryProvider)
        {
            poet = new Poet(poetryProvider);
        }
    }
}