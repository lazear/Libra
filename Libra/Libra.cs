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
		public static Dictionary<string, decimal> ExchangeRates = new Dictionary<string, decimal>
			{ { "btcusd", 0M }, { "ethusd", 0M }, { "ethbtc", 0M }, };

		public LibraMain()
		{
			InitializeComponent();
			AppDomain.CurrentDomain.ProcessExit += Exit;

			/* Callback for API errors */
			GeminiClient.InstallErrorHandler(ErrorHandler);

			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.ProgressChanged += OrderStatusChange;
			worker.DoWork += CheckPendingOrders;

			/* Update runtime every second, as well as check for order updates */
			runtime.Tick += UpdateRuntime;
			runtime.Tick += delegate (object s, EventArgs e) { if (!worker.IsBusy) worker.RunWorkerAsync(); };
			runtime.Interval = (int) Properties.Settings.Default["RefreshRate"];
			runtime.Start();


			/* Update account balance and prices every 5 seconds */
			accounts.Tick += UpdateAccounts;
			accounts.Tick += UpdatePrices;
			accounts.Interval = 5000;
			accounts.Start();

			/* Also update account balance whenever API Keys are loaded */
			GeminiClient.Wallet.OnChange += UpdateAccounts;
			GeminiClient.Wallet.OnChange += LoadActiveOrders;
			GeminiClient.Wallet.OnChange += delegate(object sender, EventArgs e) { labelAddress.Text = GeminiClient.Wallet.Key(); };
		}

		public void UpdatePastOrders(object state, ProgressChangedEventArgs e)
		{
			PastTrade status = e.UserState as PastTrade;
			treeOrders.Nodes["Past"].Nodes.Add(status.OrderID, status.OrderID);
			OrderHandling.Past.Add(status);
			
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


		/// <summary>
		/// If there are open orders from a previous session, load them
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void LoadActiveOrders(object sender, EventArgs e)
		{
			var orders = GeminiClient.GetActiveOrders();
			foreach (var order in orders)
			{
				OrderHandling.Active.Add(order);
				treeOrders.Nodes["Active"].Nodes.Add(order.ClientOrderID, order.OrderID);
			}

		}

		/// <summary>
		/// Update status strip with runtime and current prices
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdateRuntime(object sender, EventArgs e)
		{
			string[] symbols = { "btcusd", "ethusd", "ethbtc" };
			var uptime = DateTime.Now - System.Diagnostics.Process.GetCurrentProcess().StartTime;
			uptimeStatusLabel.Text = TimeSpan.FromSeconds(Math.Round(uptime.TotalSeconds, 0)).ToString();

			var ex = symbols.Aggregate(new StringBuilder(),
					(sb, s) => sb.Append(String.Format("{0}: {1}  ", s.ToUpper(), ExchangeRates[s])),
					(sb) => sb.ToString());

			connectionStatusLabel.Text = String.Format("Connected: {0}     {1}", GeminiClient.Wallet.Key(), ex);
		}

		/// <summary>
		/// Fetch currenct exchange prices
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void UpdatePrices(object sender, EventArgs e)
		{
			string[] symbols = { "btcusd", "ethusd", "ethbtc" };
			Parallel.ForEach(symbols, async symbol =>
			{
				Requests re = new Requests(GeminiClient.Wallet.Url() + "/v1/pubticker/" + symbol);
				var res = await re.Get();
				if (res.IsSuccessStatusCode)
					ExchangeRates[symbol] = res.Json<Gemini.Contracts.Ticker>().Last;

			});

			var ex2 = symbols.Aggregate(new StringBuilder(),
				(sb, s) => sb.Append(String.Format("{0}: {1}\n", s.ToUpper(), ExchangeRates[s])),
				(sb) => sb.ToString());
			rtbRates.Text = ex2;
		}

		/// <summary>
		/// Callback for when an order is placed, or status has changed
		/// </summary>
		/// <param name="state"></param>
		/// <param name="e"></param>
		private void OrderStatusChange(object state, ProgressChangedEventArgs e)
		{
			OrderStatus status = e.UserState as OrderStatus;
			var exist = treeOrders.Nodes.Find(status.ClientOrderID, true);
			if (exist.Count() > 0)
			{
				if (status.Type != "stop")
					exist.First().Remove();
				else
					return;
			}
			if (status.Type == "stop")
			{
				treeOrders.Nodes["Pending"].Nodes.Add(status.ClientOrderID, status.ClientOrderID);
				return;
			}

			if (status.IsLive)
			{
				treeOrders.Nodes["Active"].Nodes.Add(status.ClientOrderID, status.OrderID);
				OrderHandling.Active.Add(status);
				activeOrdersToolStripMenuItem.Text = OrderHandling.Active.Count + " active orders";
			}
			else if (status.IsCancelled)
			{
				treeOrders.Nodes["Cancelled"].Nodes.Add(status.ClientOrderID, status.OrderID);
				OrderHandling.Cancelled.Add(status);
			}
			else
			{
				treeOrders.Nodes["Completed"].Nodes.Add(status.ClientOrderID, status.OrderID);
				OrderHandling.Completed.Add(status);
			}

		}

		/// <summary>
		/// Check all orders in the pending order queue, and execute them 
		/// if the condition has been met
		/// </summary>
		/// <param name="state"></param>
		/// <param name="e"></param>
		private void CheckPendingOrders(object state, EventArgs e)
		{
			Parallel.ForEach(OrderHandling.PendingStop, order =>
			{
				var price = decimal.Parse(order.Price);
				if (order.Side == "buy")
				{
					/* If currenct price is above the stop-buy price, execute */
					if (price <= ExchangeRates[order.Symbol])
					{
						order.Price = (ExchangeRates[order.Symbol] + 1.0M).ToString();
						var status = GeminiClient.PlaceOrder(order);
						OrderHandling.PendingStop.Remove(order);
						((BackgroundWorker)state).ReportProgress(0, status);
					}
					else
					{
						((BackgroundWorker)state).ReportProgress(0, new OrderStatus()
						{
							Type = "stop",
							ClientOrderID = order.ClientOrderID,
						});
					}
				}
				else
				{
					/* if curenct price is below the stop-loss price, execute */
					if (price >= ExchangeRates[order.Symbol])
					{
						/* Decrease by 10, since this is still viewed as a limit order
							* by the server, and this increases our chances of getting filled */
						order.Price = (ExchangeRates[order.Symbol] - 10M).ToString();
						var status = GeminiClient.PlaceOrder(order);
						OrderHandling.PendingStop.Remove(order);
						/* Report back that we've placed an order */
						((BackgroundWorker)state).ReportProgress(0, status);
					}
					else
					{
						((BackgroundWorker)state).ReportProgress(0, new OrderStatus()
						{
							Type = "stop",
							ClientOrderID = order.ClientOrderID,
						});
					}
				}
			});

			Parallel.ForEach(OrderHandling.PendingLimit, order =>
			{
				OrderHandling.PendingLimit.Remove(order);
				((BackgroundWorker)state).ReportProgress(0, GeminiClient.PlaceOrder(order));
			});

			Parallel.ForEach(OrderHandling.Active, order =>
			{
				var status = GeminiClient.GetOrder(int.Parse(order.OrderID));
				if (!status.IsLive)
				{
					OrderHandling.Active.Remove(order);
					(state as BackgroundWorker).ReportProgress(0, status);
				}

			});

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
				//MessageBox.Show("We're going too fast... attemping to tap the brakes", "Rate Limit Hit");
				Thread.Sleep(1000);
				return;
			}
			MessageBox.Show(message, reason);
		}


		/// <summary>
		/// Thread for updating runtime, checking prices, and watching for stop order triggers
		/// </summary>
		private void UpdateAccounts(object sender, EventArgs e)
		{
			string[] symbols = { "btcusd", "ethusd", "ethbtc" };
			try
			{
				var assets = 0.0M;
				var balances = GeminiClient.GetBalances();
				foreach (var balance in balances)
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
			}
			catch { };
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
				var status = OrderHandling.PendingStop.Find((x) => x.ClientOrderID == selected.Name);
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
					OrderStatus status = null;
					if (selected.Parent.Text == "Completed")
						status = OrderHandling.Completed.Find((x) => x.OrderID == selected.Text);
					else if (selected.Parent.Text == "Active")
						status = OrderHandling.Active.Find((x) => x.OrderID == selected.Text);
					else if (selected.Parent.Text == "Cancelled")
						status = OrderHandling.Cancelled.Find((x) => x.OrderID == selected.Text);
					else
						status = GeminiClient.GetOrder(int.Parse(selected.Text));

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

					var eprice = status.Price.ToString();
					if (c2 == "USD")
						eprice = "$" + eprice;
					else
						eprice += " " + c2;

					var timestamp = DateTimeOffset.FromUnixTimeMilliseconds(status.TimestampMs);
					//timestamp.AddSeconds((double) status.TimestampMs);

					var total = OrderForm.crts(status.ExecutedAmount * status.AvgExecutionPrice, c2) + " " + c2;
					var expected = OrderForm.crts(status.OriginalAmount * status.Price, c2) + " " + c2;

					rtbOrder.Text = String.Format("{0} Order {1}\nPlaced:   {2} {3} @ {4}",
						side, timestamp.UtcDateTime, status.OriginalAmount, c1, price);
					rtbOrder.AppendText(String.Format("\nExecuted: {0} {1} @ {2}\nTotal: {3} / {4}", 
						status.ExecutedAmount, c1, eprice, total, expected));

					if (selected.Parent.Text == "Past")
					{
						var pt = OrderHandling.Past.Find((x) => x.OrderID == selected.Text);
						rtbOrder.AppendText(String.Format("\nFee: {0} {1}", OrderForm.crts(pt.FeeAmount, pt.FeeCurrency), pt.FeeCurrency));
					}
				} catch {}

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
			GeminiClient.Wallet.Close();
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
				OrderHandling.PendingStop.Remove(OrderHandling.PendingStop.Find((x) => x.ClientOrderID == node));
				selected.Remove();
				treeOrders.Nodes["Cancelled"].Nodes.Add(selected);
			}

			/* Order is on the books */
			if (selected.Parent.Name == "Active")
			{
				if ((bool)Properties.Settings.Default["RequireConfirmations"])
				{
					if (MessageBox.Show("Confirm cancellation of order " + node, "Cancel Order", MessageBoxButtons.YesNo) == DialogResult.No)
						return;
				}
				var status = OrderHandling.Active.Find((x) => x.OrderID == selected.Text);
				var res = GeminiClient.CancelOrder(int.Parse(status.OrderID));

				if (res.IsCancelled)
				{
					selected.Remove();
					treeOrders.Nodes["Cancelled"].Nodes.Add(selected);

					OrderHandling.Active.Remove(status);
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
			GeminiClient.CancelAll();
		}

		private void bCancelSession_Click(object sender, EventArgs e)
		{
			if ((bool)Properties.Settings.Default["RequireConfirmations"])
			{
				if (MessageBox.Show("Confirm cancellation of session orders", "Cancel Order", MessageBoxButtons.YesNo) == DialogResult.No)
					return;
			}
			GeminiClient.CancelSession();
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
				//notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
				//notifyIcon.BalloonTipText = "Libra running in background";
				//notifyIcon.BalloonTipTitle = "Libra";
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

	public class OrderHandling
	{
		private static OrderHandling instance;

		public static List<NewOrderRequest> PendingStop = new List<NewOrderRequest>();
		public static List<NewOrderRequest> PendingLimit = new List<NewOrderRequest>();
		public static List<OrderStatus> Active = new List<OrderStatus>();
		public static List<OrderStatus> Cancelled = new List<OrderStatus>();
		public static List<OrderStatus> Completed = new List<OrderStatus>();
		public static List<PastTrade> Past = new List<PastTrade>();

		private OrderHandling() { }
		public static OrderHandling Instance
		{
			get
			{
				if (instance == null)
					instance = new OrderHandling();
				return instance;
			}
		}
	}
}
