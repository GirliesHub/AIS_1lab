using System.Windows;
using ViewModelLabubu;

namespace LabubuView
{
    public class ViewManager : IViewManager
    {
        public void ShowMainWindow() => new MainWindow().Show();

        public bool? ShowEditLabubuDialog(EditLabubuViewModel vm)
        {
            var win = new EditWindow { DataContext = vm };
            vm.Close = result =>
            {
                win.DialogResult = result;
                win.Close();
            };
            return win.ShowDialog();
        }

        public void ShowInfo(string message, string title) =>
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);

        public void ShowError(string message, string title) =>
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);

        public bool AskConfirmation(string message, string title) =>
            MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
    }
}

