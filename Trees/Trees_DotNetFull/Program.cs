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
            Console.WriteLine("Running binary tree search examples.\n Note that all examples will use trees of less than 1000 nodes to save time.");
            RunExampleOne(stopWatch);
            RunExampleTwo(stopWatch);
            Console.WriteLine("Ending examples, press any key to exit.");
            Console.ReadKey();
        }



        private static void RunExampleOne(Stopwatch stopWatch)
        {
            stopWatch.Start();
            var amountToUse = ConsoleUtilities.GetInputLessThanXFromUser();
            new BinaryTreeSearchExamples().RunExampleOne(amountToUse);
            stopWatch.Stop();
            Console.WriteLine($"Time it took to run example: {stopWatch.Elapsed.Milliseconds} MS");
        }

        private static void RunExampleTwo(Stopwatch stopWatch)
        {
            stopWatch.Start();
            var amountToUse = ConsoleUtilities.GetInputLessThanXFromUser();
            new BinaryTreeSearchExamples().RunExampleTwo(amountToUse);
            stopWatch.Stop();
            Console.WriteLine($"Time it took to run example: {stopWatch.Elapsed.Milliseconds} MS");
        }
    }
}