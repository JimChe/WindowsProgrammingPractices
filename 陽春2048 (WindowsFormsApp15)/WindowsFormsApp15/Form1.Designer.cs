namespace WindowsFormsApp15
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
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.button6 = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(557, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(614, 224);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 66);
			this.button1.TabIndex = 1;
			this.button1.Text = "UP";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(614, 312);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 66);
			this.button2.TabIndex = 2;
			this.button2.Text = "DOWN";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(515, 312);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 66);
			this.button3.TabIndex = 3;
			this.button3.Text = "LEFT";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(713, 312);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 66);
			this.button4.TabIndex = 4;
			this.button4.Text = "RIGHT";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button5.Location = new System.Drawing.Point(287, 206);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(234, 68);
			this.button5.TabIndex = 5;
			this.button5.Text = "START";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Showcard Gothic", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(245, 30);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(327, 149);
			this.label2.TabIndex = 6;
			this.label2.Text = "2048";
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(29, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 375);
			this.label3.TabIndex = 8;
			this.label3.Text = "@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(128, 6);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 375);
			this.label4.TabIndex = 9;
			this.label4.Text = "@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(228, 6);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(20, 375);
			this.label5.TabIndex = 10;
			this.label5.Text = "@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(331, 6);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 375);
			this.label6.TabIndex = 11;
			this.label6.Text = "@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(433, 6);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(20, 375);
			this.label7.TabIndex = 12;
			this.label7.Text = "@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n@\r\n";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(29, -5);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(378, 15);
			this.label8.TabIndex = 13;
			this.label8.Text = "#####################################################";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(29, 188);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(378, 15);
			this.label9.TabIndex = 14;
			this.label9.Text = "#####################################################";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(29, 95);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(378, 15);
			this.label10.TabIndex = 15;
			this.label10.Text = "#####################################################";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(29, 289);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(378, 15);
			this.label11.TabIndex = 16;
			this.label11.Text = "#####################################################";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(29, 373);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(378, 15);
			this.label12.TabIndex = 17;
			this.label12.Text = "#####################################################";
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(614, 136);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 18;
			this.button6.Text = "previous";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(557, 61);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 18);
			this.label13.TabIndex = 19;
			this.label13.Text = "label13";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label13;
	}
}

