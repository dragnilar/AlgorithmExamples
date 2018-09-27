using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTests.Classes.LinqTests
{
    public class LinqTestsOne
    {
        public void RunTests()
        {
            Console.Clear();
            Console.WriteLine("Generating input list of random integers...");
            var list = FakeDataGenerator.GetListOfRandomIntegers();
            Console.WriteLine(".Count of list is... " + list.Count);
            Console.WriteLine("Running linq examples/tests...");
            MinMaxExample(list);
            FirstAndLastExample(list);
            Console.WriteLine("Finished linq tests one, press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();

        }

        private void MinMaxExample<T>(IEnumerable<T> inputList)
        {
            Console.WriteLine($"{nameof(inputList)}.Min() and .Max() yields...");
            Console.WriteLine(inputList.Min());
            Console.WriteLine(inputList.Max());
        }

        private void FirstAndLastExample<T>(IEnumerable<T> inputList)
        {
            Console.WriteLine($"{nameof(inputList)}.First() and .Last() yield...");
            Console.WriteLine(inputList.First());
            Console.WriteLine(inputList.Last());
        }
        
        
        
    }
}