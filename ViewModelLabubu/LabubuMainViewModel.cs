using BusinessLogic;
using Model;
using SharedLabubu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ViewModelLabubu
{
    public class LabubuMainViewModel : ViewModelBase
    {
        private readonly ILogic _logic;

        public BindingList<LabubuDtoNotify> Items { get; } = new BindingList<LabubuDtoNotify>();

        private LabubuDtoNotify _selectedItem;
        public LabubuDtoNotify SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand GroupByRarityCommand { get; }
        public ICommand GroupBySizeCommand { get; }
        public ICommand ShowCheapestCommand { get; }
        public ICommand ShowMostExpensiveCommand { get; }
        public ICommand ResetCommand { get; }

        // Делегаты для UI (WPF)
        public Func<EditLabubuViewModel, bool?> ShowEditDialog { get; set; }
        public Action<string, string> ShowInfoMessage { get; set; }
        public Action<string, string> ShowErrorMessage { get; set; }
        public Func<string, string, bool> AskConfirmation { get; set; }

        public LabubuMainViewModel(ILogic logic)
        {
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));

            AddCommand = new RelayCommand(_ => Add());
            UpdateCommand = new RelayCommand(_ => Update(), _ => SelectedItem != null);
            DeleteCommand = new RelayCommand(_ => Delete(), _ => SelectedItem != null);
            GroupByRarityCommand = new RelayCommand(_ => Group(GroupByCriteria.Rarity));
            GroupBySizeCommand = new RelayCommand(_ => Group(GroupByCriteria.Size));
            ShowCheapestCommand = new RelayCommand(_ => ShowMostLeast(false));
            ShowMostExpensiveCommand = new RelayCommand(_ => ShowMostLeast(true));
            ResetCommand = new RelayCommand(_ => LoadAll());

            LoadAll();
        }

        private void LoadAll()
        {
            Items.Clear();
            foreach (var dto in _logic.ReadAll())
                Items.Add(LabubuDtoNotify.FromDto(dto));
        }

        private void Add()
        {
            var vm = new EditLabubuViewModel(new LabubuDtoNotify(), isNew: true);
            if (ShowEditDialog?.Invoke(vm) == true)
            {
                try
                {
                    _logic.Create(vm.Item.ToDto());
                    LoadAll();
                    ShowInfoMessage?.Invoke("Добавлено!", "Успех");
                }
                catch (Exception ex)
                {
                    ShowErrorMessage?.Invoke(ex.Message, "Ошибка");
                }
            }
        }

        private void Update()
        {
            if (SelectedItem == null) return;
            var copy = new LabubuDtoNotify
            {
                ID = SelectedItem.ID,
                Name = SelectedItem.Name,
                Color = SelectedItem.Color,
                Rarity = SelectedItem.Rarity,
                Size = SelectedItem.Size,
                Price = SelectedItem.Price
            };
            var vm = new EditLabubuViewModel(copy, isNew: false);
            if (ShowEditDialog?.Invoke(vm) == true)
            {
                try
                {
                    var index = Items.IndexOf(SelectedItem);
                    if (index >= 0) _logic.Update(index, vm.Item.ToDto());
                    LoadAll();
                    ShowInfoMessage?.Invoke("Обновлено!", "Успех");
                }
                catch (Exception ex)
                {
                    ShowErrorMessage?.Invoke(ex.Message, "Ошибка");
                }
            }
        }

        private void Delete()
        {
            if (SelectedItem == null) return;
            var index = Items.IndexOf(SelectedItem);
            if (index < 0) return;
            if (AskConfirmation?.Invoke("Удалить Labubu?", "Подтверждение") != true) return;
            try
            {
                _logic.Delete(index);
                LoadAll();
                ShowInfoMessage?.Invoke("Удалено!", "Успех");
            }
            catch (Exception ex)
            {
                ShowErrorMessage?.Invoke(ex.Message, "Ошибка");
            }
        }

        private void Group(GroupByCriteria criteria)
        {
            try
            {
                Items.Clear();
                var dict = _logic.Group(criteria);
                foreach (var pair in dict)
                    foreach (var dto in pair.Value)
                        Items.Add(LabubuDtoNotify.FromDto(dto));
                ShowInfoMessage?.Invoke($"Группировка по {criteria}", "Успех");
            }
            catch (Exception ex)
            {
                ShowErrorMessage?.Invoke(ex.Message, "Ошибка");
            }
        }

        private void ShowMostLeast(bool findMost)
        {
            try
            {
                var dto = _logic.FindMostLeastExpensive(findMost);
                if (dto == null)
                {
                    ShowInfoMessage?.Invoke("Список пуст", "Инфо");
                    return;
                }
                var kind = findMost ? "дорогая" : "дешевая";
                ShowInfoMessage?.Invoke($"{kind}: {dto.Name} - {dto.Price:F2}", "Инфо");
            }
            catch (Exception ex)
            {
                ShowErrorMessage?.Invoke(ex.Message, "Ошибка");
            }
        }
    }
}
