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
            var randomInt = randomizer.Next(1, 25);
            var maxValue = randomInt * 2;
            for (int i = 1; i <= 20; i++)
            {
                randomInt = randomizer.Next(1, maxValue);
                RunTreeContainsTest(tree, randomInt);
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
    }
}
