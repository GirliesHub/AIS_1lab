using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModelLabubu
{
    /// <summary>
    /// ViewModel для окна добавления/редактирования одного Labubu.
    /// </summary>
    public class EditLabubuViewModel : ViewModelBase
    {
        public LabubuDtoNotify Item { get; }

        public bool IsNew { get; }

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        /// <summary>
        /// Делегат закрытия окна. Реализуется во View (WPF).
        /// </summary>
        public Action<bool?> Close { get; set; }

        public EditLabubuViewModel(LabubuDtoNotify item, bool isNew)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item));
            IsNew = isNew;

            OkCommand = new RelayCommand(_ => Close?.Invoke(true), _ => CanOk());
            CancelCommand = new RelayCommand(_ => Close?.Invoke(false));
        }

        private bool CanOk()
        {
            return !string.IsNullOrWhiteSpace(Item.Name)
                   && !string.IsNullOrWhiteSpace(Item.Color)
                   && Item.Price > 0;
        }
    }
}
