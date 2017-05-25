using HexagonalThis.Domain;
using HexagonalThis.Infra;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace HexagonalThis.Tests
{
    public class AcceptanceTests
    {
        [Test]
        public void Should_give_some_verses_when_asking_lines()
        {
            var poet = new Poet();
            var verses = poet.GiveMeVerses(1);

            Check.That(verses).IsEqualTo("Souvent, pour s\'amuser, les hommes d\'équipage");
        }

        [Test]
        public void Should_give_some_verses_when_asking_lines_to_the_hexagon()
        {
            var poetryProvider = Substitute.For<IKnowLotsOfPoetry>();
            poetryProvider.FindRandomPoem().Returns("If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)");

            var hexagon = new Hexagon(poetryProvider);

            Check.That(hexagon.GiveMeVerses(2)).IsEqualTo("If you could read a leaf or tree\r\nyou’d have no need of books.");
        }

        [Test]
        public void Should_give_some_verses_when_asking_lines_with_Json_format()
        {
            var poetryProvider = Substitute.For<IKnowLotsOfPoetry>();
            var alisterPoem = "If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)";
            poetryProvider.FindRandomPoem().Returns(alisterPoem);

            var hexagon = new Hexagon(poetryProvider);
            var jsonAdapter = new JsonAdapter(hexagon);

            var verses = jsonAdapter.GetSomeVerses("{ \"numberOfLines\": 3}");
            Check.That(verses).IsEqualTo("{\r\n\t\"verses\": {\r\n\t\"requested lines\": 3,\r\n\t\"fragment\": \"If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)\"\r\n\t}\r\n}");
        }
    }
}