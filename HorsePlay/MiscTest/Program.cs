using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscTest
{
    class Program
    {
        static void Main(string[] args)
        {

            RunMainMenu();

        }

        private static void RunMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Press 1 to run some true and false tests.");
                Console.WriteLine("Press ESC to to exit.");

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        new TrueAndFalseTests().RunTests();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
