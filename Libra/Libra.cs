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
using Gemini.Contracts;

namespace Libra
{

	public partial class LibraMain : Form
	{
		private System.Windows.Forms.Timer runtime = new System.Windows.Forms.Timer();
		private System.Windows.Forms.Timer accounts = new System.Windows.Forms.Timer();


		public LibraMain()
		{
			InitializeComponent();
			AppDomain.CurrentDomain.ProcessExit += Exit;

			/* Callback for API errors */
			GeminiClient.InstallErrorHandler(ErrorHandler);

			/* Update runtime clock every second  */
			runtime.Tick += UpdateRuntime;
			runtime.Interval = 1000;
			runtime.Start();


			/* Also update account balance whenever API Keys are loaded */
			GeminiClient.Wallet.OnChange += UpdateAccounts;
			GeminiClient.Wallet.OnChange += OrderEventStart;
			GeminiClient.Wallet.OnChange += delegate(object sender, EventArgs e) { labelAddress.Text = GeminiClient.Wallet.Key(); };

			/* Initialize Websockets */
			InitialPrices();
			MarketDataStart();
			
			/* Websocket PriceChanged event handles ticker data and pending Stop orders */
			PriceChanged += UpdateTicker;
			PriceChanged += OrderTracker.CheckPendingOrders;

			/* Websocket OrderChanged event */
			OrderChanged += UpdateOrders;
		}

		public void UpdatePastOrders(object state, ProgressChangedEventArgs e)
		{
			PastTrade status = e.UserState as PastTrade;
			treeOrders.Nodes["Past"].Nodes.Add(status.OrderID, status.OrderID);
			
		}

		public void LoadPastOrders(object sender, DoWorkEventArgs e)
		{
			string[] symbols = { "btcusd", "ethusd", "ethbtc" };

			foreach(var symbol in symbols)
			{
				foreach(var trade in GeminiClient.GetPastTrades(symbol, 50, 0))
					(sender as BackgroundWorker).ReportProgress(0, trade);

			};
		}

		private void ErrorHandler(string reason, string message)
		{
			if (reason == "InvalidNonce")
			{
				GeminiClient.Wallet.IncreaseNonce(30);
				return;
			}
			if (reason == "RateLimit")
			{
				MessageBox.Show("We're going too fast... attemping to tap the brakes", "Rate Limit Hit");
				return;
			}
			MessageBox.Show(message, reason);
		}

		/// <summary>
		/// Display information on the selected treeview node
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (treeOrders.SelectedNode == null || treeOrders.SelectedNode.Level == 0)
			{
				rtbOrder.Clear();
				return;
			}
			var selected = treeOrders.SelectedNode;

			if (selected.Parent.Name == "Pending")
			{
				var status = OrderTracker.Pending.Find((x) => x.ClientOrderID == selected.Name);
				rtbOrder.Text = String.Format("Pending Stop order\n{0} {1} {2} @ {3}",
					status.Side.ToUpper(),
					status.Amount,
					status.Symbol.ToUpper(),
					status.Price);
			}
			else
			{
				try
				{
					OrderEvent status = OrderTracker.Orders[selected.Text];

					var side = (status.Side == "buy") ? "Buy" : "Sell";

					/* parse out respective currencies */
					var c1 = status.Symbol.Substring(0, 3).ToUpper();
					var c2 = status.Symbol.Substring(3).ToUpper();

					/* make it all look purdy */
					var price = status.Price.ToString();
					if (c2 == "USD")
						price = "$" + price;
					else
						price += " " + c2;

					var eprice = status.AvgExecutionPrice.ToString();
					if (c2 == "USD")
						eprice = "$" + eprice;
					else
						eprice += " " + c2;

					var timestamp = DateTimeOffset.FromUnixTimeMilliseconds(status.TimestampMs);
					var total = OrderForm.crts(status.ExecutedAmount * status.AvgExecutionPrice, c2) + " " + c2;
					var expected = OrderForm.crts(status.OriginalAmount * status.Price, c2) + " " + c2;

					rtbOrder.Text = String.Format("{0} Order {1}\nPlaced:   {2} {3} @ {4}",
						side, timestamp.UtcDateTime, status.OriginalAmount, c1, price);
					rtbOrder.AppendText(String.Format("\nExecuted: {0} {1} @ {2}\nTotal: {3} / {4}", 
						status.ExecutedAmount, c1, eprice, total, expected));

				}
				catch (Exception ex)
				{
					Logger.WriteException(Logger.Level.Error, ex);
				}

			}
		}

		private void bNewAddress_Click(object sender, EventArgs e)
		{
			try
			{
				tbNewAddress.Text = GeminiClient.GetDepositAddress(cbAddress.Text, "LIBRA" + Time.Timestamp().ToString());
			}
			catch { }
		}

		private void bWithdraw_Click(object sender, EventArgs e)
		{
			try
			{
				GeminiClient.Withdraw(cbWithdraw.Text, tbWithdrawAddress.Text, tbWithdrawAmount.Text);
				UpdateAccounts(null, null);
			}
			catch { }
		}

		private void bMaxWithdraw_Click(object sender, EventArgs e)
		{
			try
			{
				tbWithdrawAmount.Text = GeminiClient.GetBalances()
					.First((x) => x.Currency == cbWithdraw.Text)
					.AvailableForWithdrawal.ToString();
			}
			catch { }
		}

		/// <summary>
		/// Handle application close
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Exit(object sender, EventArgs e)
		{
			try
			{
				foreach (var ws in sockets)
					ws.rc = null;
				GeminiClient.Wallet.Close();
			}
			 catch { }

		}


		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			new About().Show();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Exit(sender, e);
			this.Close();
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


		/// <summary>
		/// Cancel the order selected in the tree view object
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bCancelSelect_Click(object sender, EventArgs e)
		{
			if (treeOrders.SelectedNode == null)
				return;
			if (treeOrders.SelectedNode?.Level == 0)
				return;
			var node = treeOrders.SelectedNode.Name;
			var selected = treeOrders.SelectedNode;

			/* This isn't really a *real* order yet */
			if (selected.Parent.Name == "Pending")
			{
				if ((bool)Properties.Settings.Default["RequireConfirmations"])
				{
					if (MessageBox.Show("Confirm cancellation of order " + node, "Cancel Order", MessageBoxButtons.YesNo) == DialogResult.No)
						return;
				}
				OrderTracker.Pending.Remove(OrderTracker.Pending.Find((x) => x.ClientOrderID == node));
				selected.Remove();
			}

			/* Order is on the books */
			if (selected.Parent.Name == "Active")
			{
				if ((bool)Properties.Settings.Default["RequireConfirmations"])
				{
					if (MessageBox.Show("Confirm cancellation of order " + node, "Cancel Order", MessageBoxButtons.YesNo) == DialogResult.No)
						return;
				}
				try
				{
					var res = GeminiClient.CancelOrder(int.Parse(selected.Text));
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					Logger.WriteException(Logger.Level.Error, ex);
				}
			}
		}


		private void bCancelAll_Click(object sender, EventArgs e)
		{
			if ((bool)Properties.Settings.Default["RequireConfirmations"])
			{
				if (MessageBox.Show("Confirm cancellation of all orders", "Cancel Order", MessageBoxButtons.YesNo) == DialogResult.No)
					return;
			}
			try
			{
				GeminiClient.CancelAll();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Logger.WriteException(Logger.Level.Error, ex);
			}

		}

		private void bCancelSession_Click(object sender, EventArgs e)
		{
			if ((bool)Properties.Settings.Default["RequireConfirmations"])
			{
				if (MessageBox.Show("Confirm cancellation of session orders", "Cancel Order", MessageBoxButtons.YesNo) == DialogResult.No)
					return;
			}
			try
			{
				GeminiClient.CancelSession();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				Logger.WriteException(Logger.Level.Error, ex);
			}
			
		}

		private void bLoadPast_Click(object sender, EventArgs e)
		{
			treeOrders.Nodes["Past"].Nodes.Clear();

			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.ProgressChanged += UpdatePastOrders;
			worker.DoWork += LoadPastOrders;

			worker.RunWorkerAsync();

		}

		private void LibraMain_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				notifyIcon.ShowBalloonTip(50);
				this.Hide();
			}
		}
		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
			this.ShowInTaskbar = true;
		}
	}


}
