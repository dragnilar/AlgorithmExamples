using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonkeyApp_UWP.Models
{
    public class FakePerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsDead { get; set; }

        public FakePerson(string firstName, string lastName, string address, bool isDead)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            IsDead = isDead;
        }


        
    }
}
