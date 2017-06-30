using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Gemini;
using Gemini.Contracts;

namespace Libra
{

	public enum GeminiOrderStatus { Pending, Active, Cancelled, Completed, Error };
	public enum GeminiOrderType { Limit, Stop };
	public enum GeminiOrderSide { Buy, Sell };

	public class GeminiOrder
	{

		public NewOrderRequest Request = null;
		public OrderStatus Order = null;

		public GeminiOrder(NewOrderRequest newOrder, GeminiOrderSide side, GeminiOrderType type)
		{
			Request = newOrder;
			Watchdog.Watchlist.Add(new Watchdog.Watch { Order = this, Side = side, Type = type });
		}

		public GeminiOrder(OrderStatus existingOrder, GeminiOrderSide side, GeminiOrderType type)
		{
			Order = existingOrder;
			Watchdog.Watchlist.Add(new Watchdog.Watch { Order = this, Side = side, Type = type });
		}

		public GeminiOrderStatus Status()
		{
			if (Order == null && Request != null)
				return GeminiOrderStatus.Pending;

			Order = GeminiClient.GetOrder(int.Parse(Order.OrderID));

			if (Order.IsLive)
				return GeminiOrderStatus.Active;
			if (Order.IsCancelled)
				return GeminiOrderStatus.Cancelled;
			if (Order.OriginalAmount == Order.ExecutedAmount)
				return GeminiOrderStatus.Completed;
			return GeminiOrderStatus.Error;
		}

		public GeminiOrderStatus Cancel()
		{
			if (Order == null)
				throw new NullReferenceException();
			GeminiClient.CancelOrder(int.Parse(Order.OrderID));
			return Status();
		}

		public GeminiOrderStatus Start()
		{
			if (Request == null)
				throw new NullReferenceException();
			if (Order != null)
				return GeminiOrderStatus.Error;

			Order = GeminiClient.PlaceOrder(Request);
			return Status();
		}

		public override string ToString()
		{
			if (Order != null)
				return String.Format("{0} {1} {2} @ {3}", Order.Side.ToUpper(), Order.OriginalAmount, Order.Symbol.ToUpper(), Order.Price);
			else
				return String.Format("{0} {1} {2} @ {3}", Request.Side.ToUpper(), Request.Amount, Request.Symbol.ToUpper(), Request.Price);

		}
	}

	public class Watchdog
	{
		private static Watchdog instance;

		private Watchdog() {	}

		public static void Start()
		{
			new Thread(Worker).Start();
			
		}

		public static Watchdog Instance
		{
			get
			{
				if (instance == null)
					instance = new Watchdog();
				return instance;
			}
		}

		public struct Watch
		{
			public GeminiOrderSide Side;
			public GeminiOrderType Type;
			public GeminiOrder Order;
		};

		public static List<Watch> Watchlist = new List<Watch>();


		private static void Worker()
		{

			while (true) 
			{

				Watchlist.ForEach(delegate (Watch w)
				{
					if (w.Order.Status() == GeminiOrderStatus.Pending)
					{
						if (w.Type == GeminiOrderType.Stop)
						{
							var current = GeminiClient.GetLastPrice(w.Order.Request.Symbol);
							var stop = decimal.Parse(w.Order.Request.Price);


							if (w.Side == GeminiOrderSide.Buy)
							{
								if (stop >= current)
									w.Order.Start();
							}

							if (w.Side == GeminiOrderSide.Sell)
							{
								if (stop <= current)
									w.Order.Start();
							}
						} 
						else
						{
							w.Order.Start();
						}
					}

				});
				Thread.Sleep(1000);
			}

		}

	}
}
