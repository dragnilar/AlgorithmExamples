using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqTests.Classes;
using LinqTests.Classes.LinqTests;

namespace LinqTests
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {


            while (true)
            {
                ShowMenuOptions();
                
                var input = Console.ReadKey();

                switch (input.Key)
                {
                        case ConsoleKey.D1:
                        case ConsoleKey.NumPad1:
                            new LinqTestsOne().RunTests();
                            break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        new LinqTestsTwo().RunTests();
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

        private static void ShowMenuOptions()
        {
            Console.WriteLine("Press 1 For LINQ Tests One...");
            Console.WriteLine("Press 2 For LINQ Tests Two...");
            Console.WriteLine("Press ESC To Quit");
        }
    }
}
