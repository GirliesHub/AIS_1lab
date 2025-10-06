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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(118, 107);
            label1.Name = "label1";
            label1.Size = new Size(240, 35);
            label1.TabIndex = 0;
            label1.Text = "Добавление лабубу";
            label1.Click += label1_Click;
            // 
            // textName
            // 
            textName.AutoSize = true;
            textName.Font = new Font("Segoe UI", 12F);
            textName.Location = new Point(61, 168);
            textName.Name = "textName";
            textName.Size = new Size(51, 28);
            textName.TabIndex = 1;
            textName.Text = "Имя";
            // 
            // textColor
            // 
            textColor.AutoSize = true;
            textColor.Font = new Font("Segoe UI", 12F);
            textColor.Location = new Point(61, 208);
            textColor.Name = "textColor";
            textColor.Size = new Size(56, 28);
            textColor.TabIndex = 2;
            textColor.Text = "Цвет";
            // 
            // textRarity
            // 
            textRarity.AutoSize = true;
            textRarity.Font = new Font("Segoe UI", 12F);
            textRarity.Location = new Point(50, 248);
            textRarity.Name = "textRarity";
            textRarity.Size = new Size(93, 28);
            textRarity.TabIndex = 3;
            textRarity.Text = "Редкость";
            // 
            // textSize
            // 
            textSize.AutoSize = true;
            textSize.Font = new Font("Segoe UI", 12F);
            textSize.Location = new Point(50, 285);
            textSize.Name = "textSize";
            textSize.Size = new Size(78, 28);
            textSize.TabIndex = 4;
            textSize.Text = "Размер";
            // 
            // txtName
            // 
            txtName.Location = new Point(149, 172);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(114, 27);
            txtName.TabIndex = 5;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(149, 212);
            txtColor.Margin = new Padding(3, 4, 3, 4);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(114, 27);
            txtColor.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 12F);
            btnAdd.Location = new Point(157, 400);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 45);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // cmbSizes
            // 
            cmbSizes.FormattingEnabled = true;
            cmbSizes.Location = new Point(149, 289);
            cmbSizes.Margin = new Padding(3, 4, 3, 4);
            cmbSizes.Name = "cmbSizes";
            cmbSizes.Size = new Size(114, 28);
            cmbSizes.TabIndex = 10;
            // 
            // cmbRarity
            // 
            cmbRarity.FormattingEnabled = true;
            cmbRarity.Location = new Point(149, 252);
            cmbRarity.Margin = new Padding(3, 4, 3, 4);
            cmbRarity.Name = "cmbRarity";
            cmbRarity.Size = new Size(114, 28);
            cmbRarity.TabIndex = 11;
            // 
            // textPrice
            // 
            textPrice.AutoSize = true;
            textPrice.Font = new Font("Segoe UI", 12F);
            textPrice.Location = new Point(58, 325);
            textPrice.Name = "textPrice";
            textPrice.Size = new Size(59, 28);
            textPrice.TabIndex = 12;
            textPrice.Text = "Цена";
            textPrice.Click += label2_Click;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(149, 329);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(114, 27);
            txtPrice.TabIndex = 13;
            txtPrice.TextChanged += txtPrice_TextChanged;
            // 
            // AddLabubuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 500);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddLabubuForm";
            Text = "AddLabubuForm";
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
    }
}
