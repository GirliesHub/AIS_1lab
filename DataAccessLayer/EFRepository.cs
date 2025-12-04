using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DataAccessLayer 
{
    /// <summary>
    /// Слой доступа к данным
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<T> : IRepository<T>
        where T : class, IDomainObject
    {
        private readonly DBContext _context;
        private readonly DbSet<T> _set;

        public EFRepository()
        {
            _context = new DBContext();
            _set = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _set.ToList();
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }

        public void Create(T entity)
        {
            _set.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            var existing = _set.Find((entity as IDomainObject)?.ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            var item = _set.Find(id);
            if (item != null)
            {
                _set.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
