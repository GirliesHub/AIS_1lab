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

            this.btnAddLabubu.Click += btnAddLabubu_Click;
        }

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
        }

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
                listViewLabubus.Items.Add(item);
            }
        }
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

        private void btnRemoveLabubu_Click(object sender, EventArgs e)
        {
            try { var SelectedIt = listViewLabubus.SelectedItems[0]; }
            catch
            {
                MessageBox.Show("Ничего не выбрано");
                return;
            }
            int SelectedNum = listViewLabubus.SelectedItems[0].Index;
            logic.RemoveLabubu(SelectedNum);
            RefreshLabubuList();

        }
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


    }
}
