using System.Windows.Forms;

namespace WinFormsApp
{
    partial class AddLabubuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLabubuForm));
            label1 = new Label();
            textName = new Label();
            textColor = new Label();
            textRarity = new Label();
            textSize = new Label();
            txtName = new TextBox();
            txtColor = new TextBox();
            btnAdd = new Button();
            cmbSizes = new ComboBox();
            cmbRarity = new ComboBox();
            textPrice = new Label();
            txtPrice = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(104, 82);
            label1.Name = "label1";
            label1.Size = new Size(196, 28);
            label1.TabIndex = 0;
            label1.Text = "Добавление лабубу";
            label1.Click += label1_Click;
            // 
            // textName
            // 
            textName.AutoSize = true;
            textName.Font = new Font("Segoe UI", 12F);
            textName.Location = new Point(44, 131);
            textName.Name = "textName";
            textName.Size = new Size(41, 21);
            textName.TabIndex = 1;
            textName.Text = "Имя";
            // 
            // textColor
            // 
            textColor.AutoSize = true;
            textColor.Font = new Font("Segoe UI", 12F);
            textColor.Location = new Point(44, 161);
            textColor.Name = "textColor";
            textColor.Size = new Size(45, 21);
            textColor.TabIndex = 2;
            textColor.Text = "Цвет";
            // 
            // textRarity
            // 
            textRarity.AutoSize = true;
            textRarity.Font = new Font("Segoe UI", 12F);
            textRarity.Location = new Point(44, 191);
            textRarity.Name = "textRarity";
            textRarity.Size = new Size(75, 21);
            textRarity.TabIndex = 3;
            textRarity.Text = "Редкость";
            // 
            // textSize
            // 
            textSize.AutoSize = true;
            textSize.Font = new Font("Segoe UI", 12F);
            textSize.Location = new Point(44, 219);
            textSize.Name = "textSize";
            textSize.Size = new Size(62, 21);
            textSize.TabIndex = 4;
            textSize.Text = "Размер";
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 129);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 5;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(130, 159);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(100, 23);
            txtColor.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F);
            btnAdd.Location = new Point(137, 300);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(93, 34);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbSizes
            // 
            cmbSizes.FormattingEnabled = true;
            cmbSizes.Location = new Point(130, 217);
            cmbSizes.Name = "cmbSizes";
            cmbSizes.Size = new Size(100, 23);
            cmbSizes.TabIndex = 10;
            // 
            // cmbRarity
            // 
            cmbRarity.FormattingEnabled = true;
            cmbRarity.Location = new Point(130, 189);
            cmbRarity.Name = "cmbRarity";
            cmbRarity.Size = new Size(100, 23);
            cmbRarity.TabIndex = 11;
            // 
            // textPrice
            // 
            textPrice.AutoSize = true;
            textPrice.Font = new Font("Segoe UI", 12F);
            textPrice.Location = new Point(44, 249);
            textPrice.Name = "textPrice";
            textPrice.Size = new Size(47, 21);
            textPrice.TabIndex = 12;
            textPrice.Text = "Цена";
            textPrice.Click += label2_Click;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(130, 247);
            txtPrice.Margin = new Padding(3, 2, 3, 2);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 23);
            txtPrice.TabIndex = 13;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(246, 129);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 141);
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.SendToBack();
            // 
            // AddLabubuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 375);
            Controls.Add(pictureBox1);
            Controls.Add(txtPrice);
            Controls.Add(textPrice);
            Controls.Add(cmbRarity);
            Controls.Add(cmbSizes);
            Controls.Add(btnAdd);
            Controls.Add(txtColor);
            Controls.Add(txtName);
            Controls.Add(textSize);
            Controls.Add(textRarity);
            Controls.Add(textColor);
            Controls.Add(textName);
            Controls.Add(label1);
            Name = "AddLabubuForm";
            Text = "Добавление лабубу";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label textName;
        private Label textColor;
        private Label textRarity;
        private Label textSize;
        private TextBox txtName;
        private TextBox txtColor;
        private Button btnAdd;
        private ComboBox cmbSizes;
        private ComboBox cmbRarity;
        private Label textPrice;
        private TextBox txtPrice;
        private PictureBox pictureBox1;
    }
}
