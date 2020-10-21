namespace AutomatedRSSReader
{
    partial class Form1
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
            this.categories = new System.Windows.Forms.ListBox();
            this.podcastList = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.categoryNew = new System.Windows.Forms.Button();
            this.categorySave = new System.Windows.Forms.Button();
            this.categoryRemove = new System.Windows.Forms.Button();
            this.categoryNameLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.urlInput = new System.Windows.Forms.TextBox();
            this.podcastRemove = new System.Windows.Forms.Button();
            this.podcastSave = new System.Windows.Forms.Button();
            this.podcastNew = new System.Windows.Forms.Button();
            this.categorySelect = new System.Windows.Forms.ComboBox();
            this.updatefreqSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.podcastTable = new System.Windows.Forms.TableLayoutPanel();
            this.description = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // categories
            // 
            this.categories.FormattingEnabled = true;
            this.categories.Location = new System.Drawing.Point(466, 21);
            this.categories.Name = "categories";
            this.categories.Size = new System.Drawing.Size(237, 95);
            this.categories.TabIndex = 0;
            // 
            // podcastList
            // 
            this.podcastList.FormattingEnabled = true;
            this.podcastList.Location = new System.Drawing.Point(12, 197);
            this.podcastList.Name = "podcastList";
            this.podcastList.Size = new System.Drawing.Size(448, 95);
            this.podcastList.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(466, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 2;
            // 
            // categoryNew
            // 
            this.categoryNew.Location = new System.Drawing.Point(466, 170);
            this.categoryNew.Name = "categoryNew";
            this.categoryNew.Size = new System.Drawing.Size(75, 23);
            this.categoryNew.TabIndex = 3;
            this.categoryNew.Text = "New";
            this.categoryNew.UseVisualStyleBackColor = true;
            // 
            // categorySave
            // 
            this.categorySave.Location = new System.Drawing.Point(547, 170);
            this.categorySave.Name = "categorySave";
            this.categorySave.Size = new System.Drawing.Size(75, 23);
            this.categorySave.TabIndex = 4;
            this.categorySave.Text = "Save";
            this.categorySave.UseVisualStyleBackColor = true;
            // 
            // categoryRemove
            // 
            this.categoryRemove.Location = new System.Drawing.Point(628, 170);
            this.categoryRemove.Name = "categoryRemove";
            this.categoryRemove.Size = new System.Drawing.Size(75, 23);
            this.categoryRemove.TabIndex = 5;
            this.categoryRemove.Text = "Remove";
            this.categoryRemove.UseVisualStyleBackColor = true;
            // 
            // categoryNameLabel
            // 
            this.categoryNameLabel.AutoSize = true;
            this.categoryNameLabel.Location = new System.Drawing.Point(463, 128);
            this.categoryNameLabel.Name = "categoryNameLabel";
            this.categoryNameLabel.Size = new System.Drawing.Size(81, 13);
            this.categoryNameLabel.TabIndex = 6;
            this.categoryNameLabel.Text = "Category name:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(463, 5);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(60, 13);
            this.categoryLabel.TabIndex = 7;
            this.categoryLabel.Text = "Categories:";
            // 
            // urlInput
            // 
            this.urlInput.Location = new System.Drawing.Point(12, 144);
            this.urlInput.Name = "urlInput";
            this.urlInput.Size = new System.Drawing.Size(194, 20);
            this.urlInput.TabIndex = 8;
            // 
            // podcastRemove
            // 
            this.podcastRemove.Location = new System.Drawing.Point(385, 171);
            this.podcastRemove.Name = "podcastRemove";
            this.podcastRemove.Size = new System.Drawing.Size(75, 23);
            this.podcastRemove.TabIndex = 9;
            this.podcastRemove.Text = "Remove";
            this.podcastRemove.UseVisualStyleBackColor = true;
            // 
            // podcastSave
            // 
            this.podcastSave.Location = new System.Drawing.Point(304, 171);
            this.podcastSave.Name = "podcastSave";
            this.podcastSave.Size = new System.Drawing.Size(75, 23);
            this.podcastSave.TabIndex = 10;
            this.podcastSave.Text = "Save";
            this.podcastSave.UseVisualStyleBackColor = true;
            this.podcastSave.Click += new System.EventHandler(this.podcastSave_Click);
            // 
            // podcastNew
            // 
            this.podcastNew.Location = new System.Drawing.Point(223, 171);
            this.podcastNew.Name = "podcastNew";
            this.podcastNew.Size = new System.Drawing.Size(75, 23);
            this.podcastNew.TabIndex = 11;
            this.podcastNew.Text = "New";
            this.podcastNew.UseVisualStyleBackColor = true;
            this.podcastNew.Click += new System.EventHandler(this.podcastNew_Click);
            // 
            // categorySelect
            // 
            this.categorySelect.FormattingEnabled = true;
            this.categorySelect.Location = new System.Drawing.Point(339, 144);
            this.categorySelect.Name = "categorySelect";
            this.categorySelect.Size = new System.Drawing.Size(121, 21);
            this.categorySelect.TabIndex = 12;
            // 
            // updatefreqSelect
            // 
            this.updatefreqSelect.FormattingEnabled = true;
            this.updatefreqSelect.Location = new System.Drawing.Point(212, 143);
            this.updatefreqSelect.Name = "updatefreqSelect";
            this.updatefreqSelect.Size = new System.Drawing.Size(121, 21);
            this.updatefreqSelect.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Updatefrequency:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Category:";
            // 
            // podcastTable
            // 
            this.podcastTable.ColumnCount = 4;
            this.podcastTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.podcastTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 211F));
            this.podcastTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.podcastTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.podcastTable.Location = new System.Drawing.Point(12, 12);
            this.podcastTable.Name = "podcastTable";
            this.podcastTable.RowCount = 2;
            this.podcastTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.podcastTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.podcastTable.Size = new System.Drawing.Size(445, 104);
            this.podcastTable.TabIndex = 18;
            this.podcastTable.Paint += new System.Windows.Forms.PaintEventHandler(this.podcastTable_Paint);
            // 
            // description
            // 
            this.description.Cursor = System.Windows.Forms.Cursors.No;
            this.description.Location = new System.Drawing.Point(466, 199);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(237, 93);
            this.description.TabIndex = 19;
            this.description.Text = "";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(715, 304);
            this.Controls.Add(this.description);
            this.Controls.Add(this.podcastTable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updatefreqSelect);
            this.Controls.Add(this.categorySelect);
            this.Controls.Add(this.podcastNew);
            this.Controls.Add(this.podcastSave);
            this.Controls.Add(this.podcastRemove);
            this.Controls.Add(this.urlInput);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.categoryNameLabel);
            this.Controls.Add(this.categoryRemove);
            this.Controls.Add(this.categorySave);
            this.Controls.Add(this.categoryNew);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.podcastList);
            this.Controls.Add(this.categories);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox categories;
        private System.Windows.Forms.ListBox podcastList;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button categoryNew;
        private System.Windows.Forms.Button categorySave;
        private System.Windows.Forms.Button categoryRemove;
        private System.Windows.Forms.Label categoryNameLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.TextBox urlInput;
        private System.Windows.Forms.Button podcastRemove;
        private System.Windows.Forms.Button podcastSave;
        private System.Windows.Forms.Button podcastNew;
        private System.Windows.Forms.ComboBox categorySelect;
        private System.Windows.Forms.ComboBox updatefreqSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel podcastTable;
        private System.Windows.Forms.RichTextBox description;
    }
}

