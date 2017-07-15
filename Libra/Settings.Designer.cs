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
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.buttonApply = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonLogFile = new System.Windows.Forms.Button();
			this.logTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkAdvanced = new System.Windows.Forms.CheckBox();
			this.gbAdvanced = new System.Windows.Forms.GroupBox();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.checkConfirm = new System.Windows.Forms.CheckBox();
			this.buttonWallet = new System.Windows.Forms.Button();
			this.walletTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.gbAdvanced.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.buttonApply);
			this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 175);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 30);
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
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.88973F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.11027F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(334, 208);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonLogFile);
			this.panel1.Controls.Add(this.logTextBox);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.checkAdvanced);
			this.panel1.Controls.Add(this.gbAdvanced);
			this.panel1.Controls.Add(this.buttonWallet);
			this.panel1.Controls.Add(this.walletTextBox);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(328, 166);
			this.panel1.TabIndex = 3;
			// 
			// buttonLogFile
			// 
			this.buttonLogFile.Location = new System.Drawing.Point(259, 59);
			this.buttonLogFile.Name = "buttonLogFile";
			this.buttonLogFile.Size = new System.Drawing.Size(55, 26);
			this.buttonLogFile.TabIndex = 14;
			this.buttonLogFile.Text = "Select";
			this.buttonLogFile.UseVisualStyleBackColor = true;
			this.buttonLogFile.Click += new System.EventHandler(this.button1_Click);
			// 
			// logTextBox
			// 
			this.logTextBox.Location = new System.Drawing.Point(17, 63);
			this.logTextBox.Name = "logTextBox";
			this.logTextBox.Size = new System.Drawing.Size(236, 20);
			this.logTextBox.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "Default log file";
			// 
			// checkAdvanced
			// 
			this.checkAdvanced.AutoSize = true;
			this.checkAdvanced.Location = new System.Drawing.Point(18, 94);
			this.checkAdvanced.Name = "checkAdvanced";
			this.checkAdvanced.Size = new System.Drawing.Size(170, 17);
			this.checkAdvanced.TabIndex = 11;
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
			this.gbAdvanced.Location = new System.Drawing.Point(12, 117);
			this.gbAdvanced.Name = "gbAdvanced";
			this.gbAdvanced.Size = new System.Drawing.Size(302, 46);
			this.gbAdvanced.TabIndex = 10;
			this.gbAdvanced.TabStop = false;
			this.gbAdvanced.Text = "Advanced Setttings";
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.checkConfirm);
			this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(296, 27);
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
			// buttonWallet
			// 
			this.buttonWallet.Location = new System.Drawing.Point(258, 19);
			this.buttonWallet.Name = "buttonWallet";
			this.buttonWallet.Size = new System.Drawing.Size(55, 26);
			this.buttonWallet.TabIndex = 9;
			this.buttonWallet.Text = "Select";
			this.buttonWallet.UseVisualStyleBackColor = true;
			this.buttonWallet.Click += new System.EventHandler(this.buttonWallet_Click);
			// 
			// walletTextBox
			// 
			this.walletTextBox.Location = new System.Drawing.Point(16, 23);
			this.walletTextBox.Name = "walletTextBox";
			this.walletTextBox.Size = new System.Drawing.Size(236, 20);
			this.walletTextBox.TabIndex = 8;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(145, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Default API wallet file";
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(334, 208);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Settings";
			this.Text = "Settings";
			this.Load += new System.EventHandler(this.Settings_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.gbAdvanced.ResumeLayout(false);
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.Button buttonApply;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonLogFile;
		private System.Windows.Forms.TextBox logTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkAdvanced;
		private System.Windows.Forms.GroupBox gbAdvanced;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.CheckBox checkConfirm;
		private System.Windows.Forms.Button buttonWallet;
		private System.Windows.Forms.TextBox walletTextBox;
		private System.Windows.Forms.Label label2;
	}
}