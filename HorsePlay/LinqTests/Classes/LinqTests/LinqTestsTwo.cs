using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTests.Classes.LinqTests
{
    public class LinqTestsTwo
    {

        public void RunTests()
        {
            Console.Clear();
            Console.WriteLine("Generating input list of random fake people...");
            var list = FakeDataGenerator.GetListOfFakePeople();
            Console.WriteLine(".Count of list is... " + list.Count);
            Console.WriteLine("Running LINQ examples/tests...");
            GroupByTest(list);
            Console.WriteLine("Finished LINQ tests two, press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();

        }

        private void GroupByTest(List<FakePerson> inputList)
        {
            Console.WriteLine("Grouping the list by IsDead...");

            var groupResult = inputList.GroupBy(r => r.IsDead);

            Console.WriteLine("Group By Results...\n");

            foreach (var group in groupResult)
            {
                Console.WriteLine($"IsDead For These People is {group.Key}.");
                foreach (var value in group)
                {
                    Console.WriteLine($"Name of Person: {value.FirstName} {value.LastName}");
                }

                Console.WriteLine();
            }

        }
    }
}
