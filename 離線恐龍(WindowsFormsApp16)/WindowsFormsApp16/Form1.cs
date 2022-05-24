using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		List<Label> stone = new List<Label>(); // 宣告石頭物件
		private int stone_count = 0;
		private int stoness = 0;
		private void Form1_Load(object sender, EventArgs e)
		{
			button1.Visible = true;
			button1.Enabled = true;
			for (int i = 0; i<stone.LongCount(); i++)
			{
				stone[i].Visible = false;
				stone[i].Dispose();
			}
			pictureBox1.Visible = false; // 隱藏馬力歐
			label2.Visible = label3.Visible = false; // 隱藏地板
		}

		private void button1_Click(object sender, EventArgs e) // 按下開始鍵
		{
			//set_map();
			button1.Visible = false;
			button1.Enabled = false;
			pictureBox1.Visible = true;
			label2.Visible = label3.Visible = true; // 顯示地板
			mario_run_right_timer.Start();
		}
		private void set_map()
		{
			/*for (int i = 0; i < 100; i++) // 初始化石頭物件
			{
				stone[i] = new Label();
				stone[i].BackColor = Color.Gray;
				stone[i].Size = new Size(50, 50);
				Controls.Add(stone[i]);
			}
			stone[0].Size = new Size(400, 400);
			stone[0].Location = new Point(-200, 0);
			stone[1].Location = new Point(500, 270); //設定石頭們的位置
			stone[2].Location = new Point(900, 270);
			stone[3].Location = new Point(1300, 270);*/
		}

		private bool jump = false; //判斷是否在跳躍期間
		private void Form1_KeyDown(object sender, KeyEventArgs e) // 按下按鍵(或持續按著)馬力歐跑動
		{
			if ((e.KeyCode == Keys.Up || e.KeyCode == Keys.W) && jump == false) // 若不是在跳躍期間
			{
				gravity_timer.Start(); // 開始啟動重力加速度機制
				velocity = 40; //給定跳躍往往上出速度
				jump = true; // 設定為在跳躍期間
			}
			/*else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D)) // 如果沒有撞到東西(hit == false)才可以移動
			{
				label7.Text = "";
				label7.Text = stone[1].Left.ToString();
				mario_run_right_timer.Start(); // 讓物體往左移動看起來像馬力歐向右跑
				for (int i = 0; i < 99; i++)
				{
					if (pictureBox1.Left >= stone[i].Left + 50 && pictureBox1.Left + 55 <= stone[i + 1].Left) // 如果走出石頭上方(兩顆石頭之間(X軸))
					{
						gravity_timer.Start(); // 開始啟動重力加速度機制
					}
				}
				for (int i=1; i<100; i++) // 判斷往右走是否有撞到石頭
				{
					if (pictureBox1.Left + 55 >= stone[i].Left && pictureBox1.Left <= stone[i].Left + 55 && pictureBox1.Top + 50 >= stone[i].Top && pictureBox1.Top <= stone[i].Top + 50)
					{
						mario_run_right_timer.Stop(); //如果撞到石頭停止計時器表示停止移動
					}
				}
			}

			else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A) // 如果沒有撞到東西(hit == false)才可以移動
			{
				label7.Text = "";
				label7.Text = stone[1].Left.ToString();
				mario_run_left_timer.Start(); // 讓物體往右移動看起來像馬力歐向左跑
				pictureBox1.Left -= 2;
				for (int i = 0; i < 99; i++)
				{
					if (pictureBox1.Left >= stone[i].Left + 50 && pictureBox1.Left + 55 <= stone[i + 1].Left) // 如果走出石頭上方(兩顆石頭之間(X軸))
					{
						gravity_timer.Start(); // 開始啟動重力加速度機制
					}
				}
				if (distance <= -33) // 如果撞到左邊邊界不能再走
				{
					mario_run_left_timer.Stop();
				}
				for (int i = 1; i < 100; i++) // 判斷往左走是否有撞到石頭
				{
					if (pictureBox1.Left + 55 >= stone[i].Left && pictureBox1.Left <= stone[i].Left + 55 && pictureBox1.Top + 50 >= stone[i].Top && pictureBox1.Top <= stone[i].Top + 50)
					{
						mario_run_left_timer.Stop(); //如果撞到石頭停止計時器表示停止移動
					}
				}
				pictureBox1.Left += 2;
			}*/
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e) // 放開按鍵馬力歐停止跑動
		{
			/*
			if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
			{
				mario_run_right_timer.Stop();
			}

			if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
			{
				mario_run_left_timer.Stop();
			}*/
		}

		private int distance = 0;
		Random rmd = new Random();
		private void mario_run_right_timer_Tick(object sender, EventArgs e)
		{
			if (distance % 80 == 0)
			{
				int gen_stone = rmd.Next(900, 1500);
				int stone_w = rmd.Next(50, 60);
				int stone_h = rmd.Next(50, 60);
				Label stones = new Label();
				stones.BackColor = Color.Gray;
				stones.Size = new Size(stone_w, stone_h);
				stones.Location = new Point(gen_stone, 320 - stone_h);
				Controls.Add(stones);
				stone.Add(stones);
				stoness++;
			}
			for (int i = stone_count + 1; i<stone.LongCount(); i++) //逐一檢查石頭
			{
				if (pictureBox1.Left + 55 >= stone[i].Left && pictureBox1.Left <= stone[i].Left + 55 && pictureBox1.Top + 50 >= stone[i].Top && pictureBox1.Top <= stone[i].Top + 50)
				{
					stone_count = stoness;
					mario_run_right_timer.Stop();
					gravity_timer.Stop();
					velocity = 0;
					MessageBox.Show("Your scores: " + distance.ToString());
					Form1_Load(sender, e);
				}
				stone[i].Left -= 15 + (distance / 1000); // 若沒撞才繼續移動
			}
			label4.Text = "distance: " + distance.ToString();
			distance++;
		}

		private void mario_run_left_timer_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < 100; i++) //逐一檢查石頭
			{
				if (pictureBox1.Left + 55 >= stone[i].Left && pictureBox1.Left <= stone[i].Left + 55 && pictureBox1.Top + 50 >= stone[i].Top && pictureBox1.Top <= stone[i].Top + 50)
				{
					mario_run_left_timer.Stop();
					gravity_timer.Stop();
					MessageBox.Show("Your scores: " + distance.ToString());
					Form1_Load(sender , e);
				}
				stone[i].Left += 15; // 若沒撞才繼續移動
			}
			label4.Text = "distance: " + distance.ToString();
			distance--;
		}

		private int velocity = 0;
		private void gravity_timer_Tick(object sender, EventArgs e)
		{
			if (pictureBox1.Top >= 250 && jump == false) // 若馬力不是在跳躍期間(jump == false)才可以馬力歐起跳
			{
				velocity = 0; // 已經碰到地板或踩到石頭
			}
			pictureBox1.Top -= velocity; // Top值隨著下落速度改變
			velocity -= 4; // 下落速度隨時間增加
			if ( velocity <= 0 && jump == true) // 判斷馬力落地的情況(velocity<=0表示在下落)
			{
				for (int i = stone_count + 1; i<stone.LongCount(); i++) // 判定是否跳到石頭上
				{
					/*if (pictureBox1.Top + 65 >= stone[i].Top && pictureBox1.Top <= stone[i].Top + 55 && pictureBox1.Left + 55 >= stone[i].Left && pictureBox1.Left <= stone[i].Left + 55)
					{
						jump = false; //將馬力的跳躍狀態改為非跳躍期間
						velocity = 0; // 已經碰到地板或踩到石頭
						gravity_timer.Stop(); // 開始啟動重力加速度機制
					}*/
					if (pictureBox1.Left + 55 >= stone[i].Left && pictureBox1.Left <= stone[i].Left + 55 && pictureBox1.Top + 50 >= stone[i].Top && pictureBox1.Top <= stone[i].Top + 50)
					{
						stone_count = stoness;
						mario_run_right_timer.Stop();
						velocity = 0;
						gravity_timer.Stop();
						MessageBox.Show("Your scores: " + distance.ToString());
						Form1_Load(sender, e);
					}
				}
				if (pictureBox1.Top >= 250)
				{
					jump = false; //將馬力的跳躍狀態改為非跳躍期間
					velocity = 0; // 已經碰到地板或踩到石頭
					gravity_timer.Stop(); // 開始啟動重力加速度機制
				}
			}
		}
	}
}
