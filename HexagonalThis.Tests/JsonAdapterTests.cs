using HexagonalThis.Domain;
using HexagonalThis.Infra;
using NFluent;
using NSubstitute;
using NUnit.Framework;

namespace HexagonalThis.Tests
{
    public class JsonAdapterTests
    {
        [Test]
        public void Should_return_json_answer_when_asking_a_few_Verses()
        {
            var verseProvider = Substitute.For<IProvideVerses>();
            verseProvider.GiveMeVerses(2).Returns("one\r\ntwo");

            var jsonAdapter = new JsonAdapter(verseProvider);
            var result = jsonAdapter.GetSomeVerses("{ \"numberOfLines\": 2}");

            Check.That(result).IsEqualTo("{\r\n\t\"verses\": {\r\n\t\"requested lines\": 2,\r\n\t\"fragment\": \"one\r\ntwo\"\r\n\t}\r\n}");
        }
    }
}