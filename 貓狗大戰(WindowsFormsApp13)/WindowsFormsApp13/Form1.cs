using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private int wind = 0;
		private void Form1_Load(object sender, EventArgs e) // 狗先攻擊
		{
			button3.Visible = true;
			this.BackColor = Color.GreenYellow; // 背景顏色
			progressBar1.Maximum = progressBar2.Maximum = 10; // 設定血量最大值
			progressBar1.Minimum = progressBar2.Minimum = 0; // 血量為空
			progressBar1.Value = progressBar2.Value = 10; // 開始時血量是滿的
			progressBar3.Maximum = progressBar4.Maximum = 100; // 設定拋物角度 力道最大值
			progressBar3.Minimum = progressBar4.Minimum = 1; // 設定拋物角度 力道最小值
			progressBar1.Visible = progressBar2.Visible = progressBar3.Visible = progressBar4.Visible = false; // 隱藏貓的力道bar
			label2.Visible = label3.Visible = false; // 隱藏貓攻擊
			pictureBox1.Visible = pictureBox2.Visible = pictureBox3.Visible = false; // 隱藏攻擊用垃圾
			label1.Visible = label4.Visible = label5.Visible = label6.Visible = false; // 隱藏貓的回合標示label
			button1.Visible = button2.Visible = button4.Visible = button5.Visible = false; // 隱藏貓的攻擊確認鍵
		}
		private void button3_Click(object sender, EventArgs e)
		{
			game_start();
		}

		private void game_start()
		{
			button3.Visible = false;
			label7.Visible = false;
			progressBar1.Visible = progressBar2.Visible = progressBar3.Visible = true; // 顯示血量 顯示貓的力道bar
			label2.Visible = true; // 隱藏貓攻擊
			pictureBox1.Visible = pictureBox2.Visible = true; // 顯示玩家
			label1.Visible = label4.Visible = label6.Visible = true; // 隱藏貓的回合標示label
			button1.Visible = true; // 隱藏貓的攻擊確認鍵
			Random rmd = new Random(); // 初始隨機風向
			wind = rmd.Next(-5, 5);
			if (wind == 0)
			{
				label6.Text = "wind: 0";
			}
			if (wind > 0)
			{
				label6.Text = "-->wind" + wind.ToString();
			}
			if (wind < 0)
			{
				label6.Text = "wind<--" + wind.ToString();
			}
			timer1.Start(); // 開始計時狗的攻擊角度力道bar
		}

		private void button1_Click(object sender, EventArgs e) // 按下狗的確認鍵確定攻擊角度
		{
			initial_velocity = 0;
			timer1.Stop(); // 停止計時確認力道
			progressBar3.Visible = false; // 隱藏調整力道裝置
			label2.Visible = label4.Visible = false;
			button1.Visible = false;
			pictureBox3.Location = new Point(50, 300);
			pictureBox3.Visible = true;
			timer3.Start(); // 開始丟垃圾
		}

		private void button2_Click(object sender, EventArgs e) // 按下狗的確認鍵確定攻擊力道，並發動攻擊程序
		{
			initial_velocity = 0;
			timer2.Stop(); // 停止計時確認力道
			progressBar4.Visible = false; // 隱藏調整力道裝置
			label3.Visible = label5.Visible = false;
			button2.Visible = false;
			pictureBox3.Location = new Point(550, 300);
			pictureBox3.Visible = true;
			timer4.Start(); // 開始丟垃圾
		}

		private void timer1_Tick(object sender, EventArgs e) // 計時狗的攻擊角度bar，當到達最大值時再從0開始計
		{
			progressBar3.Value++;
			if (progressBar3.Value == 100)
			{
				progressBar3.Value = 1;
			}
		}

		private void timer2_Tick(object sender, EventArgs e) // 計時狗的攻擊力道bar，當到達最大值時再從0開始計
		{
			progressBar4.Value++;
			if (progressBar4.Value == 100)
			{
				progressBar4.Value = 1;
			}
		}

		private int initial_velocity = 0;
		private void timer3_Tick(object sender, EventArgs e)
		{
			initial_velocity++;
			pictureBox3.Top += (-progressBar3.Value) / 4 + initial_velocity; // 重力加速度
			pictureBox3.Left += progressBar3.Value / 4 + wind * 2; // 初速度向右
			if (pictureBox3.Top + 30 > pictureBox2.Top && pictureBox3.Top < pictureBox2.Top + 80 && pictureBox3.Left + 30 > pictureBox2.Left && pictureBox3.Left < pictureBox2.Left + 90)
			{ // 若有砸中就扣貓的血換貓攻擊
				pictureBox3.Visible = false; // 擊中目標後垃圾消失
				progressBar2.Value--; // 扣貓血
				if (progressBar2.Value == 0) //狗贏
				{
					button4.Visible = true;
					button5.Visible = true;
				}
				progressBar3.Value = 1; // 力道bar歸0
				label3.Visible = label5.Visible = true;
				progressBar4.Visible = true; // 換貓攻擊
				button2.Visible = true;
				timer2.Start();
				Random rmd = new Random(); // 初始隨機風向
				wind = rmd.Next(-5, 5);
				if (wind == 0)
				{
					label6.Text = "wind: 0";
				}
				if (wind > 0)
				{
					label6.Text = "-->wind" + wind.ToString();
				}
				if (wind < 0)
				{
					label6.Text = "wind<--" + wind.ToString();
				}
				timer3.Stop();
			}
			if (pictureBox3.Top > 400 || (pictureBox3.Left > 600 && pictureBox3.Top > 400))
			{ // 若沒砸中，換貓攻擊
				pictureBox3.Visible = false; // 擊中目標後垃圾消失
				progressBar3.Value = 1; // 力道bar歸0
				label3.Visible = label5.Visible = true;
				progressBar4.Visible = true; // 換貓攻擊
				button2.Visible = true;
				timer2.Start();
				Random rmd = new Random(); // 初始隨機風向
				wind = rmd.Next(-5, 5);
				if (wind == 0)
				{
					label6.Text = "wind: 0";
				}
				if (wind > 0)
				{
					label6.Text = "-->wind" + wind.ToString();
				}
				if (wind < 0)
				{
					label6.Text = "wind<--" + wind.ToString();
				}
				timer3.Stop();
			}
		}

		private void timer4_Tick(object sender, EventArgs e)
		{
			initial_velocity++;
			pictureBox3.Top += (-progressBar4.Value) / 4 + initial_velocity; // 重力加速度
			pictureBox3.Left -= progressBar4.Value / 4 - wind * 2; // 初速度向左
			if (pictureBox3.Top + 30 > pictureBox1.Top && pictureBox3.Top < pictureBox1.Top + 80 && pictureBox3.Left + 30 > pictureBox1.Left && pictureBox3.Left < pictureBox1.Left + 90)
			{ // 若有砸中就扣狗的血換狗攻擊
				pictureBox3.Visible = false; // 擊中目標後垃圾消失
				progressBar4.Value = 1; // 力道bar歸0
				progressBar1.Value--; // 扣狗血
				if (progressBar1.Value == 0) // 貓贏
				{
					button4.Visible = true;
					button5.Visible = true;
				}
				timer3.Stop();
				label2.Visible = label4.Visible = true;
				progressBar3.Visible = true; // 換狗攻擊
				button1.Visible = true;
				timer1.Start();
				Random rmd = new Random(); // 初始隨機風向
				wind = rmd.Next(-5, 5);
				if (wind == 0)
				{
					label6.Text = "wind: 0";
				}
				if (wind > 0)
				{
					label6.Text = "-->wind" + wind.ToString();
				}
				if (wind < 0)
				{
					label6.Text = "wind<--" + wind.ToString();
				}
				timer4.Stop();
			}
			if (pictureBox3.Top > 400 || (pictureBox3.Left < -50 && pictureBox3.Top > 400))
			{ // 若沒砸中，換狗攻擊
				pictureBox3.Visible = false; // 擊中目標後垃圾消失
				progressBar4.Value = 1; // 力道bar歸0
				timer3.Stop();
				label2.Visible = label4.Visible = true;
				progressBar3.Visible = true; // 換狗攻擊
				button1.Visible = true;
				timer1.Start();
				Random rmd = new Random(); // 初始隨機風向
				wind = rmd.Next(-5, 5);
				if (wind == 0)
				{
					label6.Text = "wind: 0";
				}
				if (wind > 0)
				{
					label6.Text = "-->wind" + wind.ToString();
				}
				if (wind < 0)
				{
					label6.Text = "wind<--" + wind.ToString();
				}
				timer4.Stop();
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Form1_Load(sender, e);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			System.Environment.Exit(0);
		}
	}
}
