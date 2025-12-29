using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        private IRepository<Labubu>? _labubuRepo;
        private IRepository<Collector>? _collectorRepo;
        private EfLabubuCollectorRepository? _labubuCollectorRepo;

        public EfUnitOfWork()
        {
            _context = new DBContext(); 
        }
        public IRepository<Labubu> LabubuRepository =>
            _labubuRepo ??= new EntityRepository<Labubu>(_context);

        public IRepository<Collector> CollectorRepository =>
            _collectorRepo ??= new EntityRepository<Collector>(_context);

        public ILabubuCollectorRepository LabubuCollectorRepository =>
            _labubuCollectorRepo ??= new EfLabubuCollectorRepository(_context);

        public int Commit() => _context.SaveChanges();
        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(e => e.State = EntityState.Unchanged);
        }
        public void Dispose() => _context?.Dispose();
    }
}
