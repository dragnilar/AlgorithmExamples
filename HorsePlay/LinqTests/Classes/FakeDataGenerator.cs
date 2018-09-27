using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;

namespace LinqTests.Classes
{
    public static class FakeDataGenerator
    {
        public static List<int> GetListOfRandomIntegers()
        {
            var faker = new Faker();
            var list = Enumerable.Range(1, 100).Select(r => faker.Random.Int(1, 9999)).ToList();
            return list;

        }


        public static List<FakePerson> GetListOfFakePeople()
        {
            var list = Enumerable.Range(1, 100).Select(r => GetRandomFakePerson()).ToList();

            return list;
        }


        public static FakePerson GetRandomFakePerson()
        {
            var faker = new Faker();

            var fakePerson = new FakePerson
            {
                DateOfBirth = faker.Date.Past(75, DateTime.Today),
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Gender = faker.PickRandom<Gender>().ToString(),
                IsDead = faker.Random.Bool(),
                NetWorth = faker.Random.Decimal(Decimal.Zero, Decimal.MaxValue)
            };


            return fakePerson;
        }


       
    }
}