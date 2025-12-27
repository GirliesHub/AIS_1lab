using System;
using System.Collections.Generic;
using System.Linq;
using SharedLabubu;
using Model;

namespace ConsoleApp
{
    /// <summary>
    /// Консольная реализация.
    /// </summary>
    public class ConsoleView : ILabubuView, IConsoleView
    {
        public event Action AddRequested;
        public event Action<int> DeleteRequested;
        public event Action<int> UpdateRequested;
        public event Action GroupRequested;
        public event Action FindMostLeastExpensiveRequested;
        public event Action ShowAllRequested;

        /// <summary>
        /// Обновляет текстовое представление списка лабуб в консоли.
        /// </summary>
        /// <param name="items">Список строк, описывающих лабуб.</param>
        public void UpdateList(List<string> items)
        {
            Console.WriteLine("\nСписок Лабуб ");
            if (items.Count == 0)
            {
                Console.WriteLine("Ничего не найдено.");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                    Console.WriteLine($"{i + 1}. {items[i]}");
            }
            Console.WriteLine("--------------------------------");
        }

        /// <summary>
        /// Показывает сообщение об ошибке.
        /// </summary>
        /// <param name="msg">Текст ошибки.</param>
        /// <param name="title">Заголовок сообщения.</param>
        public void ShowError(string msg, string title)
        {
            Console.WriteLine($"\nошибка [{title}]: {msg}");
        }

        /// <summary>
        /// Показывает информационное сообщение.
        /// </summary>
        /// <param name="msg">Текст сообщения.</param>
        /// <param name="title">Заголовок сообщения.</param>
        public void ShowMessage(string msg, string title)
        {
            Console.WriteLine($"\n[{title}]: {msg}");
        }

        public string AskInput(string prompt, string title, string defaultValue)
        {
            Console.WriteLine($"[{title}] {prompt}");
            Console.Write(defaultValue != "" ? $"[{defaultValue}]: " : ": ");
            var input = Console.ReadLine();
            return string.IsNullOrEmpty(input) ? defaultValue : input;
        }

        /// <summary>
        /// Отображает главное меню консольного приложения и предлагает выбрать действие.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("Добро пожаловать в МИР ЛАБУБ!");
            Console.WriteLine("1. Добавить лабубу");
            Console.WriteLine("2. Показать всех лабуб");
            Console.WriteLine("3. Удалить лабубу");
            Console.WriteLine("4. Изменить лабубу");
            Console.WriteLine("5. Группировать лабуб");
            Console.WriteLine("6. Найти по цене (дор./деш.)");
            Console.WriteLine("0. Выход");
            Console.Write("\nВыбор: ");
        }

        public string ReadRaw(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
