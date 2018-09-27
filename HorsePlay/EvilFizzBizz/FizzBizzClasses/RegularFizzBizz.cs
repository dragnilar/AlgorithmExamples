using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace EvilFizzBizz
{
    public class RegularFizzBizz
    {

        /// <summary>
        /// This is the classic example of fizz bizz written in C#. Standard use of modulus and all the other things that go along with it.
        /// </summary>
        public void ClassicFizzBizz()
        {
            for (var i = 1; i <= 100; i++)
                if (i % 3 == 0 && i % 5 == 0)
                {
                    App.Util.GenericPrint(i, App.Config.FizzBizzString);
                }

                else
                {
                    if (i % 3 == 0) App.Util.GenericPrint(i, App.Config.FizzString);

                    else if (i % 5 == 0) App.Util.GenericPrint(i, App.Config.BizzString);

                    else App.Util.GenericPrint(i);
                    
                }
        }

        /// <summary>
        /// This is another classic example of fizz bizz written in C#. The only major difference is that this one uses 15 for the FizzBizz string
        /// instead of checking both 3 and 5 to save some time. Otherwise its identical to the other classic example.
        /// </summary>
        public void ClassicFizzBizz2()
        {
            for (var i = 1; i <= 100; i++)
                if (i % 15 == 0)
                {
                    App.Util.GenericPrint(i, App.Config.FizzBizzString);
                }

                else
                {
                    if (i % 3 == 0) App.Util.GenericPrint(i, App.Config.FizzString);

                    else if (i % 5 == 0) App.Util.GenericPrint(i, App.Config.BizzString);

                    else App.Util.GenericPrint(i);
                }
        }

        /// <summary>
        /// This is an example of doing Fizz Bizz with a for each loop instead of using a standard for loop. This one takes
        /// advantage of System.Linq but its otherwise the same as the other two classics.
        /// </summary>
        public void FizzBizzWithForEach()
        {
            var integerList = new List<int>();
            integerList.AddRange(Enumerable.Range(1, 100));


            foreach (var integer in integerList)
            {
                if (integer % 15 == 0)
                {
                    App.Util.GenericPrint(integer, App.Config.FizzBizzString);
                }

                else if (integer % 5 == 0)
                {
                    App.Util.GenericPrint(integer, App.Config.BizzString);
                }

                else if (integer % 3 == 0)
                {
                    App.Util.GenericPrint(integer, App.Config.FizzString);
                }

                else
                {
                    App.Util.GenericPrint(integer);
                }
            }
        }

        /// <summary>
        /// Uses Linq To Do the Fizz Bizz. This is based on this post over at Code Review:
        /// https://codereview.stackexchange.com/questions/49058/single-line-fizzbuzz-solution-in-linq
        /// </summary>
        public void LinqFizzBizz()
        {
            Enumerable.Range(1, 100).Select(
                x =>
                    x % 15 == 0 ? $"{x}, {App.Config.FizzBizzString}" :
                    x % 3 == 0 ? $"{x}, {App.Config.FizzString}" :
                    x % 5 == 0 ? $"{x}, {App.Config.BizzString}" :
                    x.ToString()).ToList().ToList().ForEach(Console.WriteLine);
        }

        /// <summary>
        /// A second example of using Linq to do the Fizz Bizz. This is based on the Gist found here:
        /// https://gist.github.com/tikluganguly/2252339
        /// </summary>
        public void LinqFizzBizz2()
        {
            Enumerable.Range(1, 100).ToList().ForEach(x =>
                Console.WriteLine(x % 15 == 0
                    ? App.Config.FizzBizzString
                    : (x % 3 == 0 ? App.Config.FizzString : (x % 5 == 0 ? App.Config.BizzString : x.ToString()))));
        }
        
        /// <summary>
        /// A third of example of using Linq to do the Fizz Bizz. This just simplifies the equations.
        /// </summary>
        public void LinqFizzBizz3()
        {
            Enumerable.Range(1,100).ToList().ForEach(x => Console.WriteLine(App.Util.IsDivisibleBy15(x) ? App.Config.FizzBizzString :
                (App.Util.IsDivisibleBy5(x) ? App.Config.FizzString : 
                    App.Util.IsDivisibleBy3(x) ? App.Config.BizzString :
                    x.ToString())));

        }

        /// <summary>
        /// An example of FizzBizz with a dictionary, a nested for each loop and an ugly generic method that can throw exceptions.
        /// This was not based on anything in particular.
        /// </summary>
        public void FizzBizzWithDictionary()
        {
            var fizzDictionary = new Dictionary<int, string>
            {
                {3, App.Config.FizzString},
                {5, App.Config.BizzString},
            };

            var someList = Enumerable.Range(1, 100).ToList();

            foreach (var value in someList)
            {
                var builder = new StringBuilder();
                builder.Append(value + ", ");
                foreach (var entry in fizzDictionary)
                {

                    if (App.Util.IsDivisibleByDivisorGeneric(value, entry.Key))
                    {
                        builder.Append(entry.Value);
                    }

                }

                Console.WriteLine(builder.ToString());
            }
        }

        /// <summary>
        /// This is an example of doing the fizz bizz without using any % operators. This is based on this post from DreamInCode:
        /// https://www.dreamincode.net/forums/topic/290153-fizzbuzz-without-mod/
        /// Note that this was originally written in C++. It has been refactored in C# so that it does not use recursion. 
        /// </summary>
        public void FizzBizzWithNoModulus()
        {
            var fizzBizzNumber = 1;
            var fizzNumber = 1;
            var bizzNumber = 1;
            var counter = 1;
            while (true)
            {
                if (fizzBizzNumber == 15)
                {
                    App.Util.GenericPrint(counter, App.Config.FizzBizzString);
                    fizzBizzNumber = 0;
                    fizzNumber = 0;
                    bizzNumber = 0;
                }
                else if (fizzNumber == 3)
                {
                    App.Util.GenericPrint(counter, App.Config.FizzString);
                    fizzNumber = 0;
                }

                else if (bizzNumber == 5)
                {
                    App.Util.GenericPrint(counter, App.Config.BizzString);
                    bizzNumber = 0;
                }
                else
                {
                   App.Util.GenericPrint(counter);
                }

                if (counter < 100)
                {
                    fizzBizzNumber = ++fizzBizzNumber;
                    fizzNumber = ++fizzNumber;
                    bizzNumber = ++bizzNumber;
                    counter = ++counter;
                    continue;
                }

                break;
            }
        }
    }
}