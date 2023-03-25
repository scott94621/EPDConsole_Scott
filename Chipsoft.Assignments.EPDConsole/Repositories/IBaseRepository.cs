using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chipsoft.Assignments.EPDConsole.Repositories
{
    public  interface IBaseRepository<T> where T : class
    {
        void SaveChanges();
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T obj);
        void Update(T obj);
        void Delete(object id);
    }
}
