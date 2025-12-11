using Model;
using BusinessLogic;
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
            if (id <= 0)
            {
                MessageBox.Show($"Ошибка: некорректный ID: {id}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            LoadLabubuData();
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
        /// <summary>
        /// Загрузка данных о лабубах
        /// </summary>
        private void LoadLabubuData()
        {
            try
            {
                var labubu = logic.GetAllLabubus().FirstOrDefault(l => l.ID == id);

                if (labubu == null)
                {
                    MessageBox.Show($"Лабуба с ID {id} не найдена в базе данных",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                textName.Text = labubu.Name;
                textColor.Text = labubu.Color;

                string rarityString = labubu.Rarity switch
                {
                    RarityEnum.OneStar => "1*",
                    RarityEnum.TwoStars => "2*",
                    RarityEnum.ThreeStars => "3*",
                    RarityEnum.FourStars => "4*",
                    RarityEnum.FiveStars => "5*",
                    _ => "1*"
                };
                cmbRarity.SelectedItem = rarityString;

                cmbSize.SelectedItem = labubu.Size.ToString();

                textPrice1.Text = labubu.Price.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }
    }
}
