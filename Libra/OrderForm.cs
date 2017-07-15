using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libra
{
	public partial class OrderForm : Form
	{
		public OrderForm()
		{
			InitializeComponent();
		}

		private void bSubmit_Click(object sender, EventArgs e)
		{

			/* make NewOrderRequest object 
			 * We can only sell/buy ETHBTC, not BTCETH, etc
			 * so need to convert to the proper setting
			 * 
			 * buy btc with eth is really sell ETHBTC
			 * buy eth with btc is buy ETHBTC
			 * sell btc for eth is buy ETHBTC
			 * sell eth for btc is sell ETHBTC
			 */

			string side = cbOrderType.Text.ToLower();
			string symbol = (cbCurrency1.Text + cbCurrency2.Text).ToLower();
			if (symbol == "btceth")
			{
				symbol = "ethbtc";
				if (side == "buy")
					side = "sell";
				else
					side = "buy";
			}

			if ((bool)Properties.Settings.Default["RequireConfirmations"])
			{
				string confirm = String.Format("You are about to place an order to {0} {1} {2} for {3} {4}.\nYou can turn off confirmations in Settings.",
					side, tbAmount.Text, cbCurrency1.Text, tbTotal.Text, cbCurrency2.Text);
				if (MessageBox.Show(confirm, "Confirm order", MessageBoxButtons.OKCancel) != DialogResult.OK)
					return;
			}

			var order = new Gemini.Contracts.NewOrderRequest()
			{
				Symbol = symbol,
				Amount = tbAmount.Text,
				Price = tbPrice.Text,
				Side = side,
				Type = "exchange limit",
				ClientOrderID = String.Format("LIBRA_{0}", Gemini.Time.TimestampMs()),
				Options = null,

			};

			try
			{
				if (radioLimit.Checked)
				{
					Gemini.GeminiClient.PlaceOrder(order);
				}
				else
				{
					OrderTracker.Pending.Add(order);
				}
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception");
				Logger.WriteException(Logger.Level.Error, ex);
			}
		}

		/// <summary>
		/// currency round and convert to string
		/// </summary>
		/// <param name="d"></param>
		/// <param name="currency"></param>
		/// <returns></returns>
		public static string crts(decimal d, string currency)
		{
			if (currency == "BTC")
				return Math.Round(d, 8).ToString();
			if (currency == "ETH")
				return Math.Round(d, 6).ToString();
			return Math.Round(d, 2).ToString();
		}

		private void bMax_Click(object sender, EventArgs e)
		{
			/* load current wallet balance */
			try
			{
				var balances = Gemini.GeminiClient.GetBalances();
				foreach (var b in balances)
				{
					/* buy with X currency */
					if (b.Currency == cbCurrency2.Text && cbOrderType.Text == "BUY")
						/* remove 0.25% for fee */
						tbTotal.Text = crts(b.Available * 0.9975M, b.Currency);

					/* sell X currency for Y */
					if (b.Currency == cbCurrency1.Text && cbOrderType.Text == "SELL")
						/* remove 0.25% for fee */
						tbAmount.Text = crts(b.Available * 0.9975M, b.Currency);
				}

			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Exception"); }
			try
			{
				var price = decimal.Parse(tbPrice.Text);
				var amount = decimal.Parse(tbAmount.Text);
				var total = decimal.Parse(tbTotal.Text);
				//if (cbOrderType.Text == "BUY")
					tbAmount.Text = crts(total / price, cbCurrency1.Text);
			//	else
					tbTotal.Text = crts(amount * price, cbCurrency2.Text);
			}
			catch { }
		}

		private void bAutofillPrice_Click(object sender, EventArgs e)
		{
			if (tbTotal.Text != String.Empty && tbAmount.Text != String.Empty)
			{
				try
				{
					var amount = decimal.Parse(tbAmount.Text);
					var total = decimal.Parse(tbTotal.Text);
					tbPrice.Text = crts(total / amount, cbCurrency1.Text);
				}
				catch { }
			}
		}

		private void bAutofillAmount_Click(object sender, EventArgs e)
		{
			if (tbTotal.Text != String.Empty && tbPrice.Text != String.Empty)
			{
				try
				{
					var price = decimal.Parse(tbPrice.Text);
					var total = decimal.Parse(tbTotal.Text);
					tbAmount.Text = crts(total / price, cbCurrency1.Text);
				}
				catch { }
			}
		}

		private void bAutofillTotal_Click(object sender, EventArgs e)
		{
			if (tbAmount.Text != String.Empty && tbPrice.Text != String.Empty)
			{
				try
				{
					var price = decimal.Parse(tbPrice.Text);
					var amount = decimal.Parse(tbAmount.Text);
					tbTotal.Text = crts(amount * price, cbCurrency1.Text);
				}
				catch { }
			}
		}

		private void cbOrderType_SelectedIndexChanged(object sender, EventArgs e)
		{
			/* "BUY" */
			if ((sender as ComboBox).SelectedIndex == 0)
				this.label1.Text = "with";
			else
				this.label1.Text = "for ";
		}

		private void cbCurrency2_SelectedIndexChanged(object sender, EventArgs e)
		{
			label4.Text = "Total " + cbCurrency2.Text;
		}

		private void bLast_Click(object sender, EventArgs e)
		{
			string[] currencies = { "btcusd", "ethusd", "ethbtc" };
			string lookup = "";
			if (cbCurrency1.Text == "BTC" && cbCurrency2.Text == "ETH")
			{
				lookup = "ethbtc";
			}
			else
			{
				lookup = (cbCurrency1.Text + cbCurrency2.Text).ToLower();
			}

			try
			{
				var currentPrice = Gemini.GeminiClient.GetLastPrice(lookup);
				tbPrice.Text = currentPrice.ToString();
			}
			catch { }
		}
	}
}
