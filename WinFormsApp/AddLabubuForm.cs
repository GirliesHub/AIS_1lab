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
        private Labubu.RarityEnum ParseRarity(string rarityString)
        {
            return rarityString switch
            {
                "1*" => Labubu.RarityEnum.OneStar,
                "2*" => Labubu.RarityEnum.TwoStars,
                "3*" => Labubu.RarityEnum.ThreeStars,
                "4*" => Labubu.RarityEnum.FourStars,
                "5*" => Labubu.RarityEnum.FiveStars,
                _ => throw new ArgumentException($"Неизвестная редкость: {rarityString}")
            };
        }

        /// <summary>
        /// преобразует строку в SizeEnum
        /// </summary>
        private Labubu.SizeEnum ParseSize(string sizeString)
        {
            return sizeString.ToLower() switch
            {
                "small" => Labubu.SizeEnum.Small,
                "medium" => Labubu.SizeEnum.Medium,
                "big" => Labubu.SizeEnum.Big,
                "huge" => Labubu.SizeEnum.HUGE,
                _ => throw new ArgumentException($"Неизвестный размер: {sizeString}")
            };
        }

        /// <summary>
        /// кнопка добавить лабубу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            Labubu.RarityEnum rarity = ParseRarity(cmbRarity.SelectedItem.ToString());
            Labubu.SizeEnum size = ParseSize(cmbSizes.SelectedItem.ToString());

            int number = logic.GetAllLabubus().Count;

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
                logic.AddLabubu(number, name, color, rarity, size, price);
                MessageBox.Show("Лабуба добавлена.");
                this.Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}");
            }
        }


        //обработчики событий 
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
