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
		public static Dictionary<string, decimal> PV = new Dictionary<string, decimal>();
		public static Dictionary<string, decimal> V = new Dictionary<string, decimal>();

		public delegate void PriceChangedDel(string currency, MarketDataEvent data);
		public delegate void OrderChangedDel(string type, object order);

		public PriceChangedDel PriceChanged;
		public OrderChangedDel OrderChanged;

		/// <summary>
		/// Seed the last trade dictionary
		/// </summary>
		public void InitialPrices()
		{
			Parallel.ForEach(Symbols, s =>
			{
				LastTrades[s] = new MarketDataEvent() { Price = GeminiClient.GetLastPrice(s), };

				PV[s] = 0;
				V[s] = 0;

				//System.Threading.ThreadPool.QueueUserWorkItem(
				//delegate (object state)
				new Task(() =>
				{
					var vwap = Vwap(s, DateTime.UtcNow.Subtract(new TimeSpan(24, 0, 0)).ToTimestamp(), DateTime.UtcNow.ToTimestamp());
					PV[s] = vwap[0];
					V[s] = vwap[1];
				}).Start();
			

			});

			UpdateTicker(null, null);
		}

		/// <summary>
		/// Calculate the VWAP for a period
		/// </summary>
		/// <param name="start">epoch timestamp for beginning period</param>
		/// <param name="end">epoch timestamp for end period</param>
		public static decimal[] Vwap(string currency, long start, long end)
		{
			long timestamp = start;
			decimal pv = 0;
			decimal v = 0;
			TradeHistory[] history = null;
			do
			{
				var result = Requests.Get(String.Format("https://api.gemini.com/v1/trades/{0}?limit_trades=500&since={1}", currency, timestamp)).Result;
				if (!result.IsSuccessStatusCode)
					throw new Exception("Bad response");

				history = result.Json<TradeHistory[]>();
				foreach (var trade in history)
				{
					pv += (trade.Price * trade.Amount);
					v += trade.Amount;
				}
				timestamp = history[0].Timestamp;
			} while (history.Length > 10 && (timestamp < end));
			// add to the cumulative variables
			return new decimal[] { pv, v};
		}

		public void MarketDataStart()
		{
			foreach (var currency in Symbols)
			{
				initial[currency] = false;
				var ws = new Gemini.Websocket("wss://api.gemini.com/v1/marketdata/" + currency.ToUpper(), MarketDataCallback, currency);
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
				Gemini.Websocket ws = new Websocket(url, OrderEventCallback, null);

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
							PV[currency] += e.Price * e.Amount;
							V[currency] += e.Amount;
						}
					}
				}
			}
			catch { }

		}

		static bool ack = true;
		static long LastHeartbeat = 0;
		System.IO.Stream s = new System.IO.FileStream("log", System.IO.FileMode.Create, System.IO.FileAccess.Write);
		System.IO.Stream s2 = new System.IO.FileStream("log2", System.IO.FileMode.Create, System.IO.FileAccess.Write);
		private void OrderEventCallback(string data, object state)
		{

			s.Write(Encoding.UTF8.GetBytes(data + "\n"), 0, data.Length + 1);

			if (data.Contains("\"type\":\"subscription_ack\""))
			{
				return;
			}

			if (data == "Exception")
			{
				System.Windows.Forms.MessageBox.Show((state as Exception).Message);

				var e = state as Exception;

				s.Write(Encoding.UTF8.GetBytes(e.Message), 0, e.Message.Length);
				s.Write(Encoding.UTF8.GetBytes(e.StackTrace), 0, e.StackTrace.Length);
				return;
			}
			
			if (data.Contains("heartbeat"))
			{
				LastHeartbeat = data.Json<Heartbeat>().TimestampMs;
				return;
			}


			/* The default C# json parser is not good at mixed objects, and Gemini occasionally will send different
			 * OrderEvent objects at the same time. So we need to do a big of regex to parse out what is what */
			foreach (var item in data.TrimStart('[', '{').TrimEnd(']').Split(new string[] { "},{" }, StringSplitOptions.RemoveEmptyEntries))
			{
				string clean = "{" + item + "}";
				s2.Write(Encoding.UTF8.GetBytes(clean + "\n"), 0, clean.Length + 1);
				 
				if (clean.Contains("\"type\":\"fill\""))
				{
					//clean = clean;// + "}";
					OrderChanged?.Invoke("fill", clean.Json<OrderEventFilled>());
				}

				else if (clean.Contains("\"type\":\"cancelled\"") || data.Contains("\"type\":\"cancel_rejected\""))
				{
					OrderChanged?.Invoke("cancelled", clean.Json<OrderEventCancelled>());
				}
				else
				{
					var obj = clean.Json<OrderEvent>();
					OrderChanged?.Invoke(obj.Type, obj);
				}

			}




		}
	}
}
