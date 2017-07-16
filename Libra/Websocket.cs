using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
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
		public static Dictionary<string, decimal> PV = new Dictionary<string, decimal>();
		public static Dictionary<string, decimal> V = new Dictionary<string, decimal>();

		public delegate void PriceChangedDel(string currency, MarketDataEvent data);
		public delegate void OrderChangedDel(string type, object order);

		public PriceChangedDel PriceChanged;
		public OrderChangedDel OrderChanged;
		public List<Websocket> sockets = new List<Websocket>();

		/// <summary>
		/// Seed the last trade dictionary
		/// </summary>
		public void InitialPrices()
		{
			Parallel.ForEach(Symbols, s =>
			{
				var t = GeminiClient.GetTicker(s);
				LastTrades[s] = new MarketDataEvent() { Price = t.Last, };
				PV[s] = t.Volume.Currency2;
				V[s] = t.Volume.Currency1;
			});

			UpdateTicker(null, null);
		}

		public void MarketDataStart()
		{
			foreach (var currency in Symbols)
			{
				initial[currency] = true;
				var ws = new Gemini.Websocket("wss://api.gemini.com/v1/marketdata/" + currency.ToUpper(), MarketDataCallback, currency);
				ws.Connect();
				sockets.Add(ws);
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
				Gemini.Websocket ws = new Websocket(url, OrderEventCallback, null);

				ws.AddHeader("X-GEMINI-APIKEY", re.Headers["X-GEMINI-APIKEY"]);
				ws.AddHeader("X-GEMINI-PAYLOAD", re.Headers["X-GEMINI-PAYLOAD"]);
				ws.AddHeader("X-GEMINI-SIGNATURE", re.Headers["X-GEMINI-SIGNATURE"]);
				ws.Connect();
				sockets.Add(ws);
			}
			catch (Exception ex)
			{
				Logger.WriteException(Logger.Level.Error, ex);
				System.Windows.Forms.MessageBox.Show(ex.Message, "Error opening websocket");
			}
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
							PV[currency] += e.Price * e.Amount;
							V[currency] += e.Amount;
						}
					}
				}
			}
			catch (Exception e) { Logger.WriteException(Logger.Level.Error, e);  }

		}

		static bool ack = true;
		static long LastHeartbeat = 0;

		private void OrderEventCallback(string data, object state)
		{
			//try
			{
				var pattern = "\"type\":\"\\w+\"";
				var match = Regex.Match(data, pattern).Value;

				switch (match)
				{
					case "\"type\":\"subscription_ack\"":
						return;
					case "\"type\":\"heartbeat\"":
						LastHeartbeat = data.Json<Heartbeat>().TimestampMs;
						return;
					default:
						break;
				}


				/* The default C# json parser is not good at mixed objects, and Gemini occasionally will send different
				 * OrderEvent objects at the same time. So we need to do a big of regex to parse out what is what */
				foreach (var item in data.TrimStart('[', '{').TrimEnd(']').Split(new string[] { "},{" }, StringSplitOptions.RemoveEmptyEntries))
				{
					string clean = "{" + item + "}";
					match = Regex.Match(clean, pattern).Value;
					//System.Windows.Forms.MessageBox.Show(match);
					switch (match)
					{
						case "\"type\":\"fill\"":
							OrderChanged?.Invoke("fill", clean.Json<OrderEventFilled>());
							break;
						case "\"type\":\"cancelled\"":
						case "\"type\":\"cancel_rejected\"":
							OrderChanged?.Invoke("cancelled", clean.Json<OrderEventCancelled>());
							break;
						default:
							var obj = clean.Json<OrderEvent>();
							OrderChanged?.Invoke(obj.Type, obj);
							break;
					}
				}
			}
			//catch (Exception e)
			//{
			//	Logger.WriteException(Logger.Level.Fatal, e);
			//	Logger.Write(Logger.Level.Info, data);
			//}
		}
	}
}
