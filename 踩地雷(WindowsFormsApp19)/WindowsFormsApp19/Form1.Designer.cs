namespace WindowsFormsApp19
{
	partial class Form1
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.難度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.初級ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.中級ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.困難ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(178, 184);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(152, 71);
			this.button1.TabIndex = 0;
			this.button1.Text = "START";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(219, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(211, 35);
			this.label1.TabIndex = 1;
			this.label1.Text = "Use: 0 second";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.難度ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(502, 33);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 難度ToolStripMenuItem
			// 
			this.難度ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.初級ToolStripMenuItem,
            this.中級ToolStripMenuItem,
            this.困難ToolStripMenuItem});
			this.難度ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.難度ToolStripMenuItem.Name = "難度ToolStripMenuItem";
			this.難度ToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
			this.難度ToolStripMenuItem.Text = "難度";
			// 
			// 初級ToolStripMenuItem
			// 
			this.初級ToolStripMenuItem.Name = "初級ToolStripMenuItem";
			this.初級ToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
			this.初級ToolStripMenuItem.Text = "簡單";
			this.初級ToolStripMenuItem.Click += new System.EventHandler(this.初級ToolStripMenuItem_Click);
			// 
			// 中級ToolStripMenuItem
			// 
			this.中級ToolStripMenuItem.Name = "中級ToolStripMenuItem";
			this.中級ToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
			this.中級ToolStripMenuItem.Text = "普通";
			this.中級ToolStripMenuItem.Click += new System.EventHandler(this.中級ToolStripMenuItem_Click);
			// 
			// 困難ToolStripMenuItem
			// 
			this.困難ToolStripMenuItem.Name = "困難ToolStripMenuItem";
			this.困難ToolStripMenuItem.Size = new System.Drawing.Size(216, 30);
			this.困難ToolStripMenuItem.Text = "困難";
			this.困難ToolStripMenuItem.Click += new System.EventHandler(this.困難ToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(502, 503);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 難度ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 初級ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 中級ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 困難ToolStripMenuItem;
	}
}

