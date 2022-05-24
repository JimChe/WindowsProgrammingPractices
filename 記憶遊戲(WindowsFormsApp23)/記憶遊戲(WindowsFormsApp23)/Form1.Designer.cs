namespace 記憶遊戲_WindowsFormsApp23_
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
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.timer_close_card = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.timer_close_card2 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(597, 254);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(140, 66);
			this.button1.TabIndex = 0;
			this.button1.Text = "開始遊戲";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(597, 234);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(140, 66);
			this.button2.TabIndex = 1;
			this.button2.Text = "下一關";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(303, 306);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(140, 66);
			this.button3.TabIndex = 2;
			this.button3.Text = "重新開始";
			this.button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(903, 306);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(140, 66);
			this.button4.TabIndex = 3;
			this.button4.Text = "結束遊戲";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// timer_close_card
			// 
			this.timer_close_card.Interval = 5000;
			this.timer_close_card.Tick += new System.EventHandler(this.timer_close_card_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(1026, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 30);
			this.label1.TabIndex = 4;
			this.label1.Text = "label1";
			// 
			// timer_close_card2
			// 
			this.timer_close_card2.Interval = 1000;
			this.timer_close_card2.Tick += new System.EventHandler(this.timer_close_card2_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1319, 579);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Timer timer_close_card;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer_close_card2;
	}
}

