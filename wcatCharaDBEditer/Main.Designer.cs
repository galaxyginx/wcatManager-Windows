namespace wcatCharaDBEditer
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Add = new System.Windows.Forms.Button();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.RarityLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.RarityBox = new System.Windows.Forms.NumericUpDown();
            this.JobLabel = new System.Windows.Forms.Label();
            this.JobBox = new System.Windows.Forms.ComboBox();
            this.TypeBox = new System.Windows.Forms.ComboBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.RareTypeLabel = new System.Windows.Forms.Label();
            this.RareTypeBox = new System.Windows.Forms.ComboBox();
            this.CharacterList = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.AttributeBox = new System.Windows.Forms.ComboBox();
            this.Apply = new System.Windows.Forms.Button();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RarityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RareTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttributeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RarityBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterList)).BeginInit();
            this.SuspendLayout();
            // 
            // Add
            // 
            this.Add.BackColor = System.Drawing.Color.White;
            this.Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Add.Image = ((System.Drawing.Image)(resources.GetObject("Add.Image")));
            this.Add.Location = new System.Drawing.Point(362, 1);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(24, 24);
            this.Add.TabIndex = 67;
            this.Add.UseVisualStyleBackColor = false;
            this.Add.Click += new System.EventHandler(this.Adder_Click);
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(53, 1);
            this.NameBox.MaxLength = 30;
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(91, 20);
            this.NameBox.TabIndex = 66;
            // 
            // RarityLabel
            // 
            this.RarityLabel.AutoSize = true;
            this.RarityLabel.Location = new System.Drawing.Point(273, 3);
            this.RarityLabel.Name = "RarityLabel";
            this.RarityLabel.Size = new System.Drawing.Size(43, 13);
            this.RarityLabel.TabIndex = 72;
            this.RarityLabel.Text = "レア度：";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(2, 3);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(51, 13);
            this.NameLabel.TabIndex = 73;
            this.NameLabel.Text = "キャラ名：";
            // 
            // RarityBox
            // 
            this.RarityBox.Location = new System.Drawing.Point(315, 1);
            this.RarityBox.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RarityBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RarityBox.Name = "RarityBox";
            this.RarityBox.Size = new System.Drawing.Size(30, 20);
            this.RarityBox.TabIndex = 74;
            this.RarityBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // JobLabel
            // 
            this.JobLabel.AutoSize = true;
            this.JobLabel.Location = new System.Drawing.Point(146, 3);
            this.JobLabel.Name = "JobLabel";
            this.JobLabel.Size = new System.Drawing.Size(37, 13);
            this.JobLabel.TabIndex = 75;
            this.JobLabel.Text = "職業：";
            // 
            // JobBox
            // 
            this.JobBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.JobBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.JobBox.FormattingEnabled = true;
            this.JobBox.Items.AddRange(new object[] {
            "剣士",
            "武道家",
            "ウォリアー",
            "ランサー",
            "アーチャー",
            "魔道士",
            "クロスセイバー",
            "ドラゴンライダー",
            "ヴァリアント"});
            this.JobBox.Location = new System.Drawing.Point(179, 1);
            this.JobBox.Name = "JobBox";
            this.JobBox.Size = new System.Drawing.Size(92, 21);
            this.JobBox.TabIndex = 76;
            // 
            // TypeBox
            // 
            this.TypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeBox.FormattingEnabled = true;
            this.TypeBox.Items.AddRange(new object[] {
            "ヒーロー",
            "アタッカー",
            "ディフェンス",
            "バランス",
            "テクニカル",
            "スキル",
            "サポート"});
            this.TypeBox.Location = new System.Drawing.Point(43, 23);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.Size = new System.Drawing.Size(75, 21);
            this.TypeBox.TabIndex = 77;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(2, 26);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(39, 13);
            this.TypeLabel.TabIndex = 78;
            this.TypeLabel.Text = "タイプ：";
            // 
            // RareTypeLabel
            // 
            this.RareTypeLabel.AutoSize = true;
            this.RareTypeLabel.Location = new System.Drawing.Point(120, 26);
            this.RareTypeLabel.Name = "RareTypeLabel";
            this.RareTypeLabel.Size = new System.Drawing.Size(37, 13);
            this.RareTypeLabel.TabIndex = 79;
            this.RareTypeLabel.Text = "種類：";
            // 
            // RareTypeBox
            // 
            this.RareTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RareTypeBox.FormattingEnabled = true;
            this.RareTypeBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RareTypeBox.Items.AddRange(new object[] {
            "配布",
            "フォースター",
            "限定",
            "入替限定"});
            this.RareTypeBox.Location = new System.Drawing.Point(153, 23);
            this.RareTypeBox.Name = "RareTypeBox";
            this.RareTypeBox.Size = new System.Drawing.Size(74, 21);
            this.RareTypeBox.TabIndex = 80;
            // 
            // CharacterList
            // 
            this.CharacterList.AllowUserToAddRows = false;
            this.CharacterList.AllowUserToDeleteRows = false;
            this.CharacterList.AllowUserToOrderColumns = true;
            this.CharacterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.RarityColumn,
            this.NameColumn,
            this.JobColumn,
            this.TypeColumn,
            this.RareTypeColumn,
            this.AttributeColumn,
            this.Edit,
            this.Delete});
            this.CharacterList.Location = new System.Drawing.Point(1, 49);
            this.CharacterList.Name = "CharacterList";
            this.CharacterList.ReadOnly = true;
            this.CharacterList.RowHeadersWidth = 4;
            this.CharacterList.Size = new System.Drawing.Size(409, 244);
            this.CharacterList.TabIndex = 87;
            this.CharacterList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CharacterList_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "属性：";
            // 
            // AttributeBox
            // 
            this.AttributeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AttributeBox.FormattingEnabled = true;
            this.AttributeBox.Items.AddRange(new object[] {
            "無属性",
            "火属性",
            "水属性",
            "雷属性",
            "闇属性",
            "光属性"});
            this.AttributeBox.Location = new System.Drawing.Point(263, 23);
            this.AttributeBox.Name = "AttributeBox";
            this.AttributeBox.Size = new System.Drawing.Size(67, 21);
            this.AttributeBox.TabIndex = 90;
            // 
            // Apply
            // 
            this.Apply.Enabled = false;
            this.Apply.Image = ((System.Drawing.Image)(resources.GetObject("Apply.Image")));
            this.Apply.Location = new System.Drawing.Point(386, 1);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(24, 24);
            this.Apply.TabIndex = 91;
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // IDColumn
            // 
            this.IDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.IDColumn.Frozen = true;
            this.IDColumn.HeaderText = "ID:";
            this.IDColumn.MaxInputLength = 5;
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IDColumn.Width = 5;
            // 
            // RarityColumn
            // 
            this.RarityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.RarityColumn.Frozen = true;
            this.RarityColumn.HeaderText = "レアリティ:";
            this.RarityColumn.MaxInputLength = 1;
            this.RarityColumn.Name = "RarityColumn";
            this.RarityColumn.ReadOnly = true;
            this.RarityColumn.Width = 5;
            // 
            // NameColumn
            // 
            this.NameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.NameColumn.Frozen = true;
            this.NameColumn.HeaderText = "キャラ名：";
            this.NameColumn.MaxInputLength = 50;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 5;
            // 
            // JobColumn
            // 
            this.JobColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.JobColumn.Frozen = true;
            this.JobColumn.HeaderText = "職業";
            this.JobColumn.MaxInputLength = 10;
            this.JobColumn.Name = "JobColumn";
            this.JobColumn.ReadOnly = true;
            this.JobColumn.Width = 5;
            // 
            // TypeColumn
            // 
            this.TypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.TypeColumn.Frozen = true;
            this.TypeColumn.HeaderText = "タイプ：";
            this.TypeColumn.MaxInputLength = 10;
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            this.TypeColumn.Width = 5;
            // 
            // RareTypeColumn
            // 
            this.RareTypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.RareTypeColumn.Frozen = true;
            this.RareTypeColumn.HeaderText = "種類：";
            this.RareTypeColumn.MaxInputLength = 10;
            this.RareTypeColumn.Name = "RareTypeColumn";
            this.RareTypeColumn.ReadOnly = true;
            this.RareTypeColumn.Width = 5;
            // 
            // AttributeColumn
            // 
            this.AttributeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.AttributeColumn.Frozen = true;
            this.AttributeColumn.HeaderText = "属性";
            this.AttributeColumn.Name = "AttributeColumn";
            this.AttributeColumn.ReadOnly = true;
            this.AttributeColumn.Width = 5;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Edit.Frozen = true;
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "編集";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 5;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Delete.Frozen = true;
            this.Delete.HeaderText = "";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "削除";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 5;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(411, 294);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.AttributeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CharacterList);
            this.Controls.Add(this.RareTypeBox);
            this.Controls.Add(this.RareTypeLabel);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.TypeBox);
            this.Controls.Add(this.JobBox);
            this.Controls.Add(this.JobLabel);
            this.Controls.Add(this.RarityBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.RarityLabel);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.NameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "白猫キャラDBエディター";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RarityBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CharacterList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label RarityLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.NumericUpDown RarityBox;
        private System.Windows.Forms.Label JobLabel;
        private System.Windows.Forms.ComboBox JobBox;
        private System.Windows.Forms.ComboBox TypeBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label RareTypeLabel;
        private System.Windows.Forms.ComboBox RareTypeBox;
        private System.Windows.Forms.DataGridView CharacterList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AttributeBox;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RarityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RareTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AttributeColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}

