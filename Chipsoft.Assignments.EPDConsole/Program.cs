using Chipsoft.Assignments.EPDConsole.Classes;
using Chipsoft.Assignments.EPDConsole.Repositories;
using Chipsoft.Assignments.EPDConsole.Services;

namespace Chipsoft.Assignments.EPDConsole
{
    public class Program
    {
        //Don't create EF migrations, use the reset db option
        //This deletes and recreates the db, this makes sure all tables exist

        private static void AddPatient()
        {
            //Do action
            //return to show menu again.
            try
            {
                Manager.AddPatient();
            }
            catch(Exception ex)
            {
                // Log
                return;
            }
        }

        private static void ShowAppointment()
        {
            try
            {
                var appointments = Manager.AppointmentService.GetAll();
                if (!appointments.Any())
                {
                    Console.WriteLine("Er zijn nog geen afspraken ingeboekt.");
                }
                foreach(var appointment in appointments)
                {
                    var patient = Manager.PatientService.GetById(appointment.PatientId);
                    var physician = Manager.PhysicianService.GetById(patient.PhysicianId);
                    
                    Console.WriteLine($"Op {appointment.DateTime.ToString("dd/MM/yyyy")} heeft dokter {physician.FirstName} {physician.Name} " +
                        $"met patient {patient.FirstName} {patient.Name} een afspraak die zal gaan over {appointment.ReasonForVisit}.");

                    Console.WriteLine($"Deze afspraak zal starten om {appointment.DateTime.ToString("HH:mm")}.");

                    if(appointment.Description != string.Empty)
                    {
                        Console.WriteLine($"Dokter {physician.Name} heeft het volgende er nog bij geschreven: {appointment.Description}");
                    }
                    else
                    {
                        Console.WriteLine("Er is geen verder informatie voorzien.");
                    }
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                // Log
                return;
            }
        }

        private static void AddAppointment()
        {
            try
            {
                Manager.AddAppointment();
            }
            catch (Exception ex)
            {
                // Log
                return;
            }
        }

        private static void DeletePhysician()
        {
            try
            {
                Physician physician = ConsoleCommands.GetPhysicianInfoForPatient();

                var physicianWithId = Manager.PhysicianService.GetWithName(physician.FirstName, physician.Name);
                if(physicianWithId != null)
                {
                    Manager.PhysicianService.Delete(physicianWithId.Id);
                }
            }
            catch(Exception ex)
            {
                // Log
                return;
            }
        }

        private static void AddPhysician()
        {
            try
            {
                Manager.AddPhysician();
            }
            catch (Exception ex)
            {
                // Log
                return;
            }
        }

        private static void DeletePatient()
        {
            try
            {
                Patient patient = ConsoleCommands.GetPatientInfo();

                var patientWithId = Manager.PatientService.GetWithName(patient.FirstName, patient.Name);
                if (patientWithId != null)
                {
                    Manager.PatientService.Delete(patientWithId.Id);
                }
            }
            catch (Exception ex)
            {
                // Log
                return;
            }
        }


        #region FreeCodeForAssignment
        static void Main(string[] args)
        {
            while (ShowMenu())
            {
                //Continue
            }
        }

        public static bool ShowMenu()
        {
            Console.Clear();
            foreach (var line in File.ReadAllLines("logo.txt"))
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("");
            Console.WriteLine("1 - Patient toevoegen");
            Console.WriteLine("2 - Patienten verwijderen");
            Console.WriteLine("3 - Arts toevoegen");
            Console.WriteLine("4 - Arts verwijderen");
            Console.WriteLine("5 - Afspraak toevoegen");
            Console.WriteLine("6 - Afspraken inzien");
            Console.WriteLine("7 - Sluiten");
            Console.WriteLine("8 - Reset db");
            Console.WriteLine("9 - Testpersonen toevoegen");

            if (int.TryParse(Console.ReadLine(), out int option))
            {
                switch (option)
                {
                    case 1:
                        AddPatient();
                        return true;
                    case 2:
                        DeletePatient();
                        return true;
                    case 3:
                        AddPhysician();
                        return true;
                    case 4:
                        DeletePhysician();
                        return true;
                    case 5:
                        AddAppointment();
                        return true;
                    case 6:
                        ShowAppointment();
                        return true;
                    case 7:
                        return false;
                    case 8:
                        EPDDbContext dbContext = new EPDDbContext();
                        dbContext.Database.EnsureDeleted();
                        dbContext.Database.EnsureCreated();
                        return true;
                    case 9:
                        Manager.AddTestPeople();
                        return true;
                    default:
                        return true;
                }
            }
            return true;
        }

        #endregion
    }
}