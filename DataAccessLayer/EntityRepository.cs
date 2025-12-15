using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LabubuModel;

/// <summary>
/// Entity репозиторий
/// /<summary>
namespace Model.DataAccessLayer
{
    public class EntityRepository : ILabubuRepository
    {
        private readonly DBContext _context;

        public EntityRepository()
        {
            _context = new DBContext();
        }

        public EntityRepository(string connectionString)
        {
            _context = new DBContext(connectionString);
        }

        public IEnumerable<Labubu> GetAll()
        {
            return _context.Set<Labubu>().ToList();
        }

        public Labubu Get(int id)
        {
            return _context.Set<Labubu>().Find(id);
        }

        public void Create(Labubu entity)
        {
            _context.Set<Labubu>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(Labubu entity)
        {
            var existing = _context.Set<Labubu>().Find((entity as IDomainObject)?.ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = _context.Set<Labubu>().Find(id);
            if (entity != null)
            {
                _context.Set<Labubu>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

}
