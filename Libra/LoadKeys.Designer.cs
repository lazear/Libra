namespace Libra
{
	partial class LoadKeys
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadKeys));
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.buttonUnlock = new System.Windows.Forms.Button();
			this.buttonOpen = new System.Windows.Forms.Button();
			this.tbFile = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(12, 47);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(241, 20);
			this.tbPassword.TabIndex = 0;
			this.tbPassword.UseSystemPasswordChar = true;
			// 
			// buttonUnlock
			// 
			this.buttonUnlock.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonUnlock.Location = new System.Drawing.Point(259, 45);
			this.buttonUnlock.Name = "buttonUnlock";
			this.buttonUnlock.Size = new System.Drawing.Size(60, 23);
			this.buttonUnlock.TabIndex = 1;
			this.buttonUnlock.Text = "Unlock";
			this.buttonUnlock.UseVisualStyleBackColor = true;
			this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
			// 
			// buttonOpen
			// 
			this.buttonOpen.Location = new System.Drawing.Point(259, 11);
			this.buttonOpen.Name = "buttonOpen";
			this.buttonOpen.Size = new System.Drawing.Size(60, 23);
			this.buttonOpen.TabIndex = 3;
			this.buttonOpen.Text = "Open";
			this.buttonOpen.UseVisualStyleBackColor = true;
			this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
			// 
			// tbFile
			// 
			this.tbFile.Location = new System.Drawing.Point(12, 12);
			this.tbFile.Name = "tbFile";
			this.tbFile.Size = new System.Drawing.Size(241, 20);
			this.tbFile.TabIndex = 2;
			// 
			// LoadKeys
			// 
			this.AcceptButton = this.buttonUnlock;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(332, 82);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.buttonUnlock);
			this.Controls.Add(this.buttonOpen);
			this.Controls.Add(this.tbFile);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LoadKeys";
			this.Text = "Load API Keys";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Button buttonUnlock;
		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.TextBox tbFile;
	}
}