using System;
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
            poetryProvider.FindPoem().Returns("If you could read a leaf or tree\r\nyou’d have no need of books.\r\n-- © Alistair Cockburn (1987)");

            var hexagon = new Hexagon(poetryProvider);

            Check.That(hexagon.GiveMeVerses(2)).IsEqualTo("If you could read a leaf or tree\r\nyou’d have no need of books.");
        }
    }

    public class Hexagon : IProvideVerses
    {
        public string GiveMeVerses(int numberOfVerse)
        {
            throw new NotImplementedException();
        }

        public Hexagon(IKnowLotsOfPoetry poetryProvider)
        {
            throw new NotImplementedException();
        }
    }

    public interface IKnowLotsOfPoetry
    {
        string FindPoem();
    }

    public interface IProvideVerses
    {
        string GiveMeVerses(int numberOfVerse);
    }

    public class Poet : IProvideVerses
    {
        public string GiveMeVerses(int numberOfVerse)
        {
            return "Souvent, pour s\'amuser, les hommes d\'équipage";
        }
    }
}