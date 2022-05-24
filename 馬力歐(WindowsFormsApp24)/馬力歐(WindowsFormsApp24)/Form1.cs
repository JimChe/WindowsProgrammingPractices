using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 馬力歐_WindowsFormsApp24_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		PictureBox[] brick = new PictureBox[100]; //宣告磚塊陣列
		PictureBox[] coin = new PictureBox[10]; // 宣告金幣陣列
		PictureBox[] monster = new PictureBox[3]; // 宣告怪物陣列
		PictureBox secret_entrance = new PictureBox(); // 宣告密道入口
		PictureBox secret_exit = new PictureBox(); // 宣告密道出口
		PictureBox player = new PictureBox(); // 宣告人物
		Label distination = new Label(); // 宣告棋子(終點)
		PictureBox castle = new PictureBox(); // 宣告城堡

		private void Form1_Load(object sender, EventArgs e)
		{
			button1.Visible = button1.Enabled = true; // 顯示開始鍵
			set_map();
			hide_map();
		}

		private void set_map()
		{
			player.Image = Image.FromFile(@"恐龍.jpg"); // 建立圖片檔案
			player.SizeMode = PictureBoxSizeMode.StretchImage; // 修正size問題
			Controls.Add(player); // 加到螢幕上
			for (int i = 0; i < 42; i++) //初始化地圖物件
			{
				brick[i] = new PictureBox(); // 初始化磚塊
				brick[i].Image = Image.FromFile(@"brick.jpg"); // 建立磚塊圖片檔案
				brick[i].SizeMode = PictureBoxSizeMode.StretchImage; // 修正圖片size問題
				Controls.Add(brick[i]); // 加到螢幕上
			}
			for (int i = 0; i < 3; i++)
			{
				monster[i] = new PictureBox();
				monster[i].Image = Image.FromFile(@"香菇.jpg");
				monster[i].SizeMode = PictureBoxSizeMode.StretchImage; // 修正圖片size問題
				Controls.Add(monster[i]); // 加到螢幕上
				monster_alive[i] = true;
				monster_move[i] = 2;
			}
			for (int i = 0; i < 10; i++)
			{
				coin[i] = new PictureBox();
				coin[i].Image = Image.FromFile(@"金幣.jpg");
				coin[i].SizeMode = PictureBoxSizeMode.StretchImage; // 修正圖片size問題
				Controls.Add(coin[i]); // 加到螢幕上
			}
			secret_entrance.Image = Image.FromFile(@"密道.jpg");
			secret_entrance.SizeMode = PictureBoxSizeMode.StretchImage; // 修正圖片size問題
			Controls.Add(secret_entrance); // 加到螢幕上
			secret_exit.Image = Image.FromFile(@"密道.jpg");
			secret_exit.SizeMode = PictureBoxSizeMode.StretchImage; // 修正圖片size問題
			Controls.Add(secret_exit); // 加到螢幕上
			distination.BackColor = Color.White;
			Controls.Add(distination);
			castle.Image = Image.FromFile(@"城堡.jpg");
			castle.SizeMode = PictureBoxSizeMode.StretchImage; // 修正圖片size問題
			Controls.Add(castle); // 加到螢幕上
			hide_map();
		}

		private void hide_map()
		{
			for (int i=0; i<42; i++)
			{
				brick[i].Visible = false;
			}
			for (int i=0; i<3; i++)
			{
				monster[i].Visible = false;
			}
			for (int i=0; i<10; i++)
			{
				coin[i].Visible = false;
			}
			player.Visible = false;
			secret_entrance.Visible = false;
			secret_exit.Visible = false;
			distination.Visible = false;
			castle.Visible = false;
		}

		private void display_map()
		{
			for (int i = 0; i < 42; i++)
			{
				brick[i].Visible = true;
			}
			for (int i = 0; i < 3; i++)
			{
				monster[i].Visible = true;
			}
			for (int i = 0; i < 10; i++)
			{
				coin[i].Visible = true;
			}
			player.Visible = true;
			secret_entrance.Visible = true;
			secret_exit.Visible = true;
			distination.Visible = true;
			castle.Visible = true;
		}

		private void button1_Click(object sender, EventArgs e) // 排列好地圖個個物件的位置
		{
			button1.Visible = button1.Enabled = false; // 隱藏開始鍵
			player.SetBounds(280, 264, 40, 40); // 初始化位置大小
			brick[0].SetBounds(400, 265, 40, 40); // 初始化位置大小
			brick[1].SetBounds(600, 265, 40, 40);
			for (int i = 2; i < 7; i++)
			{
				brick[i].SetBounds(650 + 40 * (i - 2), 179, 40, 40); // 前方平台
			}
			for (int i = 7; i < 17; i++)
			{
				brick[i].SetBounds(950 + 40 * (i - 7), 199, 40, 40); // 前方平台
			}
			for (int i = 17; i < 21; i++)
			{
				brick[i].SetBounds(1070 + 40 * (i - 17), 110, 40, 40); // 前方平台
			}
			int sum = 0;
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < i + 1; j++)
				{
					brick[sum + 21].SetBounds(1470 + 40 * i, 265 - 40 * j, 40, 40); // 最後階梯
					sum++;
				}
			}
			monster[0].SetBounds(1150, 70, 40, 40);
			monster[1].SetBounds(1470, 225, 40, 40);
			monster[2].SetBounds(1630, 65, 40, 40);
			for (int i=0; i<10; i++)
			{
				coin[i].SetBounds(640 + 80 * i, 264, 40, 40);
			}
			secret_entrance.SetBounds(460, 185, 80, 120);
			secret_exit.SetBounds(1710, 185, 80, 120);
			distination.SetBounds(2110, 0, 10, 305);
			castle.SetBounds(2210, 205, 100, 100);
			display_map(); // 顯示地圖
			timer_vertical_move.Start(); // 開啟移動計時器(開始可以移動)
			timer_horizantal_move.Start();
			timer_game_time.Start();
			timer_monster_move.Start();
		}

		private bool go_right = false, go_left = false, jump = false; // 宣告變數紀錄玩家移動的狀態
		private bool can_gothrough = false;
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			/*****起跳******/
			if (jump == false && (e.KeyCode == Keys.Up || e.KeyCode == Keys.W))
			{
				velocity = 15; // 故意不要讓v<0(可能迴圈剛好在讓他速度變成小於0的地方)
				jump = true; // 將跳躍狀態改為跳躍中
			}
			/*****控制左右*****/
			if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
			{
				go_right = true; // 移動狀態改為往右
				go_left = false; // 移除往左移動狀態
				for (int i = 0; i < 42; i++) // 逐一檢查是否撞到障礙物
				{
					if (player.Top + 39 >= brick[i].Top && player.Top - 39 <= brick[i].Top && player.Left + 39 >= brick[i].Left && player.Left - 20 <= brick[i].Left)
					{
						go_right = false;
					}
					else if (player.Top + 39 >= secret_entrance.Top && player.Top - 119 <= secret_entrance.Top && player.Left + 40 >= secret_entrance.Left && player.Left - 20 <= secret_entrance.Left)
					{
						go_right = false;
					}
					else if (player.Top + 39 >= secret_exit.Top && player.Top - 119 <= secret_exit.Top && player.Left + 40 >= secret_exit.Left && player.Left - 20 <= secret_exit.Left)
					{
						go_right = false;
					}
				}
				if (player.Top + 39 >= distination.Top && player.Top - 305 <= distination.Top && player.Left + 39 >= distination.Left && player.Left + 10 >= distination.Left)
				{
					velocity = 0;
					score += 1000 - player.Top;
					timer_vertical_move.Stop(); // 將計時器暫停
					timer_horizantal_move.Stop();
					timer_game_time.Stop();
					timer_monster_move.Stop();
					timer_endgame.Start();
				}
			}
			if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
			{
				go_right = false; // 移除往右移動狀態
				go_left = true; // 移動狀態改為往左
				for (int i = 0; i < 42; i++) // 逐一檢查是否撞到障礙物
				{
					if (player.Top + 39 >= brick[i].Top && player.Top - 39 <= brick[i].Top && player.Left + 20 >= brick[i].Left && player.Left - 39 <= brick[i].Left)
					{
						go_left = false;
					}
					else if (player.Top + 39 >= secret_entrance.Top && player.Top - 119 <= secret_entrance.Top && player.Left + 20 >= secret_entrance.Left && player.Left - 80 <= secret_entrance.Left)
					{
						go_left = false;
					}
					else if (player.Top + 39 >= secret_exit.Top && player.Top - 119 <= secret_exit.Top && player.Left + 20 >= secret_exit.Left && player.Left - 80 <= secret_exit.Left)
					{
						go_left = false;
					}
				}
			}
			if ((e.KeyCode == Keys.Down || e.KeyCode == Keys.S) && can_gothrough == true)
			{
				timer_gothrough_animation.Start();
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
			{
				go_right = false;
			}
			if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
			{
				go_left = false;
			}
		}

		private int velocity = 0; // 宣告玩家下墜時的速度
		private int time = 180;
		private int score = 0;

		private void timer_game_time_Tick(object sender, EventArgs e)
		{
			label6.Text = "Time: " + time.ToString();
			time--;
			if (time == 0) // 如果時間到尚未過關則遊戲結束
			{
				game_over();
			}
		}

		private int[] monster_move = new int[3];
		private int[] monster_velocity = new int[3];
		private void timer_monster_move_Tick(object sender, EventArgs e)
		{
			for (int i=0; i<3; i++) // 左右移動
			{
				if (monster_alive[i] == true)
				{
					monster[i].Left -= monster_move[i];
					if (monster[i].Top + 10 >= brick[1].Top && monster[i].Top - 10 <= brick[1].Top && monster[i].Left + 39 >= brick[1].Left && monster[i].Left - 39 <= brick[1].Left)
					{
						monster_move[i] *= -1;
					}
					else if (monster[i].Top + 10 >= brick[21].Top && monster[i].Top - 10 <= brick[21].Top && monster[i].Left + 39 >= brick[21].Left && monster[i].Left - 39 <= brick[21].Left)
					{
						monster_move[i] *= -1;
					}
					if (monster_velocity[i] < 0)
					{
						for (int j = 0; j < 42; j++) // 香菇踩在方塊上
						{
							if (monster[i].Top + 40 >= brick[j].Top && monster[i].Top - 20 <= brick[j].Top && monster[i].Left + 37 >= brick[j].Left && monster[i].Left - 37 <= brick[j].Left)
							{
								monster[i].Top = brick[i].Top - 41;
								monster_velocity[i] = 0;
							}
						}
						if (monster[i].Top >= 264) // 香菇掉到地板上
						{
							monster[i].Top = 264;
							monster_velocity[i] = 0;
						}
					}
					monster[i].Top -= monster_velocity[i];
					monster_velocity[i]--;
				}
			}
		}

		private bool[] monster_alive = new bool[3];

		private void timer_monster_die_animation_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < 3; i++)
			{
				if (monster_alive[i] == false)
				{
					monster[i].Visible = false;
				}
			}
			timer_monster_die_animation.Stop();
		}

		private void whether_get_coin()
		{
			for (int i=0; i<10; i++)
			{
				if (coin[i].Visible == true && player.Top + 40 >= coin[i].Top && player.Top - 40 <= coin[i].Top && player.Left + 40 >= coin[i].Left && player.Left - 40 <= coin[i].Left)
				{
					coin[i].Visible = false;
					score += 100;
				}
			}
		}

		private void timer_horizantal_move_Tick(object sender, EventArgs e) // 玩家左右移動的計時器
		{
			label4.Text = "player.Left: " + player.Left.ToString(); // 測試
			whether_get_coin();
			if (go_right == true)
			{
				if (player.Left >= 280)
				{
					for (int i = 0; i < 42; i++)
					{
						if (i < 3)
						{
							monster[i].Left -= 1;
						}
						if (i < 10)
						{
							coin[i].Left -= 1;
						}
						brick[i].Left -= 1;
					}
					secret_entrance.Left -= 1;
					secret_exit.Left -= 1;
					distination.Left -= 1;
					castle.Left -= 1;
				}
				else if (player.Left >= 0 && player.Left < 280)
				{
					player.Left += 1;
				}
			}
			if (go_left == true)
			{
				if (player.Left > 0 && player.Left <= 280)
				{
					player.Left -= 1;
				}
				else
				{
					player.Left = player.Left;
				}
			}
			for (int i = 0; i < 3; i++) // 判斷是否碰到香菇
			{
				if (monster_alive[i] == true && monster[i].Visible == true && player.Top + 20 >= monster[i].Top && player.Top - 39 <= monster[i].Top && player.Left + 39 >= monster[i].Left && player.Left - 39 <= monster[i].Left)
				{
					game_over();
				}
			}
		}


		private void timer_vertical_move_Tick(object sender, EventArgs e) // 判斷玩家在垂直移動方向的計時器
		{
			can_gothrough = false;
			label3.Text = "player.Top: " + player.Top.ToString(); // 測試
			label5.Text = "Score: " + score.ToString();
			whether_get_coin();

			if (player.Top >= 264) // 跳躍於空中與地板之間
			{
				if (velocity < 0) // 如果跳躍後下墜(v<0)碰到地板
				{
					player.Top = 264;
					jump = false; // 將跳躍狀態改為非跳躍
				}
				velocity = 0; // 只要碰到地板就停下來
				if (jump == true) // 如果是跳躍狀態(按下跳躍鍵)就往上衝
				{
					velocity = 15;
				}
			}
			if (velocity < 0) // 往下墜的狀態
			{
				for (int i = 0; i < 42; i++) //判定是否跳到障礙物上
				{
					if (player.Top + 40 >= brick[i].Top && player.Top - 20 <= brick[i].Top && player.Left + 40 >= brick[i].Left && player.Left - 40 <= brick[i].Left)
					{
						player.Top = brick[i].Top - 41;
						velocity = 0;
						jump = false; // 將跳躍狀態改為非跳躍
					}
				}
				if (player.Top + 40 >= secret_entrance.Top && player.Top - 10 <= secret_entrance.Top && player.Left + 39 >= secret_entrance.Left && player.Left - 79 <= secret_entrance.Left)
				{
					player.Top = secret_entrance.Top - 41;
					velocity = 0;
					jump = false; // 將跳躍狀態改為非跳躍
					can_gothrough = true; // 在竹子上可穿越
				}
				if (player.Top + 40 >= secret_exit.Top && player.Top - 10 <= secret_exit.Top && player.Left + 39 >= secret_exit.Left && player.Left - 79 <= secret_exit.Left)
				{
					player.Top = secret_exit.Top - 41;
					velocity = 0;
					jump = false; // 將跳躍狀態改為非跳躍
				}
			}
			else if (velocity > 0) //往上衝的狀態
			{
				for (int i = 0; i < 42; i++) //判定是否頭撞到障礙物
				{
					if (player.Top + 40 >= brick[i].Top && player.Top - 40 <= brick[i].Top && player.Left + 40 >= brick[i].Left && player.Left - 40 <= brick[i].Left)
					{
						velocity = 1;
					}
				}
			}
			player.Top -= velocity;
			velocity -= 1;
			if (velocity < 0) // 判定是否採到香菇
			{
				for (int i = 0; i < 3; i++)
				{
					if (monster_alive[i] == true && monster[i].Visible == true && player.Top + 40 >= monster[i].Top && player.Top - 39 <= monster[i].Top && player.Left + 39 >= monster[i].Left && player.Left - 39 <= monster[i].Left)
					{
						monster[i].SetBounds(monster[i].Left, monster[i].Top + 32, 40, 8);
						monster_alive[i] = false;
						velocity = 5;
						score += 100;
						timer_monster_die_animation.Start(); 
					}
				}
			}
			if (player.Top + 39 >= distination.Top && player.Top - 305 <= distination.Top && player.Left + 39 >= distination.Left && player.Left + 10 >= distination.Left)
			{
				velocity = 0;
				score += 1000 - player.Top;
				timer_vertical_move.Stop(); // 將計時器暫停
				timer_horizantal_move.Stop();
				timer_game_time.Stop();
				timer_monster_move.Stop();
				timer_endgame.Start();
			}
		}

		private bool end = false;
		private void timer_endgame_Tick(object sender, EventArgs e)
		{
			label5.Text = "Score: " + score.ToString();
			label6.Text = "Time: " + time.ToString();
			if (player.Top < 264)
			{
				player.Top += 1;
			}
			else if (player.Top >= 264)
			{
				if (player.Left < 320)
				{
					player.Left += 1;
				}
				else if (player.Left >= 320)
				{
					player.Visible = false;
					score += 10;
					time--;
					if (time == 0)
					{
						end = true;
						timer_endgame.Stop();
						MessageBox.Show("遊戲結束!!!\r\n" + "獲得" + score.ToString() + "分");
						game_over();
					}
				}
			}
		}

		private void timer_gothrough_animation_Tick(object sender, EventArgs e)
		{
			for (int i = 0; i < 42; i++)
			{
				brick[i].Left -= 1400;
			}
			for (int i = 0; i < 3; i++)
			{
				monster[i].Left -= 1400;
			}
			for (int i = 0; i < 10; i++)
			{
				coin[i].Left -= 1400;
			}
			secret_entrance.Left -= 1400;
			secret_exit.Left -= 1400;
			distination.Left -= 1400;
			castle.Left -= 1400;
			player.Left -= 140;
			timer_gothrough_animation.Stop();
		}

		private void game_over()
		{
			score = 0; // 將物件重新初始化
			time = 180;
			go_right = go_left = jump = false;
			for (int i=0; i<3; i++)
			{
				monster_alive[i] = true;
			}
			timer_vertical_move.Stop(); // 將計時器暫停
			timer_horizantal_move.Stop();
			timer_game_time.Stop();
			timer_monster_move.Stop();
			hide_map();
			button1.Visible = button1.Enabled = true; // 可以重新開始
		}
	}
}
