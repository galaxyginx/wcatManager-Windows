namespace wcatManager
{
    partial class GenerateForAPlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerateForAPlayer));
            this.GenerateOneBox = new System.Windows.Forms.GroupBox();
            this.GenerateForOneLabel = new System.Windows.Forms.Label();
            this.GenerateForOne = new System.Windows.Forms.Button();
            this.GenerateOneBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GenerateOneBox
            // 
            this.GenerateOneBox.Controls.Add(this.GenerateForOneLabel);
            this.GenerateOneBox.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GenerateOneBox.Location = new System.Drawing.Point(1, 1);
            this.GenerateOneBox.Name = "GenerateOneBox";
            this.GenerateOneBox.Size = new System.Drawing.Size(202, 116);
            this.GenerateOneBox.TabIndex = 0;
            this.GenerateOneBox.TabStop = false;
            this.GenerateOneBox.Text = "一人用結果：";
            // 
            // GenerateForOneLabel
            // 
            this.GenerateForOneLabel.AutoSize = true;
            this.GenerateForOneLabel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GenerateForOneLabel.Location = new System.Drawing.Point(3, 22);
            this.GenerateForOneLabel.Name = "GenerateForOneLabel";
            this.GenerateForOneLabel.Size = new System.Drawing.Size(197, 24);
            this.GenerateForOneLabel.TabIndex = 0;
            this.GenerateForOneLabel.Text = "Generate For A Player";
            // 
            // GenerateForOne
            // 
            this.GenerateForOne.Location = new System.Drawing.Point(65, 117);
            this.GenerateForOne.Name = "GenerateForOne";
            this.GenerateForOne.Size = new System.Drawing.Size(75, 23);
            this.GenerateForOne.TabIndex = 1;
            this.GenerateForOne.Text = "Generate";
            this.GenerateForOne.UseVisualStyleBackColor = true;
            this.GenerateForOne.Click += new System.EventHandler(this.GenerateForOne_Click);
            // 
            // GenerateForAPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(204, 141);
            this.Controls.Add(this.GenerateForOne);
            this.Controls.Add(this.GenerateOneBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GenerateForAPlayer";
            this.Text = "GenerateForAPlayer";
            this.GenerateOneBox.ResumeLayout(false);
            this.GenerateOneBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GenerateOneBox;
        private System.Windows.Forms.Button GenerateForOne;
        private System.Windows.Forms.Label GenerateForOneLabel;
    }
}