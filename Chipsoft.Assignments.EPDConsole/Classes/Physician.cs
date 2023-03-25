using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole.Classes
{
    public  class Physician: Person
    {
        public ICollection<Patient>? Patients { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

        public Physician(string firstName, string name, string address):base(firstName, name, address)
        {

        }
    }
}
