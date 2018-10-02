using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using MonkeyApp_UWP.Models;

namespace MonkeyApp_UWP.Factories
{
    public class FakePersonFactory
    {
        public FakePerson GenerateFakePerson()
        {
            var faker = new Faker();

            return new FakePerson(faker.Person.FirstName, faker.Person.LastName, faker.Person.Address.Street, faker.Random.Bool());
        }
    }
}
