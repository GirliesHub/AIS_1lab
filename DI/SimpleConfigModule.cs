using System;
using System.IO;
using Ninject.Modules;
using Microsoft.Extensions.Configuration;
using Shared;
using LabubuModel;
using Presenter;
using WinFormsApp;
using ConsoleApp;
using System.Windows.Forms;
using Model.DataAccessLayer;
using Model;

namespace DI
{
    public class SimpleConfigModule : NinjectModule
    {
        public override void Load()
        {
            var projectRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;

            var jsonFilePath = Path.Combine(projectRootPath, "DataAccessLayer");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(jsonFilePath)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            string framework = configuration["DataAccessFramework"];
            string view = configuration["View"];
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            Bind<DBContext>().ToSelf().InTransientScope();

            Bind<IModel>()
                .To<Model.Model>()  
                .InTransientScope();

            switch (view)
            {
                case "Console":
                    Bind<ILabubuView>().To<Program>().InSingletonScope();
                    break;

                case "Form":
                    Bind<ILabubuView>().To<MainForm>().InSingletonScope();
                    break;
            }

            Bind<IPresenter>().To<MainPresenter>().InSingletonScope();

            switch (framework)
            {
                case "Dapper":
                    Bind<IRepository<Labubu>>()
                        .To<DapperRepository>()
                        .InSingletonScope()
                        .WithConstructorArgument("connectionString", connectionString);
                    break;

                case "EntityFramework":
                    Bind<IRepository<Labubu>>()
                        .To<EFRepository>()
                        .InSingletonScope();
                    break;

                default:
                    throw new ArgumentException("Неподдерживаемый фреймворк доступа к данным");
            }
        }
    }
}
