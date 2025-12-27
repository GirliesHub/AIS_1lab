using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLabubu
{
    /// <summary>
    /// Общий интерфейс представления для работы с лабубами (консоль и WinForms).
    /// </summary>
    public interface ILabubuView
    {
        event Action AddRequested;
        event Action<int> DeleteRequested;
        event Action<int> UpdateRequested;
        event Action GroupRequested;
        event Action FindMostLeastExpensiveRequested;
        event Action ShowAllRequested;

        /// <summary>
        /// Обновляет список лабуб.
        /// </summary>
        void UpdateList(List<string> items);

        /// <summary>
        /// Показывает сообщение об ошибке.
        /// </summary>
        void ShowError(string msg, string title);

        /// <summary>
        /// Показывает информационное сообщение.
        /// </summary>
        void ShowMessage(string msg, string title);

        /// <summary>
        /// Запрашивает строковый ввод с подсказкой.
        /// </summary>
        string AskInput(string prompt, string title, string defaultValue);
    }
}

