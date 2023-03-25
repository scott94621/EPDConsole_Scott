using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole.Classes
{
    public class Appointment: Base
    {
        public string ReasonForVisit { get; set; }
        public string? Description { get; set; }

        public DateTime DateTime { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Appointment(string reasonForVisit)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            ReasonForVisit = reasonForVisit;
            Description = string.Empty;
        }

    }
}
