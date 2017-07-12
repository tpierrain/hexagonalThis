using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HexagonalThis.Domain;
using HexagonalThis.Infra;

namespace HexagonalThis.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the hexagon (with no right-side adapter-> hard coded poems here)
            var poetryReader = new PoetryReader();

            // Instantiate the left-side adapter(s)
            var consoleAdapter = new ConsoleAdapter(poetryReader);

            // App logic is only using left-side adapter(s).
            System.Console.WriteLine("Here is some poetry:\n");
            consoleAdapter.Ask();
            System.Console.ReadLine();
        }
    }
}
