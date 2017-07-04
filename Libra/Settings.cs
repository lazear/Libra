using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libra
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void checkAdvanced_CheckedChanged(object sender, EventArgs e)
        {
            gbAdvanced.Enabled = !gbAdvanced.Enabled;
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["RequireConfirmations"] = checkConfirm.CheckState.Equals(CheckState.Checked);
            Properties.Settings.Default["DefaultWallet"] = walletTextBox.Text;
			Properties.Settings.Default["DefaultLogFile"] = logTextBox.Text;
			Properties.Settings.Default.Save();
			this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

            walletTextBox.Text = (string)Properties.Settings.Default["DefaultWallet"];
			logTextBox.Text = (string)Properties.Settings.Default["DefaultLogFile"];
			if ((bool)Properties.Settings.Default["RequireConfirmations"])
                checkConfirm.CheckState = CheckState.Checked;
            else
                checkConfirm.CheckState = CheckState.Unchecked;

        }

        private void buttonWallet_Click(object sender, EventArgs e)
        {
            using (var file = new OpenFileDialog())
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    walletTextBox.Text = file.FileName;
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void button1_Click(object sender, EventArgs e)
		{
			using (var file = new OpenFileDialog())
			{
				if (file.ShowDialog() == DialogResult.OK)
				{
					logTextBox.Text = file.FileName;
				}
			}
		}

	}
}
