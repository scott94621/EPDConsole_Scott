using Chipsoft.Assignments.EPDConsole.Classes;
using Chipsoft.Assignments.EPDConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole
{
    public static class Manager
    {
        public static PatientService PatientService;

        public static PhysicianService PhysicianService;

        public static AppointmentService AppointmentService;

        static Manager() { 
            PatientService = new PatientService();
            PhysicianService = new PhysicianService();
            AppointmentService = new AppointmentService();

        }

        public static void AddPatient()
        {
            Patient patient = ConsoleCommands.GetPatientInfo();
            Physician physician = ConsoleCommands.GetPhysicianInfoForPatient();

            var physicianEntity = PhysicianService.GetWithName(physician.FirstName, physician.Name);
            patient.PhysicianId = physicianEntity.Id;

            PatientService.Add(patient);
        }

        public static void AddPhysician()
        {
            Physician physician = ConsoleCommands.GetPhysicianInfo();
            PhysicianService.Add(physician);
        }

        public static void AddAppointment()
        {
            Appointment app = ConsoleCommands.GetAppointmentInfo();
 
            Console.WriteLine("De informatie van de patient:");
            var patient = ConsoleCommands.GetPersonName();
            var patientWithId = (Patient)PatientService.GetWithName(patient.FirstName, patient.Name);

            app.PatientId = patientWithId.Id;

            AppointmentService.Add(app);
        }
        public static void AddTestPeople()
        {
            var doctor1 = new Physician("Ludo", "Graeven", "Koninklijkesteenweg 12");

            var doctor2 = new Physician("Chantal", "Peeters", "Leien 521");

            var doctor3 = new Physician("Erica", "America", "Tscheld 1");

            var patient1 = new Patient("Dirk", "Veronderd", "Hoogstaandsebaan 55") { PhysicianId = 1};

            var patient2 = new Patient("Gil", "Yasser", "Oudstrijderslaan 12") { PhysicianId = 1 };

            var patient3 = new Patient("Amie", "Meerinckx", "IJzerlaan 44") { PhysicianId = 3 };

            var appointment1 = new Appointment("Doktersbezoek")
            {
                Description = "Een opvolging ivm de lever.",
                DateTime = new DateTime(2023, 5, 12, 14, 0, 0),
                PatientId = 1
            };

            PhysicianService.Add(doctor1);
            PhysicianService.Add(doctor2);
            PhysicianService.Add(doctor3);

            PatientService.Add(patient1);
            PatientService.Add(patient2);
            PatientService.Add(patient3);

            AppointmentService.Add(appointment1);
        }
    }
}
