namespace HexagonalThis.Tests.Domain
{
    public class Poet : IProvideVerses
    {
        public string GiveMeVerses(int numberOfVerse)
        {
            return "Souvent, pour s\'amuser, les hommes d\'équipage";
        }
    }
}