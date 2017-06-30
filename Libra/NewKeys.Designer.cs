namespace Libra
{
	partial class NewKeys
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewKeys));
			this.sandboxToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.panel4 = new System.Windows.Forms.Panel();
			this.saveWalletButton = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.confirmTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.apiSecretTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.apiKeyTextBox = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// sandboxToolTip
			// 
			this.sandboxToolTip.ToolTipTitle = "Gemini Sandbox API";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(4, 4);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(88, 17);
			this.checkBox1.TabIndex = 5;
			this.checkBox1.Text = "Sandbox API";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.checkBox1);
			this.panel4.Controls.Add(this.saveWalletButton);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(3, 185);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(328, 23);
			this.panel4.TabIndex = 5;
			// 
			// saveWalletButton
			// 
			this.saveWalletButton.Location = new System.Drawing.Point(127, 0);
			this.saveWalletButton.Name = "saveWalletButton";
			this.saveWalletButton.Size = new System.Drawing.Size(75, 23);
			this.saveWalletButton.TabIndex = 4;
			this.saveWalletButton.Text = "Save Wallet";
			this.saveWalletButton.UseVisualStyleBackColor = true;
			this.saveWalletButton.Click += new System.EventHandler(this.saveWalletButton_Click);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(65, 38);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(206, 13);
			this.linkLabel1.TabIndex = 3;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://exchange.gemini.com/settings/api";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 6);
			this.label1.MaximumSize = new System.Drawing.Size(300, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(298, 26);
			this.label1.TabIndex = 2;
			this.label1.Text = "Enter your API Key and API Secret from Gemini. This must be a newly generated key" +
    "pair.\r\n";
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.linkLabel1);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(3, 3);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(328, 51);
			this.panel3.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(42, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Confirm";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(65, 1);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(206, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "AES-256 Encryption is used for API Wallet\r\n";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 20);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Password";
			// 
			// confirmTextBox
			// 
			this.confirmTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.confirmTextBox.Location = new System.Drawing.Point(68, 40);
			this.confirmTextBox.Name = "confirmTextBox";
			this.confirmTextBox.Size = new System.Drawing.Size(226, 20);
			this.confirmTextBox.TabIndex = 1;
			this.confirmTextBox.UseSystemPasswordChar = true;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(68, 17);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(226, 20);
			this.passwordTextBox.TabIndex = 0;
			this.passwordTextBox.UseSystemPasswordChar = true;
			// 
			// apiSecretTextBox
			// 
			this.apiSecretTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.apiSecretTextBox.Location = new System.Drawing.Point(68, 26);
			this.apiSecretTextBox.Name = "apiSecretTextBox";
			this.apiSecretTextBox.Size = new System.Drawing.Size(226, 20);
			this.apiSecretTextBox.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 13);
			this.label5.TabIndex = 2;
			this.label5.Text = "API Key";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 29);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(58, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "API Secret";
			// 
			// apiKeyTextBox
			// 
			this.apiKeyTextBox.Location = new System.Drawing.Point(68, 3);
			this.apiKeyTextBox.Name = "apiKeyTextBox";
			this.apiKeyTextBox.Size = new System.Drawing.Size(226, 20);
			this.apiKeyTextBox.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.apiSecretTextBox);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.apiKeyTextBox);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 60);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(328, 51);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label6);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.confirmTextBox);
			this.panel2.Controls.Add(this.passwordTextBox);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 117);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(328, 62);
			this.panel2.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 211);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// NewKeys
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 211);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NewKeys";
			this.Text = "Create New API Key Wallet";
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ToolTip sandboxToolTip;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button saveWalletButton;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox confirmTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.TextBox apiSecretTextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox apiKeyTextBox;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}