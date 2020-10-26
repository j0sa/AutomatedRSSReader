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
            this.episodeList = new System.Windows.Forms.ListBox();
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
            this.podcastListLabel = new System.Windows.Forms.Label();
            this.urlLabel = new System.Windows.Forms.Label();
            this.updateFreqLabel = new System.Windows.Forms.Label();
            this.podcastCategoryLabel = new System.Windows.Forms.Label();
            this.episodeDescription = new System.Windows.Forms.RichTextBox();
            this.updateFreqSelect = new System.Windows.Forms.NumericUpDown();
            this.podcastList = new System.Windows.Forms.ListView();
            this.columnHeaderEpisode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFrequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.updateFreqSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // categories
            // 
            this.categories.FormattingEnabled = true;
            this.categories.Location = new System.Drawing.Point(531, 21);
            this.categories.Name = "categories";
            this.categories.Size = new System.Drawing.Size(237, 95);
            this.categories.TabIndex = 0;
            // 
            // episodeList
            // 
            this.episodeList.FormattingEnabled = true;
            this.episodeList.Location = new System.Drawing.Point(12, 259);
            this.episodeList.Name = "episodeList";
            this.episodeList.Size = new System.Drawing.Size(507, 186);
            this.episodeList.TabIndex = 1;
            this.episodeList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.episodeList_MouseClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(531, 143);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(237, 20);
            this.textBox1.TabIndex = 2;
            // 
            // categoryNew
            // 
            this.categoryNew.Location = new System.Drawing.Point(531, 171);
            this.categoryNew.Name = "categoryNew";
            this.categoryNew.Size = new System.Drawing.Size(75, 23);
            this.categoryNew.TabIndex = 3;
            this.categoryNew.Text = "New";
            this.categoryNew.UseVisualStyleBackColor = true;
            // 
            // categorySave
            // 
            this.categorySave.Location = new System.Drawing.Point(612, 171);
            this.categorySave.Name = "categorySave";
            this.categorySave.Size = new System.Drawing.Size(75, 23);
            this.categorySave.TabIndex = 4;
            this.categorySave.Text = "Save";
            this.categorySave.UseVisualStyleBackColor = true;
            // 
            // categoryRemove
            // 
            this.categoryRemove.Location = new System.Drawing.Point(693, 171);
            this.categoryRemove.Name = "categoryRemove";
            this.categoryRemove.Size = new System.Drawing.Size(75, 23);
            this.categoryRemove.TabIndex = 5;
            this.categoryRemove.Text = "Remove";
            this.categoryRemove.UseVisualStyleBackColor = true;
            // 
            // categoryNameLabel
            // 
            this.categoryNameLabel.AutoSize = true;
            this.categoryNameLabel.Location = new System.Drawing.Point(525, 128);
            this.categoryNameLabel.Name = "categoryNameLabel";
            this.categoryNameLabel.Size = new System.Drawing.Size(81, 13);
            this.categoryNameLabel.TabIndex = 6;
            this.categoryNameLabel.Text = "Category name:";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(525, 5);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(60, 13);
            this.categoryLabel.TabIndex = 7;
            this.categoryLabel.Text = "Categories:";
            // 
            // urlInput
            // 
            this.urlInput.Location = new System.Drawing.Point(12, 199);
            this.urlInput.Name = "urlInput";
            this.urlInput.Size = new System.Drawing.Size(253, 20);
            this.urlInput.TabIndex = 8;
            // 
            // podcastRemove
            // 
            this.podcastRemove.Location = new System.Drawing.Point(444, 225);
            this.podcastRemove.Name = "podcastRemove";
            this.podcastRemove.Size = new System.Drawing.Size(75, 23);
            this.podcastRemove.TabIndex = 9;
            this.podcastRemove.Text = "Remove";
            this.podcastRemove.UseVisualStyleBackColor = true;
            // 
            // podcastSave
            // 
            this.podcastSave.Location = new System.Drawing.Point(363, 225);
            this.podcastSave.Name = "podcastSave";
            this.podcastSave.Size = new System.Drawing.Size(75, 23);
            this.podcastSave.TabIndex = 10;
            this.podcastSave.Text = "Save";
            this.podcastSave.UseVisualStyleBackColor = true;
            this.podcastSave.Click += new System.EventHandler(this.podcastSave_Click);
            // 
            // podcastNew
            // 
            this.podcastNew.Location = new System.Drawing.Point(282, 225);
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
            this.categorySelect.Location = new System.Drawing.Point(398, 198);
            this.categorySelect.Name = "categorySelect";
            this.categorySelect.Size = new System.Drawing.Size(121, 21);
            this.categorySelect.TabIndex = 12;
            // 
            // podcastListLabel
            // 
            this.podcastListLabel.AutoSize = true;
            this.podcastListLabel.Location = new System.Drawing.Point(12, 238);
            this.podcastListLabel.Name = "podcastListLabel";
            this.podcastListLabel.Size = new System.Drawing.Size(35, 13);
            this.podcastListLabel.TabIndex = 14;
            this.podcastListLabel.Text = "label1";
            // 
            // urlLabel
            // 
            this.urlLabel.AutoSize = true;
            this.urlLabel.Location = new System.Drawing.Point(12, 181);
            this.urlLabel.Name = "urlLabel";
            this.urlLabel.Size = new System.Drawing.Size(32, 13);
            this.urlLabel.TabIndex = 15;
            this.urlLabel.Text = "URL:";
            // 
            // updateFreqLabel
            // 
            this.updateFreqLabel.AutoSize = true;
            this.updateFreqLabel.Location = new System.Drawing.Point(271, 182);
            this.updateFreqLabel.Name = "updateFreqLabel";
            this.updateFreqLabel.Size = new System.Drawing.Size(92, 13);
            this.updateFreqLabel.TabIndex = 16;
            this.updateFreqLabel.Text = "Updatefrequency:";
            // 
            // podcastCategoryLabel
            // 
            this.podcastCategoryLabel.AutoSize = true;
            this.podcastCategoryLabel.Location = new System.Drawing.Point(395, 182);
            this.podcastCategoryLabel.Name = "podcastCategoryLabel";
            this.podcastCategoryLabel.Size = new System.Drawing.Size(52, 13);
            this.podcastCategoryLabel.TabIndex = 17;
            this.podcastCategoryLabel.Text = "Category:";
            // 
            // episodeDescription
            // 
            this.episodeDescription.BackColor = System.Drawing.SystemColors.Control;
            this.episodeDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.episodeDescription.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.episodeDescription.Location = new System.Drawing.Point(528, 200);
            this.episodeDescription.Name = "episodeDescription";
            this.episodeDescription.Size = new System.Drawing.Size(240, 245);
            this.episodeDescription.TabIndex = 19;
            this.episodeDescription.Text = "";
            // 
            // updateFreqSelect
            // 
            this.updateFreqSelect.Location = new System.Drawing.Point(271, 199);
            this.updateFreqSelect.Name = "updateFreqSelect";
            this.updateFreqSelect.Size = new System.Drawing.Size(120, 20);
            this.updateFreqSelect.TabIndex = 20;
            // 
            // podcastList
            // 
            this.podcastList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.podcastList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderEpisode,
            this.columnHeaderName,
            this.columnHeaderFrequency,
            this.columnHeaderCategory});
            this.podcastList.FullRowSelect = true;
            this.podcastList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.podcastList.HideSelection = false;
            this.podcastList.Location = new System.Drawing.Point(12, 21);
            this.podcastList.Name = "podcastList";
            this.podcastList.Size = new System.Drawing.Size(507, 157);
            this.podcastList.TabIndex = 0;
            this.podcastList.UseCompatibleStateImageBehavior = false;
            this.podcastList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderEpisode
            // 
            this.columnHeaderEpisode.Text = "Episodes";
            this.columnHeaderEpisode.Width = 55;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 250;
            // 
            // columnHeaderFrequency
            // 
            this.columnHeaderFrequency.Text = "Update Frequency";
            this.columnHeaderFrequency.Width = 100;
            // 
            // columnHeaderCategory
            // 
            this.columnHeaderCategory.Text = "Category";
            this.columnHeaderCategory.Width = 90;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(780, 457);
            this.Controls.Add(this.podcastList);
            this.Controls.Add(this.updateFreqSelect);
            this.Controls.Add(this.episodeDescription);
            this.Controls.Add(this.podcastCategoryLabel);
            this.Controls.Add(this.updateFreqLabel);
            this.Controls.Add(this.urlLabel);
            this.Controls.Add(this.podcastListLabel);
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
            this.Controls.Add(this.episodeList);
            this.Controls.Add(this.categories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.updateFreqSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox categories;
        private System.Windows.Forms.ListBox episodeList;
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
        private System.Windows.Forms.Label podcastListLabel;
        private System.Windows.Forms.Label urlLabel;
        private System.Windows.Forms.Label updateFreqLabel;
        private System.Windows.Forms.Label podcastCategoryLabel;
        private System.Windows.Forms.RichTextBox episodeDescription;
        private System.Windows.Forms.NumericUpDown updateFreqSelect;
        private System.Windows.Forms.ListView podcastList;
        private System.Windows.Forms.ColumnHeader columnHeaderEpisode;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderFrequency;
        private System.Windows.Forms.ColumnHeader columnHeaderCategory;
    }
}

