using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilFizzBizz.FizzBizzClasses
{
    public class SomeOtherOverlyComplexFizzBizz
    {
        /// <summary>
        /// This is an another example of doing the fizz bizz without using any hard coded logic checks.
        /// This is heavily based on the following code review post: 
        /// https://codereview.stackexchange.com/questions/121714/fizzbuzz-without-hard-coded-logic-checks
        /// Note that this one can throw some funny exceptions..
        /// </summary>
        public void DoTheFizzBizz()
        {
            var fizzBizzBook = new FizzBizzPointBook();
            fizzBizzBook.AddPoint(3, App.Config.FizzString);
            fizzBizzBook.AddPoint(5, App.Config.BizzString);

            foreach (var integer in FizzListBuilder(1, 100))
            {
                Console.WriteLine(fizzBizzBook.GetFizzBizzReturnString(integer));
            }
        }

        private IEnumerable<int> FizzListBuilder(int minimumFizz, int maximumFizz)
        {
            ValidateFizzRange(minimumFizz, maximumFizz);

            return Enumerable.Range(minimumFizz, maximumFizz).ToList();
        }



        private static void ValidateFizzRange(int minimumFizz, int maximumFizz)
        {
            if (minimumFizz > maximumFizz)
            {
                throw new ArgumentException("ಠ_ಠ The minimum fizz cannot be greater than the maximum fizz!  ಠ_ಠ");
            }

            if (minimumFizz > 0) return;
            if (maximumFizz <= 0)
            {
                throw new ArgumentException(
                    "ლ(ಠ益ಠლ) You can't have a minimum fizz and a maximum fizz that are both less than or equal to zero, it doesn't work that way!");
            }
        }

        private class FizzBizzPointBook
        {
            private readonly List<FizzBuzzPoint> FizzBizzPoints;

            internal FizzBizzPointBook()
            {
                FizzBizzPoints = new List<FizzBuzzPoint>();
            }

            internal void AddPoint(int divisor, string returnString)
            {
                FizzBizzPoints.Add(new FizzBuzzPoint{Divisor = divisor, ReturnString = returnString});
            }

            internal string GetFizzBizzReturnString(int integer)
            {
                var fizzBuilder = new StringBuilder();
                foreach (var x in FizzBizzPoints)
                {
                    fizzBuilder.Append(App.Util.IsDivisibleByDivisor(integer, x.Divisor) ? x.ReturnString + " " : "");

                }

                var outPutString = fizzBuilder.ToString();

                return String.IsNullOrWhiteSpace(outPutString) ? integer.ToString() : $"{integer}, {outPutString}";
            }
        }


        private class FizzBuzzPoint
        {
            internal int Divisor;
            internal string ReturnString;
        }

    }
}
