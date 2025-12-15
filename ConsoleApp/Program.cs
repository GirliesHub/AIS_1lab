using System;
using System.Collections.Generic;
using LabubuModel;
using Shared;
using Ninject;

namespace ConsoleApp
{
    public class Program : ILabubuView
    {

        // Events 
        public event EventHandler<ViewLabubuAddEventArgs> EventViewLabubuAdd = delegate { };
        public event EventHandler<ViewLabubuSelectEventArgs> EventViewLabubuDelete = delegate { };
        public event EventHandler<ViewLabubuUpdateEventArgs> EventViewLabubuUpdate = delegate { };
        public event EventHandler<ViewLabubuLoadListEventArgs> EventViewLabubuLoadList = delegate { };
        public event EventHandler<ViewLabubuGroupEventArgs> EventViewLabubuGroup = delegate { };
        public event EventHandler<ViewLabubuPriceEventArgs> EventViewLabubuPrice = delegate { };
        private List<Labubu> _labubus;

        public Program()
        {
            _labubus = new List<Labubu>();
        }

        public void Run()
        {
            string command;
            do
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в Мир Лабуб! Что вы хотите сделать?");
                Console.WriteLine("1. Добавить лабубу \n 2. Удалить лабубу \n 3. Изменить лабубу \n 4. Сгруппировать лабуб по признаку \n 5. Показать список всех лабуб \n 6. Найти самую дорогую/дешевую лабубу \n 0. Выход");
                Console.WriteLine("Выберите номер: ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Console.Clear();
                        CheckAddLabubu();
                        break;
                    case "2":
                        Console.Clear();
                        CheckDeleteLabubu();
                        break;
                    case "3":
                        Console.Clear();
                        CheckUpdateLabubu();
                        break;
                    case "4":
                        Console.Clear();
                        CheckGroupLabubu();
                        break;
                    case "5":
                        Console.Clear();
                        EventViewLabubuLoadList(this, new());
                        break;
                    case "6":
                        Console.Clear();
                        CheckPriceLabubu();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Спасибо, что затестили Мир Лабуб! До скорого!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Неверный выбор, попробуйте еще раз");
                        Console.ReadKey();
                        break;
                }

            } while (command != "exit");
        }

        private void CheckAddLabubu()
        {
            Console.Write("Имя: ");
            string name = Console.ReadLine();

            Console.Write("Цвет: ");
            string color = Console.ReadLine();

            var rarity = GetValidRarity();
            var size = GetValidSize();
            var price = GetValidPrice();

            EventViewLabubuAdd(this,
                new ViewLabubuAddEventArgs(name, color, rarity, size, price));
        }

        public void AddLabubu(Labubu labubu)
        {
            Console.WriteLine("Лабуба успешно добавлена!");
            return;
        }


        private void CheckDeleteLabubu()
        {
            EventViewLabubuLoadList(this, new());
            Console.Write("Введите ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                EventViewLabubuDelete(this, new(id));
        }

        public void DeleteLabubu(int id)
        {
            Console.WriteLine("Лабуба удалена!");
        }


        private void CheckUpdateLabubu()
        {
            EventViewLabubuLoadList(this, new());

            Console.Write("ID для изменения: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
                return;

            var current = _labubus.FirstOrDefault(l => l.ID == id);
            if (current == null)
            {
                Console.WriteLine("Не найдено");
                return;
            }

            Console.Write($"Имя ({current.Name}): ");
            string name = Console.ReadLine();
            name = string.IsNullOrWhiteSpace(name) ? current.Name : name;

            Console.Write($"Цвет ({current.Color}): ");
            string color = Console.ReadLine();
            color = string.IsNullOrWhiteSpace(color) ? current.Color : color;

            var rarity = GetValidRarityOptional(current.Rarity);
            var size = GetValidSizeOptional(current.Size);
            var price = GetValidPriceOptional(current.Price);

            EventViewLabubuUpdate(this,
                new ViewLabubuUpdateEventArgs(
                    new Labubu { ID = id, Name = name, Color = color, Rarity = rarity, Size = size, Price = price }
                ));
        }

        public void UpdateLabubu(Labubu labubu)
        {
            Console.WriteLine("Лабуба обновлена!");
        }

        public void LoadLabubus(List<Labubu> labubus)
        {
            _labubus = labubus;

            if (_labubus.Count == 0)
            {
                Console.WriteLine("Лабуб нет");
                return;
            }

            foreach (var l in _labubus)
            {
                Console.WriteLine(
                    $"ID: {l.ID}, " +
                    $"Имя: {l.Name}, " +
                    $"Цвет: {l.Color}, " +
                    $"Редкость: {l.Rarity}, " +
                    $"Размер: {l.Size}, " +
                    $"Цена: {l.Price:F2}");
            }
        }


        private void CheckGroupLabubu()
        {
            Console.WriteLine("1.Rarity  2.Size");
            string c = Console.ReadLine();
            EventViewLabubuGroup(this,
                new ViewLabubuGroupEventArgs(c == "1" ? GroupByCriteria.Rarity : GroupByCriteria.Size));
        }

        public void ShowGroupedData(Dictionary<string, List<Labubu>> data, string criteria)
        {
            Console.WriteLine($"\nГруппировка по: {criteria}");

            foreach (var group in data)
            {
                Console.WriteLine($"\n{group.Key}:");
                foreach (var labubu in group.Value)
                {
                    Console.WriteLine(
                        $"  ID: {labubu.ID}, " +
                        $"Имя: {labubu.Name}, " +
                        $"Цена: {labubu.Price:F2}");
                }
            }
        }

        private void CheckPriceLabubu()
        {
            Console.WriteLine("1.Дешёвая  2.Дорогая");
            string c = Console.ReadLine();
            EventViewLabubuPrice(this, new(c == "2"));
        }

        public void ShowLabubuPrice(Labubu labubu, bool isMostExpensive)
        {
            if (labubu == null)
            {
                Console.WriteLine("Лабубы не найдены");
                return;
            }

            string text = isMostExpensive
                ? "Самая дорогая лабуба"
                : "Самая дешёвая лабуба";

            Console.WriteLine(
                $"{text}: {labubu.Name}, цена: {labubu.Price:F2}");
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

        public void ShowMessage(string message, string title = "Информация")
        {
            throw new NotImplementedException();
        }
    }

}
