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

		/* first response is the initial order book, which we don't really care about */
		static Dictionary<string, bool> initial = new Dictionary<string, bool>();

		public string[] Symbols = { "btcusd", "ethusd", "ethbtc" };
		public static Dictionary<string, MarketDataEvent> LastTrades = new Dictionary<string, MarketDataEvent>();


		public delegate void PriceChangedDel(string currency, MarketDataEvent data);
		public delegate void OrderChangedDel(string type, object order);

		public PriceChangedDel PriceChanged;
		public OrderChangedDel OrderChanged;

		/// <summary>
		/// Seed the last trade dictionary
		/// </summary>
		public void InitialPrices()
		{
			string[] symbols = { "btcusd", "ethusd", "ethbtc" };
			foreach (var s in symbols)
				LastTrades[s] = new MarketDataEvent() { Price = GeminiClient.GetLastPrice(s),  };
		}

		public void MarketDataStart()
		{
			foreach (var currency in Symbols)
			{
				initial[currency] = false;
				var ws = new Websocket.Websocket("wss://api.gemini.com/v1/marketdata/" + currency.ToUpper(), MarketDataCallback, currency);
				ws.Connect();
			}
			
		}

		/// <summary>
		/// Start a websocket for observing order events
		/// </summary>
		public void OrderEventStart(object sender, EventArgs e)
		{

			/* a hack to just reuse the REST API client to sign out websocket headers */
			var re = new Requests();
			string url = "wss://api.gemini.com/v1/order/events";
			try
			{

				GeminiClient.Wallet.Authenticate(re, new Gemini.Contracts.PrivateRequest() { Request = "/v1/order/events" });
				if (GeminiClient.Wallet.Url().Contains("sandbox"))
					url = "wss://api.sandbox.gemini.com/v1/order/events";
				Websocket.Websocket ws = new Websocket.Websocket(url, OrderEventCallback, null);

				ws.AddHeader("X-GEMINI-APIKEY", re.Headers["X-GEMINI-APIKEY"]);
				ws.AddHeader("X-GEMINI-PAYLOAD", re.Headers["X-GEMINI-PAYLOAD"]);
				ws.AddHeader("X-GEMINI-SIGNATURE", re.Headers["X-GEMINI-SIGNATURE"]);
				ws.Connect();
			} catch { System.Windows.Forms.MessageBox.Show("Error opening websocket for order events"); }
		}

		private void MarketDataCallback(string data, object state)
		{
			
			string currency = (string)state;

			if (initial[currency])
			{
				initial[currency] = false;
				return;
			}
			try
			{
				var market = data.Json<MarketData>();
				if (market.Type == "update")
				{
					foreach (MarketDataEvent e in market.Events)
					{
						if (e.Type == "trade")
						{
							if (LastTrades[currency].Price != e.Price)
								PriceChanged?.Invoke(currency, e);

							LastTrades[currency] = e;
						}
					}
				}
			}
			catch { }

		}

		static bool ack = true;


		private void OrderEventCallback(string data, object state)
		{
			if (ack)
			{
				ack = false;
				var a = data.Json<OrderEventSubscriptionAck>();
				return;
			}

			if (data.Contains("heartbeat"))
			{
				return;
			}


			foreach(var def in data.Json<OrderEvent[]>())
			{
				System.Windows.Forms.MessageBox.Show(def.Type);
				switch (def.Type)
				{
					case "fill":
						OrderChanged?.Invoke(def.Type, data.Json<OrderEventFilled>());
						break;
					case "cancel_rejected":
					case "cancelled":
						OrderChanged?.Invoke(def.Type, data.Json<OrderEventCancelled>());
						break;
					default:
						OrderChanged?.Invoke(def.Type, def);
						break;
				}
			}


		}


	}
}
