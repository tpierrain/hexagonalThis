using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace HexagonalThis.Tests
{
    public class AcceptanceTests
    {
        [Test]
        public void Should_give_verses_when_asking_poetry()
        {
            // Simplest Driver possible
            // port: IProvideVerses
            // API verb: Poet.GiveMeSomePoetry();
            IProvideVerses poet = new Poet();
            var verses = poet.GiveMeSomePoetry();

            Check.That(verses).IsEqualTo("If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)");
        }

        [Test]
        public void Should_give_verses_from_a_poetryLibrary()
        {
            // Introducing a second port: IKnowABunchOfPoetry
            // port: IKnowABunchOfPoetry
            // API verb: Poet.GetPoem();
            var poetryLibrary = Substitute.For<IKnowABunchOfPoetry>();
            poetryLibrary.GetPoem().Returns("blah");

            // instantiate the hexagon
            var poet = new Poet(poetryLibrary);
            var verses = poet.GiveMeSomePoetry();

            Check.That(verses).IsEqualTo("blah");
        }

    }

    public interface IKnowABunchOfPoetry
    {
        string GetPoem();
    }

    public interface IProvideVerses
    {
        string GiveMeSomePoetry();
    }

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
    }
}