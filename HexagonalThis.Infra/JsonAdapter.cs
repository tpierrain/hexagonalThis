using HexagonalThis.Domain;
using Newtonsoft.Json;

namespace HexagonalThis.Infra
{
    public class JsonAdapter
    {
        private readonly IProvideVerses verseProvider;

        public JsonAdapter(IProvideVerses verseProvider)
        {
            this.verseProvider = verseProvider;
        }

        public string GetSomeVerses(string jsonRequest)
        {
            // Adapts from the Json model to the domain one.
            var request = JsonConvert.DeserializeObject<JsonRequest>(jsonRequest);
            
            // call the business logic
            var rawResult = this.verseProvider.GiveMeVerses(request.numberOfLines);

            // Adapts from the business domain to the json one.
            return BuildJsonResult(request.numberOfLines, rawResult);
        }

        private string BuildJsonResult(int numberOfLineRequested, string rawResult)
        {
            return $"{{\r\n\t\"verses\": {{\r\n\t\"requested lines\": {numberOfLineRequested},\r\n\t\"fragment\": \"{rawResult}\"\r\n\t}}\r\n}}";
        }
    }
}