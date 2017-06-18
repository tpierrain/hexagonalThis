using HexagonalThis.Domain;

namespace HexagonalThis.Infra
{
    

    public class ConsoleAdapter
    {
        private readonly PoetryReader poetryReader;
        private IWriteStuffOnTheConsole writeStrategy;

        public ConsoleAdapter(PoetryReader poetryReader) : this (poetryReader, new DefaultPublicationStrategy())
        {
            
        }

        public ConsoleAdapter(PoetryReader poetryReader, IWriteStuffOnTheConsole writeStrategy)
        {
            this.poetryReader = poetryReader;
            this.writeStrategy = writeStrategy;
        }

        public void Ask()
        {
            // Adapt from the infra to the domain

            // Call the business logic
            var verses = this.poetryReader.GiveMeSomePoetry();

            // Adapt from Domain to Infra
            this.writeStrategy.WriteLine($"A beautiful poem:\n\n{verses}");
        }

        private class DefaultPublicationStrategy : IWriteStuffOnTheConsole
        {
            public void WriteLine(string text)
            {
                System.Console.WriteLine(text);
            }
        }
    }
}