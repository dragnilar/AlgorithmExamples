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
            Console.WriteLine("Running manual binary tree test...");
            stopWatch.Start();
            RunExampleOne();
            stopWatch.Stop();
            Console.WriteLine($"Time it took to run example: {stopWatch.Elapsed.Milliseconds} MS");
            Console.WriteLine("Ending examples, press any key to exit.");
            Console.ReadKey();
        }

        private static void RunExampleOne()
        {
            Console.WriteLine("Building a tree with 12 values in it");
            var tree = BuildTreeWith12Values();
            RunTreeContainsTest(tree, 1);
            RunTreeContainsTest(tree, 4);
            RunTreeContainsTest(tree, 7);
            RunTreeContainsTest(tree, 9);
            RunTreeContainsTest(tree, 11);
            RunTreeContainsTest(tree, 12);
            RunTreeContainsTest(tree, 22);
            RunTreeContainsTest(tree, 99999999);


        }



        private static Trees_Core_DotNetFull.BinaryTreeClasses.BinarySearchTree<int> BuildTreeWith12Values()
        {
            var binaryTree = new Trees_Core_DotNetFull.BinaryTreeClasses.BinarySearchTree<int>();
            for (int i = 1; i <= 12; i++)
            {
                binaryTree.AddNewNode(i);
            }

            return binaryTree;
        }

        private static void RunTreeContainsTest(Trees_Core_DotNetFull.BinaryTreeClasses.BinarySearchTree<int> tree ,int valueToTest)
        {
            Console.WriteLine($"Testing to see if the binary tree contains int value {valueToTest}");
            var result = tree.ContainsData(valueToTest);
            OutPutTreeContainsData(result, valueToTest);
        }

        private static void OutPutTreeContainsData(bool containsResult, int value)
        {
            Console.WriteLine(containsResult
                ? $"The tree contains the value of {value}."
                : $"The tree does not contain the value of {value}.");
        }
    }
}