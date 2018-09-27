using System;
using System.Collections.Generic;
using System.Text;

namespace EvilFizzBizz
{
    public class NoLogicCheckFizzBizz
    {
        /// <summary>
        /// This is an example of doing the fizz bizz without using any hard coded logic checks. This is primarily taken from this code review post:
        /// https://codereview.stackexchange.com/questions/121714/fizzbuzz-without-hard-coded-logic-checks
        /// </summary>
        public void DoTheFizzBizz()
        {
            var catalog = new FizzBizzCatalog();
            catalog.Add(3, App.Config.FizzString);
            catalog.Add(5, App.Config.BizzString);
            catalog.Add(15, App.Config.PozzString);

            var counter = new FizzBizzCounter(1, 100, catalog);

            counter.OutPutFizzBizz();
        }

        private class FizzBizzCounter
        {
            private readonly FizzBizzCatalog _fizzBizzCatalog;
            private readonly int max;
            private readonly int min;

            internal FizzBizzCounter(int Min, int Max, FizzBizzCatalog fizzBizzCatalog)
            {
                min = Min;
                max = Max;
                _fizzBizzCatalog = fizzBizzCatalog;
            }

            internal void OutPutFizzBizz()
            {
                for (var i = min; i <= max; i++) Console.WriteLine(_fizzBizzCatalog.GetString(i));
            }
        }

        private class FizzBizzCatalog
        {
            private readonly List<FizzBizzSpecification> fizzBizzSpecs;

            internal FizzBizzCatalog()
            {
                fizzBizzSpecs = new List<FizzBizzSpecification>();
            }

            internal void Add(int Divisor, string Output)
            {
                fizzBizzSpecs.Add(new FizzBizzSpecification {Divisor = Divisor, Output = Output});
            }

            internal string GetString(int Number)
            {
                var builder = new StringBuilder();
                foreach (var x in fizzBizzSpecs)
                {
                    builder.Append(Number % x.Divisor == 0 ? x.Output : "");
                }
                string outputString = builder.ToString();

                return String.IsNullOrWhiteSpace(outputString) ? Number.ToString() : outputString;
            }

            private class FizzBizzSpecification
            {
                internal int Divisor;
                internal string Output;
            }
        }
    }
}