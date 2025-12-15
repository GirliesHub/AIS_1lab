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
using Shared;
using LabubuModel;

namespace WinFormsApp
{
    public partial class AddLabubuForm : Form
    {
        public event EventHandler<ViewLabubuAddEventArgs> LabubuAddedOnAddForm = delegate { };

        public Labubu Labubu { get; private set; }

        public AddLabubuForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        /// <summary>
        /// выпадающие списки
        /// </summary>
        private void InitializeComboBoxes()
        {
            cmbRarity.Items.Clear();
            cmbRarity.Items.AddRange(new string[] { "1*", "2*", "3*", "4*", "5*" });

            cmbSizes.Items.Clear();
            cmbSizes.Items.AddRange(new string[] { "small", "medium", "big", "HUGE" });
        }

        /// <summary>
        /// преобразует строку в RarityEnum
        /// </summary>
        private RarityEnum ParseRarity(string rarityString)
        {
            return rarityString switch
            {
                "1*" => RarityEnum.OneStar,
                "2*" => RarityEnum.TwoStars,
                "3*" => RarityEnum.ThreeStars,
                "4*" => RarityEnum.FourStars,
                "5*" => RarityEnum.FiveStars,
                _ => throw new ArgumentException($"Неизвестная редкость: {rarityString}")
            };
        }

        /// <summary>
        /// преобразует строку в SizeEnum
        /// </summary>
        private SizeEnum ParseSize(string sizeString)
        {
            return sizeString.ToLower() switch
            {
                "small" => SizeEnum.Small,
                "medium" => SizeEnum.Medium,
                "big" => SizeEnum.Big,
                "huge" => SizeEnum.HUGE,
                _ => throw new ArgumentException($"Неизвестный размер: {sizeString}")
            };
        }

        /// <summary>
        /// кнопка добавить лабубу
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string color = txtColor.Text;

            if (cmbRarity.SelectedItem == null)
            {
                MessageBox.Show("Выберите редкость!");
                return;
            }

            if (cmbSizes.SelectedItem == null)
            {
                MessageBox.Show("Выберите размер!");
                return;
            }

            RarityEnum rarity = ParseRarity(cmbRarity.SelectedItem.ToString());
            SizeEnum size = ParseSize(cmbSizes.SelectedItem.ToString());

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену (должна быть положительной)!");
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(color))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            try
            {
                LabubuAddedOnAddForm(this, new ViewLabubuAddEventArgs(name, color, rarity, size, price));
                MessageBox.Show("добавили походу");
                //Labubu = new Labubu
                //{
                //    Name = name,
                //    Color = color,
                //    Rarity = rarity,
                //    Size = size,
                //    Price = price
                //};

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании лабубы: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
