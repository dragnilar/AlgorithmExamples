using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EvilFizzBizz.FizzBizzClasses;

namespace EvilFizzBizz
{
    partial class Program
    {
        static readonly RegularFizzBizz RegularFizzBizzCollection = new RegularFizzBizz();

        /// <summary>
        /// This is not really a pattern example or test. This is just a bunch of examples on how to do the silly FizzBizz game in C#
        /// using various approaches. For sources of inspiration and/or the base of the examples, refer to the XML documentation on
        /// the particular methods or classes.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MainMenu();
        }



        static void MainMenu()
        {


            while (true)
            {
                ShowMenuOptions();

                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        RegularFizzBizzCollection.ClassicFizzBizz();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        RegularFizzBizzCollection.ClassicFizzBizz2();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        RegularFizzBizzCollection.LinqFizzBizz();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        RegularFizzBizzCollection.LinqFizzBizz2();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        RegularFizzBizzCollection.FizzBizzWithNoModulus();
                        break;
                    case ConsoleKey.D6:
                    case ConsoleKey.NumPad6:
                        Console.Clear();
                        MenuTwo();
                        break;
                    case ConsoleKey.F:
                        Console.Clear();
                        Console.WriteLine("Toggling obscenities...");
                        App.Config.ToggleObscenities();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You selected an invalid test... :/");
                        break;
                }

                ReturnToMainMenu();
                break;
            }

        }

        private static void MenuTwo()
        {
            while (true)
            {
                ShowMenuTwoOptions();

                var input = Console.ReadKey();
                switch (input.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        Console.Clear();
                        new NoLogicCheckFizzBizz().DoTheFizzBizz();
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        Console.Clear();
                        RegularFizzBizzCollection.FizzBizzWithForEach();
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Console.Clear();
                        new SomeOtherOverlyComplexFizzBizz().DoTheFizzBizz();
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        Console.Clear();
                        RegularFizzBizzCollection.LinqFizzBizz3();
                        break;
                    case ConsoleKey.D5:
                    case ConsoleKey.NumPad5:
                        Console.Clear();
                        RegularFizzBizzCollection.FizzBizzWithDictionary();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        MainMenu();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("You selected an invalid test... :/");
                        break;
                }

                ReturnToMenuTwo();
                break;
            }
        }

        static void ShowMenuOptions()
        {
            Console.WriteLine("Select a Fizz Bizz Test To Run..");
            Console.WriteLine("1. Classic Fizz Bizz");
            Console.WriteLine("2. Classic Fizz Bizz 2");
            Console.WriteLine("3. Linq Fizz Bizz");
            Console.WriteLine("4. Linq Fizz Bizz 2");
            Console.WriteLine("5. Fizz Bizz With NO Modulus");
            Console.WriteLine("6. More...");
            Console.WriteLine("You can also press F to toggle obscenities and tell 'em what you really think about Fizz Bizz...");
            Console.WriteLine("Press Esc to Exit");
        }


        static void ShowMenuTwoOptions()
        {
            Console.WriteLine("Menu Two");
            Console.WriteLine("Select a Fizz Bizz Test To Run..");
            Console.WriteLine("1. Fizz Bizz With No Hardcoded Logic Checks");
            Console.WriteLine("2. Fizz Bizz Using a For Each");
            Console.WriteLine("3. Some other overly complex Fizz Bizz");
            Console.WriteLine("4. Linq Fizz Bizz 3");
            Console.WriteLine("5. Fizz Bizz With a Dictionary, Nested For Each Loops And Other Stuff...");
            Console.WriteLine("Press Esc to go up one menu");
        }



        private static void ReturnToMainMenu()
        {
            Console.WriteLine("Press Any Key To Return To Main Menu");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        private static void ReturnToMenuTwo()
        {
            Console.WriteLine("Press Any Key To Return To Second Menu");
            Console.ReadKey();
            Console.Clear();
            MenuTwo();
        }


    }
}
