using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessLogic;
using Model;
using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class AddCollectorForm : Form
    {
        private readonly Logic _logic;

        public AddCollectorForm(Logic logic)
        {
            InitializeComponent();
            _logic = logic ?? throw new ArgumentNullException(nameof(logic));

            this.btnSave.Click += btnSave_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string city = txtCity.Text.Trim();

                if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(city))
                {
                    MessageBox.Show("Имя и город не могут быть пустыми");
                    return;
                }

                _logic.AddCollector(name, city);
                MessageBox.Show("Коллекционер добавлен");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
