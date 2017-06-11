using System;
using HexagonalThis.Domain;

namespace HexagonalThis.ConsoleApp.Adapters
{
    public interface IWriteStuffsToTheConsole
    {
        void WriteLine(string text);
    }

    public class ConsoleAdapter
    {
        private readonly IProvideVerses poet;
        private readonly IWriteStuffsToTheConsole publicationStrategy;

        public ConsoleAdapter(IProvideVerses poet) : this(poet, new ConsolePublicationStrategy())
        {
        }

        public ConsoleAdapter(IProvideVerses poet, IWriteStuffsToTheConsole publicationStrategy)
        {
            this.poet = poet;
            this.publicationStrategy = publicationStrategy;
        }

        public void RequestVerses(string consoleArguments)
        {
            // accept the argument

            // Call the busines logic
            var verses = this.poet.GiveMeSomePoetry();

            // Get back with the answer onto the Console
            this.publicationStrategy.WriteLine(verses);
        }

        public void RequestFirstVersesForAPoem(string line)
        {
            // Map the request passed by the infra side (here Console app arguments)
            int numberOfLine = int.Parse(line);

            // Call the business logic
            var verses = this.poet.GiveMeLinesOfPoetry(numberOfLine);

            // Get back with the answer onto the Infra side (Console)
            this.publicationStrategy.WriteLine(verses);
        }

        // default publication strategy: write to the Console
        private class ConsolePublicationStrategy : IWriteStuffsToTheConsole
        {
            public void WriteLine(string text)
            {
                Console.WriteLine(text);
            }
        }
    }

    
}