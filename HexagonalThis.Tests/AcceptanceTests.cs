using System;
using HexagonalThis.ConsoleApp.Domain;
using HexagonalThis.ConsoleApp.Infra;
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

        [Test]
        public void Should_return_poetry_when_asked_from_the_console_adapter()
        {
            // Introducing a second driver for the 1st port: IProvideVerses
            var poetryLibrary = Substitute.For<IKnowABunchOfPoetry>();
            poetryLibrary.GetPoem().Returns("I want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)");

            // instantiate the hexagon
            var poet = new Poet(poetryLibrary);

            // Instantiate the left-side adapter to request the hexagon
            var publicationStrategy = Substitute.For<IWriteStuffsToTheConsole>();

            var consoleAdapter = new ConsoleAdapter(poet, publicationStrategy);
            consoleAdapter.RequestVerses("I need poetry!");

            publicationStrategy.Received().WriteLine("I want to sleep\r\nSwat the flies\r\nSoftly, please.\r\n\r\n-- Masaoka Shiki (1867-1902)");
        }

        [Test]
        public void Should_return_number_of_first_verses_when_asked_from_the_console_adapter()
        {
            // Introducing a second verb for the 1st port: IProvideVerses
            var poetryLibrary = Substitute.For<IKnowABunchOfPoetry>();
            poetryLibrary.GetPoem().Returns("Souvent, pour s'amuser, les hommes d'équipage\r\nPrennent des albatros, vastes oiseaux des mers,\r\nQui suivent, indolents compagnons de voyage,\r\nLe navire glissant sur les gouffres amers.\r\n\r\nA peine les ont-ils déposés sur les planches,\r\nQue ces rois de l'azur, maladroits et honteux,\r\nLaissent piteusement leurs grandes ailes blanches\r\nComme des avirons traîner à côté d'eux.\r\n\r\nCe voyageur ailé, comme il est gauche et veule !\r\nLui, naguère si beau, qu'il est comique et laid !\r\nL'un agace son bec avec un brûle-gueule,\r\nL'autre mime en boitant, l'infirme qui volait !\r\n\r\nLe Poète est semblable au prince des nuées\r\nQui hante la tempête et se rit de l'archer ;\r\nExilé sur le sol au milieu des huées,\r\nSes ailes de géant l'empêchent de marcher.\r\n\r\n(L'albatros, Charles BAUDELAIRE)");

            // instantiate the hexagon
            var poet = new Poet(poetryLibrary);

            // Instantiate the left-side adapter to request the hexagon
            var publicationStrategy = Substitute.For<IWriteStuffsToTheConsole>();

            var consoleAdapter = new ConsoleAdapter(poet, publicationStrategy);
            consoleAdapter.RequestFirstVersesForAPoem("1");

            // Assert publication has been made
            publicationStrategy.Received().WriteLine("Souvent, pour s'amuser, les hommes d'équipage");
        }
    }
}