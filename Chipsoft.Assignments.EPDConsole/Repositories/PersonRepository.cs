using Chipsoft.Assignments.EPDConsole.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole.Repositories
{
    public class PersonRepository<T> :BaseRepository<T> where T: Person
    {
    }
}
