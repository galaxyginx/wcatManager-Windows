using System;
using System.Drawing;
using System.Windows.Forms;

namespace wcatManager
{
    public partial class ResultWindow : Form
    {
        public ResultWindow()
        {
            InitializeComponent();
            FirstPlayer.Text = "";
            SecondPlayer.Text = "";
            ThirdPlayer.Text = "";
            FourthPlayer.Text = "";
            FirstPlayer.ForeColor = Color.Black;
            SecondPlayer.ForeColor = Color.Black;
            ThirdPlayer.ForeColor = Color.Black;
            FourthPlayer.ForeColor = Color.Black;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ((Main)this.Owner).OtherWindow();
            ((Main)this.Owner).Timerfor4.Start();
        }
    }
}