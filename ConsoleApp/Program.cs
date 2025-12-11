using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Model;
using BusinessLogic;
using DataAccessLayer;
using BusinessLogic.BusinessLogic;


namespace ConsoleApp 
{
    public class Program
    {
        static Logic _logic;
        static void Main(string[] args)
        {
            NinjectService.Initialize();
            _logic = NinjectService.Get<Logic>();

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
                try
                {
                    Console.WriteLine("\nДобавление новой лабубы");

                    var labubu = new Labubu
                    {
                        Name = GetValidatedInput("Введите имя: ", false),
                        Color = GetValidatedInput("Введите цвет: ", false),
                        Rarity = GetValidRarity(),
                        Size = GetValidSize(),
                        Price = GetValidPrice()
                    };

                    _logic.AddLabubu(labubu);
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

                    _logic.RemoveLabubu(id);
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

                    var existingLabubu = _logic.GetLabubuById(id);
                    if (existingLabubu == null)
                    {
                        Console.WriteLine($"Лабуба с ID {id} не найдена!");
                        return;
                    }

                    Console.WriteLine($"\nРедактирование лабубы ID: {id}");
                    Console.WriteLine($"Текущее имя: {existingLabubu.Name}");
                    Console.WriteLine($"Текущий цвет: {existingLabubu.Color}");
                    Console.WriteLine($"Текущая редкость: {existingLabubu.Rarity}");
                    Console.WriteLine($"Текущий размер: {existingLabubu.Size}");
                    Console.WriteLine($"Текущая цена: {existingLabubu.Price}");

                    string newName = GetValidatedInput($"Введите новое имя (или нажмите Enter для '{existingLabubu.Name}'): ", true);
                    string newColor = GetValidatedInput($"Введите новый цвет (или нажмите Enter для '{existingLabubu.Color}'): ", true);
                    RarityEnum newRarity = GetValidRarityOptional(existingLabubu.Rarity);
                    SizeEnum newSize = GetValidSizeOptional(existingLabubu.Size);
                    decimal newPrice = GetValidPriceOptional(existingLabubu.Price);

                    var updatedLabubu = new Labubu
                    {
                        ID = id,
                        Name = string.IsNullOrWhiteSpace(newName) ? existingLabubu.Name : newName,
                        Color = string.IsNullOrWhiteSpace(newColor) ? existingLabubu.Color : newColor,
                        Rarity = newRarity,
                        Size = newSize,
                        Price = newPrice
                    };

                    _logic.UpdateLabubu(updatedLabubu); 
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
                        grouped = _logic.GroupLabubu(GroupByCriteria.Rarity);
                        Console.WriteLine("Группировка по редкости");
                    }
                    else if (choice == "2")
                    {
                        grouped = _logic.GroupLabubu(GroupByCriteria.Size);
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
                            Console.WriteLine($"  ID: {labubu.ID}, Имя: {labubu.Name}, Цвет: {labubu.Color}, Размер: {labubu.Size}, Цена: {labubu.Price}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            ///<summary>
            ///Метод, возвращающий список всех лабуб
            ///</summary>>
            static void GetAllLabubus()
            {
                try
                {
                    Console.WriteLine("Список всех лабуб");
                    var allLabubus = _logic.GetAllLabubus();

                    if (allLabubus.Count == 0)
                    {
                        Console.WriteLine("Лабуб нет в списке");
                        return;
                    }

                    foreach (var labubu in allLabubus)
                    {
                        Console.WriteLine($"ID: {labubu.ID}");
                        Console.WriteLine($"Имя: {labubu.Name}");
                        Console.WriteLine($"Цвет: {labubu.Color}");
                        Console.WriteLine($"Редкость: {labubu.Rarity}");
                        Console.WriteLine($"Размер: {labubu.Size}");
                        Console.WriteLine($"Цена: {labubu.Price:C}");
                        Console.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            ///<summary>
            ///Метод, ищущий самую дорогую/дешевую лабубу
            ///</summary>
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
                            var cheapestLabubu = _logic.FindMostLeastExpensiveLabubu(false);
                            Console.WriteLine($"Самая дешевая лабуба: {cheapestLabubu.Name} - {cheapestLabubu.Price} руб.");
                            break;
                        case "2":
                            var mostExpensiveLabubu = _logic.FindMostLeastExpensiveLabubu(true);
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
       /// <summary>
       /// Вспомогательные методы для правильного ввода значений
       /// </summary>
       /// <param name="prompt"></param>
       /// <param name="allowEmpty"></param>
       /// <returns></returns>
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
        private static RarityEnum GetValidRarity()
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
                    return (RarityEnum)rarityNum;
                }
                Console.WriteLine("Неверный ввод! Пожалуйста, введите число от 1 до 5.");
            }
        }
        private static SizeEnum GetValidSize()
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
                    return (SizeEnum)(sizeNum - 1); 
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

        private static RarityEnum GetValidRarityOptional(RarityEnum currentRarity)
        {
            while (true)
            {
                Console.WriteLine($"\nТекущая редкость: {(int)currentRarity}*");
                Console.WriteLine("Выберите новую редкость (или нажмите Enter для текущей):");
                Console.WriteLine("1. 1*");
                Console.WriteLine("2. 2*");
                Console.WriteLine("3. 3*");
                Console.WriteLine("4. 4*");
                Console.WriteLine("5. 5*");
                Console.Write("Выбор (1-5 или Enter): ");

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return currentRarity;
                }

                if (int.TryParse(input, out int rarityNum) && rarityNum >= 1 && rarityNum <= 5)
                {
                    return (RarityEnum)rarityNum;
                }

                Console.WriteLine("Неверный ввод! Пожалуйста, введите число от 1 до 5 или нажмите Enter.");
            }
        }

        private static SizeEnum GetValidSizeOptional(SizeEnum currentSize)
        {
            while (true)
            {
                Console.WriteLine($"\nТекущий размер: {currentSize}");
                Console.WriteLine("Выберите новый размер (или нажмите Enter для текущего):");
                Console.WriteLine("1. Small");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Big");
                Console.WriteLine("4. HUGE");
                Console.Write("Выбор (1-4 или Enter): ");

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return currentSize; 
                }

                if (int.TryParse(input, out int sizeNum) && sizeNum >= 1 && sizeNum <= 4)
                {
                    return (SizeEnum)(sizeNum - 1);
                }

                Console.WriteLine("Неверный ввод! Пожалуйста, введите число от 1 до 4 или нажмите Enter.");
            }
        }

        private static decimal GetValidPriceOptional(decimal currentPrice)
        {
            while (true)
            {
                Console.Write($"\nТекущая цена: {currentPrice:F2}\nВведите новую цену (или нажмите Enter для текущей): ");

                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return currentPrice; 
                }

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
