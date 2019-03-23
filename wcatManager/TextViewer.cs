using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wcatManager
{
    public partial class TextViewer : Form
    {
        public TextViewer()
        {
            InitializeComponent();
        }

        private void TextViewer_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(((Main)this.Owner).File))
            {
                //"C:\test\1.txt"をShift-JISコードとして開く
                System.IO.StreamReader sr = new System.IO.StreamReader(
                    ((Main)this.Owner).File,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                //内容をすべて読み込む
                string s = sr.ReadToEnd();
                //閉じる
                sr.Close();
                Viewer.Text = s;
            }
            else
            {
                MessageBox.Show("ファイルが見つかりません。", "エラー", MessageBoxButtons.OK);
                Close();
            }
        }
    }
}
