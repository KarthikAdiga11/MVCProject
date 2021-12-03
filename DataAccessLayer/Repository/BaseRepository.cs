using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDBContext _context;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T Get(int Id)
        {
            return _context.Set<T>().FirstOrDefault(e => e.Id == Id);
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Remove(Get(id));
            _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _context.Set<T>().Any(e => e.Id == id);
        }
    }
}
