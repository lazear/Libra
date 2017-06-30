using System;
using System.Windows.Forms;
using Gemini;

namespace Libra
{
	public partial class NewKeys : Form
	{
		public NewKeys()
		{
			InitializeComponent();
		}

		private void saveWalletButton_Click(object sender, EventArgs e)
		{
			var password = passwordTextBox.Text;
			if (password == confirmTextBox.Text)
			{
				if (password == String.Empty)
				{
					MessageBox.Show("You may not use an empty password. Unencrypted API Keys are NOT supported.", "Password Warning");
					return;
				}
				var file = new SaveFileDialog();

				if (file.ShowDialog() == DialogResult.OK)
				{
					try
					{
						string url = (string)Properties.Settings.Default["Api"];
						if (checkBox1.Checked)
							url = (string)Properties.Settings.Default["ApiSandbox"];

						GeminiClient.Wallet.Create(new GeminiWallet() { Key = apiKeyTextBox.Text, Secret = apiSecretTextBox.Text, Url = url },
							file.FileName, password);
						this.Close();
					}
					catch (System.Exception ex)
					{
						MessageBox.Show(string.Format("Erroring creating wallet: {0}", ex.Message));
					}

				}
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(linkLabel1.Text);
		}
	}
}