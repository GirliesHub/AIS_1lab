using System;
using DI;
using Ninject;
using Shared;

namespace Start
{
    internal static class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Запуск приложения 'Мир Лабуб'...");

                // Создаем DI контейнер
                var kernel = new StandardKernel(new SimpleConfigModule());

                // Получаем представление (тип зависит от конфигурации)
                var view = kernel.Get<ILabubuView>();

                // Запускаем приложение
                view.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Критическая ошибка: {ex.Message}");
                Console.WriteLine("Детали ошибки:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("\nНажмите Enter для выхода...");
                Console.ReadLine();
            }
        }
    }
}