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
            Properties.Settings.Default["RefreshRate"] = (int)this.refreshRateUpDown.Value;
            Properties.Settings.Default["RequireConfirmations"] = checkConfirm.CheckState.Equals(CheckState.Checked);
            Properties.Settings.Default["DefaultWallet"] = walletTextBox.Text;
            Properties.Settings.Default.Save();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            refreshRateUpDown.Value = (int)Properties.Settings.Default["RefreshRate"];
            walletTextBox.Text = (string)Properties.Settings.Default["DefaultWallet"];

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
    }
}
