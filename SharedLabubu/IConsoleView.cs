using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLabubu
{
    /// <summary>
    /// Интерфейс консольной вьюхи.Тут минимальный набор методов для ввода и отображения меню.
    /// </summary>
    public interface IConsoleView
    {
        /// <summary>
        /// Читает строку из консоли.
        /// </summary>
        string ReadRaw(string prompt);

        /// <summary>
        /// Отображает главное меню консольного приложения.
        /// </summary>
        void ShowMenu();
    }
}
