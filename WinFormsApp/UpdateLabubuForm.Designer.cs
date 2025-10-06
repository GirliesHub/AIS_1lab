namespace WinFormsApp
{
    partial class UpdateLabubuForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textName = new TextBox();
            textColor = new TextBox();
            cmbSize = new ComboBox();
            cmbRarity = new ComboBox();
            button1 = new Button();
            textPrice1 = new TextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(107, 105);
            label1.Name = "label1";
            label1.Size = new Size(230, 35);
            label1.TabIndex = 0;
            label1.Text = "Изменение лабубу";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(52, 173);
            label2.Name = "label2";
            label2.Size = new Size(112, 28);
            label2.TabIndex = 1;
            label2.Text = "Новое имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(52, 213);
            label3.Name = "label3";
            label3.Size = new Size(121, 28);
            label3.TabIndex = 2;
            label3.Text = "Новый цвет";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(52, 284);
            label4.Name = "label4";
            label4.Size = new Size(147, 28);
            label4.TabIndex = 3;
            label4.Text = "Новый размер";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(52, 248);
            label5.Name = "label5";
            label5.Size = new Size(156, 28);
            label5.TabIndex = 4;
            label5.Text = "Новая редкость";
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 31);
            label6.TabIndex = 0;
            // 
            // textName
            // 
            textName.Location = new Point(208, 177);
            textName.Margin = new Padding(3, 4, 3, 4);
            textName.Name = "textName";
            textName.Size = new Size(114, 27);
            textName.TabIndex = 5;
            // 
            // textColor
            // 
            textColor.Location = new Point(208, 212);
            textColor.Margin = new Padding(3, 4, 3, 4);
            textColor.Name = "textColor";
            textColor.Size = new Size(114, 27);
            textColor.TabIndex = 6;
            // 
            // cmbSize
            // 
            cmbSize.FormattingEnabled = true;
            cmbSize.Location = new Point(208, 284);
            cmbSize.Margin = new Padding(3, 4, 3, 4);
            cmbSize.Name = "cmbSize";
            cmbSize.Size = new Size(114, 28);
            cmbSize.TabIndex = 7;
            // 
            // cmbRarity
            // 
            cmbRarity.FormattingEnabled = true;
            cmbRarity.Location = new Point(208, 247);
            cmbRarity.Margin = new Padding(3, 4, 3, 4);
            cmbRarity.Name = "cmbRarity";
            cmbRarity.Size = new Size(114, 28);
            cmbRarity.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(162, 402);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(114, 40);
            button1.TabIndex = 9;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnUpdate_Click;
            // 
            // textPrice1
            // 
            textPrice1.Location = new Point(208, 319);
            textPrice1.Name = "textPrice1";
            textPrice1.Size = new Size(114, 27);
            textPrice1.TabIndex = 10;
            textPrice1.TextChanged += textPrice1_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(55, 319);
            label7.Name = "label7";
            label7.Size = new Size(118, 28);
            label7.TabIndex = 11;
            label7.Text = "Новая цена";
            // 
            // UpdateLabubuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(455, 500);
            Controls.Add(label7);
            Controls.Add(textPrice1);
            Controls.Add(button1);
            Controls.Add(cmbRarity);
            Controls.Add(cmbSize);
            Controls.Add(textColor);
            Controls.Add(textName);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UpdateLabubuForm";
            Text = "Изменение лабубу";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textName;
        private TextBox textColor;
        private ComboBox cmbSize;
        private ComboBox cmbRarity;
        private Button button1;
        private TextBox textPrice1;
        private Label label7;
    }
}
