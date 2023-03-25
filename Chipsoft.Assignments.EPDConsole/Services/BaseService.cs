using Chipsoft.Assignments.EPDConsole.Classes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chipsoft.Assignments.EPDConsole.Repositories;

namespace Chipsoft.Assignments.EPDConsole.Services
{
    public abstract class BaseService<T> where T : Base
    {
        protected readonly BaseRepository<T> baseRepository;

        public BaseService(BaseRepository<T> baseRepository) {
            this.baseRepository = baseRepository;
        }

        public IEnumerable<T> GetAll()
        {
            return baseRepository.GetAll();
        }

        public T GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public void Add(T obj)
        {
            baseRepository.Add(obj);
            baseRepository.SaveChanges();
        }

        public void Update(T obj)
        {
            baseRepository.Update(obj);
            baseRepository.SaveChanges();
        }

        public void Delete(object id)
        {
            baseRepository.Delete(id);
            baseRepository.SaveChanges();
        }

    }
}
