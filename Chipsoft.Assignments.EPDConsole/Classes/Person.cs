using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole.Classes
{
    public class Person: Base
    {
        public string FirstName { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public Person(string firstName, string name, string address)
        {
            FirstName = firstName;

            Name = name;

            Address = address;

        }


    }
}
