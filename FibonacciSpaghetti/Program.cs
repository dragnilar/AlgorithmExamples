using System;
using FibonacciSpaghetti.Classes;

namespace FibonacciSpaghetti
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to some useless Fibonacci Sequences...");

            while (true)
            {
                MainMenu();
            }
            
        }

        static void MainMenu()
        {
            Console.WriteLine("Select a menu option...\n");

            Console.WriteLine("Press 1 for a basic example of the Fibonacci sequence.");
            Console.WriteLine("Press 2 for an example of a recursive Fibonacci sequence");
            Console.WriteLine("Press 3 for an example of calculating the desired number in a Fibonacci sequence (up to number 46)");
            Console.WriteLine("Press F4 for an explanation of what the heck a Fibonacci Sequence \"is\"");
            Console.WriteLine("Press ESC to bail out and quit.");

            var input = Console.ReadKey();

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    new BasicFibonacci().RunBasicExample();
                    Console.Clear();
                    break;
                case ConsoleKey.D2:
                    new BasicFibonacci().RunRecursiveExample();
                    Console.Clear();
                    break;
                case ConsoleKey.D3:
                    new FibonacciCalculations().RunBasicExample();
                    Console.Clear();
                    break;
                case ConsoleKey.F4:
                    Help();
                    Console.Clear();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }

        static void Help()
        {
            Console.Clear();
            Console.WriteLine("A Fibonacci Sequence is a series of numbers in which each number (Fibonacci numbers) is the sum of the two preceding numbers.\n" +
                              "An example of a sequence would be 0, 1, 1, 2, 3, 5, 8, 13...\n\n" +
                              "Like teh Fizz Bizz, its another programming interview question that gets abused.\n\n\n" +
                              "Press any key to return to the main menu.");
            Console.ReadKey();
        }
    }  
}
