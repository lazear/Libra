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
			if ((bool)Properties.Settings.Default["RequireConfirmations"])
			{
				string confirm = String.Format("You are about to place an order to {0} {1} {2} for {3} {4}.\nYou can turn off confirmations in Settings.",
					cbOrderType.Text, tbAmount.Text, cbCurrency1.Text, tbPrice.Text, cbCurrency2.Text);
				if (MessageBox.Show(confirm, "Confirm order", MessageBoxButtons.OKCancel) != DialogResult.OK)
					return;
			}

			/* make NewOrderRequest object */
			var order = new Gemini.Contracts.NewOrderRequest()
			{
				Symbol = (cbCurrency1.Text + cbCurrency2.Text).ToLower(),
				Amount = tbAmount.Text,
				Price = tbPrice.Text,
				Side = cbOrderType.Text.ToLower(),
				Type = "exchange limit",

			};


			try
			{
				//var status = Gemini.GeminiClient.PlaceOrder(order);
				GeminiOrderSide side;
				GeminiOrderType type;

				if (cbOrderType.Text == "BUY")
					side = GeminiOrderSide.Buy;
				else
					side = GeminiOrderSide.Sell;

				if (radioButton1.Checked)
					type = GeminiOrderType.Limit;
				else
					type = GeminiOrderType.Stop;

				var go = new GeminiOrder(order, side, type);
				if (type == GeminiOrderType.Limit)
					go.Start();

				//if (status != null)
				//MessageBox.Show(status.Timestamp, "Order Placed!");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception");
			}
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
						tbTotal.Text = (b.Available * 0.9975M).ToString();

					/* sell X currency for Y */
					if (b.Currency == cbCurrency1.Text && cbOrderType.Text == "SELL")
						/* remove 0.25% for fee */
						tbTotal.Text = (b.Available * 0.9975M).ToString();
				}

			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Exception"); }
			try
			{
				var d = decimal.Parse(tbPrice.Text);
				tbAmount.Text = (decimal.Parse(tbTotal.Text) / d).ToString();
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
					if (cbCurrency1.Text == "BTC")
						tbPrice.Text = Math.Round(total / amount, 8).ToString();
					else
						tbPrice.Text = Math.Round(total / amount, 6).ToString();
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
					if (cbCurrency1.Text == "BTC")
						tbAmount.Text = Math.Round(total / price, 8).ToString();
					else
						tbAmount.Text = Math.Round(total / price, 6).ToString();
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
					if (cbCurrency1.Text == "BTC")
						tbTotal.Text = Math.Round(amount * price, 8).ToString();
					else
						tbTotal.Text = Math.Round(amount * price, 6).ToString();
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
			bool invert = false;
			if (cbCurrency1.Text == "BTC" && cbCurrency2.Text == "ETH")
			{
				lookup = "ethbtc";
				invert = true;
			}
			else
			{
				lookup = (cbCurrency1.Text + cbCurrency2.Text).ToLower();
			}

			try
			{
				var currentPrice = Gemini.GeminiClient.GetLastPrice(lookup);
				if (invert)
					currentPrice = 1 / currentPrice;
				tbPrice.Text = currentPrice.ToString();
			}
			catch { }
		}
	}
}
