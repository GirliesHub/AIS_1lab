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
        /// <summary>
        /// изменить лабубу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Проверки
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
                Labubu.RarityEnum rarity = cmbRarity.SelectedItem.ToString() switch
                {
                    "1*" => Labubu.RarityEnum.OneStar,
                    "2*" => Labubu.RarityEnum.TwoStars,
                    "3*" => Labubu.RarityEnum.ThreeStars,
                    "4*" => Labubu.RarityEnum.FourStars,
                    "5*" => Labubu.RarityEnum.FiveStars,
                    _ => Labubu.RarityEnum.OneStar
                };

                Labubu.SizeEnum size = cmbSize.SelectedItem.ToString().ToLower() switch
                {
                    "small" => Labubu.SizeEnum.Small,
                    "medium" => Labubu.SizeEnum.Medium,
                    "big" => Labubu.SizeEnum.Big,
                    "huge" => Labubu.SizeEnum.HUGE,
                    _ => Labubu.SizeEnum.Small
                };

                logic.UpdateLabubu(id, textName.Text, textColor.Text, rarity, size, price);
                MessageBox.Show("Лабуба изменена!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
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

        private void textPrice1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
