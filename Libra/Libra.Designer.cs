namespace Libra
{
    partial class LibraMain
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
			System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Active");
			System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Pending");
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Completed");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Cancelled");
			System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Past");
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibraMain));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aPIKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.uptimeStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.groupboxAccounts = new System.Windows.Forms.GroupBox();
			this.textboxUsdBalance = new System.Windows.Forms.TextBox();
			this.textboxEthBalance = new System.Windows.Forms.TextBox();
			this.textboxBtcBalance = new System.Windows.Forms.TextBox();
			this.labelUsdBalance = new System.Windows.Forms.Label();
			this.labelEthBalance = new System.Windows.Forms.Label();
			this.labelBtcBalance = new System.Windows.Forms.Label();
			this.bLoadWallet = new System.Windows.Forms.Button();
			this.labelAssetValue = new System.Windows.Forms.Label();
			this.labelAddress = new System.Windows.Forms.Label();
			this.groupboxTransactions = new System.Windows.Forms.GroupBox();
			this.bMaxWithdraw = new System.Windows.Forms.Button();
			this.tbWithdrawAmount = new System.Windows.Forms.TextBox();
			this.tbWithdrawAddress = new System.Windows.Forms.TextBox();
			this.tbNewAddress = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.bWithdraw = new System.Windows.Forms.Button();
			this.cbWithdraw = new System.Windows.Forms.ComboBox();
			this.bNewAddress = new System.Windows.Forms.Button();
			this.cbAddress = new System.Windows.Forms.ComboBox();
			this.groupboxOrders = new System.Windows.Forms.GroupBox();
			this.rtbRates = new System.Windows.Forms.RichTextBox();
			this.rtbOrder = new System.Windows.Forms.RichTextBox();
			this.treeOrders = new System.Windows.Forms.TreeView();
			this.bCancelSelect = new System.Windows.Forms.Button();
			this.bLoadPast = new System.Windows.Forms.Button();
			this.bCancelAll = new System.Windows.Forms.Button();
			this.bCancelSession = new System.Windows.Forms.Button();
			this.bPlaceOrder = new System.Windows.Forms.Button();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.activeOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.placeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.groupboxAccounts.SuspendLayout();
			this.groupboxTransactions.SuspendLayout();
			this.groupboxOrders.SuspendLayout();
			this.notifyMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(609, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "Menu Strip";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPIKeysToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// aPIKeysToolStripMenuItem
			// 
			this.aPIKeysToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.closeToolStripMenuItem});
			this.aPIKeysToolStripMenuItem.Name = "aPIKeysToolStripMenuItem";
			this.aPIKeysToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.aPIKeysToolStripMenuItem.Text = "Wallet";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new System.EventHandler(this.bLoadWallet_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.settingsToolStripMenuItem.Text = "Settings";
			this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uptimeStatusLabel,
            this.connectionStatusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 389);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(609, 22);
			this.statusStrip.TabIndex = 1;
			this.statusStrip.Text = "statusStrip1";
			// 
			// uptimeStatusLabel
			// 
			this.uptimeStatusLabel.Name = "uptimeStatusLabel";
			this.uptimeStatusLabel.Size = new System.Drawing.Size(55, 17);
			this.uptimeStatusLabel.Text = "00:00:00";
			// 
			// connectionStatusLabel
			// 
			this.connectionStatusLabel.Name = "connectionStatusLabel";
			this.connectionStatusLabel.Size = new System.Drawing.Size(79, 17);
			this.connectionStatusLabel.Text = "Disconnected";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.groupboxAccounts);
			this.flowLayoutPanel1.Controls.Add(this.groupboxTransactions);
			this.flowLayoutPanel1.Controls.Add(this.groupboxOrders);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(609, 365);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// groupboxAccounts
			// 
			this.groupboxAccounts.Controls.Add(this.textboxUsdBalance);
			this.groupboxAccounts.Controls.Add(this.textboxEthBalance);
			this.groupboxAccounts.Controls.Add(this.textboxBtcBalance);
			this.groupboxAccounts.Controls.Add(this.labelUsdBalance);
			this.groupboxAccounts.Controls.Add(this.labelEthBalance);
			this.groupboxAccounts.Controls.Add(this.labelBtcBalance);
			this.groupboxAccounts.Controls.Add(this.bLoadWallet);
			this.groupboxAccounts.Controls.Add(this.labelAssetValue);
			this.groupboxAccounts.Controls.Add(this.labelAddress);
			this.groupboxAccounts.Location = new System.Drawing.Point(3, 3);
			this.groupboxAccounts.Name = "groupboxAccounts";
			this.groupboxAccounts.Size = new System.Drawing.Size(156, 157);
			this.groupboxAccounts.TabIndex = 10;
			this.groupboxAccounts.TabStop = false;
			this.groupboxAccounts.Text = "Account Balances";
			// 
			// textboxUsdBalance
			// 
			this.textboxUsdBalance.Location = new System.Drawing.Point(37, 84);
			this.textboxUsdBalance.Name = "textboxUsdBalance";
			this.textboxUsdBalance.ReadOnly = true;
			this.textboxUsdBalance.Size = new System.Drawing.Size(113, 20);
			this.textboxUsdBalance.TabIndex = 6;
			// 
			// textboxEthBalance
			// 
			this.textboxEthBalance.Location = new System.Drawing.Point(37, 58);
			this.textboxEthBalance.Name = "textboxEthBalance";
			this.textboxEthBalance.ReadOnly = true;
			this.textboxEthBalance.Size = new System.Drawing.Size(113, 20);
			this.textboxEthBalance.TabIndex = 6;
			// 
			// textboxBtcBalance
			// 
			this.textboxBtcBalance.Location = new System.Drawing.Point(37, 32);
			this.textboxBtcBalance.Name = "textboxBtcBalance";
			this.textboxBtcBalance.ReadOnly = true;
			this.textboxBtcBalance.Size = new System.Drawing.Size(113, 20);
			this.textboxBtcBalance.TabIndex = 6;
			// 
			// labelUsdBalance
			// 
			this.labelUsdBalance.AutoSize = true;
			this.labelUsdBalance.Location = new System.Drawing.Point(6, 87);
			this.labelUsdBalance.Name = "labelUsdBalance";
			this.labelUsdBalance.Size = new System.Drawing.Size(25, 13);
			this.labelUsdBalance.TabIndex = 5;
			this.labelUsdBalance.Text = "USD";
			// 
			// labelEthBalance
			// 
			this.labelEthBalance.AutoSize = true;
			this.labelEthBalance.Location = new System.Drawing.Point(6, 61);
			this.labelEthBalance.Name = "labelEthBalance";
			this.labelEthBalance.Size = new System.Drawing.Size(25, 13);
			this.labelEthBalance.TabIndex = 5;
			this.labelEthBalance.Text = "ETH";
			// 
			// labelBtcBalance
			// 
			this.labelBtcBalance.AutoSize = true;
			this.labelBtcBalance.Location = new System.Drawing.Point(6, 35);
			this.labelBtcBalance.Name = "labelBtcBalance";
			this.labelBtcBalance.Size = new System.Drawing.Size(25, 13);
			this.labelBtcBalance.TabIndex = 5;
			this.labelBtcBalance.Text = "BTC";
			// 
			// bLoadWallet
			// 
			this.bLoadWallet.Location = new System.Drawing.Point(37, 130);
			this.bLoadWallet.Name = "bLoadWallet";
			this.bLoadWallet.Size = new System.Drawing.Size(75, 23);
			this.bLoadWallet.TabIndex = 4;
			this.bLoadWallet.Text = "Load Wallet";
			this.bLoadWallet.UseVisualStyleBackColor = true;
			this.bLoadWallet.Click += new System.EventHandler(this.bLoadWallet_Click);
			// 
			// labelAssetValue
			// 
			this.labelAssetValue.AutoSize = true;
			this.labelAssetValue.Location = new System.Drawing.Point(6, 113);
			this.labelAssetValue.Name = "labelAssetValue";
			this.labelAssetValue.Size = new System.Drawing.Size(97, 13);
			this.labelAssetValue.TabIndex = 3;
			this.labelAssetValue.Text = "Total Value: $0";
			// 
			// labelAddress
			// 
			this.labelAddress.AutoSize = true;
			this.labelAddress.Location = new System.Drawing.Point(6, 16);
			this.labelAddress.Name = "labelAddress";
			this.labelAddress.Size = new System.Drawing.Size(103, 13);
			this.labelAddress.TabIndex = 2;
			this.labelAddress.Text = "No wallet loaded";
			// 
			// groupboxTransactions
			// 
			this.groupboxTransactions.Controls.Add(this.bMaxWithdraw);
			this.groupboxTransactions.Controls.Add(this.tbWithdrawAmount);
			this.groupboxTransactions.Controls.Add(this.tbWithdrawAddress);
			this.groupboxTransactions.Controls.Add(this.tbNewAddress);
			this.groupboxTransactions.Controls.Add(this.label5);
			this.groupboxTransactions.Controls.Add(this.label4);
			this.groupboxTransactions.Controls.Add(this.label3);
			this.groupboxTransactions.Controls.Add(this.bWithdraw);
			this.groupboxTransactions.Controls.Add(this.cbWithdraw);
			this.groupboxTransactions.Controls.Add(this.bNewAddress);
			this.groupboxTransactions.Controls.Add(this.cbAddress);
			this.groupboxTransactions.Location = new System.Drawing.Point(165, 3);
			this.groupboxTransactions.Name = "groupboxTransactions";
			this.groupboxTransactions.Size = new System.Drawing.Size(428, 157);
			this.groupboxTransactions.TabIndex = 11;
			this.groupboxTransactions.TabStop = false;
			this.groupboxTransactions.Text = "Deposit/Withdraw";
			// 
			// bMaxWithdraw
			// 
			this.bMaxWithdraw.Location = new System.Drawing.Point(288, 127);
			this.bMaxWithdraw.Name = "bMaxWithdraw";
			this.bMaxWithdraw.Size = new System.Drawing.Size(47, 21);
			this.bMaxWithdraw.TabIndex = 8;
			this.bMaxWithdraw.Text = "Max";
			this.bMaxWithdraw.UseVisualStyleBackColor = true;
			this.bMaxWithdraw.Click += new System.EventHandler(this.bMaxWithdraw_Click);
			// 
			// tbWithdrawAmount
			// 
			this.tbWithdrawAmount.Location = new System.Drawing.Point(69, 127);
			this.tbWithdrawAmount.Name = "tbWithdrawAmount";
			this.tbWithdrawAmount.Size = new System.Drawing.Size(213, 20);
			this.tbWithdrawAmount.TabIndex = 6;
			// 
			// tbWithdrawAddress
			// 
			this.tbWithdrawAddress.Location = new System.Drawing.Point(69, 105);
			this.tbWithdrawAddress.Name = "tbWithdrawAddress";
			this.tbWithdrawAddress.Size = new System.Drawing.Size(266, 20);
			this.tbWithdrawAddress.TabIndex = 6;
			// 
			// tbNewAddress
			// 
			this.tbNewAddress.Location = new System.Drawing.Point(69, 50);
			this.tbNewAddress.Name = "tbNewAddress";
			this.tbNewAddress.ReadOnly = true;
			this.tbNewAddress.Size = new System.Drawing.Size(266, 20);
			this.tbNewAddress.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 130);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(43, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Amount";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(205, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Withdraw to a whitelisted address";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 31);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(265, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Create a new cryptocurrency deposit address";
			// 
			// bWithdraw
			// 
			this.bWithdraw.Location = new System.Drawing.Point(341, 103);
			this.bWithdraw.Name = "bWithdraw";
			this.bWithdraw.Size = new System.Drawing.Size(81, 45);
			this.bWithdraw.TabIndex = 4;
			this.bWithdraw.Text = "Withdraw";
			this.bWithdraw.UseVisualStyleBackColor = true;
			this.bWithdraw.Click += new System.EventHandler(this.bWithdraw_Click);
			// 
			// cbWithdraw
			// 
			this.cbWithdraw.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbWithdraw.FormattingEnabled = true;
			this.cbWithdraw.Items.AddRange(new object[] {
            "BTC",
            "ETH"});
			this.cbWithdraw.Location = new System.Drawing.Point(6, 105);
			this.cbWithdraw.Name = "cbWithdraw";
			this.cbWithdraw.Size = new System.Drawing.Size(57, 21);
			this.cbWithdraw.TabIndex = 5;
			// 
			// bNewAddress
			// 
			this.bNewAddress.Location = new System.Drawing.Point(341, 48);
			this.bNewAddress.Name = "bNewAddress";
			this.bNewAddress.Size = new System.Drawing.Size(81, 23);
			this.bNewAddress.TabIndex = 4;
			this.bNewAddress.Text = "New Address";
			this.bNewAddress.UseVisualStyleBackColor = true;
			this.bNewAddress.Click += new System.EventHandler(this.bNewAddress_Click);
			// 
			// cbAddress
			// 
			this.cbAddress.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAddress.FormattingEnabled = true;
			this.cbAddress.Items.AddRange(new object[] {
            "BTC",
            "ETH"});
			this.cbAddress.Location = new System.Drawing.Point(6, 50);
			this.cbAddress.Name = "cbAddress";
			this.cbAddress.Size = new System.Drawing.Size(57, 21);
			this.cbAddress.TabIndex = 5;
			// 
			// groupboxOrders
			// 
			this.groupboxOrders.Controls.Add(this.rtbRates);
			this.groupboxOrders.Controls.Add(this.rtbOrder);
			this.groupboxOrders.Controls.Add(this.treeOrders);
			this.groupboxOrders.Controls.Add(this.bCancelSelect);
			this.groupboxOrders.Controls.Add(this.bLoadPast);
			this.groupboxOrders.Controls.Add(this.bCancelAll);
			this.groupboxOrders.Controls.Add(this.bCancelSession);
			this.groupboxOrders.Controls.Add(this.bPlaceOrder);
			this.groupboxOrders.Location = new System.Drawing.Point(3, 166);
			this.groupboxOrders.Name = "groupboxOrders";
			this.groupboxOrders.Size = new System.Drawing.Size(590, 196);
			this.groupboxOrders.TabIndex = 12;
			this.groupboxOrders.TabStop = false;
			this.groupboxOrders.Text = "Order Management";
			// 
			// rtbRates
			// 
			this.rtbRates.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbRates.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbRates.Location = new System.Drawing.Point(302, 106);
			this.rtbRates.Name = "rtbRates";
			this.rtbRates.ReadOnly = true;
			this.rtbRates.Size = new System.Drawing.Size(282, 80);
			this.rtbRates.TabIndex = 10;
			this.rtbRates.Text = "";
			// 
			// rtbOrder
			// 
			this.rtbOrder.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtbOrder.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtbOrder.Location = new System.Drawing.Point(302, 20);
			this.rtbOrder.Name = "rtbOrder";
			this.rtbOrder.ReadOnly = true;
			this.rtbOrder.Size = new System.Drawing.Size(282, 80);
			this.rtbOrder.TabIndex = 10;
			this.rtbOrder.Text = "";
			// 
			// treeOrders
			// 
			this.treeOrders.BackColor = System.Drawing.SystemColors.Control;
			this.treeOrders.Location = new System.Drawing.Point(122, 19);
			this.treeOrders.Name = "treeOrders";
			treeNode1.Name = "Active";
			treeNode1.Text = "Active";
			treeNode2.Name = "Pending";
			treeNode2.Text = "Pending";
			treeNode3.Name = "Completed";
			treeNode3.Text = "Completed";
			treeNode4.Name = "Cancelled";
			treeNode4.Text = "Cancelled";
			treeNode5.Name = "Past";
			treeNode5.Text = "Past";
			this.treeOrders.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
			this.treeOrders.Size = new System.Drawing.Size(173, 171);
			this.treeOrders.TabIndex = 9;
			this.treeOrders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// bCancelSelect
			// 
			this.bCancelSelect.Location = new System.Drawing.Point(10, 48);
			this.bCancelSelect.Name = "bCancelSelect";
			this.bCancelSelect.Size = new System.Drawing.Size(106, 23);
			this.bCancelSelect.TabIndex = 5;
			this.bCancelSelect.Text = "Cancel Order";
			this.bCancelSelect.UseVisualStyleBackColor = true;
			this.bCancelSelect.Click += new System.EventHandler(this.bCancelSelect_Click);
			// 
			// bLoadPast
			// 
			this.bLoadPast.Location = new System.Drawing.Point(10, 136);
			this.bLoadPast.Name = "bLoadPast";
			this.bLoadPast.Size = new System.Drawing.Size(106, 23);
			this.bLoadPast.TabIndex = 5;
			this.bLoadPast.Text = "Past Orders";
			this.bLoadPast.UseVisualStyleBackColor = true;
			this.bLoadPast.Click += new System.EventHandler(this.bLoadPast_Click);
			// 
			// bCancelAll
			// 
			this.bCancelAll.Location = new System.Drawing.Point(10, 107);
			this.bCancelAll.Name = "bCancelAll";
			this.bCancelAll.Size = new System.Drawing.Size(106, 23);
			this.bCancelAll.TabIndex = 5;
			this.bCancelAll.Text = "Cancel All Orders";
			this.bCancelAll.UseVisualStyleBackColor = true;
			this.bCancelAll.Click += new System.EventHandler(this.bCancelAll_Click);
			// 
			// bCancelSession
			// 
			this.bCancelSession.Location = new System.Drawing.Point(10, 77);
			this.bCancelSession.Name = "bCancelSession";
			this.bCancelSession.Size = new System.Drawing.Size(106, 23);
			this.bCancelSession.TabIndex = 5;
			this.bCancelSession.Text = "Cancel Session Orders";
			this.bCancelSession.UseVisualStyleBackColor = true;
			this.bCancelSession.Click += new System.EventHandler(this.bCancelSession_Click);
			// 
			// bPlaceOrder
			// 
			this.bPlaceOrder.Location = new System.Drawing.Point(10, 19);
			this.bPlaceOrder.Name = "bPlaceOrder";
			this.bPlaceOrder.Size = new System.Drawing.Size(106, 23);
			this.bPlaceOrder.TabIndex = 4;
			this.bPlaceOrder.Text = "Place Order";
			this.bPlaceOrder.UseVisualStyleBackColor = true;
			this.bPlaceOrder.Click += new System.EventHandler(this.bPlaceOrder_Click);
			// 
			// notifyIcon
			// 
			this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon.BalloonTipText = "Libra running in background";
			this.notifyIcon.BalloonTipTitle = "Libra";
			this.notifyIcon.ContextMenuStrip = this.notifyMenu;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Libra";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
			// 
			// notifyMenu
			// 
			this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activeOrdersToolStripMenuItem,
            this.toolStripSeparator1,
            this.placeOrderToolStripMenuItem,
            this.aboutToolStripMenuItem1,
            this.exitToolStripMenuItem1});
			this.notifyMenu.Name = "notifyMenu";
			this.notifyMenu.Size = new System.Drawing.Size(151, 98);
			// 
			// activeOrdersToolStripMenuItem
			// 
			this.activeOrdersToolStripMenuItem.Name = "activeOrdersToolStripMenuItem";
			this.activeOrdersToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.activeOrdersToolStripMenuItem.Text = "0 active orders";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(147, 6);
			// 
			// placeOrderToolStripMenuItem
			// 
			this.placeOrderToolStripMenuItem.Name = "placeOrderToolStripMenuItem";
			this.placeOrderToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
			this.placeOrderToolStripMenuItem.Text = "Place Order";
			this.placeOrderToolStripMenuItem.Click += new System.EventHandler(this.bPlaceOrder_Click);
			// 
			// aboutToolStripMenuItem1
			// 
			this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
			this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
			this.aboutToolStripMenuItem1.Text = "About";
			this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem1
			// 
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
			this.exitToolStripMenuItem1.Text = "Exit";
			this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// LibraMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(609, 411);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.menuStrip);
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.Name = "LibraMain";
			this.Text = "LIBRA";
			this.Resize += new System.EventHandler(this.LibraMain_Resize);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.groupboxAccounts.ResumeLayout(false);
			this.groupboxAccounts.PerformLayout();
			this.groupboxTransactions.ResumeLayout(false);
			this.groupboxTransactions.PerformLayout();
			this.groupboxOrders.ResumeLayout(false);
			this.notifyMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPIKeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel uptimeStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupboxAccounts;
        private System.Windows.Forms.TextBox textboxUsdBalance;
        private System.Windows.Forms.TextBox textboxEthBalance;
        private System.Windows.Forms.TextBox textboxBtcBalance;
        private System.Windows.Forms.Label labelUsdBalance;
        private System.Windows.Forms.Label labelEthBalance;
        private System.Windows.Forms.Label labelBtcBalance;
        private System.Windows.Forms.Button bLoadWallet;
        private System.Windows.Forms.Label labelAssetValue;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.GroupBox groupboxTransactions;
        private System.Windows.Forms.Button bMaxWithdraw;
        private System.Windows.Forms.TextBox tbWithdrawAmount;
        private System.Windows.Forms.TextBox tbWithdrawAddress;
        private System.Windows.Forms.TextBox tbNewAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button bWithdraw;
        private System.Windows.Forms.ComboBox cbWithdraw;
        private System.Windows.Forms.Button bNewAddress;
        private System.Windows.Forms.ComboBox cbAddress;
        private System.Windows.Forms.GroupBox groupboxOrders;
        private System.Windows.Forms.Button bCancelSelect;
        private System.Windows.Forms.Button bCancelAll;
        private System.Windows.Forms.Button bCancelSession;
        private System.Windows.Forms.Button bPlaceOrder;
        public System.Windows.Forms.TreeView treeOrders;
        private System.Windows.Forms.RichTextBox rtbOrder;
		private System.Windows.Forms.Button bLoadPast;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip notifyMenu;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem activeOrdersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem placeOrderToolStripMenuItem;
		private System.Windows.Forms.RichTextBox rtbRates;
	}
}

