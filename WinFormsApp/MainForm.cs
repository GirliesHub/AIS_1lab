using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LabubuModel;
using Shared;

namespace WinFormsApp
{
    public partial class MainForm : Form, ILabubuView
    {
        public AddLabubuForm addLabubuForm;
        public UpdateLabubuForm updateLabubuForm;
        public event EventHandler<ViewLabubuAddEventArgs> EventViewLabubuAdd = delegate { };
        public event EventHandler<ViewLabubuSelectEventArgs> EventViewLabubuDelete = delegate { };
        public event EventHandler<ViewLabubuLoadListEventArgs> EventViewLabubuLoadList = delegate { };
        public event EventHandler<ViewLabubuUpdateEventArgs> EventViewLabubuUpdate = delegate { };
        public event EventHandler<ViewLabubuGroupEventArgs> EventViewLabubuGroup = delegate { };
        public event EventHandler<ViewLabubuPriceEventArgs> EventViewLabubuPrice = delegate { };

        public MainForm()
        {
            InitializeComponent();
            InitializeListView();

            addLabubuForm = new AddLabubuForm();
            //updateLabubuForm = new UpdateLabubuForm();
            addLabubuForm.LabubuAddedOnAddForm += OnLabubuAddedInAddForm;
            updateLabubuForm.ViewLabubuUpdate += OnLabubuUpdated;

            EventViewLabubuLoadList(this, new ViewLabubuLoadListEventArgs());

        }

        /// <summary>
        /// создание listview
        /// </summary>
        private void InitializeListView()
        {
            listViewLabubus.View = View.Details;
            listViewLabubus.FullRowSelect = true;
            listViewLabubus.GridLines = true;
            listViewLabubus.Columns.Clear();
            listViewLabubus.Columns.Add("Номер", 90);
            listViewLabubus.Columns.Add("Имя", 90);
            listViewLabubus.Columns.Add("Цвет", 90);
            listViewLabubus.Columns.Add("Редкость", 90);
            listViewLabubus.Columns.Add("Размер", 90);
            listViewLabubus.Columns.Add("Цена", 90);

        }
        public void Run()
        {
            EventViewLabubuLoadList(this, new ViewLabubuLoadListEventArgs());
            Application.Run(this);
        }


        public void LoadLabubus(List<Labubu> labubus)
        {
            listViewLabubus.Items.Clear();

            foreach (var l in labubus)
            {
                var item = new ListViewItem(l.ID.ToString());
                item.SubItems.Add(l.Name);
                item.SubItems.Add(l.Color);
                item.SubItems.Add(l.Rarity.ToString());
                item.SubItems.Add(l.Size.ToString());
                item.SubItems.Add(l.Price.ToString("F2"));

                listViewLabubus.Items.Add(item);
            }
        }

        public void AddLabubu(Labubu labubu)
        {
            MessageBox.Show("Лабуба успешно добавлена");
            EventViewLabubuLoadList(this, new ViewLabubuLoadListEventArgs());
        }

        public void UpdateLabubu(Labubu labubu)
        {
            MessageBox.Show("Лабуба обновлена");
            EventViewLabubuLoadList(this, new ViewLabubuLoadListEventArgs());
        }

        public void DeleteLabubu(int id)
        {
            MessageBox.Show("Лабуба удалена");
            EventViewLabubuLoadList(this, new ViewLabubuLoadListEventArgs());
        }
        public void OnLabubuAddedInAddForm(object sender, ViewLabubuAddEventArgs e)
        {
            EventViewLabubuAdd(this, e);
        }

        public void ShowGroupedData(Dictionary<string, List<Labubu>> data, string criteria)
        {
            MessageBox.Show($"Группировка по: {criteria}");

            listViewLabubus.Items.Clear();

            foreach (var group in data)
            {
                foreach (var l in group.Value)
                {
                    var item = new ListViewItem(l.ID.ToString());
                    item.SubItems.Add(l.Name);
                    item.SubItems.Add(l.Color);
                    item.SubItems.Add(l.Rarity.ToString());
                    item.SubItems.Add(l.Size.ToString());
                    item.SubItems.Add(l.Price.ToString("F2"));

                    listViewLabubus.Items.Add(item);
                }
            }
        }


        public void ShowLabubuPrice(Labubu labubu, bool isMostExpensive)
        {
            string text = isMostExpensive
                ? $"Самая дорогая лабуба: {labubu.Name} — {labubu.Price}"
                : $"Самая дешёвая лабуба: {labubu.Name} — {labubu.Price}";

            MessageBox.Show(text);
        }

        public void ShowMessage(string message, string title = "Информация")
        {
            MessageBox.Show(message, title);
        }



        private void btnAddLabubu_Click(object sender, EventArgs e)
        {
            addLabubuForm.ShowDialog();
        }

        private void btnDeleteLabubu_Click(object sender, EventArgs e)
        {
            if (listViewLabubus.SelectedItems.Count == 0)
                return;

            int id = int.Parse(listViewLabubus.SelectedItems[0].Text);
            EventViewLabubuDelete(this, new ViewLabubuSelectEventArgs(id));
        }

        private void btnUpdateLabubu_Click(object sender, EventArgs e)
        {
            if (listViewLabubus.SelectedItems.Count == 0)
                return;

            var item = listViewLabubus.SelectedItems[0];

            var labubu = new Labubu
            {
                ID = int.Parse(item.SubItems[0].Text),
                Name = item.SubItems[1].Text,
                Color = item.SubItems[2].Text,
                Rarity = Enum.Parse<RarityEnum>(item.SubItems[3].Text),
                Size = Enum.Parse<SizeEnum>(item.SubItems[4].Text),
                Price = decimal.Parse(item.SubItems[5].Text)
            };

            var form = new UpdateLabubuForm(labubu);

            if (form.ShowDialog() == DialogResult.OK)
            {
                EventViewLabubuUpdate(this, new ViewLabubuUpdateEventArgs(form.Labubu));
            }
        }


        public void OnLabubuUpdated(object sender, ViewLabubuUpdateEventArgs e)
        {
            EventViewLabubuUpdate(this, e);
        }
    }
}
