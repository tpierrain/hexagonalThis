using System.IO;
using HexagonalThis.Domain;

namespace HexagonalThis.Infra
{
    public class PoemFileAdapter : IObtainPoems
    {
        private readonly string poem;

        public PoemFileAdapter(string filePath)
        {
            this.poem = File.ReadAllText(filePath);
        }

        public string GetAPoem()
        {
            return this.poem;
        }
    }
}