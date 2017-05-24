using HexagonalThis.Tests.Domain;
using Newtonsoft.Json;

namespace HexagonalThis.Tests.Infra
{
    public class JsonAdapter
    {
        private readonly IProvideVerses verseProvider;

        public JsonAdapter(IProvideVerses verseProvider)
        {
            this.verseProvider = verseProvider;
        }

        public string Post(string jsonRequest)
        {
            var request = JsonConvert.DeserializeObject<JsonRequest>(jsonRequest);

            return this.verseProvider.GiveMeVerses(request.numberOfLines);
        }
    }
}