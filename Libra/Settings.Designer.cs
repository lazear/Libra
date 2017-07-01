namespace Libra
{
    partial class Settings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.checkAdvanced = new System.Windows.Forms.CheckBox();
			this.gbAdvanced = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.checkConfirm = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.refreshRateUpDown = new System.Windows.Forms.NumericUpDown();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.buttonWallet = new System.Windows.Forms.Button();
			this.walletTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gbAdvanced.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.refreshRateUpDown)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.88973F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.11027F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 212);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(328, 169);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.checkAdvanced);
			this.tabPage1.Controls.Add(this.gbAdvanced);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.refreshRateUpDown);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(320, 143);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Connection";
			// 
			// checkAdvanced
			// 
			this.checkAdvanced.AutoSize = true;
			this.checkAdvanced.Location = new System.Drawing.Point(5, 32);
			this.checkAdvanced.Name = "checkAdvanced";
			this.checkAdvanced.Size = new System.Drawing.Size(170, 17);
			this.checkAdvanced.TabIndex = 4;
			this.checkAdvanced.Text = "Enable Advanced Settings";
			this.checkAdvanced.UseVisualStyleBackColor = true;
			this.checkAdvanced.CheckedChanged += new System.EventHandler(this.checkAdvanced_CheckedChanged);
			// 
			// gbAdvanced
			// 
			this.gbAdvanced.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.gbAdvanced.AutoSize = true;
			this.gbAdvanced.Controls.Add(this.flowLayoutPanel2);
			this.gbAdvanced.Enabled = false;
			this.gbAdvanced.Location = new System.Drawing.Point(9, 57);
			this.gbAdvanced.Name = "gbAdvanced";
			this.gbAdvanced.Size = new System.Drawing.Size(302, 83);
			this.gbAdvanced.TabIndex = 3;
			this.gbAdvanced.TabStop = false;
			this.gbAdvanced.Text = "Advanced Setttings";
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.checkConfirm);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(296, 64);
			this.flowLayoutPanel2.TabIndex = 0;
			// 
			// checkConfirm
			// 
			this.checkConfirm.AutoSize = true;
			this.checkConfirm.Location = new System.Drawing.Point(3, 3);
			this.checkConfirm.Name = "checkConfirm";
			this.checkConfirm.Size = new System.Drawing.Size(146, 17);
			this.checkConfirm.TabIndex = 1;
			this.checkConfirm.Text = "Require confirmation";
			this.checkConfirm.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(80, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Refresh rate, seconds";
			// 
			// refreshRateUpDown
			// 
			this.refreshRateUpDown.Location = new System.Drawing.Point(5, 6);
			this.refreshRateUpDown.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.refreshRateUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.refreshRateUpDown.Name = "refreshRateUpDown";
			this.refreshRateUpDown.Size = new System.Drawing.Size(69, 20);
			this.refreshRateUpDown.TabIndex = 1;
			this.refreshRateUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.buttonWallet);
			this.tabPage2.Controls.Add(this.walletTextBox);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(320, 143);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "User";
			// 
			// buttonWallet
			// 
			this.buttonWallet.Location = new System.Drawing.Point(262, 20);
			this.buttonWallet.Name = "buttonWallet";
			this.buttonWallet.Size = new System.Drawing.Size(45, 26);
			this.buttonWallet.TabIndex = 2;
			this.buttonWallet.Text = "Select";
			this.buttonWallet.UseVisualStyleBackColor = true;
			this.buttonWallet.Click += new System.EventHandler(this.buttonWallet_Click);
			// 
			// walletTextBox
			// 
			this.walletTextBox.Location = new System.Drawing.Point(10, 24);
			this.walletTextBox.Name = "walletTextBox";
			this.walletTextBox.Size = new System.Drawing.Size(246, 20);
			this.walletTextBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 7);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(145, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Default API wallet file";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.buttonApply);
			this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 178);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 31);
			this.flowLayoutPanel1.TabIndex = 2;
			// 
			// buttonApply
			// 
			this.buttonApply.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonApply.Location = new System.Drawing.Point(3, 3);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new System.Drawing.Size(75, 23);
			this.buttonApply.TabIndex = 0;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(84, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 212);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Settings";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.Settings_Load);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.gbAdvanced.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.refreshRateUpDown)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkAdvanced;
        private System.Windows.Forms.GroupBox gbAdvanced;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox checkConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown refreshRateUpDown;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonWallet;
        private System.Windows.Forms.TextBox walletTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
    }
}