using System;
using System.Windows.Forms;
using Model;
using SharedLabubu;

namespace WinFormsApp
{
    /// <summary>
    /// Форма добавления новой лабубы
    /// </summary>
    public partial class AddLabubuForm : Form
    {
        public LabubuDTO Result { get; private set; }

        public AddLabubuForm()
        {
            InitializeComponent();
            InitializeComboBoxes();
        }

        /// <summary>
        /// Заполняет комбобоксы
        /// </summary>
        private void InitializeComboBoxes()
        {
            cmbRarity.Items.Clear();
            cmbRarity.Items.AddRange(new string[] { "1*", "2*", "3*", "4*", "5*" });

            cmbSizes.Items.Clear();
            cmbSizes.Items.AddRange(new string[] { "small", "medium", "big", "HUGE" });
        }

        /// <summary>
        /// Преобразует строку редкости в перечисление <see cref="RarityEnum"/>.
        /// </summary>
        private RarityEnum ParseRarity(string rarityString) => rarityString switch
        {
            "1*" => RarityEnum.OneStar,
            "2*" => RarityEnum.TwoStars,
            "3*" => RarityEnum.ThreeStars,
            "4*" => RarityEnum.FourStars,
            "5*" => RarityEnum.FiveStars,
            _ => throw new ArgumentException($"Неизвестная редкость: {rarityString}")
        };

        /// <summary>
        /// Преобразует строку размера в перечисление <see cref="SizeEnum"/>.
        /// </summary>
        private SizeEnum ParseSize(string sizeString) => sizeString.ToLower() switch
        {
            "small" => SizeEnum.Small,
            "medium" => SizeEnum.Medium,
            "big" => SizeEnum.Big,
            "huge" => SizeEnum.HUGE,
            _ => throw new ArgumentException($"Неизвестный размер: {sizeString}")
        };

        /// <summary>
        /// Обработчик кнопки добавления. Валидирует ввод и формирует DTO в свойстве <see cref="Result"/>.
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

            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену (положительное число)!");
                return;
            }

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(color))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            var rarity = ParseRarity(cmbRarity.SelectedItem.ToString());
            var size = ParseSize(cmbSizes.SelectedItem.ToString());

            Result = new LabubuDTO
            {
                Name = name,
                Color = color,
                Rarity = rarity,
                Size = size,
                Price = price
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
