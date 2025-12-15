using Model.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using LabubuModel;

namespace DataAccessLayer
{
    /// <summary>
    /// Интерфейс репозитория для работы с данными лабуб.
    /// </summary>
    public interface ILabubuRepository : IRepository<Labubu>
    {

    }
}
