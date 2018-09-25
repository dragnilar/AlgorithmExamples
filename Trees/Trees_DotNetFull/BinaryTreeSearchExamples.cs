using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trees_Core_DotNetFull.BinaryTreeClasses;

namespace Trees_DotNetFull
{
    public class BinaryTreeSearchExamples
    {
        public void RunExampleOne(int amountToUse)
        {
            Console.WriteLine($"Building a tree with {amountToUse} values in it");
            var tree = BuildTreeWithXValues(amountToUse);
            Console.WriteLine($"Performing 20 searches on the tree");
            var randomizer = new Random(DateTime.Now.Millisecond);
            var maxValue = amountToUse * 2;
            for (int i = 1; i <= 20; i++)
            {
                var randomInt = randomizer.Next(1, maxValue);
                RunTreeContainsTest(tree, randomInt);
            }
        }

        public void RunExampleTwo(int amountToUse)
        {
            Console.WriteLine($"Building a tree with {amountToUse} values in it");
            var tree = BuildTreeWithXValues(amountToUse);
            Console.WriteLine("Enter a number of nodes to delete from the tree between 1 and 20");
            var input = ConsoleUtilities.GetInputLessThanXFromUser(21);
            var randomizer = new Random(DateTime.Now.Millisecond);
            for (int i = 1; i <= input; i++)
            {
                var randomInt = randomizer.Next(1, input);
                RunDeleteTest( tree, randomInt);
            }

        }




        private BinarySearchTree<int> BuildTreeWithXValues(int x)
        {
            var binaryTree = new BinarySearchTree<int>();
            for (var i = 1; i <= x; i++) binaryTree.AddNewNode(i);

            return binaryTree;
        }

        private void RunTreeContainsTest(BinarySearchTree<int> tree, int valueToTest)
        {
            Console.WriteLine($"Testing to see if the binary tree contains int value {valueToTest}");
            var result = tree.ContainsData(valueToTest);
            OutPutTreeContainsData(result, valueToTest);
        }

        private void OutPutTreeContainsData(bool containsResult, int value)
        {
            Console.WriteLine(containsResult
                ? $"The tree contains the value of {value}."
                : $"The tree does not contain the value of {value}.");
        }

        private void RunDeleteTest(BinarySearchTree<int> tree, int randomInt)
        {
            Console.WriteLine($"Attempting to delete node with value of {randomInt} from tree");
            var deleteResult = tree.DeleteNode(randomInt);
            OutPutDeleteTestResult(deleteResult, randomInt);
        }

        private void OutPutDeleteTestResult(bool deleteResult, int value)
        {
            Console.WriteLine(deleteResult
                ? $"Successfully deleted {value} from tree."
                : $"The tree does not contain the value of {value}; it was not deleted.");
        }
    }
}
