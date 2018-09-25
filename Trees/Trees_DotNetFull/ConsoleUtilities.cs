using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees_DotNetFull
{
    public static class ConsoleUtilities
    {
        public static int GetInputLessThanXFromUser(int amountToUse = 1000)
        {

            var returnInteger = 0;
            var parseSuccessful = false;
            var numberIsValid = false;

            while (!parseSuccessful || !numberIsValid)
            {
                Console.WriteLine($"Input a number less than {amountToUse} to use for the example(s) and press enter");
                var input = Console.ReadLine();
                parseSuccessful = int.TryParse(input, out returnInteger);
                numberIsValid = ValidateInput(amountToUse, parseSuccessful, numberIsValid, returnInteger);

            }
            return returnInteger;
        }


        private static bool ValidateInput(int amountToUse, bool parseSuccessful, bool numberIsValid, int returnInteger)
        {
            if (parseSuccessful)
            {
                numberIsValid = NumberIsValid(returnInteger, amountToUse);
                if (!numberIsValid)
                {
                    Console.Clear();
                }
            }
            else
            {
                Console.Clear();
            }

            return numberIsValid;
        }

        private static bool NumberIsValid(int input, int max)
        {
            if (input <= 0)
            {
                return false;
            }

            return input < max;
        }


    }
}
