namespace SQLiteManager
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
            this.Adder = new System.Windows.Forms.Button();
            this.AdderTextBox = new System.Windows.Forms.TextBox();
            this.Binds = new System.Windows.Forms.Button();
            this.Maps = new System.Windows.Forms.Button();
            this.Jobs = new System.Windows.Forms.Button();
            this.Types = new System.Windows.Forms.Button();
            this.MapDifficulty = new System.Windows.Forms.NumericUpDown();
            this.Delete = new System.Windows.Forms.Button();
            this.DataList = new System.Windows.Forms.DataGridView();
            this.DifficultyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.MapDifficulty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataList)).BeginInit();
            this.SuspendLayout();
            // 
            // Adder
            // 
            this.Adder.BackColor = System.Drawing.Color.White;
            this.Adder.Image = ((System.Drawing.Image)(resources.GetObject("Adder.Image")));
            this.Adder.Location = new System.Drawing.Point(201, 23);
            this.Adder.Name = "Adder";
            this.Adder.Size = new System.Drawing.Size(24, 24);
            this.Adder.TabIndex = 57;
            this.Adder.UseVisualStyleBackColor = false;
            this.Adder.Click += new System.EventHandler(this.Adder_Click);
            // 
            // AdderTextBox
            // 
            this.AdderTextBox.Location = new System.Drawing.Point(37, 25);
            this.AdderTextBox.Name = "AdderTextBox";
            this.AdderTextBox.Size = new System.Drawing.Size(163, 20);
            this.AdderTextBox.TabIndex = 56;
            // 
            // Binds
            // 
            this.Binds.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Binds.Location = new System.Drawing.Point(1, 1);
            this.Binds.Name = "Binds";
            this.Binds.Size = new System.Drawing.Size(47, 23);
            this.Binds.TabIndex = 59;
            this.Binds.Text = "縛り";
            this.Binds.UseVisualStyleBackColor = true;
            this.Binds.Click += new System.EventHandler(this.Binds_Click);
            // 
            // Maps
            // 
            this.Maps.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Maps.Location = new System.Drawing.Point(48, 1);
            this.Maps.Name = "Maps";
            this.Maps.Size = new System.Drawing.Size(50, 23);
            this.Maps.TabIndex = 60;
            this.Maps.Text = "マップ";
            this.Maps.UseVisualStyleBackColor = true;
            this.Maps.Click += new System.EventHandler(this.Maps_Click);
            // 
            // Jobs
            // 
            this.Jobs.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jobs.Location = new System.Drawing.Point(98, 1);
            this.Jobs.Name = "Jobs";
            this.Jobs.Size = new System.Drawing.Size(50, 23);
            this.Jobs.TabIndex = 63;
            this.Jobs.Text = "職業";
            this.Jobs.UseVisualStyleBackColor = true;
            this.Jobs.Click += new System.EventHandler(this.Jobs_Click);
            // 
            // Types
            // 
            this.Types.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Types.Location = new System.Drawing.Point(148, 1);
            this.Types.Name = "Types";
            this.Types.Size = new System.Drawing.Size(50, 23);
            this.Types.TabIndex = 64;
            this.Types.Text = "タイプ";
            this.Types.UseVisualStyleBackColor = true;
            this.Types.Click += new System.EventHandler(this.Types_Click);
            // 
            // MapDifficulty
            // 
            this.MapDifficulty.Location = new System.Drawing.Point(1, 25);
            this.MapDifficulty.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.MapDifficulty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MapDifficulty.Name = "MapDifficulty";
            this.MapDifficulty.Size = new System.Drawing.Size(35, 20);
            this.MapDifficulty.TabIndex = 65;
            this.MapDifficulty.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // Delete
            // 
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.Location = new System.Drawing.Point(225, 23);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(24, 24);
            this.Delete.TabIndex = 67;
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // DataList
            // 
            this.DataList.AllowUserToAddRows = false;
            this.DataList.AllowUserToDeleteRows = false;
            this.DataList.AllowUserToOrderColumns = true;
            this.DataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DifficultyColumn,
            this.DataColumn});
            this.DataList.Location = new System.Drawing.Point(1, 48);
            this.DataList.Name = "DataList";
            this.DataList.ReadOnly = true;
            this.DataList.RowHeadersWidth = 4;
            this.DataList.Size = new System.Drawing.Size(262, 209);
            this.DataList.TabIndex = 70;
            // 
            // DifficultyColumn
            // 
            this.DifficultyColumn.Frozen = true;
            this.DifficultyColumn.HeaderText = "☆";
            this.DifficultyColumn.MaxInputLength = 2;
            this.DifficultyColumn.Name = "DifficultyColumn";
            this.DifficultyColumn.ReadOnly = true;
            this.DifficultyColumn.Width = 30;
            // 
            // DataColumn
            // 
            this.DataColumn.Frozen = true;
            this.DataColumn.HeaderText = "データ";
            this.DataColumn.MaxInputLength = 50;
            this.DataColumn.Name = "DataColumn";
            this.DataColumn.ReadOnly = true;
            this.DataColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataColumn.Width = 180;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(265, 259);
            this.Controls.Add(this.DataList);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.MapDifficulty);
            this.Controls.Add(this.Types);
            this.Controls.Add(this.Jobs);
            this.Controls.Add(this.Maps);
            this.Controls.Add(this.Binds);
            this.Controls.Add(this.Adder);
            this.Controls.Add(this.AdderTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "基本データエディター";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MapDifficulty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Adder;
        private System.Windows.Forms.TextBox AdderTextBox;
        private System.Windows.Forms.Button Binds;
        private System.Windows.Forms.Button Maps;
        private System.Windows.Forms.Button Jobs;
        private System.Windows.Forms.Button Types;
        private System.Windows.Forms.NumericUpDown MapDifficulty;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.DataGridView DataList;
        private System.Windows.Forms.DataGridViewTextBoxColumn DifficultyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataColumn;
    }
}

