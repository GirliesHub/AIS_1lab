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
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp
{
    public partial class AddLabubuForm : Form
    {

        private Logic logic;
        public AddLabubuForm(Logic logic)
        {
            InitializeComponent();
            this.logic = logic;
            InitializeComboBoxes();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            string name = txtName.Text;
            string color = txtColor.Text;
            string rarity = cmbRarity.SelectedItem.ToString();
            string size = cmbSizes.SelectedItem.ToString();
            int number = logic.GetAllLabubus().Count;

            try { logic.AddLabubu(number, name, color, rarity, size); }
            catch
            {
                MessageBox.Show("Одно из полей пустое!");
                return;
            }
            MessageBox.Show("Лабубу добавлена.");
            this.Close();
        }

        private void InitializeComboBoxes()
        {
            cmbRarity.Items.Clear();
            cmbRarity.Items.AddRange(new string[] { "1*", "2*", "3*", "4*", "5*" });


            cmbSizes.Items.Clear();
            cmbSizes.Items.AddRange(new string[] { "small", "medium", "big", "HUGE" });
        }
    }
}
