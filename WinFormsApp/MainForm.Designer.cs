

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
            btnUpdate = new Button();
            listViewLabubus = new ListView();
            SuspendLayout();
            // 
            // btnAddLabubu
            // 
            btnAddLabubu.Location = new Point(707, 204);
            btnAddLabubu.Margin = new Padding(3, 4, 3, 4);
            btnAddLabubu.Name = "btnAddLabubu";
            btnAddLabubu.Size = new Size(136, 31);
            btnAddLabubu.TabIndex = 0;
            btnAddLabubu.Text = "Добавить лабубу";
            btnAddLabubu.UseVisualStyleBackColor = true;
            btnAddLabubu.Click += btnAddLabubu_Click;
            // 
            // btnRemoveLabubu
            // 
            btnRemoveLabubu.Location = new Point(707, 261);
            btnRemoveLabubu.Margin = new Padding(3, 4, 3, 4);
            btnRemoveLabubu.Name = "btnRemoveLabubu";
            btnRemoveLabubu.Size = new Size(136, 31);
            btnRemoveLabubu.TabIndex = 1;
            btnRemoveLabubu.Text = "Удалить лабубу";
            btnRemoveLabubu.UseVisualStyleBackColor = true;
            btnRemoveLabubu.Click += btnRemoveLabubu_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(707, 316);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(136, 31);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Изменить лабубу";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdateLabubu_Click;
            // 
            // listViewLabubus
            // 
            listViewLabubus.Location = new Point(14, 176);
            listViewLabubus.Margin = new Padding(3, 4, 3, 4);
            listViewLabubus.Name = "listViewLabubus";
            listViewLabubus.Size = new Size(611, 204);
            listViewLabubus.TabIndex = 3;
            listViewLabubus.UseCompatibleStateImageBehavior = false;
            listViewLabubus.SelectedIndexChanged += listViewLabubus_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(listViewLabubus);
            Controls.Add(btnUpdate);
            Controls.Add(btnRemoveLabubu);
            Controls.Add(btnAddLabubu);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Мир Лабуб";
            ResumeLayout(false);
        }



        #endregion

        private Button btnAddLabubu;
        private Button btnRemoveLabubu;
        private Button btnUpdate;
        private ListView listViewLabubus;
    }
}
