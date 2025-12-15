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
using Shared;
using LabubuModel;


namespace WinFormsApp
{
    public partial class UpdateLabubuForm : Form
    {
        public event EventHandler<ViewLabubuUpdateEventArgs> ViewLabubuUpdate;

        public Labubu Labubu { get; private set; }
        private int _id;

        public UpdateLabubuForm(Labubu labubu)
        {
            InitializeComponent();
            InitializeComboBoxes();
            //_id = id;

        }

        /// <summary>
        /// выпадающие списки
        /// </summary>
        private void InitializeComboBoxes()
        {
            cmbRarity.Items.Clear();
            cmbRarity.Items.AddRange(new string[] { "1*", "2*", "3*", "4*", "5*" });

            cmbSize.Items.Clear();
            cmbSize.Items.AddRange(new string[] { "small", "medium", "big", "HUGE" });
        }

        /// <summary>
        /// кнопка изменить лабубу
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbRarity.SelectedItem == null || cmbSize.SelectedItem == null)
            {
                MessageBox.Show("Выберите редкость и размер!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textName.Text) || string.IsNullOrWhiteSpace(textColor.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (!decimal.TryParse(textPrice1.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Цена должна быть положительным числом!");
                return;
            }

            try
            {
                RarityEnum rarity = cmbRarity.SelectedItem.ToString() switch
                {
                    "1*" => RarityEnum.OneStar,
                    "2*" => RarityEnum.TwoStars,
                    "3*" => RarityEnum.ThreeStars,
                    "4*" => RarityEnum.FourStars,
                    "5*" => RarityEnum.FiveStars,
                    _ => RarityEnum.OneStar
                };

                SizeEnum size = cmbSize.SelectedItem.ToString().ToLower() switch
                {
                    "small" => SizeEnum.Small,
                    "medium" => SizeEnum.Medium,
                    "big" => SizeEnum.Big,
                    "huge" => SizeEnum.HUGE,
                    _ => SizeEnum.Small
                };

                ViewLabubuUpdate(this, new ViewLabubuUpdateEventArgs(new Labubu(_id, textName.Text, textColor.Text, rarity, size, price)));

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
