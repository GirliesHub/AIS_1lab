using System;
using System.Windows.Forms;
using DI;
using Ninject;
using Presenter;
using Shared;

namespace Start
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            try
            {
                IKernel kernel = new StandardKernel(new SimpleConfigModule());

                string view = GetViewString.ViewString();

                if (view == "Console")
                {
                    var presenter = kernel.Get<IPresenter>();
                    var consoleView = kernel.Get<ILabubuView>();
                    consoleView.Run();
                }
                else if (view == "Form")
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    var presenter = kernel.Get<IPresenter>();
                    var formView = kernel.Get<ILabubuView>();

                    Application.Run((Form)formView);
                }
                else
                {
                    Console.WriteLine("Неизвестный тип View");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
