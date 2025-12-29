using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Labubu> LabubuRepository { get; }
        IRepository<Collector> CollectorRepository { get; }
        ILabubuCollectorRepository LabubuCollectorRepository { get; }
        int Commit();
        void Rollback();
    }
}
