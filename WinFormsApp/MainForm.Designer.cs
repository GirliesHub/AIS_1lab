

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
            btnAddLabubu.Location = new Point(552, 174);
            btnAddLabubu.Name = "btnAddLabubu";
            btnAddLabubu.Size = new Size(119, 23);
            btnAddLabubu.TabIndex = 0;
            btnAddLabubu.Text = "Добавить лабубу";
            btnAddLabubu.UseVisualStyleBackColor = true;
            btnAddLabubu.Click += btnAddLabubu_Click;
            // 
            // btnRemoveLabubu
            // 
            btnRemoveLabubu.Location = new Point(552, 203);
            btnRemoveLabubu.Name = "btnRemoveLabubu";
            btnRemoveLabubu.Size = new Size(119, 23);
            btnRemoveLabubu.TabIndex = 1;
            btnRemoveLabubu.Text = "Удалить лабубу";
            btnRemoveLabubu.UseVisualStyleBackColor = true;
            btnRemoveLabubu.Click += btnRemoveLabubu_Click;
            // 
            // btnUpdateLabubu
            // 
            btnUpdate.Location = new Point(552, 232);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(119, 23);
            btnUpdate.TabIndex = 2;
            btnUpdate.Text = "Изменить лабубу";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdateLabubu_Click;
            // 
            // listViewLabubus
            // 
            listViewLabubus.Location = new Point(12, 132);
            listViewLabubus.Name = "listViewLabubus";
            listViewLabubus.Size = new Size(451, 154);
            listViewLabubus.TabIndex = 3;
            listViewLabubus.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listViewLabubus);
            Controls.Add(btnUpdate);
            Controls.Add(btnRemoveLabubu);
            Controls.Add(btnAddLabubu);
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
