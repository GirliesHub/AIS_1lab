using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModelLabubu
{
    /// <summary>
    /// Базовый класс для всех ViewModel, реализующий INotifyPropertyChanged.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
