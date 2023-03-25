using Chipsoft.Assignments.EPDConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole
{
    public static class ConsoleCommands
    {
        private static string QuestionFirstName = "Wat is de persoon zijn voornaam?";

        private static string QuestionLastName = "Wat is de persoon zijn achternaam?";

        private static string QuestionAddress = "Wat is de persoon zijn adres? Straatnaam is voldoende :).";
        
        private static string QuestionPhysician = "Welke dokter bent u?";

        private static string QuestionAppointmentReason = "Wat is de reden voor de visite?";
        private static string QuestionAppointmentDescriptionNeeded = "Wilt u een beschrijving toevoegen? Ja of nee antwoord alsjeblieft.";
        private static string QuestionAppointmentDescription = "De beschrijving:";
        private static string QuestionAppointmentDate = "Geef een datum in (in het dd-MM-yyyy format).";
        private static string QuestionAppointmentTime = "Geef een tijdstip in (in het HH:mm format, 24 uur stelsel).";



        public static T GetPerson<T>() where T: Person, new()
        {
            string firstName = GetDetail(QuestionFirstName);
            string lastName = GetDetail(QuestionLastName);
            string address = GetDetail(QuestionAddress);

            return new()
            {
                FirstName = firstName,
                Name = lastName,
                Address = address
            };
        }

        public static Person GetPersonName()
        {
            string firstName = GetDetail(QuestionFirstName);
            string lastName = GetDetail(QuestionLastName);
            return new Person(firstName, lastName, string.Empty);
        }

        public static Patient GetPatientInfo()
        {
            string firstName = GetDetail(QuestionFirstName);
            string lastName = GetDetail(QuestionLastName);
            string address = GetDetail(QuestionAddress);

            return new Patient(firstName, lastName, address);
        }

        public static Physician GetPhysicianInfo()
        {

            string firstName = GetDetail(QuestionFirstName);
            string lastName = GetDetail(QuestionLastName);
            string address = GetDetail(QuestionAddress);

            return new Physician(firstName, lastName, address);
        }

        public static Physician GetPhysicianInfoForPatient()
        {
            Console.WriteLine(QuestionPhysician);
            string firstName = GetDetail(QuestionFirstName);
            string name = GetDetail(QuestionLastName);
            return new Physician(firstName, name, string.Empty);
        }

        public static Appointment GetAppointmentInfo()
        {
            string reason = GetDetail(QuestionAppointmentReason);
            string description = string.Empty;
            string descriptionNeeded= GetDetail(QuestionAppointmentDescriptionNeeded);
            if (descriptionNeeded == "Ja")
            {
                description = GetDetail(QuestionAppointmentDescription);
            }

            var dateTime = GetExactDateTime();
            
            return new Appointment(reason)
            {
                Description = description,
                DateTime = dateTime
            };
        }

        private static DateTime GetExactDateTime()
        {
            DateTime result = new DateTime();
            bool correctResult = false;
            while (!correctResult) { 
                try
                {
                    string date = GetDetail(QuestionAppointmentDate);
                    string time = GetDetail(QuestionAppointmentTime);


                    result = DateTime.ParseExact($"{date} {time}", "dd-MM-yyyy HH:mm", null);
                    correctResult = true;
                    return result;
                }
                catch (Exception ex)
                {
                    // Log
                    Console.WriteLine("Het format dat u gebruikte klopt niet. Zou u het nog eens willen proberen?");
                    correctResult = false;
                    continue;
                }
            }
            return result;
        }


        private static string GetDetail(string question)
        {
            string result = string.Empty;
            while (result == string.Empty)
            {
                if(result == string.Empty)
                {
                    Console.WriteLine(question);
                }
                result = Console.ReadLine() ?? string.Empty;
            }


            return result;
        }
    }
}
