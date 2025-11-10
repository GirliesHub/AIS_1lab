using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleApp // Добавить проверку на отр.цену, enum на редкость и размер, пофиксить id (не давать пользователю в консоли прописать номер), потестить на пустые поля
{
    public class Program
    {
        static Logic logic = new Logic();
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в Мир Лабуб! Что вы хотите сделать?");
                Console.WriteLine("1. Добавить лабубу \n 2. Удалить лабубу \n 3. Изменить лабубу \n 4. Сгруппировать лабуб по признаку \n 5. Показать список всех лабуб \n 6. Найти самую дорогую/дешевую лабубу \n 0. Выход");
                Console.WriteLine("Выберите номер: ");
                string number = Console.ReadLine();
                switch (number)
                {
                    case "1":
                        Console.Clear();
                        AddLabubu();
                        break;
                    case "2":
                        Console.Clear();
                        break;
                    case "3":
                        Console.Clear();
                        UpdateLabubu();
                        break;
                    case "4":
                        Console.Clear();
                        GroupLabubu();
                        break;
                    case "5":
                        Console.Clear();
                        GetAllLabubus();
                        break;
                    case "6":
                        Console.Clear();
                        FindMostLeastExpensiveLabubu();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Спасибо, что затестили Мир Лабуб! До скорого!");
                        exit = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор, попробуйте еще раз");
                        Console.ReadKey();
                        break;

                }
                Console.ReadKey();
            }
            /// <summary>
            /// Функция для добавления лабубы через консоль
            /// </summary>>
            static void AddLabubu()
            {
                try
                {
                    Console.WriteLine("Добавление новой лабубы");

                    string name = GetValidatedInput("Введите имя: ", false);
                    string color = GetValidatedInput("Введите цвет: ", false);

                    Labubu.RarityEnum rarity = GetValidRarity();
                    Labubu.SizeEnum size = GetValidSize();
                    decimal price = GetValidPrice();

                    logic.AddLabubu(name, color, rarity, size, price);
                    Console.WriteLine("Лабуба успешно добавлена!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            /// <summary>
            /// Функция для удаления лабубы через консоль
            /// </summary>>
            static void RemoveLabubu()
            {
                try
                {
                    Console.WriteLine("Удаление лабубы");
                    GetAllLabubus();
                    Console.Write("Введите ID лабубы для удаления: ");
                    int id = int.Parse(Console.ReadLine());

                    logic.RemoveLabubu(id);
                    Console.WriteLine("Лабуба успешно удалена!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            /// <summary>
            /// Функция для обновления лабубы через консоль
            /// </summary>>
            static void UpdateLabubu()
            {
                try
                {
                    Console.WriteLine("Изменение лабубы");
                    GetAllLabubus();
                    Console.Write("Введите ID лабубы для изменения: ");
                    int id = int.Parse(Console.ReadLine());

                    string newName = GetValidatedInput("Введите новое имя: ", true);
                    string newColor = GetValidatedInput("Введите новый цвет: ", true);
                    Labubu.RarityEnum newRarity = GetValidRarity();
                    Labubu.SizeEnum newSize = GetValidSize();
                    decimal newPrice = GetValidPrice();

                    logic.UpdateLabubu(id, newName, newColor, newRarity, newSize, newPrice);
                    Console.WriteLine("Лабуба успешно изменена!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            /// <summary>
            /// Функция для группировки лабуб через консоль
            /// </summary>>
            static void GroupLabubu()
            {
                try
                {
                    Console.WriteLine("Группировка лабуб");
                    Console.WriteLine("1. По редкости");
                    Console.WriteLine("2. По размеру");
                    Console.Write("Выберите критерий: ");

                    string choice = Console.ReadLine();
                    Dictionary<string, List<Labubu>> grouped;

                    if (choice == "1")
                    {
                        grouped = logic.GroupLabubu(Labubu.GroupByCriteria.Rarity);
                        Console.WriteLine("Группировка по редкости");
                    }
                    else if (choice == "2")
                    {
                        grouped = logic.GroupLabubu(Labubu.GroupByCriteria.Size);
                        Console.WriteLine("Группировка по размеру");
                    }
                    else
                    {
                        Console.WriteLine("Неверный выбор, попробуйте еще раз");
                        return;
                    }

                    foreach (var group in grouped)
                    {
                        Console.WriteLine($"\n{group.Key}:");
                        foreach (var labubu in group.Value)
                        {
                            Console.WriteLine($"  ID: {labubu.Id}, Имя: {labubu.Name}, Цвет: {labubu.Color}, Размер: {labubu.Size}, Цена: {labubu.Price}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            static void GetAllLabubus()
            {
                try
                {
                    Console.WriteLine("Список всех лабуб");
                    var allLabubus = logic.GetAllLabubus();

                    if (allLabubus.Count == 0)
                    {
                        Console.WriteLine("Лабуб нет в списке");
                    }
                    else
                    {
                        foreach (var labubu in allLabubus)
                        {
                            Console.WriteLine($"ID: {labubu[0]}, Имя: {labubu[1]}, Цвет: {labubu[2]}, Редкость: {labubu[3]}, Размер: {labubu[4]}, Цена: {labubu[5]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            static void FindMostLeastExpensiveLabubu()
            {
                try
                {
                    Console.WriteLine("Поиск лабубы по цене. Какую лабубу найти?");
                    Console.WriteLine("1. Самую дешевую");
                    Console.WriteLine("2. Самую дорогую");
                    Console.Write("Выберите вариант: ");

                    string option = Console.ReadLine();

                    switch (option)
                    {
                        case "1":
                            var cheapestLabubu = logic.FindMostLeastExpensiveLabubu(false);
                            Console.WriteLine($"Самая дешевая лабуба: {cheapestLabubu.Name} - {cheapestLabubu.Price} руб.");
                            break;
                        case "2":
                            var mostExpensiveLabubu = logic.FindMostLeastExpensiveLabubu(true);
                            Console.WriteLine($"Самая дорогая лабуба: {mostExpensiveLabubu.Name} - {mostExpensiveLabubu.Price} руб.");
                            break;
                        default:
                            Console.WriteLine("Неверный выбор");
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                    Console.WriteLine("Сначала добавьте лабуб через меню (опция 1)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
        // Вспомогательные методы для валидации ввода
        private static string GetValidatedInput(string prompt, bool allowEmpty)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (!allowEmpty && string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Поле не может быть пустым! Попробуйте снова.");
                }
                else
                {
                    break;
                }
            } while (true);

            return input?.Trim() ?? "";
        }
        private static Labubu.RarityEnum GetValidRarity()
        {
            while (true)
            {
                Console.WriteLine("Выберите редкость:");
                Console.WriteLine("1*");
                Console.WriteLine("2*");
                Console.WriteLine("3*");
                Console.WriteLine("4*");
                Console.WriteLine("5*");
                Console.Write("Введите номер (1-5): ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int rarityNum) && rarityNum >= 1 && rarityNum <= 5)
                {
                    return (Labubu.RarityEnum)rarityNum;
                }
                Console.WriteLine("Неверный ввод! Пожалуйста, введите число от 1 до 5.");
            }
        }
        private static Labubu.SizeEnum GetValidSize()
        {
            while (true)
            {
                Console.WriteLine("Выберите размер:");
                Console.WriteLine("1 - small");
                Console.WriteLine("2 - medium");
                Console.WriteLine("3 - big");
                Console.WriteLine("4 - HUGE");
                Console.Write("Введите номер (1-4): ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int sizeNum) && sizeNum >= 1 && sizeNum <= 4)
                {
                    return (Labubu.SizeEnum)(sizeNum - 1); // -1 потому что enum начинается с 0
                }
                Console.WriteLine("Неверный ввод! Пожалуйста, введите число от 1 до 4.");
            }
        }
        private static decimal GetValidPrice()
        {
            while (true)
            {
                Console.Write("Введите цену: ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal price))
                {
                    if (price > 0)
                    {
                        return price;
                    }
                    Console.WriteLine("Цена должна быть положительной! Попробуйте снова.");
                }
                else
                {
                    Console.WriteLine("Неверный формат цены! Попробуйте снова.");
                }
            }
        }
    }

}
