using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        public IEnumerable<T> GetAll();
        public T Get(int Id);
        public void Add(T entity);
        public void Update(T entity);
        public void Delete(int Id);
        public bool Exists(int Id);
    }
}
