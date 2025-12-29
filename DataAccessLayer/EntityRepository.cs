using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

/// <summary>
/// Entity репозиторий
/// /<summary>
namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        protected readonly DBContext _context;

        public EntityRepository(DBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public EntityRepository()
        {
            _context = new DBContext();
        }

        public EntityRepository(string connectionString)
        {
            _context = new DBContext(connectionString);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            var existing = _context.Set<T>().Find(entity.ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
            }
        }

        public void Remove(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

}
