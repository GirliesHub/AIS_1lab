using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ILabubuCollectorRepository
    {
        void AssignLabubuToCollector(int labubuId, int collectorId);
        void RemoveLabubuFromCollector(int labubuId, int collectorId);
        List<Labubu> GetLabubusByCollector(int collectorId);
        List<Collector> GetCollectorsByLabubu(int labubuId);
    }
}
