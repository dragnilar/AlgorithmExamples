using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciSpaghetti.Classes
{
    public class FibonacciCalculations
    {
        public void RunBasicExample()
        {
            Console.Clear();
            var numberIsValid = false;
            var desiredNumber = 0;
            while (numberIsValid != true)
            {
                Console.WriteLine("Enter a desired number to calculate in the fib sequence. Don't enter 0 or a number higher than 46.\n" +
                                  "If you're wondering why, after 46, we blow past the maximum value of an integer... :-/");
                var input = Console.ReadLine();
                var parsed = int.TryParse(input, out desiredNumber);

                if (!parsed) continue;
                if (desiredNumber <= 0) continue;
                if (desiredNumber <= 1000)
                {
                    numberIsValid = true;
                }
                Console.Clear();
            }


            CalculateFibNumberBasic(desiredNumber);
        }

        private void CalculateFibNumberBasic(int desiredNumber)
        {

            Console.WriteLine($"Calculating the {desiredNumber}th number in the fib sequence...\n\n");
            int firstNumber = 1;
            int secondNumber = 1;
            int[] fibonacciSequence = new int[desiredNumber];
            fibonacciSequence[0] = firstNumber;
            fibonacciSequence[1] = secondNumber;
            for (int i = 2; i < desiredNumber; i++)
            {
                fibonacciSequence[i] = fibonacciSequence[i - 2] + fibonacciSequence[i - 1];

            }

            Console.WriteLine($"The {desiredNumber}-ith number in the sequence is : {fibonacciSequence[desiredNumber - 1]}"); //Decrement because of the index
            Console.ReadKey();
            Console.Clear();
        }
    }
}
