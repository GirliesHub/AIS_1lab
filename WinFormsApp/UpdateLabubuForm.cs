using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class UpdateLabubuForm : Form
    {
        private Logic logic;
        private int id;
        public UpdateLabubuForm(Logic logic, int Id)
        {
            InitializeComponent();
            InitializeComboBoxes();
            this.logic = logic;
            this.id = Id;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newName = textName.Text;
            string newColor = textColor.Text;
            string newRarity = cmbRarity.SelectedItem.ToString();
            string newSize = cmbSize.SelectedItem.ToString();
            try { logic.UpdateLabubu(id, newName, newColor, newRarity, newSize); }
            catch
            {
                MessageBox.Show("Одно или несколько из полей пустое(ые)!");
                return;
            }
            MessageBox.Show("Лабубу изменена");
            this.Close();
        }
        private void InitializeComboBoxes()
        {
            cmbRarity.Items.Clear();
            cmbRarity.Items.AddRange(new string[] { "1*", "2*", "3*", "4*", "5*" });


            cmbSize.Items.Clear();
            cmbSize.Items.AddRange(new string[] { "small", "medium", "big", "HUGE" });
        }

    }
}
