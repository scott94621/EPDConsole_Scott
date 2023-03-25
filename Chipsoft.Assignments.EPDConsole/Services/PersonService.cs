using Chipsoft.Assignments.EPDConsole.Classes;
using Chipsoft.Assignments.EPDConsole.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole.Services
{
    public abstract class PersonService<T> : BaseService<T> where T: Person
    {
        public PersonService(PersonRepository<T> personRepository): base(personRepository)
        {

        }

        public Person GetWithName(string firstName, string name)
        {
            var results = baseRepository.GetAll().Where(x => x.FirstName == firstName && x.Name == name);
            if(results.Any() && results.Count() == 1)
            {
                return results.First();
            }
            else
            {
                return null;
            }
        }

    }
}
