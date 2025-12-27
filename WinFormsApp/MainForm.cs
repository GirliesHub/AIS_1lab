using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BusinessLogic;
using Microsoft.VisualBasic.Logging;
using SharedLabubu;

namespace WinFormsApp
{
    /// <summary>
    /// Главная форма WinForms приложения
    /// </summary>
    public partial class MainForm : Form, ILabubuView
    {
        public event Action AddRequested;
        public event Action<int> DeleteRequested;
        public event Action<int> UpdateRequested;
        public event Action GroupRequested;
        public event Action FindMostLeastExpensiveRequested;
        public event Action ShowAllRequested;
        public MainForm()
        {

            InitializeComponent();
            InitializeListView();
            SetFormBackground();

            Load += (s, e) => ShowAllRequested?.Invoke();

            btnAddLabubu.Click += (s, e) => AddRequested?.Invoke();
            btnUpdateLabubu.Click += (s, e) =>
            {
                if (listViewLabubus.SelectedIndices.Count > 0)
                    UpdateRequested?.Invoke(listViewLabubus.SelectedIndices[0]);
                else
                    ShowError("Ничего не выбрано", "Изменение");
            };


            btnRemoveLabubu.Click += (s, e) =>
            {
                if (listViewLabubus.SelectedIndices.Count > 0)
                    DeleteRequested?.Invoke(listViewLabubus.SelectedIndices[0]);
                else
                    ShowError("Ничего не выбрано", "Удаление");
            };

            btnGroupByRarity.Click += (s, e) => GroupRequested?.Invoke();
            btnCheapest.Click += (s, e) => FindMostLeastExpensiveRequested?.Invoke();

            btnReset.Click += (s, e) => ShowAllRequested?.Invoke();

        }
        
        private void BtnAddLabubu_Click(object sender, EventArgs e)
        {
            AddRequested?.Invoke();
        }

        private void BtnUpdateLabubu_Click(object sender, EventArgs e)
        {
            if (listViewLabubus.SelectedItems.Count == 0)
            {
                ShowError("Ничего не выбрано", "Изменение");
                return;
            }

            int index = listViewLabubus.SelectedIndices[0];
            UpdateRequested?.Invoke(index);
        }


        private List<string> _allItems = new List<string>();

        public void UpdateList(List<string> items)
        {
            _allItems = new List<string>(items);
            ApplyFilter(txtSearch.Text);
        }


        public void ShowError(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowMessage(string msg, string title)
        {
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public string AskInput(string prompt, string title, string defaultValue)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(prompt, title, defaultValue);
        }

        private void InitializeListView()
        {
            listViewLabubus.View = View.Details;
            listViewLabubus.FullRowSelect = true;
            listViewLabubus.GridLines = true;
            listViewLabubus.Columns.Clear();

            listViewLabubus.Columns.Add("Лабубы", 500);
        }

        private void SetFormBackground()
        {
            try
            {
                this.BackgroundImage = Image.FromFile(
                    @"C:\Users\lonit\source\repos\GirliesHub\AIS_1lab\labubu_background.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {
                this.BackColor = SystemColors.Control;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter(txtSearch.Text);
        }
        private void ApplyFilter(string filter)
        {
            filter = (filter ?? string.Empty).Trim().ToLower();

            listViewLabubus.Items.Clear();

            IEnumerable<string> source = _allItems;

            if (!string.IsNullOrEmpty(filter))
                source = _allItems.FindAll(s => s != null &&
                                                s.ToLower().Contains(filter));

            foreach (var s in source)
            {
                listViewLabubus.Items.Add(new ListViewItem(s));
            }
        }
    }
}
