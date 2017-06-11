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
            // port: Poet.GiveMeSomePoetry();
            var poet = new Poet();
            var verses = poet.GiveMeSomePoetry();

            Check.That(verses).IsEqualTo("If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)");
        }
        
    }

    public class Poet
    {
        public object GiveMeSomePoetry()
        {
            return "If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)";
        }
    }
}