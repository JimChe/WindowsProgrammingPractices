namespace 俄羅斯方塊_WindowsFormsApp25_
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
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.timer_falldown = new System.Windows.Forms.Timer(this.components);
			this.timer_animation = new System.Windows.Forms.Timer(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Showcard Gothic", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(182, 115);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(270, 60);
			this.label1.TabIndex = 0;
			this.label1.Text = "俄羅斯方塊";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(246, 262);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(155, 49);
			this.button1.TabIndex = 1;
			this.button1.Text = "start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("新細明體", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label2.Location = new System.Drawing.Point(418, 21);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 28);
			this.label2.TabIndex = 2;
			this.label2.Text = "label2";
			// 
			// timer_falldown
			// 
			this.timer_falldown.Interval = 1000;
			this.timer_falldown.Tick += new System.EventHandler(this.timer_falldown_Tick);
			// 
			// timer_animation
			// 
			this.timer_animation.Interval = 10;
			this.timer_animation.Tick += new System.EventHandler(this.timer_animation_Tick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(460, 236);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "Hold";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(460, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 15);
			this.label4.TabIndex = 4;
			this.label4.Text = "Next";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(633, 620);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer timer_falldown;
		private System.Windows.Forms.Timer timer_animation;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
	}
}

