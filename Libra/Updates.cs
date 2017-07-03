using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemini;
using Gemini.Contracts;

namespace Libra
{
	public partial class LibraMain
	{
		/// <summary>
		/// Update the connection status label with current prices
		/// </summary>
		private void UpdateTicker(string currency, MarketDataEvent e)
		{
			var ticker = Symbols
				.Aggregate(new StringBuilder(), (sb, s) => sb.Append(String.Format("{0}: {1}  ", s.ToUpper(), LastTrades[s]?.Price)), sb => sb.ToString());
			connectionStatusLabel.Text = String.Format("Connected: {0}   {1}", GeminiClient.Wallet.Key(), ticker);
			rtbRates.Text = Symbols
				.Aggregate(new StringBuilder(), (sb, s) => sb.Append(String.Format("{0}: {1}\n", s.ToUpper(), LastTrades[s]?.Price)), sb => sb.ToString()); ;
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
		}

		/// <summary>
		/// Update account balances and total USD value
		/// </summary>
		private void UpdateAccounts(object sender, EventArgs e)
		{
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
							assets += balance.Amount * LastTrades["btcusd"].Price;
							break;
						case "ETH":
							textboxEthBalance.Text = balance.Amount.ToString();
							assets += balance.Amount * LastTrades["ethusd"].Price;
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
		/// Callback for when an order is placed, or status has changed
		/// </summary>
		/// <param name="state"></param>
		/// <param name="e"></param>
		private void UpdateOrders(string type, object data)
		{
			var order = (OrderEvent)data;
			if (type == "fill")
			{
				var fill = (OrderEventFilled)data;
				treeOrders.Nodes["Completed"].Nodes.Add(fill.OrderID, fill.OrderID);

			}
			else if (type == "cancelled")
			{
				//var cancelled = (OrderEventCancelled)data;
				treeOrders.Nodes["Active"].Nodes.Find(order.OrderID, false)?.First()?.Remove();
				treeOrders.Nodes["Cancelled"].Nodes.Add(order.OrderID, order.OrderID);
			}
			else if (type == "booked")
			{
				treeOrders.Nodes["Active"].Nodes.Add(order.OrderID, order.OrderID);
				OrderTracker.Orders.Add(order);
			}
			else if (type == "initial")
			{
				treeOrders.Nodes["Active"].Nodes.Add(order.OrderID, order.OrderID);
				OrderTracker.Orders.Add(order);
			}
			else
			{
				
			}

			UpdateAccounts(null, null);
		}


	}
}
