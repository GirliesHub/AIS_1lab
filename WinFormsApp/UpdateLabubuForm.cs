using System;
using System.Linq;
using System.Windows.Forms;
using Model;
using SharedLabubu;

namespace WinFormsApp
{
    public partial class UpdateLabubuForm : Form
    {
        private readonly LabubuDTO original;
        public LabubuDTO Result { get; private set; }

        public UpdateLabubuForm(LabubuDTO dto)
        {
            InitializeComponent();
            InitializeComboBoxes();

            original = dto ?? throw new ArgumentNullException(nameof(dto));
            LoadLabubuData();
        }

        /// <summary>
        /// Заполняет комбобоксы
        /// </summary>
        private void InitializeComboBoxes()
        {
            cmbRarity.Items.Clear();
            cmbRarity.Items.AddRange(new string[] { "1*", "2*", "3*", "4*", "5*" });

            cmbSize.Items.Clear();
            cmbSize.Items.AddRange(new string[] { "small", "medium", "big", "HUGE" });
        }

        /// <summary>
        /// Загружает данные исходной лабубы
        /// </summary>
        private void LoadLabubuData()
        {
            textName.Text = original.Name;
            textColor.Text = original.Color;

            string rarityString = original.Rarity switch
            {
                RarityEnum.OneStar => "1*",
                RarityEnum.TwoStars => "2*",
                RarityEnum.ThreeStars => "3*",
                RarityEnum.FourStars => "4*",
                RarityEnum.FiveStars => "5*",
                _ => "1*"
            };
            cmbRarity.SelectedItem = rarityString;

            cmbSize.SelectedItem = original.Size.ToString();

            textPrice1.Text = original.Price.ToString("F2");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbRarity.SelectedItem == null || cmbSize.SelectedItem == null)
            {
                MessageBox.Show("Выберите редкость и размер!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textName.Text) ||
                string.IsNullOrWhiteSpace(textColor.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (!decimal.TryParse(textPrice1.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Цена должна быть положительным числом!");
                return;
            }

            var rarity = cmbRarity.SelectedItem.ToString() switch
            {
                "1*" => RarityEnum.OneStar,
                "2*" => RarityEnum.TwoStars,
                "3*" => RarityEnum.ThreeStars,
                "4*" => RarityEnum.FourStars,
                "5*" => RarityEnum.FiveStars,
                _ => RarityEnum.OneStar
            };

            var size = cmbSize.SelectedItem.ToString().ToLower() switch
            {
                "small" => SizeEnum.Small,
                "medium" => SizeEnum.Medium,
                "big" => SizeEnum.Big,
                "huge" => SizeEnum.HUGE,
                _ => SizeEnum.Small
            };

            Result = new LabubuDTO
            {
                ID = original.ID,
                Name = textName.Text,
                Color = textColor.Text,
                Rarity = rarity,
                Size = size,
                Price = price
            };

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
