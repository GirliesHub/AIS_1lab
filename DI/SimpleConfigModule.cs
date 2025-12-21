using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Ninject.Modules;
using Shared;
using Model;
using Presenter;
using ConsoleApp;
using Model.DataAccessLayer;
using LabubuModel;

namespace DI
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            Bind<IRepository<Labubu>>()
                .To<EFRepository>()
                .InSingletonScope();

            Bind<IModel>()
                .To<Model.Model>()
                .InSingletonScope();

            Bind<ILabubuView>()
                .To<Program>()
                .InSingletonScope();

            Bind<IPresenter>()
                .To<MainPresenter>()
                .InSingletonScope();
        }
    }
}
