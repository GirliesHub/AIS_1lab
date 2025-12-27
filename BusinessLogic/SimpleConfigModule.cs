using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Ninject.Modules;

namespace BusinessLogic
{
    /// <summary>
    /// Конфигурационный модуль Ninject для настройки зависимостей слоя данных и бизнес‑логики.
    /// </summary>
    public class SimpleConfigModule : NinjectModule
    {
        /// <summary>
        /// Регистрирует привязки интерфейсов к конкретным реализациям.
        /// </summary>
        public override void Load()
        {
            Bind<IRepository<Labubu>>()
                .To<DapperRepository<Labubu>>()
                .InSingletonScope();

            Bind<ILogic>()
                .To<Logic>()
                .InSingletonScope();
        }
    }
}
