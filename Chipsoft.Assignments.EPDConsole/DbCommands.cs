using Chipsoft.Assignments.EPDConsole.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole
{
    public class DbCommands<T> where T: Base
    {
        public void SaveChanges(DbContext context)
        {
            context.SaveChanges();
        }

        public void Add(DbContext context, T item)
        {
            context.Add(item);
            
        }

    }
}
