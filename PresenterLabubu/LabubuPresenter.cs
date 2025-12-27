using BusinessLogic;
using Model;
using SharedLabubu;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WinFormsApp;

namespace PresenterLabubu
{
    /// <summary>
    /// Презентер для работы с лабубами.
    /// Связывает слой бизнес-логики (<see cref="ILogic"/>) с вьюхами (консоль и WinForms), обрабатывает пользовательские действия и управляет отображением данных.
    /// </summary>
    public class LabubuPresenter
    {
        private readonly ILogic logic;
        private readonly ILabubuView view;
        private List<LabubuDTO> allItems;

        /// <summary>
        /// Создаёт экземпляр презентера и подписывается на события представления.
        /// </summary>
        public LabubuPresenter(ILogic logic, ILabubuView view)
        {
            this.logic = logic;
            this.view = view;

            allItems = logic.ReadAll().ToList();

            view.AddRequested += OnAdd;
            view.DeleteRequested += OnDelete;
            view.UpdateRequested += OnUpdate;
            view.GroupRequested += OnGroup;
            view.FindMostLeastExpensiveRequested += OnFindMostLeastExpensiveRequested;
            view.ShowAllRequested += OnShowAll;

        }

        /// <summary>
        /// Форматирует DTO лабубы в строку для отображения в списке.
        /// </summary>
        private static string FormatLabubu(LabubuDTO l)
        {
            return $"{l.Name} - {l.Color} - {l.Rarity} - {l.Size} - {l.Price:F2}";
        }


        /// <summary>
        /// Удаляет лабубу по индексу и обновляет список.
        /// </summary>
        private void OnDelete(int index)
        {
            logic.Delete(index);
            OnShowAll();
        }


        /// <summary>
        /// Выполняет группировку лабуб по выбранному критерию (редкость или размер) и передаёт результат во view.
        /// </summary>
        private void OnGroup()
        {
            var choice = view.AskInput(
                "По какому признаку сгруппировать?\n1 - По редкости\n2 - По размеру",
                "Группировка",
                "Выбор");

            GroupByCriteria criteria;
            switch (choice)
            {
                case "1":
                    criteria = GroupByCriteria.Rarity;
                    break;
                case "2":
                    criteria = GroupByCriteria.Size;
                    break;
                default:
                    view.ShowMessage("Группировка отменена.", "Информация");
                    return;
            }

            try
            {
                var groups = logic.Group(criteria);

                var items = groups
                    .Select(g => $"{g.Key}: {g.Value.Count} лабуб")
                    .ToList();

                view.UpdateList(items);
            }
            catch
            {
                view.ShowError("Ошибка при группировке!", "Ошибка");
            }
        }

        /// <summary>
        /// Ищет самую дешёвую или самую дорогую лабубу и выводит результат.
        /// </summary>
        /// <param name="findMostExpensive">
        /// true — искать самую дорогую, false — самую дешёвую.
        /// </param>
        private void OnFindMostLeastExpensive(bool findMostExpensive)
        {
            var labubu = logic.FindMostLeastExpensive(findMostExpensive);
            if (labubu == null)
            {
                view.ShowMessage("Список лабуб пуст.", "Результат");
                return;
            }

            var kind = findMostExpensive ? "самая дорогая" : "самая дешевая";
            view.ShowMessage(
                $"Найдена {kind} лабуба: {labubu.Name} - {labubu.Price:F2}",
                "Результат");
        }

        /// <summary>
        /// Обрабатывает запрос на поиск по цене, уточняя, какую именно лабубу нужно найти (дорогую или дешёвую).
        /// </summary>
        private void OnFindMostLeastExpensiveRequested()
        {
            var choice = view.AskInput(
                "Что показать?\n1 - Самую дешевую\n2 - Самую дорогую",
                "Поиск по цене",
                "1");

            if (choice == "1")
                OnFindMostLeastExpensive(false);
            else if (choice == "2")
                OnFindMostLeastExpensive(true);
            else
                view.ShowMessage("Операция отменена или неверный ввод.", "Информация");
        }

        /// <summary>
        /// Считывает все лабубы из логики, форматирует их и передаёт во view
        /// </summary>
        private void OnShowAll()
        {
            var items = logic.ReadAll()
                             .Select(FormatLabubu)
                             .ToList();

            view.UpdateList(items);
        }

        /// <summary>
        /// Пошагово запрашивает данные новой/изменяемой лабубы в консольном режиме и формирует DTO.
        /// </summary>
        private bool TryReadLabubuFromConsole(out LabubuDTO dto)
        {
            dto = null;

            if (view is not IConsoleView console)
            {
                view.ShowError("Консольный ввод недоступен для этого вида.", "Ошибка");
                return false;
            }

            string name;
            while (true)
            {
                name = console.ReadRaw("Введите имя: ");
                if (string.IsNullOrWhiteSpace(name))
                {
                    view.ShowError("Имя не может быть пустым!", "Некорректный ввод");
                    continue;
                }
                if (!name.All(ch => char.IsLetter(ch) || ch == ' '))
                {
                    view.ShowError("Имя должно содержать только буквы и пробелы!", "Некорректный ввод");
                    continue;
                }
                break;
            }

            string color;
            while (true)
            {
                color = console.ReadRaw("Введите цвет: ");
                if (string.IsNullOrWhiteSpace(color))
                {
                    view.ShowError("Цвет не может быть пустым!", "Некорректный ввод");
                    continue;
                }
                if (!color.All(ch => char.IsLetter(ch) || ch == ' '))
                {
                    view.ShowError("Цвет должен содержать только буквы и пробелы!", "Некорректный ввод");
                    continue;
                }
                break;
            }

            RarityEnum rarity;
            while (true)
            {
                Console.WriteLine("Выберите редкость:");
                Console.WriteLine("1 - OneStar");
                Console.WriteLine("2 - TwoStars");
                Console.WriteLine("3 - ThreeStars");
                Console.WriteLine("4 - FourStars");
                Console.WriteLine("5 - FiveStars");
                var rarityInput = console.ReadRaw("Введите номер редкости (1-5): ");

                if (!int.TryParse(rarityInput, out int r) || r < 1 || r > 5)
                {
                    view.ShowError("Редкость должна быть числом от 1 до 5!", "Некорректный ввод");
                    continue;
                }

                rarity = (RarityEnum)r;
                break;
            }

            SizeEnum size;
            while (true)
            {
                Console.WriteLine("Выберите размер:");
                Console.WriteLine("1 - Small");
                Console.WriteLine("2 - Medium");
                Console.WriteLine("3 - Big");
                Console.WriteLine("4 - HUGE");
                var sizeInput = console.ReadRaw("Введите номер размера (1-4): ");

                if (!int.TryParse(sizeInput, out int s) || s < 1 || s > 4)
                {
                    view.ShowError("Размер должен быть числом от 1 до 4!", "Некорректный ввод");
                    continue;
                }

                size = (SizeEnum)(s - 1);
                break;
            }

            decimal price;
            while (true)
            {
                var priceText = console.ReadRaw("Введите цену: ");
                if (!decimal.TryParse(priceText, out price) || price <= 0)
                {
                    view.ShowError(
                        "Цена должна быть положительным числом (например: 10 или 10,50)!",
                        "Некорректный ввод");
                    continue;
                }
                break;
            }

            dto = new LabubuDTO
            {
                Name = name,
                Color = color,
                Rarity = rarity,
                Size = size,
                Price = price
            };

            return true;
        }



        /// <summary>
        /// Обработчик события добавления в WinForms: открывает форму добавления, получает DTO и создаёт новую запись.
        /// </summary>
        private void OnAdd()
        {
            var form = new WinFormsApp.AddLabubuForm();

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                form.Result != null)
            {
                logic.Create(form.Result);
                OnShowAll();
            }
        }


        /// <summary>
        /// Обработчик события изменения в WinForms: открывает форму редактирования по индексу и обновляет запись.
        /// </summary>
        private void OnUpdate(int index)
        {
            var all = logic.ReadAll();
            if (index < 0 || index >= all.Count)
                return;

            var original = all[index];
            var form = new WinFormsApp.UpdateLabubuForm(original);

            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
                form.Result != null)
            {
                logic.Update(index, form.Result);
                OnShowAll();
            }
        }

        /// <summary>
        /// Консольное добавление новой лабубы.
        /// </summary>
        public void HandleAdd()
        {
            Console.Clear();

            if (!TryReadLabubuFromConsole(out var dto))
            {
                PauseAndClear();
                return;
            }

            logic.Create(dto);
            view.ShowMessage("Лабуба успешно добавлена!", "Успех");
            PauseAndClear();
        }

        /// <summary>
        /// Консольное удаление лабубы.
        /// </summary>
        public void HandleDelete()
        {
            Console.Clear();
            OnShowAll();

            if (view is IConsoleView consoleView)
            {
                string input = consoleView.ReadRaw("\nВведите номер для удаления: ");
                if (int.TryParse(input, out int id) && id > 0)
                {
                    OnDelete(id - 1);
                    view.ShowMessage("Лабуба успешно удалена!", "Успех");
                }
                else
                {
                    view.ShowMessage("Операция отменена.", "Информация");
                }
            }

            PauseAndClear();
        }

        /// <summary>
        /// Консольное обновление лабубы.
        /// </summary>
        public void HandleUpdate()
        {
            Console.Clear();
            OnShowAll();

            if (view is IConsoleView consoleView)
            {
                string input = consoleView.ReadRaw("\nВведите номер для изменения: ");
                if (int.TryParse(input, out int id) && id > 0)
                {
                    OnUpdate(id - 1);
                    view.ShowMessage("Данные успешно обновлены!", "Успех");
                }
                else
                {
                    view.ShowMessage("Операция отменена.", "Информация");
                }
            }

            PauseAndClear();
        }

        /// <summary>
        /// Консольная группировка лабуб.
        /// </summary>
        public void HandleGroup()
        {
            Console.Clear();
            OnGroup();
            PauseAndClear();
        }

        /// <summary>
        /// Консольный поиск самой дешёвой/дорогой лабубы.
        /// </summary>
        public void HandleFindMostLeastExpensive()
        {
            Console.Clear();
            Console.WriteLine("Поиск лабубы по цене. Какую лабубу найти?");
            Console.WriteLine("1. Самую дешевую");
            Console.WriteLine("2. Самую дорогую");
            Console.Write("Выберите вариант: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    OnFindMostLeastExpensive(false);
                    break;
                case "2":
                    OnFindMostLeastExpensive(true);
                    break;
                default:
                    view.ShowMessage("Операция отменена или некорректный выбор.", "Информация");
                    break;
            }

            PauseAndClear();
        }

        /// <summary>
        /// Консольный вывод всех лабуб.
        /// </summary>
        public void HandleShowAll()
        {
            Console.Clear();
            OnShowAll();
            Console.WriteLine("\nНажмите Enter для возврата...");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Ожидает нажатия клавиши и очищает консоль.
        /// Используется в конце консольных сценариев.
        /// </summary>
        private void PauseAndClear()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
        }




    }
}
