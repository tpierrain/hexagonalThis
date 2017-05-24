using System;
using NFluent;
using NUnit.Framework;

namespace HexagonalThis.Tests
{
    public class AcceptanceTests
    {
        [Test]
        public void Should_give_some_poetry_fragment_when_asking_lines()
        {
            var poet = new Poet();
            var verses = poet.GiveMeVerses(1);

            Check.That(verses).IsEqualTo("Souvent, pour s\'amuser, les hommes d\'équipage");
        }
    }

    public class Poet
    {
        public string GiveMeVerses(int numberOfVerse)
        {
            throw new NotImplementedException();
        }
    }
}