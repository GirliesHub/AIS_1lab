using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ConsoleApp
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
                        RemoveLabubu();
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
                Console.WriteLine("Добавление новой лабубы");
                Console.Write("Введите номер:");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Введите имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите цвет: ");
                string color = Console.ReadLine();
                Console.Write("Введите редкость: ");
                string rarity = Console.ReadLine();
                Console.Write("Введите размер: ");
                string size = Console.ReadLine();
                Console.Write("Введите цену: ");
                decimal price = decimal.Parse(Console.ReadLine());
                try { logic.AddLabubu(id, name, color, rarity, size, price); }
                catch
                {
                    Console.WriteLine("Ошибка!");
                    return;
                }
                Console.WriteLine("Лабуба успешно добавлена!");
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
                    Console.Write("Введите новое имя: ");
                    string newName = Console.ReadLine();
                    Console.Write("Введите новый цвет: ");
                    string newColor = Console.ReadLine();
                    Console.Write("Введите новую редкость: ");
                    string newRarity = Console.ReadLine();
                    Console.Write("Введите новый размер: ");
                    string newSize = Console.ReadLine();
                    Console.Write("Введите новую цену: ");
                    decimal newPrice = decimal.Parse(Console.ReadLine());

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
                            Console.WriteLine($"  ID: {labubu.Id}, Имя: {labubu.Name}, Цвет: {labubu.Color}, Размер: {labubu.Size}");
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
                        for (int i = 0; i < allLabubus.Count; i++)
                        {
                            var labubu = allLabubus[i];
                            Console.WriteLine($"[{i}] ID: {labubu[0]}, Имя: {labubu[1]}, Цвет: {labubu[2]}, Редкость: {labubu[3]}, Размер: {labubu[4]}, Цена: {labubu[5]}");
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

    } 
}
