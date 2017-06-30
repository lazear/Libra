using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gemini;

namespace Libra
{
	public partial class LibraMain : Form
	{
		private System.Windows.Forms.Timer runtime = new System.Windows.Forms.Timer();
		private System.Windows.Forms.Timer accounts = new System.Windows.Forms.Timer();
		public static Dictionary<string, decimal> ExchangeRates = new Dictionary<string, decimal>
			{ { "btcusd", 0M }, { "ethusd", 0M }, { "ethbtc", 0M }, };

		public LibraMain()
		{
			InitializeComponent();
			AppDomain.CurrentDomain.ProcessExit += Exit;
			GeminiClient.InstallErrorHandler(ErrorHandler);

			runtime.Tick += UpdateRuntime;
			runtime.Interval = 1000;
			runtime.Start();

			accounts.Tick += UpdatePrices;
			accounts.Tick += UpdateAccounts;
			accounts.Interval = 5000;
			accounts.Start();

			UpdatePrices(null, null);
			UpdateAccounts(null, null);

		}

		private void ErrorHandler(string reason, string message)
		{
			if (reason == "InvalidNonce")
			{
				GeminiClient.Wallet.IncreaseNonce(30);
				return;
			}
			MessageBox.Show(message, reason);
		}

		private void UpdateRuntime(object sender, EventArgs e)
		{
			var uptime = DateTime.Now - System.Diagnostics.Process.GetCurrentProcess().StartTime;
			uptimeStatusLabel.Text = TimeSpan.FromSeconds(Math.Round(uptime.TotalSeconds, 0)).ToString();
		}

		private async void UpdatePrices(object sender, EventArgs e)
		{

			float[] last = { 0.0F, 0.0F };

			try
			{
				string[] symbols = { "btcusd", "ethusd", "btcusd" };
				foreach (string symbol in symbols)
				{
					Requests re = new Requests("https://api.gemini.com/v1/pubticker/" + symbol);
					var res = await re.Get();
					ExchangeRates[symbol] = res.Json<Gemini.Contracts.Ticker>().Last;

				}
			}
			catch {	}

		}

		/// <summary>
		/// Thread for updating runtime, checking prices, and watching for stop order triggers
		/// </summary>
		private void UpdateAccounts(object sender, EventArgs e)
		{
			var uptime = DateTime.Now - System.Diagnostics.Process.GetCurrentProcess().StartTime;

			string[] symbols = { "btcusd", "ethusd", "ethbtc" };

			uptimeStatusLabel.Text = TimeSpan.FromSeconds(Math.Round(uptime.TotalSeconds, 0)).ToString();

			connectionStatusLabel.Text = String.Format("Connected: {0}     {1}", GeminiClient.Wallet.Key(), 
				symbols.Aggregate(new StringBuilder(), 
								(sb, s) => sb.Append(String.Format("{0}: {1}  ", s.ToUpper(), ExchangeRates[s])), 
								(sb) => sb.ToString()));

			try
			{
				var assets = 0.0M;
				var balances = GeminiClient.GetBalances();
				foreach(var balance in balances)
				{
					switch (balance.Currency)
					{
						case "BTC":
							textboxBtcBalance.Text = balance.Amount.ToString();
							assets += balance.Amount * ExchangeRates["btcusd"];
							break;
						case "ETH":
							textboxEthBalance.Text = balance.Amount.ToString();
							assets += balance.Amount * ExchangeRates["ethusd"];
							break;
						case "USD":
							textboxUsdBalance.Text = balance.Amount.ToString();
							assets += balance.Amount;
							break;
					}
				}
				labelAssetValue.Text = String.Format("Total Value: ${0}", Math.Round(assets, 2));

			} catch { };

		


			//foreach(Watchdog.Watch w in Watchdog.Watchlist)
			//{
			//	var exist = treeView1.Nodes.Find(w.GetHashCode().ToString(), true);
			//	var status = Enum.GetName(typeof(GeminiOrderStatus), w.Order.Status());

			//	if (exist.Count() != 0)
			//	{
			//		var node = exist.First();
			//		if (node.Parent.Name != status)
			//		{
			//			node.Remove();
			//			treeView1.Nodes[status].Nodes.Add(exist.First());
			//		}

			//		//exist.First().Parent = treeView1.Nodes[w.Order.Status().ToString()];
			//	}
			//	else
			//	{
			//		treeView1.Nodes[status].Nodes.Add(w.GetHashCode().ToString(), w.Order.ToString());
			//	}


			//}

		}

		/// <summary>
		/// Handle application close
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Exit(object sender, EventArgs e)
		{
			GeminiClient.Wallet.Close();
		}


		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new About().Show();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Exit(sender, e);
		}

		private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new Settings().Show();
		}

		private void bLoadWallet_Click(object sender, EventArgs e)
		{
			new LoadKeys().ShowDialog();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			GeminiClient.Wallet.Close();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new NewKeys().ShowDialog();
		}

		private void bPlaceOrder_Click(object sender, EventArgs e)
		{
			new OrderForm().Show();
		}
	}
}
