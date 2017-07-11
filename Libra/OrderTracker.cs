using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gemini;
using Gemini.Contracts;

namespace Libra
{
	/// <summary>
	/// Really, just a wrapper for some global variables, since C# doesn't allow them
	/// </summary>
	public class OrderTracker
	{
		private static OrderTracker instance;

		public static List<NewOrderRequest> Pending = new List<NewOrderRequest>();
		public static Dictionary<string, OrderEvent> Orders = new Dictionary<string, OrderEvent> ();

		private OrderTracker() { }

		public static OrderTracker Instance
		{
			get
			{
				if (instance == null)
					instance = new OrderTracker();
				return instance;
			}
		}

		/// <summary>
		/// Check all orders in the pending queue, and execute if price condition is met.
		/// This is called by the OrderEvents websocket
		/// </summary>
		/// <param name="currency"></param>
		/// <param name="data"></param>
		public static void CheckPendingOrders(string currency, MarketDataEvent data)
		{
			Parallel.ForEach(Pending, order =>
			{
				
				var price = decimal.Parse(order.Price);
				if (order.Symbol == currency)
				{
					if (order.Side == "buy")
					{
						/* If currenct price is above the stop-buy price, execute */
						if (price <= data.Price)
						{
							order.Price = (data.Price + 0.01M).ToString();
							order.ClientOrderID += "STOP";
							order.Options = new string[] { "immediate-or-cancel" };
							GeminiClient.PlaceOrder(order);
							Pending.Remove(order);
						}
					}
					else
					{
						/* if curenct price is below the stop-loss price, execute */
						if (price >= data.Price)
						{
							/* Decrease by 10, since this is still viewed as a limit order
							* by the server, and this increases our chances of getting filled */
							order.Price = (data.Price - 0.01M).ToString();
							order.ClientOrderID += "STOP";
							GeminiClient.PlaceOrder(order);
							Pending.Remove(order);
						}
					}
				}});
		}
		
	}
}
