using Model;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    public class EfLabubuCollectorRepository : ILabubuCollectorRepository
    {
        private readonly DBContext _context;

        public EfLabubuCollectorRepository(DBContext context)
        {
            _context = context;
        }

        public void AssignLabubuToCollector(int labubuId, int collectorId)
        {
            var link = new LabubuCollector
            {
                LabubuId = labubuId,
                CollectorId = collectorId
            };
            _context.LabubuCollectors.Add(link);
        }

        public void RemoveLabubuFromCollector(int labubuId, int collectorId)
        {
            var link = _context.LabubuCollectors
                .FirstOrDefault(lc => lc.LabubuId == labubuId && lc.CollectorId == collectorId);
            if (link != null)
                _context.LabubuCollectors.Remove(link);
        }

        public List<Labubu> GetLabubusByCollector(int collectorId)
        {
            return _context.LabubuCollectors
                .Where(lc => lc.CollectorId == collectorId)
                .Select(lc => lc.Labubu)
                .ToList();
        }

        public List<Collector> GetCollectorsByLabubu(int labubuId)
        {
            return _context.LabubuCollectors
                .Where(lc => lc.LabubuId == labubuId)
                .Select(lc => lc.Collector)
                .ToList();
        }
    }
}