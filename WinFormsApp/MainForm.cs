using Microsoft.VisualBasic.Logging;
using Model;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private Logic logic = new Logic();
        public MainForm()
        {
            InitializeComponent();
            InitializeListView();
            RefreshLabubuList();
            SetFormBackground();

            this.btnAddLabubu.Click += btnAddLabubu_Click;
            this.btnReset.Click += BtnSearch_Click;
            this.txtSearch.TextChanged += TxtSearch_TextChanged;
            this.btnGroupByRarity.Click += BtnGroupByRarity_Click;
            this.btnGroupBySize.Click += BtnGroupBySize_Click;
            this.btnMostExpensive.Click += btnMostExpensive_Click;
            this.btnCheapest.Click += BtnCheapest_Click;

            this.listViewLabubus.SelectedIndexChanged += listViewLabubus_SelectedIndexChanged;
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

        /// <summary>
        /// обновление лабуб
        /// </summary>
        private void RefreshLabubuList()
        {
            listViewLabubus.Items.Clear();

            foreach (var labubu in logic.GetAllLabubus())
            {
                var item = new ListViewItem(labubu[0]);
                item.SubItems.Add(labubu[1]);
                item.SubItems.Add(labubu[2]);
                item.SubItems.Add(labubu[3]);
                item.SubItems.Add(labubu[4]);
                item.SubItems.Add(labubu[5]);
                listViewLabubus.Items.Add(item);
            }
        }

        /// <summary>
        /// добавление лабуб
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddLabubu_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new AddLabubuForm(logic);
                addForm.ShowDialog();
                RefreshLabubuList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка открытия формы: {ex.Message}");
            }
        }

        /// <summary>
        /// удаление лабуб
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveLabubu_Click(object sender, EventArgs e)
        {
            try { var SelectedIt = listViewLabubus.SelectedItems[0]; }
            catch
            {
                MessageBox.Show("Ничего не выбрано");
                return;
            }
            int selectedId = int.Parse(listViewLabubus.SelectedItems[0].Text);

            try
            {
                logic.RemoveLabubu(selectedId);
                RefreshLabubuList();
                MessageBox.Show("Лабуба удалена!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// изменение лабуб
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateLabubu_Click(object sender, EventArgs e)
        {
            try
            {
                var selecteditem = listViewLabubus.SelectedItems[0].Text;
            }
            catch
            {
                MessageBox.Show("Ничего не выбрано");
                return;
            }
            var updateForm = new UpdateLabubuForm(logic, listViewLabubus.SelectedItems[0].Index);
            updateForm.ShowDialog();
            RefreshLabubuList();
        }

        private void btnLists_Click(object sender, EventArgs e)
        {
            RefreshLabubuList();
        }

        private void listViewLabubus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// метод для отображения отфильтрованных данных
        /// </summary>
        private void SearchLabubu()
        {
            string searchText = txtSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                RefreshLabubuList();
                return;
            }

            var allLabubus = logic.GetAllLabubus();
            var filteredList = allLabubus.Where(l =>
                l[0].ToLower().Contains(searchText) ||
                l[1].ToLower().Contains(searchText) ||
                l[2].ToLower().Contains(searchText) ||
                l[3].ToLower().Contains(searchText) ||
                l[4].ToLower().Contains(searchText) ||
                l[5].ToLower().Contains(searchText)
            ).ToList();

            listViewLabubus.Items.Clear();
            foreach (var labubuData in filteredList)
            {
                var item = new ListViewItem(labubuData[0]);
                item.SubItems.Add(labubuData[1]);
                item.SubItems.Add(labubuData[2]);
                item.SubItems.Add(labubuData[3]);
                item.SubItems.Add(labubuData[4]);
                item.SubItems.Add(labubuData[5]);
                listViewLabubus.Items.Add(item);
            }
        }


        /// <summary>
        /// группировка по редкости
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGroupByRarity_Click(object sender, EventArgs e)
        {
            try
            {
                var groupedData = logic.GroupLabubu(Labubu.GroupByCriteria.Rarity);
                DisplayGroupedData(groupedData, "редкости");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// группировка по размеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGroupBySize_Click(object sender, EventArgs e)
        {
            try
            {
                var groupedData = logic.GroupLabubu(Labubu.GroupByCriteria.Size);
                DisplayGroupedData(groupedData, "размеру");
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// добавляем заголовок и элементы группы
        /// </summary>
        /// <param name="groupedData"></param>
        /// <param name="criteria"></param>
        private void DisplayGroupedData(Dictionary<string, List<Labubu>> groupedData, string criteria)
        {
            listViewLabubus.Items.Clear();

            foreach (var group in groupedData)
            {
                var groupHeader = new ListViewItem($"--- {group.Key} ---");
                groupHeader.BackColor = Color.LightPink;
                groupHeader.Font = new Font(listViewLabubus.Font, FontStyle.Bold);
                listViewLabubus.Items.Add(groupHeader);

                foreach (var labubu in group.Value)
                {
                    var item = new ListViewItem(labubu.Id.ToString());
                    item.SubItems.Add(labubu.Name);
                    item.SubItems.Add(labubu.Color);
                    item.SubItems.Add(RarityEnumToString(labubu.Rarity));
                    item.SubItems.Add(SizeEnumToString(labubu.Size));
                    item.SubItems.Add(labubu.Price.ToString("C"));
                    listViewLabubus.Items.Add(item);
                }
            }

            // Показываем информацию о группировке
            string info = $"Группировка по {criteria}:\n";
            foreach (var group in groupedData)
            {
                info += $"{group.Key}: {group.Value.Count} лабуб\n";
            }
            MessageBox.Show(info, "Информация о группировке", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Преобразует RarityEnum в строку для отображения
        /// </summary>
        private string RarityEnumToString(Labubu.RarityEnum rarity)
        {
            return rarity switch
            {
                Labubu.RarityEnum.OneStar => "1*",
                Labubu.RarityEnum.TwoStars => "2*",
                Labubu.RarityEnum.ThreeStars => "3*",
                Labubu.RarityEnum.FourStars => "4*",
                Labubu.RarityEnum.FiveStars => "5*",
                _ => rarity.ToString()
            };
        }

        /// <summary>
        /// Преобразует SizeEnum в строку для отображения
        /// </summary>
        private string SizeEnumToString(Labubu.SizeEnum size)
        {
            return size switch
            {
                Labubu.SizeEnum.Small => "Small",
                Labubu.SizeEnum.Medium => "Medium",
                Labubu.SizeEnum.Big => "Big",
                Labubu.SizeEnum.HUGE => "HUGE",
                _ => size.ToString()
            };
        }

        /// <summary>
        /// поиск самой дорогой лабубы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostExpensive_Click(object sender, EventArgs e)
        {
            try
            {
                var mostExpensive = logic.FindMostLeastExpensiveLabubu(true);
                HighlightLabubu(mostExpensive.Id);

                MessageBox.Show($"Самая дорогая лабубу:\nID: {mostExpensive.Id}\nИмя: {mostExpensive.Name}\nЦена: {mostExpensive.Price:C}",
                              "Самая дорогая лабубу", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// поиск самой дешевой лабубы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCheapest_Click(object sender, EventArgs e)
        {
            try
            {
                var cheapest = logic.FindMostLeastExpensiveLabubu(false);
                HighlightLabubu(cheapest.Id);

                MessageBox.Show($"Самая дешевая лабубу:\nID: {cheapest.Id}\nИмя: {cheapest.Name}\nЦена: {cheapest.Price:C}",
                              "Самая дешевая лабубу", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// выдает лабубу по id
        /// </summary>
        /// <param name="id"></param>
        private void HighlightLabubu(int id)
        {
            foreach (ListViewItem item in listViewLabubus.Items)
            {
                if (item.Text == id.ToString())
                {
                    item.Selected = true;
                    item.Focused = true;
                    item.EnsureVisible();
                    listViewLabubus.Focus();
                    break;
                }
            }
        }

        // обработчики событий поиска
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchLabubu();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchLabubu();
        }

        /// <summary>
        /// задаем фон для осн. формы
        /// </summary>
        private void SetFormBackground()
        {
            try
            {
                this.BackgroundImage = Image.FromFile(@"C:\Users\lonit\source\repos\GirliesHub\AIS_1lab\labubu_background.jpg");
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {
                this.BackColor = SystemColors.Control;
            }
        }
    }
}
