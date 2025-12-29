

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
            numericMinPrice = new NumericUpDown();
            numericMaxPrice = new NumericUpDown();
            btnApplyPriceFilter = new Button();
            btnClearFilters = new Button();
            labelFilter = new Label();
            listViewCollectors = new ListView();
            btnAddCollector = new Button();
            btnAssignLabubu = new Button();
            btnShowCollectorLabubus = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericMinPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMaxPrice).BeginInit();
            SuspendLayout();
            // 
            // btnAddLabubu
            // 
            btnAddLabubu.Location = new Point(521, 150);
            btnAddLabubu.Name = "btnAddLabubu";
            btnAddLabubu.Size = new Size(119, 23);
            btnAddLabubu.TabIndex = 0;
            btnAddLabubu.Text = "Добавить лабубу";
            btnAddLabubu.UseVisualStyleBackColor = true;
            btnAddLabubu.Click += btnAddLabubu_Click;
            // 
            // btnRemoveLabubu
            // 
            btnRemoveLabubu.Location = new Point(521, 192);
            btnRemoveLabubu.Name = "btnRemoveLabubu";
            btnRemoveLabubu.Size = new Size(119, 23);
            btnRemoveLabubu.TabIndex = 1;
            btnRemoveLabubu.Text = "Удалить лабубу";
            btnRemoveLabubu.UseVisualStyleBackColor = true;
            btnRemoveLabubu.Click += btnRemoveLabubu_Click;
            // 
            // btnUpdateLabubu
            // 
            btnUpdateLabubu.Location = new Point(521, 234);
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
            listViewLabubus.Size = new Size(503, 154);
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
            label4.Location = new Point(12, 99);
            label4.Name = "label4";
            label4.Size = new Size(359, 30);
            label4.TabIndex = 13;
            label4.Text = "Добро пожаловать в Мир Лабуб!";
            // 
            // numericMinPrice
            // 
            numericMinPrice.DecimalPlaces = 2;
            numericMinPrice.Location = new Point(395, 338);
            numericMinPrice.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            numericMinPrice.Name = "numericMinPrice";
            numericMinPrice.Size = new Size(120, 23);
            numericMinPrice.TabIndex = 14;
            // 
            // numericMaxPrice
            // 
            numericMaxPrice.DecimalPlaces = 2;
            numericMaxPrice.Location = new Point(395, 367);
            numericMaxPrice.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            numericMaxPrice.Name = "numericMaxPrice";
            numericMaxPrice.Size = new Size(120, 23);
            numericMaxPrice.TabIndex = 15;
            // 
            // btnApplyPriceFilter
            // 
            btnApplyPriceFilter.Location = new Point(395, 396);
            btnApplyPriceFilter.Name = "btnApplyPriceFilter";
            btnApplyPriceFilter.Size = new Size(120, 23);
            btnApplyPriceFilter.TabIndex = 16;
            btnApplyPriceFilter.Text = "Задать диапазон";
            btnApplyPriceFilter.UseVisualStyleBackColor = true;
            // 
            // btnClearFilters
            // 
            btnClearFilters.Location = new Point(395, 425);
            btnClearFilters.Name = "btnClearFilters";
            btnClearFilters.Size = new Size(120, 23);
            btnClearFilters.TabIndex = 17;
            btnClearFilters.Text = "Сброс";
            btnClearFilters.UseVisualStyleBackColor = true;
            // 
            // labelFilter
            // 
            labelFilter.AutoSize = true;
            labelFilter.Location = new Point(395, 320);
            labelFilter.Name = "labelFilter";
            labelFilter.Size = new Size(120, 15);
            labelFilter.TabIndex = 18;
            labelFilter.Text = "Фильтрация по цене";
            // 
            // listViewCollectors
            // 
            listViewCollectors.BackColor = SystemColors.Window;
            listViewCollectors.Location = new Point(670, 132);
            listViewCollectors.Name = "listViewCollectors";
            listViewCollectors.Size = new Size(358, 154);
            listViewCollectors.TabIndex = 19;
            listViewCollectors.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddCollector
            // 
            btnAddCollector.Location = new Point(656, 336);
            btnAddCollector.Name = "btnAddCollector";
            btnAddCollector.Size = new Size(163, 45);
            btnAddCollector.TabIndex = 20;
            btnAddCollector.Text = "Добавить коллекционера";
            btnAddCollector.UseVisualStyleBackColor = true;
            // 
            // btnAssignLabubu
            // 
            btnAssignLabubu.Location = new Point(656, 422);
            btnAssignLabubu.Name = "btnAssignLabubu";
            btnAssignLabubu.Size = new Size(178, 23);
            btnAssignLabubu.TabIndex = 21;
            btnAssignLabubu.Text = "Назначить лабубу";
            btnAssignLabubu.UseVisualStyleBackColor = true;
            // 
            // btnShowCollectorLabubus
            // 
            btnShowCollectorLabubus.Location = new Point(862, 353);
            btnShowCollectorLabubus.Name = "btnShowCollectorLabubus";
            btnShowCollectorLabubus.Size = new Size(166, 23);
            btnShowCollectorLabubus.TabIndex = 22;
            btnShowCollectorLabubus.Text = "Показать лабубу";
            btnShowCollectorLabubus.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(656, 318);
            label5.Name = "label5";
            label5.Size = new Size(163, 15);
            label5.TabIndex = 23;
            label5.Text = "Добавление коллекционера";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(656, 389);
            label6.Name = "label6";
            label6.Size = new Size(178, 30);
            label6.TabIndex = 24;
            label6.Text = "Назначить выбранную лабубу \r\nвыбранному коллекционеру";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(862, 320);
            label7.Name = "label7";
            label7.Size = new Size(166, 30);
            label7.TabIndex = 25;
            label7.Text = "Показать лабубу \r\nконкретного коллекционера";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 450);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnShowCollectorLabubus);
            Controls.Add(btnAssignLabubu);
            Controls.Add(btnAddCollector);
            Controls.Add(listViewCollectors);
            Controls.Add(labelFilter);
            Controls.Add(btnClearFilters);
            Controls.Add(btnApplyPriceFilter);
            Controls.Add(numericMaxPrice);
            Controls.Add(numericMinPrice);
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
            ((System.ComponentModel.ISupportInitialize)numericMinPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMaxPrice).EndInit();
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
        private NumericUpDown numericMinPrice;
        private NumericUpDown numericMaxPrice;
        private Button btnApplyPriceFilter;
        private Button btnClearFilters;
        private Label labelFilter;
        private ListView listViewCollectors;
        private Button btnAddCollector;
        private Button btnAssignLabubu;
        private Button btnShowCollectorLabubus;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}
