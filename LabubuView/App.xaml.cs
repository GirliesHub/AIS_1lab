using System.Windows;
using Ninject;
using BusinessLogic;
using ViewModelLabubu;
using LabubuView;

namespace LabubuView
{
    public partial class App : Application
    {
        private IKernel _kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _kernel = new StandardKernel(new BusinessLogic.SimpleConfigModule());
            var logic = _kernel.Get<BusinessLogic.ILogic>();

            // ✅ ИСПОЛЬЗУЙ LabubuMainViewModel ВЕЗДЕ
            var mainVm = new LabubuMainViewModel(logic);

            var viewManager = new ViewManager();
            mainVm.ShowEditDialog = vm => viewManager.ShowEditLabubuDialog(vm);
            mainVm.ShowInfoMessage = (msg, title) => viewManager.ShowInfo(msg, title);
            mainVm.ShowErrorMessage = (msg, title) => viewManager.ShowError(msg, title);
            mainVm.AskConfirmation = (msg, title) => viewManager.AskConfirmation(msg, title);

            var mainWindow = new MainWindow { DataContext = mainVm };
            MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
