using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciSpaghetti.Classes
{
    public class BasicFibonacci
    {
        public BasicFibonacci()
        {
            Console.Clear(); //We will always clear the console when instantiating this class. This is lazy, I know. 
        }
        public void RunBasicExample()
        {
            var a = 1;
            var b = 1;
            var c = 0;

            Console.WriteLine($"Explanation:\n\nFibonacci variables are as follows: \n a = {a}\n b = {b} \n c = {c}\n a and b are the first two numbers in the " +
                              $"sequence. We will do a simple for loop and add them both to c. \nThen we will output c and update a to match b and c to match b.\n" +
                              $"\n\nSimple, huh?\n\n");

            Console.WriteLine("Below are the first 25 numbers in a Fibonacci Sequence using the above method described.\n\n ");
            BasicFiboSequence(a, b, 25);
            Console.WriteLine("\n\nDone doing a basic sequence. Press any key to go back to the main menu. ");
            Console.ReadKey();
        }

        private static void BasicFiboSequence(int firstNumber, int secondNumber, int length)
        {
            Console.Write($"{firstNumber} {secondNumber}");
            length = length - 2; //Subtract the number of supplied variables
            for (int i = firstNumber; i <= length; i++)
            {
                var thirdNumber = firstNumber + secondNumber;
                Console.Write($" {thirdNumber}");
                firstNumber = secondNumber;
                secondNumber = thirdNumber;
            }
        }

        public void RunRecursiveExample()
        {
            var a = 1;
            var b = 1;
            Console.WriteLine($"Explanation:\n\nFor the recursive example, we will start with just two numbers, {a} and {b}.\n" +
                              $"We will then set the first number equal to the sum of both, and then make a recursive call for the desired number of times.\n" +
                              $"The only other thing that should be noted is that we are going to have a counter variable that will be used to stop the\n" +
                              $"recursive calls so that we don't blow the stack. :)\n\n");

            Console.WriteLine("Below are the first 25 numbers in a Fibonacci Sequence using the above method described.\n\n ");

            RecursiveFiboSequence(a, b, 25, 1);

            Console.WriteLine("\n\nDone doing a recursive sequence. Press any key to go back to the main menu. ");
            Console.ReadKey();
        }

        private void RecursiveFiboSequence(int firstNumber, int secondNumber, int length, int recursionCounter)
        {
            length = length - 2;
            Console.Write($"{firstNumber} {secondNumber}");
            if (recursionCounter <= length)
            {
                firstNumber = firstNumber + secondNumber;
                Console.Write($"{firstNumber}");
                RecursiveFiboSequence(secondNumber, firstNumber, length, recursionCounter );
            }
        }
    }
}
