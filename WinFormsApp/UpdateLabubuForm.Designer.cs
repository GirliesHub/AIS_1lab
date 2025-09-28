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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(103, 80);
            label1.Name = "label1";
            label1.Size = new Size(186, 28);
            label1.TabIndex = 0;
            label1.Text = "Изменение лабубу";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(53, 154);
            label2.Name = "label2";
            label2.Size = new Size(87, 21);
            label2.TabIndex = 1;
            label2.Text = "Новое имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(53, 183);
            label3.Name = "label3";
            label3.Size = new Size(95, 21);
            label3.TabIndex = 2;
            label3.Text = "Новый цвет";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(53, 241);
            label4.Name = "label4";
            label4.Size = new Size(114, 21);
            label4.TabIndex = 3;
            label4.Text = "Новый размер";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(53, 212);
            label5.Name = "label5";
            label5.Size = new Size(123, 21);
            label5.TabIndex = 4;
            label5.Text = "Новая редкость";
            // 
            // label6
            // 
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(100, 23);
            label6.TabIndex = 0;
            // 
            // textName
            // 
            textName.Location = new Point(182, 152);
            textName.Name = "textName";
            textName.Size = new Size(100, 23);
            textName.TabIndex = 5;
            // 
            // textColor
            // 
            textColor.Location = new Point(182, 181);
            textColor.Name = "textColor";
            textColor.Size = new Size(100, 23);
            textColor.TabIndex = 6;
            // 
            // cmbSize
            // 
            cmbSize.FormattingEnabled = true;
            cmbSize.Location = new Point(182, 239);
            cmbSize.Name = "cmbSize";
            cmbSize.Size = new Size(100, 23);
            cmbSize.TabIndex = 7;
            // 
            // cmbRarity
            // 
            cmbRarity.FormattingEnabled = true;
            cmbRarity.Location = new Point(182, 210);
            cmbRarity.Name = "cmbRarity";
            cmbRarity.Size = new Size(100, 23);
            cmbRarity.TabIndex = 8;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F);
            button1.Location = new Point(182, 303);
            button1.Name = "button1";
            button1.Size = new Size(100, 30);
            button1.TabIndex = 9;
            button1.Text = "Изменить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnUpdate_Click;
            // 
            // UpdateLabubuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 375);
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
    }
}