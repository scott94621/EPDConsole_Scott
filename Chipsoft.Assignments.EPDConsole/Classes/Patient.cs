using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chipsoft.Assignments.EPDConsole.Classes
{
    public class Patient : Person
    {
        
        public int PhysicianId { get; set; }
        public Physician Physician { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Patient(string firstName, string name, string address) : base(firstName, name, address)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            
        }


    }
}
