using HexagonalThis.ConsoleApp.Domain;
using HexagonalThis.ConsoleApp.Infra;

namespace HexagonalThis.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // instantiate the hexagon
            var poet = new Poet();

            // Instantiate the left-side adapter to request the hexagon
            var consoleAdapter = new ConsoleAdapter(poet);

            var firstArgument = args[0];
            consoleAdapter.RequestVerses(firstArgument);

            System.Console.WriteLine("Type enter to exit");
            System.Console.ReadLine();
        }
    }
}
