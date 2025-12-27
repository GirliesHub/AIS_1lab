using BusinessLogic;
using Ninject;
using ConsoleApp;
using WinFormsApp;

namespace PresenterLabubu
{
    /// <summary>
    /// Точка входа приложения. Настраивает DI-контейнер и переключает запуск между консолью и WinForms.
    /// </summary>
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var kernel = new StandardKernel(new SimpleConfigModule());

            var logic = kernel.Get<ILogic>();

            bool useWinForms = false; // false консоль, true WinForms

            if (useWinForms)
            {
                RunWinForms(logic);
            }
            else
            {
                RunConsole(logic);
            }
        }

        /// <summary>
        /// Запускает WinForms приложение.
        /// </summary>
        private static void RunWinForms(ILogic logic)
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var view = new MainForm();           
            var presenter = new LabubuPresenter(logic, view);

            System.Windows.Forms.Application.Run(view);
        }

        /// <summary>
        /// Запускает консольное приложение.
        /// </summary>
        static void RunConsole(ILogic logic)
        {
            var view = new ConsoleView();
            var presenter = new LabubuPresenter(logic, view);

            while (true)
            {
                Console.Clear();
                view.ShowMenu();
                string choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        presenter.HandleAdd();
                        break;
                    case "2":
                        presenter.HandleShowAll();
                        break;
                    case "3":
                        presenter.HandleDelete();
                        break;
                    case "4":
                        presenter.HandleUpdate();
                        break;
                    case "5":
                        presenter.HandleGroup();
                        break;
                    case "6":
                        presenter.HandleFindMostLeastExpensive();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неизвестная команда.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
