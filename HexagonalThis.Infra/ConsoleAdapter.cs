using HexagonalThis.Domain;

namespace HexagonalThis.Infra
{
    public class ConsoleAdapter
    {
        private readonly IRequestVerses poetryReader;
        private readonly IWriteLines publicationStrategy;

        public ConsoleAdapter(IRequestVerses poetryReader, IWriteLines publicationStrategy)
        {
            this.poetryReader = poetryReader;
            this.publicationStrategy = publicationStrategy;
        }

        public ConsoleAdapter(PoetryReader poetryReader) : this(poetryReader, new ConsolePublicationStrategy())
        {
        }

        public void Ask()
        {
            // from infra to domain

            // busines logic
            var verses = this.poetryReader.GiveMeSomePoetry();

            // from domain to Infra
            this.publicationStrategy.WriteLine($"Poem:\n{verses}");
        }

        private class ConsolePublicationStrategy : IWriteLines
        {
            public void WriteLine(string text)
            {
                System.Console.WriteLine(text);
            }
        }


    }
}