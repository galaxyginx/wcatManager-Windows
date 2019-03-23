namespace wcatManager
{
    partial class TextViewer
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
            this.Viewer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Viewer
            // 
            this.Viewer.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Viewer.Location = new System.Drawing.Point(1, 1);
            this.Viewer.Multiline = true;
            this.Viewer.Name = "Viewer";
            this.Viewer.ReadOnly = true;
            this.Viewer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Viewer.Size = new System.Drawing.Size(563, 259);
            this.Viewer.TabIndex = 2;
            // 
            // TextViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 262);
            this.Controls.Add(this.Viewer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TextViewer";
            this.Text = "TextViewer";
            this.Load += new System.EventHandler(this.TextViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox Viewer;
    }
}