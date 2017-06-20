using System.IO;
using HexagonalThis.Domain;

namespace HexagonalThis.Infra
{
    public class PoetryLibraryFileAdapter : IObtainPoems
    {
        private string poem;

        public PoetryLibraryFileAdapter(string filePath)
        {
            this.poem = File.ReadAllText(filePath);
        }

        public string GetMeAPoem()
        {
            return this.poem;
        }
    }
}