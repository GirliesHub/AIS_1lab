using System;
using System.Collections.Generic;
using System.Linq;
using LabubuModel;
using Shared;

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
                Console.WriteLine("1. Добавить лабубу");
                Console.WriteLine("2. Удалить лабубу");
                Console.WriteLine("3. Изменить лабубу");
                Console.WriteLine("4. Сгруппировать лабуб по признаку");
                Console.WriteLine("5. Показать список всех лабуб");
                Console.WriteLine("6. Найти самую дорогую/дешевую лабубу");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите номер: ");

                command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        Console.Clear();
                        CheckAddLabubu();
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        CheckDeleteLabubu();
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        CheckUpdateLabubu();
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        CheckGroupLabubu();
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        EventViewLabubuLoadList(this, new ViewLabubuLoadListEventArgs());
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Clear();
                        CheckPriceLabubu();
                        Console.WriteLine("Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
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
            } while (command != "0");
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
            _labubus.Add(labubu); // Исправлено: добавление в список
            Console.WriteLine("Лабуба успешно добавлена!");
        }

        private void CheckDeleteLabubu()
        {
            EventViewLabubuLoadList(this, new ViewLabubuLoadListEventArgs());
            Console.Write("Введите ID для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                EventViewLabubuDelete(this, new ViewLabubuSelectEventArgs(id));
            else
                Console.WriteLine("Некорректный ID!");
        }

        public void DeleteLabubu(int id)
        {
            var labubu = _labubus.FirstOrDefault(l => l.ID == id);
            if (labubu != null)
            {
                _labubus.Remove(labubu);
                Console.WriteLine("Лабуба удалена!");
            }
            else
            {
                Console.WriteLine("Лабуба с таким ID не найдена!");
            }
        }

        private void CheckUpdateLabubu()
        {
            EventViewLabubuLoadList(this, new ViewLabubuLoadListEventArgs());
            Console.Write("ID для изменения: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный ID!");
                return;
            }

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

        public void UpdateLabubu(Labubu updatedLabubu)
        {
            var existing = _labubus.FirstOrDefault(l => l.ID == updatedLabubu.ID);
            if (existing != null)
            {
                existing.Name = updatedLabubu.Name;
                existing.Color = updatedLabubu.Color;
                existing.Rarity = updatedLabubu.Rarity;
                existing.Size = updatedLabubu.Size;
                existing.Price = updatedLabubu.Price;
                Console.WriteLine("Лабуба обновлена!");
            }
            else
            {
                Console.WriteLine("Лабуба не найдена!");
            }
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
            Console.WriteLine("Группировать по:");
            Console.WriteLine("1. Редкость");
            Console.WriteLine("2. Размер");
            Console.Write("Выберите (1 или 2): ");
            string c = Console.ReadLine();

            GroupByCriteria criteria = c == "1" ? GroupByCriteria.Rarity : GroupByCriteria.Size;
            EventViewLabubuGroup(this, new ViewLabubuGroupEventArgs(criteria));
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
            Console.WriteLine("Найти:");
            Console.WriteLine("1. Самую дешёвую");
            Console.WriteLine("2. Самую дорогую");
            Console.Write("Выберите (1 или 2): ");
            string c = Console.ReadLine();
            EventViewLabubuPrice(this, new ViewLabubuPriceEventArgs(c == "2"));
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

            Console.WriteLine($"{text}: {labubu.Name}, цена: {labubu.Price:F2}");
        }

        // Вспомогательные методы остаются без изменений
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
                Console.WriteLine("1 - Small");
                Console.WriteLine("2 - Medium");
                Console.WriteLine("3 - Big");
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
            Console.WriteLine($"{title}: {message}");
        }
    }
}