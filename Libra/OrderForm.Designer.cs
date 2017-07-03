namespace Libra
{
	partial class OrderForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
			this.bSubmit = new System.Windows.Forms.Button();
			this.bAutofillPrice = new System.Windows.Forms.Button();
			this.bAutofillAmount = new System.Windows.Forms.Button();
			this.bLast = new System.Windows.Forms.Button();
			this.bMax = new System.Windows.Forms.Button();
			this.bAutofillTotal = new System.Windows.Forms.Button();
			this.tbTotal = new System.Windows.Forms.TextBox();
			this.tbAmount = new System.Windows.Forms.TextBox();
			this.tbPrice = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbOrderType = new System.Windows.Forms.ComboBox();
			this.cbCurrency2 = new System.Windows.Forms.ComboBox();
			this.cbCurrency1 = new System.Windows.Forms.ComboBox();
			this.radioStop = new System.Windows.Forms.RadioButton();
			this.radioLimit = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// bSubmit
			// 
			this.bSubmit.ForeColor = System.Drawing.SystemColors.ControlText;
			this.bSubmit.Location = new System.Drawing.Point(107, 129);
			this.bSubmit.Name = "bSubmit";
			this.bSubmit.Size = new System.Drawing.Size(67, 26);
			this.bSubmit.TabIndex = 18;
			this.bSubmit.Text = "Submit";
			this.bSubmit.UseVisualStyleBackColor = true;
			this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
			// 
			// bAutofillPrice
			// 
			this.bAutofillPrice.Location = new System.Drawing.Point(180, 41);
			this.bAutofillPrice.Name = "bAutofillPrice";
			this.bAutofillPrice.Size = new System.Drawing.Size(46, 23);
			this.bAutofillPrice.TabIndex = 6;
			this.bAutofillPrice.Text = "Auto";
			this.bAutofillPrice.UseVisualStyleBackColor = true;
			this.bAutofillPrice.Click += new System.EventHandler(this.bAutofillPrice_Click);
			// 
			// bAutofillAmount
			// 
			this.bAutofillAmount.Location = new System.Drawing.Point(180, 67);
			this.bAutofillAmount.Name = "bAutofillAmount";
			this.bAutofillAmount.Size = new System.Drawing.Size(46, 23);
			this.bAutofillAmount.TabIndex = 7;
			this.bAutofillAmount.Text = "Auto";
			this.bAutofillAmount.UseVisualStyleBackColor = true;
			this.bAutofillAmount.Click += new System.EventHandler(this.bAutofillAmount_Click);
			// 
			// bLast
			// 
			this.bLast.Location = new System.Drawing.Point(232, 40);
			this.bLast.Name = "bLast";
			this.bLast.Size = new System.Drawing.Size(46, 23);
			this.bLast.TabIndex = 9;
			this.bLast.Text = "Last";
			this.bLast.UseVisualStyleBackColor = true;
			this.bLast.Click += new System.EventHandler(this.bLast_Click);
			// 
			// bMax
			// 
			this.bMax.Location = new System.Drawing.Point(232, 67);
			this.bMax.Name = "bMax";
			this.bMax.Size = new System.Drawing.Size(46, 48);
			this.bMax.TabIndex = 10;
			this.bMax.Text = "Max";
			this.bMax.UseVisualStyleBackColor = true;
			this.bMax.Click += new System.EventHandler(this.bMax_Click);
			// 
			// bAutofillTotal
			// 
			this.bAutofillTotal.Location = new System.Drawing.Point(180, 93);
			this.bAutofillTotal.Name = "bAutofillTotal";
			this.bAutofillTotal.Size = new System.Drawing.Size(46, 23);
			this.bAutofillTotal.TabIndex = 8;
			this.bAutofillTotal.Text = "Auto";
			this.bAutofillTotal.UseVisualStyleBackColor = true;
			this.bAutofillTotal.Click += new System.EventHandler(this.bAutofillTotal_Click);
			// 
			// tbTotal
			// 
			this.tbTotal.Location = new System.Drawing.Point(80, 95);
			this.tbTotal.Name = "tbTotal";
			this.tbTotal.Size = new System.Drawing.Size(94, 20);
			this.tbTotal.TabIndex = 5;
			// 
			// tbAmount
			// 
			this.tbAmount.Location = new System.Drawing.Point(80, 69);
			this.tbAmount.Name = "tbAmount";
			this.tbAmount.Size = new System.Drawing.Size(94, 20);
			this.tbAmount.TabIndex = 4;
			// 
			// tbPrice
			// 
			this.tbPrice.Location = new System.Drawing.Point(80, 43);
			this.tbPrice.Name = "tbPrice";
			this.tbPrice.Size = new System.Drawing.Size(94, 20);
			this.tbPrice.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 98);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Total";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Amount";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 14;
			this.label2.Text = "Price";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(148, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 11;
			this.label1.Text = "with";
			// 
			// cbOrderType
			// 
			this.cbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOrderType.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbOrderType.FormattingEnabled = true;
			this.cbOrderType.Items.AddRange(new object[] {
            "BUY",
            "SELL"});
			this.cbOrderType.Location = new System.Drawing.Point(12, 12);
			this.cbOrderType.Name = "cbOrderType";
			this.cbOrderType.Size = new System.Drawing.Size(62, 22);
			this.cbOrderType.TabIndex = 0;
			this.cbOrderType.SelectedIndexChanged += new System.EventHandler(this.cbOrderType_SelectedIndexChanged);
			// 
			// cbCurrency2
			// 
			this.cbCurrency2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCurrency2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbCurrency2.FormattingEnabled = true;
			this.cbCurrency2.Items.AddRange(new object[] {
            "USD",
            "BTC",
            "ETH"});
			this.cbCurrency2.Location = new System.Drawing.Point(180, 12);
			this.cbCurrency2.Name = "cbCurrency2";
			this.cbCurrency2.Size = new System.Drawing.Size(62, 22);
			this.cbCurrency2.TabIndex = 2;
			this.cbCurrency2.SelectedIndexChanged += new System.EventHandler(this.cbCurrency2_SelectedIndexChanged);
			// 
			// cbCurrency1
			// 
			this.cbCurrency1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCurrency1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbCurrency1.FormattingEnabled = true;
			this.cbCurrency1.Items.AddRange(new object[] {
            "ETH",
            "BTC"});
			this.cbCurrency1.Location = new System.Drawing.Point(80, 12);
			this.cbCurrency1.Name = "cbCurrency1";
			this.cbCurrency1.Size = new System.Drawing.Size(62, 22);
			this.cbCurrency1.TabIndex = 1;
			// 
			// radioStop
			// 
			this.radioStop.AutoSize = true;
			this.radioStop.Location = new System.Drawing.Point(15, 138);
			this.radioStop.Name = "radioStop";
			this.radioStop.Size = new System.Drawing.Size(49, 17);
			this.radioStop.TabIndex = 24;
			this.radioStop.Text = "Stop";
			this.radioStop.UseVisualStyleBackColor = true;
			// 
			// radioLimit
			// 
			this.radioLimit.AutoSize = true;
			this.radioLimit.Checked = true;
			this.radioLimit.Location = new System.Drawing.Point(15, 120);
			this.radioLimit.Name = "radioLimit";
			this.radioLimit.Size = new System.Drawing.Size(55, 17);
			this.radioLimit.TabIndex = 24;
			this.radioLimit.TabStop = true;
			this.radioLimit.Text = "Limit";
			this.radioLimit.UseVisualStyleBackColor = true;
			// 
			// OrderForm
			// 
			this.AcceptButton = this.bSubmit;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 164);
			this.Controls.Add(this.radioStop);
			this.Controls.Add(this.radioLimit);
			this.Controls.Add(this.bSubmit);
			this.Controls.Add(this.bAutofillPrice);
			this.Controls.Add(this.bAutofillAmount);
			this.Controls.Add(this.bLast);
			this.Controls.Add(this.bMax);
			this.Controls.Add(this.bAutofillTotal);
			this.Controls.Add(this.tbTotal);
			this.Controls.Add(this.tbAmount);
			this.Controls.Add(this.tbPrice);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbOrderType);
			this.Controls.Add(this.cbCurrency2);
			this.Controls.Add(this.cbCurrency1);
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OrderForm";
			this.Text = "Place New Order";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bSubmit;
		private System.Windows.Forms.Button bAutofillPrice;
		private System.Windows.Forms.Button bAutofillAmount;
		private System.Windows.Forms.Button bLast;
		private System.Windows.Forms.Button bMax;
		private System.Windows.Forms.Button bAutofillTotal;
		private System.Windows.Forms.TextBox tbTotal;
		private System.Windows.Forms.TextBox tbAmount;
		private System.Windows.Forms.TextBox tbPrice;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbOrderType;
		private System.Windows.Forms.ComboBox cbCurrency2;
		private System.Windows.Forms.ComboBox cbCurrency1;
		private System.Windows.Forms.RadioButton radioStop;
		private System.Windows.Forms.RadioButton radioLimit;
	}
}