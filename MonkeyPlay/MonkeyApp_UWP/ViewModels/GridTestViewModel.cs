using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bogus;
using MonkeyApp_UWP.Factories;
using MonkeyApp_UWP.Helpers;
using MonkeyApp_UWP.Models;

namespace MonkeyApp_UWP.ViewModels
{
    public class GridTestViewModel : Observable
    {
        public ObservableCollection<FakePerson> FakePersons { get; set; }

        public GridTestViewModel()
        {

            FakePersons = GetFakePersons();

        }


        public ObservableCollection<FakePerson> GetFakePersons()
        {
            var fakeFactory = new FakePersonFactory();
            var faker = new Faker();
            var fakePersonsCollection = new ObservableCollection<FakePerson>();

            for (int i = 0; i < faker.Random.Int(10,255); i++)
            {
                fakePersonsCollection.Add(fakeFactory.GenerateFakePerson());
            }

            return fakePersonsCollection;

        }
    }
}
