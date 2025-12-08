using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class NinjectModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Labubu>>().To<EntityRepository<Labubu>>().InSingletonScope();
            Bind<Logic>().ToSelf();
        }
    }
}
