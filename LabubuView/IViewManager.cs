using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ViewModelLabubu;

namespace LabubuView
{
    public interface IViewManager
    {
        void ShowMainWindow();
        bool? ShowEditLabubuDialog(EditLabubuViewModel vm);  
        void ShowInfo(string message, string title);
        void ShowError(string message, string title);
        bool AskConfirmation(string message, string title);
    }
}
