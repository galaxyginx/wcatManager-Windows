namespace wcatManager
{
    partial class ResultWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultWindow));
            this.ShowResaultof4 = new System.Windows.Forms.GroupBox();
            this.TRResult = new System.Windows.Forms.Label();
            this.FourthPlayer = new System.Windows.Forms.Label();
            this.ThirdPlayer = new System.Windows.Forms.Label();
            this.SecondPlayer = new System.Windows.Forms.Label();
            this.FirstPlayer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ShowResaultof4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ShowResaultof4
            // 
            this.ShowResaultof4.BackColor = System.Drawing.Color.White;
            this.ShowResaultof4.Controls.Add(this.TRResult);
            this.ShowResaultof4.Controls.Add(this.FourthPlayer);
            this.ShowResaultof4.Controls.Add(this.ThirdPlayer);
            this.ShowResaultof4.Controls.Add(this.SecondPlayer);
            this.ShowResaultof4.Controls.Add(this.FirstPlayer);
            this.ShowResaultof4.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShowResaultof4.Location = new System.Drawing.Point(1, 2);
            this.ShowResaultof4.Name = "ShowResaultof4";
            this.ShowResaultof4.Size = new System.Drawing.Size(487, 208);
            this.ShowResaultof4.TabIndex = 8;
            this.ShowResaultof4.TabStop = false;
            this.ShowResaultof4.Text = "結果：";
            // 
            // TRResult
            // 
            this.TRResult.AutoSize = true;
            this.TRResult.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TRResult.ForeColor = System.Drawing.Color.Red;
            this.TRResult.Location = new System.Drawing.Point(121, 103);
            this.TRResult.Name = "TRResult";
            this.TRResult.Size = new System.Drawing.Size(210, 23);
            this.TRResult.TabIndex = 8;
            this.TRResult.Text = "レアリティ合計値： 設定なし";
            // 
            // FourthPlayer
            // 
            this.FourthPlayer.AutoSize = true;
            this.FourthPlayer.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Bold);
            this.FourthPlayer.Location = new System.Drawing.Point(248, 134);
            this.FourthPlayer.Name = "FourthPlayer";
            this.FourthPlayer.Size = new System.Drawing.Size(116, 23);
            this.FourthPlayer.TabIndex = 3;
            this.FourthPlayer.Text = "Fourth Player";
            // 
            // ThirdPlayer
            // 
            this.ThirdPlayer.AutoSize = true;
            this.ThirdPlayer.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Bold);
            this.ThirdPlayer.Location = new System.Drawing.Point(37, 134);
            this.ThirdPlayer.Name = "ThirdPlayer";
            this.ThirdPlayer.Size = new System.Drawing.Size(106, 23);
            this.ThirdPlayer.TabIndex = 2;
            this.ThirdPlayer.Text = "Third Player";
            // 
            // SecondPlayer
            // 
            this.SecondPlayer.AutoSize = true;
            this.SecondPlayer.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Bold);
            this.SecondPlayer.Location = new System.Drawing.Point(248, 43);
            this.SecondPlayer.Name = "SecondPlayer";
            this.SecondPlayer.Size = new System.Drawing.Size(121, 23);
            this.SecondPlayer.TabIndex = 1;
            this.SecondPlayer.Text = "Second Player";
            // 
            // FirstPlayer
            // 
            this.FirstPlayer.AutoSize = true;
            this.FirstPlayer.Font = new System.Drawing.Font("メイリオ", 11F, System.Drawing.FontStyle.Bold);
            this.FirstPlayer.Location = new System.Drawing.Point(37, 43);
            this.FirstPlayer.Name = "FirstPlayer";
            this.FirstPlayer.Size = new System.Drawing.Size(99, 23);
            this.FirstPlayer.TabIndex = 0;
            this.FirstPlayer.Text = "First Player";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(189, 210);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "再生成";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ResultWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(490, 234);
            this.Controls.Add(this.ShowResaultof4);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultWindow";
            this.Text = "ResultWindow";
            this.ShowResaultof4.ResumeLayout(false);
            this.ShowResaultof4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox ShowResaultof4;
        public System.Windows.Forms.Label TRResult;
        public System.Windows.Forms.Label FourthPlayer;
        public System.Windows.Forms.Label ThirdPlayer;
        public System.Windows.Forms.Label SecondPlayer;
        public System.Windows.Forms.Label FirstPlayer;
        public System.Windows.Forms.Button button1;
    }
}