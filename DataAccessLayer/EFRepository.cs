using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DataAccessLayer;
using LabubuModel;

namespace Model.DataAccessLayer
{
    public class EFRepository : ILabubuRepository
    {
        private readonly DBContext _context;
        private readonly DbSet<Labubu> _set;

        public EFRepository()
        {
            _context = new DBContext(); // Использует строку из appsettings.json
            _set = _context.Set<Labubu>();
        }

        // Конструктор с явной строкой подключения
        public EFRepository(string connectionString)
        {
            _context = new DBContext(connectionString);
            _set = _context.Set<Labubu>();
        }

        public IEnumerable<Labubu> GetAll()
        {
            return _set.ToList();
        }

        public Labubu Get(int id)
        {
            return _set.Find(id);
        }

        public void Create(Labubu entity)
        {
            _set.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Labubu entity)
        {
            var existing = _set.Find(entity.ID);
            if (existing != null)
            {
                _context.Entry(existing).CurrentValues.SetValues(entity);
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
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