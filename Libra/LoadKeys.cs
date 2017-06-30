using System;
using System.Windows.Forms;
using Gemini;

namespace Libra
{
	public partial class LoadKeys : Form
	{
		public LoadKeys()
		{
			InitializeComponent();
		}

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			using (var file = new OpenFileDialog())
			{
				if (file.ShowDialog() == DialogResult.OK)
				{
					tbFile.Text = file.FileName;
					Properties.Settings.Default["DefaultWallet"] = file.FileName;
					Properties.Settings.Default.Save();
				}
			}
		}

		private void buttonUnlock_Click(object sender, EventArgs e)
		{
			try
			{
				GeminiClient.Wallet.Open(tbFile.Text, tbPassword.Text);
				this.Close();
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.Message, "API Key File Exception");
			}
		}
	}
}
