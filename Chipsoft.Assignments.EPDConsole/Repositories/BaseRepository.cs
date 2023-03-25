using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chipsoft.Assignments.EPDConsole.Classes;

namespace Chipsoft.Assignments.EPDConsole.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private EPDDbContext _context = null;
        private DbSet<T> table = null;
     
        public BaseRepository()
        {
            this._context = new EPDDbContext();
            table = _context.Set<T>();
        }
        
        public BaseRepository(EPDDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        
        public T GetById(int id)
        {
            return table.Find(id);
        }
        
        public void Add(T obj)
        {
            table.Add(obj);
        }
        
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
    }
}
