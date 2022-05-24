namespace 象棋
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
			this.start_button = new System.Windows.Forms.Button();
			this.end_button = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// start_button
			// 
			this.start_button.Location = new System.Drawing.Point(270, 370);
			this.start_button.Name = "start_button";
			this.start_button.Size = new System.Drawing.Size(171, 59);
			this.start_button.TabIndex = 0;
			this.start_button.Text = "雙人對戰";
			this.start_button.UseVisualStyleBackColor = true;
			this.start_button.Click += new System.EventHandler(this.start_button_Click);
			// 
			// end_button
			// 
			this.end_button.Location = new System.Drawing.Point(270, 507);
			this.end_button.Name = "end_button";
			this.end_button.Size = new System.Drawing.Size(171, 53);
			this.end_button.TabIndex = 1;
			this.end_button.Text = "結束遊戲";
			this.end_button.UseVisualStyleBackColor = true;
			this.end_button.Click += new System.EventHandler(this.end_button_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("新細明體", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(204, 147);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(292, 120);
			this.label1.TabIndex = 2;
			this.label1.Text = "象棋";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(702, 721);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.end_button);
			this.Controls.Add(this.start_button);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button start_button;
		private System.Windows.Forms.Button end_button;
		private System.Windows.Forms.Label label1;
	}
}

