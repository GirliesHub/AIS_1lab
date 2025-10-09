

namespace WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddLabubu = new Button();
            btnRemoveLabubu = new Button();
            btnUpdateLabubu = new Button();
            listViewLabubus = new ListView();
            txtSearch = new TextBox();
            btnReset = new Button();
            btnGroupByRarity = new Button();
            btnGroupBySize = new Button();
            label1 = new Label();
            label2 = new Label();
            btnCheapest = new Button();
            btnMostExpensive = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // btnAddLabubu
            // 
            btnAddLabubu.Location = new Point(619, 153);
            btnAddLabubu.Name = "btnAddLabubu";
            btnAddLabubu.Size = new Size(119, 23);
            btnAddLabubu.TabIndex = 0;
            btnAddLabubu.Text = "Добавить лабубу";
            btnAddLabubu.UseVisualStyleBackColor = true;
            btnAddLabubu.Click += btnAddLabubu_Click;
            // 
            // btnRemoveLabubu
            // 
            btnRemoveLabubu.Location = new Point(619, 195);
            btnRemoveLabubu.Name = "btnRemoveLabubu";
            btnRemoveLabubu.Size = new Size(119, 23);
            btnRemoveLabubu.TabIndex = 1;
            btnRemoveLabubu.Text = "Удалить лабубу";
            btnRemoveLabubu.UseVisualStyleBackColor = true;
            btnRemoveLabubu.Click += btnRemoveLabubu_Click;
            // 
            // btnUpdateLabubu
            // 
            btnUpdateLabubu.Location = new Point(619, 237);
            btnUpdateLabubu.Name = "btnUpdateLabubu";
            btnUpdateLabubu.Size = new Size(119, 23);
            btnUpdateLabubu.TabIndex = 2;
            btnUpdateLabubu.Text = "Изменить лабубу";
            btnUpdateLabubu.UseVisualStyleBackColor = true;
            btnUpdateLabubu.Click += btnUpdateLabubu_Click;
            // 
            // listViewLabubus
            // 
            listViewLabubus.BackColor = SystemColors.Window;
            listViewLabubus.Location = new Point(12, 132);
            listViewLabubus.Name = "listViewLabubus";
            listViewLabubus.Size = new Size(535, 154);
            listViewLabubus.TabIndex = 3;
            listViewLabubus.UseCompatibleStateImageBehavior = false;
            listViewLabubus.SelectedIndexChanged += listViewLabubus_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(244, 339);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(110, 23);
            txtSearch.TabIndex = 4;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(12, 396);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(79, 23);
            btnReset.TabIndex = 5;
            btnReset.Text = "Сброс";
            btnReset.UseVisualStyleBackColor = true;
            // 
            // btnGroupByRarity
            // 
            btnGroupByRarity.Location = new Point(12, 338);
            btnGroupByRarity.Name = "btnGroupByRarity";
            btnGroupByRarity.Size = new Size(79, 23);
            btnGroupByRarity.TabIndex = 6;
            btnGroupByRarity.Text = "Редкость";
            btnGroupByRarity.UseVisualStyleBackColor = true;
            // 
            // btnGroupBySize
            // 
            btnGroupBySize.Location = new Point(12, 367);
            btnGroupBySize.Name = "btnGroupBySize";
            btnGroupBySize.Size = new Size(79, 23);
            btnGroupBySize.TabIndex = 7;
            btnGroupBySize.Text = "Размер";
            btnGroupBySize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 320);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 8;
            label1.Text = "Группировка";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(244, 320);
            label2.Name = "label2";
            label2.Size = new Size(110, 15);
            label2.TabIndex = 9;
            label2.Text = "Поиск по лабубам";
            // 
            // btnCheapest
            // 
            btnCheapest.Location = new Point(122, 338);
            btnCheapest.Name = "btnCheapest";
            btnCheapest.Size = new Size(88, 23);
            btnCheapest.TabIndex = 10;
            btnCheapest.Text = "Мин цена";
            btnCheapest.UseVisualStyleBackColor = true;
            // 
            // btnMostExpensive
            // 
            btnMostExpensive.Location = new Point(122, 367);
            btnMostExpensive.Name = "btnMostExpensive";
            btnMostExpensive.Size = new Size(88, 23);
            btnMostExpensive.TabIndex = 11;
            btnMostExpensive.Text = "Макс цена";
            btnMostExpensive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(122, 320);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 12;
            label3.Text = "Поиск по цене";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Window;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.FromArgb(255, 128, 128);
            label4.Location = new Point(101, 99);
            label4.Name = "label4";
            label4.Size = new Size(359, 30);
            label4.TabIndex = 13;
            label4.Text = "Добро пожаловать в Мир Лабуб!";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnMostExpensive);
            Controls.Add(btnCheapest);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGroupBySize);
            Controls.Add(btnGroupByRarity);
            Controls.Add(btnReset);
            Controls.Add(txtSearch);
            Controls.Add(listViewLabubus);
            Controls.Add(btnUpdateLabubu);
            Controls.Add(btnRemoveLabubu);
            Controls.Add(btnAddLabubu);
            Name = "MainForm";
            Text = "Мир Лабуб";
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button btnAddLabubu;
        private Button btnRemoveLabubu;
        private Button btnUpdateLabubu;
        private ListView listViewLabubus;
        private TextBox txtSearch;
        private Button btnReset;
        private Button btnGroupByRarity;
        private Button btnGroupBySize;
        private Label label1;
        private Label label2;
        private Button btnCheapest;
        private Button btnMostExpensive;
        private Label label3;
        private Label label4;
    }
}
