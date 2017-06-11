using HexagonalThis.ConsoleApp.Adapters;
using HexagonalThis.Domain;

namespace HexagonalThis.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstArgument = args[0];

            // instantiate the hexagon
            var poet = new Poet();

            // Instantiate the left-side adapter to request the hexagon
            var consoleAdapter = new ConsoleAdapter(poet);

            System.Console.WriteLine($"Here are the first {firstArgument} verses:\n");

            consoleAdapter.RequestFirstVersesForAPoem(firstArgument);

            System.Console.WriteLine("\nType enter to exit");
            System.Console.ReadLine();
        }
    }
}
