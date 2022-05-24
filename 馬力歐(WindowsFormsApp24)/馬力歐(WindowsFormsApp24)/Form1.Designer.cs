namespace 馬力歐_WindowsFormsApp24_
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.button1 = new System.Windows.Forms.Button();
			this.timer_vertical_move = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.timer_game_time = new System.Windows.Forms.Timer(this.components);
			this.timer_horizantal_move = new System.Windows.Forms.Timer(this.components);
			this.timer_monster_move = new System.Windows.Forms.Timer(this.components);
			this.timer_monster_die_animation = new System.Windows.Forms.Timer(this.components);
			this.timer_gothrough_animation = new System.Windows.Forms.Timer(this.components);
			this.timer_endgame = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(331, 197);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(155, 70);
			this.button1.TabIndex = 0;
			this.button1.Text = "START";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// timer_vertical_move
			// 
			this.timer_vertical_move.Interval = 25;
			this.timer_vertical_move.Tick += new System.EventHandler(this.timer_vertical_move_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(-11, 381);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(815, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = resources.GetString("label1.Text");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label2.Location = new System.Drawing.Point(-11, 396);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(815, 45);
			this.label2.TabIndex = 2;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(627, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 15);
			this.label3.TabIndex = 3;
			this.label3.Text = "player.Top: ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(627, 91);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 15);
			this.label4.TabIndex = 4;
			this.label4.Text = "label4";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(630, 13);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 15);
			this.label5.TabIndex = 5;
			this.label5.Text = "score: ";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 13);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 15);
			this.label6.TabIndex = 6;
			this.label6.Text = "time: ";
			// 
			// timer_game_time
			// 
			this.timer_game_time.Interval = 1000;
			this.timer_game_time.Tick += new System.EventHandler(this.timer_game_time_Tick);
			// 
			// timer_horizantal_move
			// 
			this.timer_horizantal_move.Interval = 1;
			this.timer_horizantal_move.Tick += new System.EventHandler(this.timer_horizantal_move_Tick);
			// 
			// timer_monster_move
			// 
			this.timer_monster_move.Tick += new System.EventHandler(this.timer_monster_move_Tick);
			// 
			// timer_monster_die_animation
			// 
			this.timer_monster_die_animation.Interval = 3000;
			this.timer_monster_die_animation.Tick += new System.EventHandler(this.timer_monster_die_animation_Tick);
			// 
			// timer_gothrough_animation
			// 
			this.timer_gothrough_animation.Interval = 2000;
			this.timer_gothrough_animation.Tick += new System.EventHandler(this.timer_gothrough_animation_Tick);
			// 
			// timer_endgame
			// 
			this.timer_endgame.Interval = 10;
			this.timer_endgame.Tick += new System.EventHandler(this.timer_endgame_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 439);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Timer timer_vertical_move;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Timer timer_game_time;
		private System.Windows.Forms.Timer timer_horizantal_move;
		private System.Windows.Forms.Timer timer_monster_move;
		private System.Windows.Forms.Timer timer_monster_die_animation;
		private System.Windows.Forms.Timer timer_gothrough_animation;
		private System.Windows.Forms.Timer timer_endgame;
	}
}

