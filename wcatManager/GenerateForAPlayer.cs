using System;
using System.Windows.Forms;

namespace wcatManager
{
    public partial class GenerateForAPlayer : Form
    {

        public GenerateForAPlayer()
        {
            InitializeComponent();
        }

        private void GenerateForOne_Click(object sender, EventArgs e)
        {
            string ErrorMsg = ((Main)this.Owner).SetConditions();
            if (!((Main)this.Owner).Error)
            {
                ((Main)this.Owner).One = GenerateForOneLabel;
                ((Main)this.Owner).Players = 1;
                ((Main)this.Owner).SettingStatus(false);
                ((Main)this.Owner).Timerfor4.Start();
            }
            else
            {
                ((Main)this.Owner).Error = false;
                MessageBox.Show(ErrorMsg, "", MessageBoxButtons.OK);
            }
        }
    }
}