using System;
using System.Diagnostics;
using Trees_Core_DotNetFull.BinaryTreeClasses;

namespace Trees_DotNetFull
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            Console.WriteLine("Running binary tree search examples.");
            stopWatch.Start();
            var amountToUse = GetInputFromUser();
            new BinaryTreeSearchExamples().RunExampleOne(amountToUse);
            stopWatch.Stop();
            Console.WriteLine($"Time it took to run example: {stopWatch.Elapsed.Milliseconds} MS");
            Console.WriteLine("Ending examples, press any key to exit.");
            Console.ReadKey();
        }


        private static int GetInputFromUser()
        {

            var returnInteger = 0;
            var parseSuccessful = false;
            var numberIsLessThan1000 = false;

            while (!parseSuccessful || !numberIsLessThan1000)
            {
                Console.WriteLine("Input a number less than 1000 to use for the example(s) and press enter.\n" +
                                  "We will not be using a number greater than that amount due to the amount of time it would take to build the tree...");
                var input = Console.ReadLine();
                parseSuccessful = Int32.TryParse(input, out returnInteger);
                numberIsLessThan1000 = returnInteger < 1000;
                if (!parseSuccessful || !numberIsLessThan1000)
                {
                    Console.Clear();
                }
            }
            return returnInteger;
        }



    }
}