using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 俄羅斯方塊_WindowsFormsApp25_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e) // 初始化以及隱藏物件
		{
			label1.Visible = label1.Enabled = true;
			label2.Visible = label2.Enabled = false;
			button1.Visible = button1.Enabled = true;
			label3.Visible = label3.Enabled = label4.Visible = label4.Enabled = false;
			initialize_map(); // 初始化地圖物件
			hide_map(); // 初始完畢後隱藏
		}

		private void button1_Click(object sender, EventArgs e) // 將物件顯示並隱藏開始按鈕
		{
			label1.Visible = label1.Enabled = false;
			label2.Visible = label2.Enabled = true;
			label2.Text = "Score: " + score.ToString();
			button1.Visible = button1.Enabled = false;
			label3.Visible = label3.Enabled = label4.Visible = label4.Enabled = true;
			display_map(); // 按下開始鍵之後顯示地圖
			gen_tetris();
			timer_falldown.Start();
		}

		Button[,] b_map = new Button[22, 12];
		int[,] map = new int[22, 12];
		private void initialize_map()
		{
			for (int i = 0; i < 22; i++) // 初始化顯示用地圖
			{
				for (int j = 0; j < 12; j++)
				{
					b_map[i, j] = new Button();
					b_map[i, j].SetBounds(10 + 20 * j, 20 + 20 * i, 20, 20);
					b_map[i, j].Enabled = false;
					Controls.Add(b_map[i, j]);
					if (i == 0 || i == 21 || j == 0 || j == 11)
					{
						b_map[i, j].BackColor = Color.Black;
					}
					else 
					{
						b_map[i, j].BackColor = Color.WhiteSmoke; // 空白的第方的button為白色(之後嗅出地圖時如果是白色button則隱藏)
					}
				}
			}

			for (int i=0; i<22; i++) // 初始化比對用地圖
			{
				for (int j=0; j<12; j++)
				{
					if (i == 0 || i == 21 || j == 0 || j == 11)
					{
						map[i, j] = -1; // 遊戲外框
					}
					else
					{
						map[i, j] = 0; // 空白處
					}
				}
			}
			for (int i=0; i<4; i++) // 初始化用來表示next的圖案
			{
				schematic_diagram_next[i] = new Button();
				schematic_diagram_next[i].Enabled = false;
				Controls.Add(schematic_diagram_next[i]);
				schematic_diagram_hold[i] = new Button();
				schematic_diagram_hold[i].Enabled = false;
				Controls.Add(schematic_diagram_hold[i]);
			}
		}

		private void hide_map() // 隱藏地圖
		{
			for (int i = 0; i < 22; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					b_map[i, j].Visible = false;
				}
			}
			for (int i=0; i<4; i++)
			{
				schematic_diagram_next[i].Visible = false;
				schematic_diagram_hold[i].Visible = false;
			}
		}

		private void display_map() // 顯示地圖
		{
			for (int i = 0; i < 22; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					if (b_map[i, j].BackColor != Color.WhiteSmoke) // 代表空白的button處隱藏
					{
						b_map[i, j].Visible = true;
					}
				}
			}
			for (int i = 0; i < 4; i++)
			{
				schematic_diagram_next[i].Visible = true;
				schematic_diagram_hold[i].Visible = true;
			}
		}

		private bool[,] tetris_rotation_status = new bool[7, 4]; // 紀錄方塊的旋轉狀態(7表示7種方塊，4表示4種狀態)[x, y]表示目前方塊為第x種的方塊的第y種狀態
		private void Form1_KeyDown(object sender, KeyEventArgs e) // 操作遊戲部分(移動以及放置方塊)
		{
			if (e.KeyCode == Keys.Up) // 改變方塊方向
			{
				int t_count = 0; // 記錄方塊個數位置的變數
				for (int i = 21; i >= 0; i--) // 先找出目前方塊位置
				{
					for (int j = 11; j >= 0; j--)
					{
						if (map[i, j] >= 8 && map[i, j] <= 14)
						{
							tetris[t_count, 0] = i;
							tetris[t_count, 1] = j;
							t_count++;
						}
					}
				}
				// 分開討論每種方塊在不同狀態是否能旋轉 (O型方塊初始狀態怎麼旋轉都一樣，不用討論)
				/*******I型方塊*******/
				// I型方塊初始狀態
				if (tetris_rotation_status[1, 0] == true && map[tetris[3, 0] + 1, tetris[3, 1]] == 0 && map[tetris[3, 0] + 2, tetris[3, 1]] == 0 && map[tetris[3, 0] + 3, tetris[3, 1]] == 0)
				{
					map[tetris[3, 0] + 1, tetris[3, 1]] = map[tetris[3, 0] + 2, tetris[3, 1]] = map[tetris[3, 0] + 3, tetris[3, 1]] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[3, 0], tetris[3, 1] + 1] = map[tetris[3, 0], tetris[3, 1] + 2] = map[tetris[3, 0], tetris[3, 1] + 3] = 0;
					tetris_rotation_status[1, 1] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[1, 0] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[1, 1] == true && map[tetris[3, 0], tetris[3, 1] + 1] == 0 && map[tetris[3, 0], tetris[3, 1] + 2] == 0 && map[tetris[3, 0], tetris[3, 1] + 3] == 0)
				{
					map[tetris[3, 0], tetris[3, 1] + 1] = map[tetris[3, 0], tetris[3, 1] + 2] = map[tetris[3, 0], tetris[3, 1] + 3] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[3, 0] + 1, tetris[3, 1]] = map[tetris[3, 0] + 2, tetris[3, 1]] = map[tetris[3, 0] + 3, tetris[3, 1]] = 0;
					tetris_rotation_status[1, 0] = true;
					tetris_rotation_status[1, 1] = false;
				}
				/*********/
				/*******S型方塊********/
				if (tetris_rotation_status[2, 0] == true && map[tetris[2, 0] + 1, tetris[2, 1]] == 0 && map[tetris[2, 0] + 2, tetris[2, 1]] == 0)
				{
					map[tetris[2, 0] + 1, tetris[2, 1]] = map[tetris[2, 0] + 2, tetris[2, 1]] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[2, 0], tetris[2, 1]] = map[tetris[1, 0], tetris[1, 1]] = 0;
					tetris_rotation_status[2, 1] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[2, 0] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[2, 1] == true && map[tetris[3, 0], tetris[3, 1] + 1] == 0 && map[tetris[2, 0], tetris[2, 1] - 1] == 0)
				{
					map[tetris[3, 0], tetris[3, 1] + 1] = map[tetris[2, 0], tetris[2, 1] - 1] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[0, 0], tetris[0, 1]] = map[tetris[1, 0], tetris[1, 1]] = 0;
					tetris_rotation_status[2, 0] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[2, 1] = false; // 關閉直的旋轉狀態
				}
				/************/
				/*******Z型方塊********/
				if (tetris_rotation_status[3, 0] == true && map[tetris[3, 0] + 1, tetris[3, 1]] == 0 && map[tetris[3, 0] + 2, tetris[3, 1]] == 0)
				{
					map[tetris[3, 0] + 1, tetris[3, 1]] = map[tetris[3, 0] + 2, tetris[3, 1]] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[3, 0], tetris[3, 1]] = map[tetris[0, 0], tetris[0, 1]] = 0;
					tetris_rotation_status[3, 1] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[3, 0] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[3, 1] == true && map[tetris[3, 0], tetris[3, 1] - 1] == 0 && map[tetris[1, 0], tetris[1, 1] + 1] == 0)
				{
					map[tetris[3, 0], tetris[3, 1] - 1] = map[tetris[1, 0], tetris[1, 1] + 1] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[0, 0], tetris[0, 1]] = map[tetris[2, 0], tetris[2, 1]] = 0;
					tetris_rotation_status[3, 0] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[3, 1] = false; // 關閉直的旋轉狀態
				}
				/************/
				/*******L型方塊*******/
				if (tetris_rotation_status[4, 0] == true && map[tetris[2, 0], tetris[2, 1] - 1] == 0 && map[tetris[2, 0], tetris[2, 1] + 1] == 0 && map[tetris[1, 0], tetris[1, 1] - 1] == 0)
				{
					map[tetris[2, 0], tetris[2, 1] - 1] = map[tetris[2, 0], tetris[2, 1] + 1] = map[tetris[1, 0], tetris[1, 1] - 1] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[3, 0], tetris[3, 1]] = map[tetris[1, 0], tetris[1, 1]] = map[tetris[0, 0], tetris[0, 1]] = 0;
					tetris_rotation_status[4, 1] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[4, 0] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[4, 1] == true && map[tetris[1, 0] + 1, tetris[1, 1]] == 0 && map[tetris[1, 0] + 2, tetris[1, 1]] == 0)
				{
					map[tetris[1, 0] + 1, tetris[1, 1]] = map[tetris[1, 0] + 2, tetris[1, 1]] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[0, 0], tetris[0, 1]] = map[tetris[3, 0], tetris[3, 1]] = 0;
					tetris_rotation_status[4, 2] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[4, 1] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[4, 2] == true && map[tetris[1, 0], tetris[1, 1] - 1] == 0 && map[tetris[1, 0], tetris[1, 1] - 2] == 0)
				{
					map[tetris[1, 0], tetris[1, 1] - 1] = map[tetris[1, 0], tetris[1, 1] - 2] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[3, 0], tetris[3, 1]] = map[tetris[0, 0], tetris[0, 1]] = 0;
					tetris_rotation_status[4, 3] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[4, 2] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[4, 3] == true && map[tetris[1, 0] - 1, tetris[1, 1]] == 0 && map[tetris[1, 0] + 1, tetris[1, 1]] == 0 && map[tetris[0, 0] + 1, tetris[0, 1]] == 0)
				{
					map[tetris[1, 0] - 1, tetris[1, 1]] = map[tetris[1, 0] + 1, tetris[1, 1]] = map[tetris[0, 0] + 1, tetris[0, 1]] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[0, 0], tetris[0, 1]] = map[tetris[2, 0], tetris[2, 1]] = map[tetris[3, 0], tetris[3, 1]] = 0;
					tetris_rotation_status[4, 0] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[4, 3] = false; // 關閉直的旋轉狀態
				}
				/************/
				/********J型方塊********/
				if (tetris_rotation_status[5, 0] == true && map[tetris[2, 0], tetris[2, 1] - 1] == 0 && map[tetris[2, 0], tetris[3, 1] + 1] == 0 && map[tetris[3, 0], tetris[0, 1] - 1] == 0)
				{
					map[tetris[2, 0], tetris[2, 1] - 1] = map[tetris[2, 0], tetris[2, 1] + 1] = map[tetris[3, 0], tetris[3, 1] - 1] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[3, 0], tetris[3, 1]] = map[tetris[1, 0], tetris[1, 1]] = map[tetris[0, 0], tetris[0, 1]] = 0;
					tetris_rotation_status[5, 1] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[5, 0] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[5, 1] == true && map[tetris[3, 0], tetris[3, 1] + 1] == 0 && map[tetris[2, 0] + 1, tetris[2, 1]] == 0)
				{
					map[tetris[3, 0], tetris[3, 1] + 1] = map[tetris[2, 0] + 1, tetris[2, 1]] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[0, 0], tetris[0, 1]] = map[tetris[1, 0], tetris[1, 1]] = 0;
					tetris_rotation_status[5, 2] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[5, 1] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[5, 2] == true && map[tetris[2, 0], tetris[2, 1] + 1] == 0 && map[tetris[2, 0] + 1, tetris[2, 1] + 1] == 0)
				{
					map[tetris[2, 0], tetris[2, 1] + 1] = map[tetris[2, 0] + 1, tetris[2, 1] + 1] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[1, 0], tetris[1, 1]] = map[tetris[0, 0], tetris[0, 1]] = 0;
					tetris_rotation_status[5, 3] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[5, 2] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[5, 3] == true && map[tetris[3, 0] + 1, tetris[3, 1]] == 0 && map[tetris[2, 0] - 1, tetris[2, 1]] == 0 && map[tetris[2, 0] + 1, tetris[2, 1]] == 0)
				{
					map[tetris[3, 0] + 1, tetris[3, 1]] = map[tetris[2, 0] - 1, tetris[2, 1]] = map[tetris[2, 0] + 1, tetris[2, 1]] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[0, 0], tetris[0, 1]] = map[tetris[1, 0], tetris[1, 1]] = map[tetris[3, 0], tetris[3, 1]] = 0;
					tetris_rotation_status[5, 0] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[5, 3] = false; // 關閉直的旋轉狀態
				}
				/************/
				/*********T型方塊*********/
				if (tetris_rotation_status[6, 0] == true && map[tetris[2, 0] - 1, tetris[2, 1]] == 0)
				{
					map[tetris[2, 0] - 1, tetris[2, 1]] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[3, 0], tetris[3, 1]] = 0;
					tetris_rotation_status[6, 1] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[6, 0] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[6, 1] == true && map[tetris[2, 0], tetris[2, 1] - 1] == 0)
				{
					map[tetris[2, 0], tetris[2, 1] - 1] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[0, 0], tetris[0, 1]] = 0;
					tetris_rotation_status[6, 2] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[6, 1] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[6, 2] == true && map[tetris[1, 0] + 1, tetris[1, 1]] == 0)
				{
					map[tetris[1, 0] + 1, tetris[1, 1]] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[0, 0], tetris[0, 1]] = 0;
					tetris_rotation_status[6, 3] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[6, 2] = false; // 關閉直的旋轉狀態
				}
				else if (tetris_rotation_status[6, 3] == true && map[tetris[1, 0], tetris[1, 1] + 1] == 0)
				{
					map[tetris[1, 0], tetris[1, 1] + 1] = map[tetris[3, 0], tetris[3, 1]];
					map[tetris[3, 0], tetris[3, 1]] = 0;
					tetris_rotation_status[6, 0] = true; // 將旋轉狀態改為橫的
					tetris_rotation_status[6, 3] = false; // 關閉直的旋轉狀態
				}
				/************/
				tetris_shadow(); // 方塊旋轉或往左或往右時更新影子狀態
			}
			if (e.KeyCode == Keys.Down) // 讓方塊快速落下
			{
				/**********如果方塊的小塊下方都是空的才可以移動，否則停止移動**********/
				if (whether_falling_collid() == false)
				{
					for (int i = 0; i < 4; i++)
					{
						map[tetris[i, 0] + 1, tetris[i, 1]] = map[tetris[i, 0], tetris[i, 1]];
						map[tetris[i, 0], tetris[i, 1]] = 0;
					}
				}
				else if (fall_end == false && whether_falling_collid() == true)
				{
					for (int i = 0; i < 4; i++)
					{
						map[tetris[i, 0], tetris[i, 1]] -= 7;
					}
					for (int i=0; i<7; i++)
					{
						for (int j=0; j<4; j++)
						{
							if (tetris_rotation_status[i, j] == true)
							{
								tetris_rotation_status[i, j] = false;
							}
						}
					}
					fall_end = true;
				}
				/*********************/
			}
			if (e.KeyCode == Keys.Left)
			{
				int t_count = 0; // 記錄方塊個數位置的變數
				for (int j = 0; j <= 11; j++) // 先找出目前方塊位置 
				{
					for (int i = 21; i >= 0; i--)
					{
						if (map[i, j] >= 8 && map[i, j] <= 14)
						{
							tetris[t_count, 0] = i;
							tetris[t_count, 1] = j;
							t_count++;
						}
					}
				}
				// 如果往左不會撞到就可以往左
				if ((map[tetris[0, 0], tetris[0, 1] - 1] == 0 || map[tetris[0, 0], tetris[0, 1] - 1] == 99 || map[tetris[0, 0], tetris[0, 1] - 1] == map[tetris[0, 0], tetris[0, 1]]) &&
				 (map[tetris[1, 0], tetris[1, 1] - 1] == 0 || map[tetris[1, 0], tetris[1, 1] - 1] == 99 || map[tetris[1, 0], tetris[1, 1] - 1] == map[tetris[0, 0], tetris[0, 1]]) &&
				 (map[tetris[2, 0], tetris[2, 1] - 1] == 0 || map[tetris[2, 0], tetris[2, 1] - 1] == 99 || map[tetris[2, 0], tetris[2, 1] - 1] == map[tetris[0, 0], tetris[0, 1]]) &&
				 (map[tetris[3, 0], tetris[3, 1] - 1] == 0 || map[tetris[3, 0], tetris[3, 1] - 1] == 99 || map[tetris[3, 0], tetris[3, 1] - 1] == map[tetris[0, 0], tetris[0, 1]])) 
				{
					for (int i = 0; i < 4; i++)
					{
						map[tetris[i, 0], tetris[i, 1] - 1] = map[tetris[i, 0], tetris[i, 1]];
						map[tetris[i, 0], tetris[i, 1]] = 0;
					}
				}
				tetris_shadow(); // 方塊旋轉或往左或往右時更新影子狀態
			}
			if (e.KeyCode == Keys.Right)
			{
				int t_count = 0; // 記錄方塊個數位置的變數
				for (int j = 11; j >= 0; j--) // 先找出目前方塊位置
				{
					for (int i = 0; i <= 21; i++)
					{
						if (map[i, j] >= 8 && map[i, j] <= 14)
						{
							tetris[t_count, 0] = i;
							tetris[t_count, 1] = j;
							t_count++;
						}
					}
				}
				// 如果往右不會撞到就可以往右
				if ((map[tetris[0, 0], tetris[0, 1] + 1] == 0 || map[tetris[0, 0], tetris[0, 1] + 1] == 99 || map[tetris[0, 0], tetris[0, 1] + 1] == map[tetris[0, 0], tetris[0, 1]]) &&
				 (map[tetris[1, 0], tetris[1, 1] + 1] == 0 || map[tetris[1, 0], tetris[1, 1] + 1] == 99 || map[tetris[1, 0], tetris[1, 1] + 1] == map[tetris[0, 0], tetris[0, 1]]) &&
				 (map[tetris[2, 0], tetris[2, 1] + 1] == 0 || map[tetris[2, 0], tetris[2, 1] + 1] == 99 || map[tetris[2, 0], tetris[2, 1] + 1] == map[tetris[0, 0], tetris[0, 1]]) &&
				 (map[tetris[3, 0], tetris[3, 1] + 1] == 0 || map[tetris[3, 0], tetris[3, 1] + 1] == 99 || map[tetris[3, 0], tetris[3, 1] + 1] == map[tetris[0, 0], tetris[0, 1]])) // 如果往右0不會撞到就可以往右
				{
					for (int i = 0; i < 4; i++)
					{
						map[tetris[i, 0], tetris[i, 1] + 1] = map[tetris[i, 0], tetris[i, 1]];
						map[tetris[i, 0], tetris[i, 1]] = 0;
					}
				}
				tetris_shadow(); // 方塊旋轉或往左或往右時更新影子狀態
			}
			if (e.KeyCode == Keys.Space)
			{
				while (whether_falling_collid() == false) // 在撞到之前一直移動
				{
					for (int i = 0; i < 4; i++)
					{
						map[tetris[i, 0] + 1, tetris[i, 1]] = map[tetris[i, 0], tetris[i, 1]];
						map[tetris[i, 0], tetris[i, 1]] = 0;
					}
					if (whether_falling_collid() == true) // 如果撞到底就離開迴圈
					{
						break;
					}
				}
				for (int i = 0; i < 4; i++)
				{
					map[tetris[i, 0], tetris[i, 1]] -= 7;
				}
				for (int i = 0; i < 7; i++)
				{
					for (int j = 0; j < 4; j++)
					{
						if (tetris_rotation_status[i, j] == true)
						{
							tetris_rotation_status[i, j] = false;
						}
					}
				}
				fall_end = true;
				exchange = false;
				whether_eliminate_tetris();
				gen_tetris();
			}
			if (exchange == false && e.KeyCode == Keys.Z) // 換成暫存區的方塊
			{
				exchange = true; // 表示要交換
				gen_tetris();
			}
			update_map();
		}

		private bool exchange = false;
		Random rmd = new Random(Guid.NewGuid().GetHashCode());
		private int[] default_tetris = new int[14];
		private int default_tetris_count = 0;
		private int which;
		private bool need_first_round = true, need_second_round = true;
		Button[] schematic_diagram_next = new Button[4]; // 顯示next區的
		Button[] schematic_diagram_hold = new Button[4]; // 顯示hold區的
		private int next_count = 0;
		private int hold = 0; // 初始設定hold裡面是空的(數字代表方塊)
		private void gen_tetris()
		{
			fall_end = false;
			if (need_first_round == true)
			{
				for (int i = 1; i <= 7; i++) // 將陣列7個元素填完(7個都有且不重複)
				{
					while (default_tetris[which] != 0)
					{
						which = rmd.Next(0, 7); // 如果預設的陣列內容已經有了(不能重複)
					}
					default_tetris[which] = i;
				}
				need_first_round = false; // 生產完一整列之後在下一輪之前就不用生產
			}
			if (need_second_round == true)
			{
				for (int i = 1; i <= 7; i++) // 將陣列7個元素填完(7個都有且不重複)
				{
					while (default_tetris[which] != 0)
					{
						which = rmd.Next(7, 14); // 如果預設的陣列內容已經有了(不能重複)
					}
					default_tetris[which] = i; // 生產完一整列之後在下一輪之前就不用生產
				}
				need_second_round = false;
			}
		
			/*******判斷是否有按下shift*********/
			if (exchange == false)
			{
				show_tetris();
			}
			else if (exchange == true) // 如果按下shift
			{
				for (int i = 21; i >= 0; i--) // 先把之前的方塊清除
				{
					for (int j = 11; j >= 0; j--)
					{
						if ( (map[i, j] >= 8 && map[i, j] <= 14) || (map[i, j] == 99))
						{
							map[i, j] = 0;
						}
					}
				}
				if (hold == 0)
				{
					hold = default_tetris[default_tetris_count - 1];
				}
				else if (hold != 0) // 如果hold有方塊將hold裡的與現在的方塊交換
				{
					if (default_tetris_count == 0)
					{
						int temp = hold;
						hold = default_tetris[13];
						default_tetris[13] = temp;
					}
					else if (default_tetris_count != 0)
					{
						int temp = hold;
						hold = default_tetris[default_tetris_count - 1];
						default_tetris[default_tetris_count - 1] = temp;
					}
				}
				show_tetris();
			}
			/***************/

			if (default_tetris_count == 7) // 如果進到第二輪就要在生產第一輪方塊(需要兩輪因為第一輪最後一個如果要秀next就需要第二輪)
			{
				need_first_round = true;
				for (int i = 0; i < 7; i++) // 將陣列7個元素填完(7個都有且不重複)
				{
					default_tetris[i] = 0;
				}
			}
			if (default_tetris_count == 14)
			{
				need_second_round = true;
				default_tetris_count = 0;
				for (int i = 7; i < 14; i++) // 將陣列7個元素填完(7個都有且不重複)
				{
					default_tetris[i] = 0;
				}
			}
			tetris_shadow(); // 生成方塊時也產生影子
		}
		private void end_game()
		{
			timer_animation.Stop();
			timer_falldown.Stop();
			MessageBox.Show("Nope");
			Environment.Exit(0);
		}

		private void show_tetris()
		{
			switch (default_tetris[default_tetris_count])
			{
				case 1: // O型方塊
					if (map[1, 6] != 0 || map[1, 7] != 0 || map[2, 6] != 0 || map[2, 7] != 0)
					{
						end_game();
					}
					map[1, 6] = map[1, 7] = map[2, 6] = map[2, 7] = 8;
					tetris_rotation_status[0, 0] = true; // [x, 0]表示為第x種方塊的初始生成狀態(數字0表示)
					break;
				case 2: // I型方塊
					if (map[1, 5] != 0 || map[1, 6] != 0 || map[1, 7] != 0 || map[1, 8] != 0)
					{
						end_game();
					}
					map[1, 5] = map[1, 6] = map[1, 7] = map[1, 8] = 9;
					tetris_rotation_status[1, 0] = true;
					break;
				case 3: // S型方塊
					if (map[1, 7] != 0 || map[1, 8] != 0 || map[2, 7] != 0 || map[2, 6] != 0)
					{
						end_game();
					}
					map[1, 7] = map[1, 8] = map[2, 7] = map[2, 6] = 10;
					tetris_rotation_status[2, 0] = true;
					break;
				case 4: // Z型方塊
					if (map[1, 6] != 0 || map[1, 7] != 0 || map[2, 7] != 0 || map[2, 8] != 0)
					{
						end_game();
					}
					map[1, 6] = map[1, 7] = map[2, 7] = map[2, 8] = 11;
					tetris_rotation_status[3, 0] = true;
					break;
				case 5: // L型方塊
					if (map[1, 6] != 0 || map[2, 6] != 0 || map[3, 6] != 0 || map[3, 7] != 0)
					{
						end_game();
					}
					map[1, 6] = map[2, 6] = map[3, 6] = map[3, 7] = 12;
					tetris_rotation_status[4, 0] = true;
					break;
				case 6: // J型方塊
					if (map[1, 7] != 0 || map[2, 7] != 0 || map[3, 6] != 0 || map[3, 7] != 0)
					{
						end_game();
					}
					map[1, 7] = map[2, 7] = map[3, 6] = map[3, 7] = 13;
					tetris_rotation_status[5, 0] = true;
					break;
				case 7: // T型方塊
					if (map[1, 6] != 0 || map[1, 7] != 0 || map[1, 8] != 0 || map[2, 7] != 0)
					{
						end_game();
					}
					map[1, 6] = map[1, 7] = map[1, 8] = map[2, 7] = 14;
					tetris_rotation_status[6, 0] = true;
					break;
			}
			if (default_tetris_count < 13)
			{
				next_count = default_tetris_count + 1;
			}
			else if (default_tetris_count == 13)
			{
				next_count = 0;
			}
			switch (default_tetris[next_count])
			{
				case 1: // O型方塊
					for (int i = 0; i < 4; i++)
					{
						schematic_diagram_next[i].SetBounds(350 + 20 * (i % 2), 100 + 20 * (i / 2), 20, 20);
						schematic_diagram_next[i].BackColor = Color.Yellow;
					}
					break;
				case 2: // I型方塊
					for (int i = 0; i < 4; i++)
					{
						schematic_diagram_next[i].SetBounds(350 + 20 * i, 110, 20, 20);
						schematic_diagram_next[i].BackColor = Color.LightBlue;
					}
					break;
				case 3: // S型方塊
					for (int i = 0; i < 4; i++)
					{
						schematic_diagram_next[i].SetBounds(370 + 20 * (i % 2) - 20 * ((i + 1) / 2), 130 - 20 * ((i + 1) / 2), 20, 20);
						schematic_diagram_next[i].BackColor = Color.LightGreen;
					}
					break;
				case 4: // Z型方塊
					for (int i = 0; i < 4; i++)
					{
						schematic_diagram_next[i].SetBounds(360 + 20 * (i % 2) - 20 * ((i + 1) / 2), 100 + 20 * ((i + 1) / 2), 20, 20);
						schematic_diagram_next[i].BackColor = Color.Red;
					}
					break;
				case 5: // L型方塊
					schematic_diagram_next[0].SetBounds(380, 150, 20, 20);
					schematic_diagram_next[0].BackColor = Color.Orange;
					for (int i = 1; i < 4; i++)
					{
						schematic_diagram_next[i].SetBounds(360, 90 + 20 * i, 20, 20);
						schematic_diagram_next[i].BackColor = Color.Orange;
					}
					break;
				case 6: // J型方塊
					schematic_diagram_next[0].SetBounds(360, 150, 20, 20);
					schematic_diagram_next[0].BackColor = Color.Blue;
					for (int i = 1; i < 4; i++)
					{
						schematic_diagram_next[i].SetBounds(380, 90 + 20 * i, 20, 20);
						schematic_diagram_next[i].BackColor = Color.Blue;
					}
					break;
				case 7: // T型方塊
					schematic_diagram_next[0].SetBounds(390, 110, 20, 20);
					schematic_diagram_next[0].BackColor = Color.Purple;
					for (int i = 1; i < 4; i++)
					{
						schematic_diagram_next[i].SetBounds(350 + 20 * i, 90, 20, 20);
						schematic_diagram_next[i].BackColor = Color.Purple;
					}
					break;
			}
			switch (hold)
			{
				case 1: // O型方塊
					for (int i = 0; i < 4; i++)
					{
						schematic_diagram_hold[i].SetBounds(350 + 20 * (i % 2), 220 + 20 * (i / 2), 20, 20);
						schematic_diagram_hold[i].BackColor = Color.Yellow;
					}
					break;
				case 2: // I型方塊
					for (int i = 0; i < 4; i++)
					{
						schematic_diagram_hold[i].SetBounds(350 + 20 * i, 230, 20, 20);
						schematic_diagram_hold[i].BackColor = Color.LightBlue;
					}
					break;
				case 3: // S型方塊
					for (int i = 0; i < 4; i++)
					{
						schematic_diagram_hold[i].SetBounds(370 + 20 * (i % 2) - 20 * ((i + 1) / 2), 250 - 20 * ((i + 1) / 2), 20, 20);
						schematic_diagram_hold[i].BackColor = Color.LightGreen;
					}
					break;
				case 4: // Z型方塊
					for (int i = 0; i < 4; i++)
					{
						schematic_diagram_hold[i].SetBounds(360 + 20 * (i % 2) - 20 * ((i + 1) / 2), 220 + 20 * ((i + 1) / 2), 20, 20);
						schematic_diagram_hold[i].BackColor = Color.Red;
					}
					break;
				case 5: // L型方塊
					schematic_diagram_hold[0].SetBounds(380, 270, 20, 20);
					schematic_diagram_hold[0].BackColor = Color.Orange;
					for (int i = 1; i < 4; i++)
					{
						schematic_diagram_hold[i].SetBounds(360, 210 + 20 * i, 20, 20);
						schematic_diagram_hold[i].BackColor = Color.Orange;
					}
					break;
				case 6: // J型方塊
					schematic_diagram_hold[0].SetBounds(360, 270, 20, 20);
					schematic_diagram_hold[0].BackColor = Color.Blue;
					for (int i = 1; i < 4; i++)
					{
						schematic_diagram_hold[i].SetBounds(380, 210 + 20 * i, 20, 20);
						schematic_diagram_hold[i].BackColor = Color.Blue;
					}
					break;
				case 7: // T型方塊
					schematic_diagram_hold[0].SetBounds(390, 230, 20, 20);
					schematic_diagram_hold[0].BackColor = Color.Purple;
					for (int i = 1; i < 4; i++)
					{
						schematic_diagram_hold[i].SetBounds(350 + 20 * i, 210, 20, 20);
						schematic_diagram_hold[i].BackColor = Color.Purple;
					}
					break;
			}
			default_tetris_count++;
		}

		private int[,] temp_tetris = new int[4, 2];
		private int temp = 0;
		private void tetris_shadow() // 處理方塊的預計掉落位置的影子(用和掉落一樣的方法尋找影子因為是預計會掉落到的位置，找到後將影子數字改為99，在把原本紀錄的方塊位置還回去)
		{
			for (int i = 21; i >= 0; i--) // 先找出目前方塊位置
			{
				for (int j = 11; j >= 0; j--)
				{
					if (map[i, j] == 99)
					{
						map[i, j] = 0;
					}
				}
			}
			int t_count = 0; // 記錄方塊個數位置的變數
			for (int i = 21; i >= 0; i--) // 先找出目前方塊位置
			{
				for (int j = 11; j >= 0; j--)
				{
					if (map[i, j] >= 8 && map[i, j] <= 14)
					{
						temp = map[i, j];
						tetris[t_count, 0] = i;
						tetris[t_count, 1] = j;
						t_count++;
					}
				}
			}
			for (int i = 0; i < 4; i++) // 暫存方塊原本位置
			{
				temp_tetris[i, 0] = tetris[i, 0];
				temp_tetris[i, 1] = tetris[i, 1];
			}
			while (whether_falling_collid() == false) // 在撞到之前一直移動
			{
				for (int i = 0; i < 4; i++)
				{
					map[tetris[i, 0] + 1, tetris[i, 1]] = map[tetris[i, 0], tetris[i, 1]];
					map[tetris[i, 0], tetris[i, 1]] = 0;
				}
				if (whether_falling_collid() == true) // 如果撞到底就離開迴圈
				{
					break;
				}
			}
			for (int i = 0; i < 4; i++)
			{
				map[tetris[i, 0], tetris[i, 1]] = 99; // 表示影子
			}
			for (int i = 0; i < 4; i++)
			{
				map[temp_tetris[i, 0], temp_tetris[i, 1]] = temp;
			}
		}

		private int score = 0;
		private void whether_eliminate_tetris()
		{
			update_map();
			//當整排都有方塊時
			for (int k = 1; k < 21; k++)
			{
				if (map[k, 1] != 0 && map[k, 2] != 0 && map[k, 3] != 0 && map[k, 4] != 0 && map[k, 5] != 0 &&
					map[k, 6] != 0 && map[k, 7] != 0 && map[k, 8] != 0 && map[k, 9] != 0 && map[k, 10] != 0)
				{
					for (int i = k; i > 0; i--)
					{
						for (int j = 1; j < 11; j++)
						{
							if (i == 1)
							{
								map[i, j] = 0;
							}
							else if (i > 1)
							{
								map[i, j] = map[i - 1, j];
							}
						}
					}
					score++;
					label2.Text = "Score: " + score.ToString();
				}
			}
		}

		private void update_map() // 即時更新最新地圖狀態(顯示每次移動的結果)
		{
			for (int i = 0; i < 22; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					switch(map[i, j] % 7)
					{
						case 0: // T型方塊
							b_map[i, j].BackColor = Color.Purple;
							break;
						case 1: // O型方塊
							b_map[i, j].BackColor = Color.Yellow;
							break;
						case 2: // I型方塊
							b_map[i, j].BackColor = Color.LightBlue;
							break;
						case 3: // S型方塊
							b_map[i, j].BackColor = Color.LightGreen;
							break;
						case 4: // Z型方塊
							b_map[i, j].BackColor = Color.Red;
							break;
						case 5: // L型方塊
							b_map[i, j].BackColor = Color.Orange;
							break;
						case 6: // J型方塊
							b_map[i, j].BackColor = Color.Blue;
							break;
					}
					if (map[i, j] == 0)
					{
						b_map[i, j].BackColor = Color.WhiteSmoke;
					}
					if (map[i, j] == 99)
					{
						b_map[i, j].BackColor = Color.Gray;
					}
					if (b_map[i, j].BackColor != Color.WhiteSmoke)
					{
						b_map[i, j].Visible = true;
					}
					else if (b_map[i, j].BackColor == Color.WhiteSmoke)
					{
						b_map[i, j].Visible = false;
					}
				}
			}
		}

		private bool fall_end = false;
		int[,] tetris = new int[4, 2]; // 紀錄目前方塊的X,Y座標(垂直i)(水平j)
		private void timer_falldown_Tick(object sender, EventArgs e) // 方塊落下計時器
		{
			/**********如果方塊的小塊下方都是空的才可以移動，否則停止移動**********/
			if (whether_falling_collid() == false)
			{
				for (int i = 0; i < 4; i++)
				{
					map[tetris[i, 0] + 1, tetris[i, 1]] = map[tetris[i, 0], tetris[i, 1]];
					map[tetris[i, 0], tetris[i, 1]] = 0;
				}
			}
			else if (fall_end == false && whether_falling_collid() == true)
			{
				for (int i = 0; i < 7; i++)
				{
					for (int j = 0; j < 4; j++)
					{
						if (tetris_rotation_status[i, j] == true)
						{
							tetris_rotation_status[i, j] = false;
						}
					}
				}
				for (int i = 0; i < 4; i++)
				{
					map[tetris[i, 0], tetris[i, 1]] -= 7;
				}
				fall_end = true;
			}
			/*********************/
			/*****如果停止移動則產生新的方塊******/
			if (fall_end == true)
			{
				exchange = false;
				whether_eliminate_tetris();
				gen_tetris();
			}
			/*****/
			update_map(); // 更新遊戲顯示的狀態
		}

		private bool whether_falling_collid()
		{
			int t_count = 0; // 記錄方塊個數位置的變數
			for (int i = 21; i >= 0; i--) // 先找出目前方塊位置
			{
				for (int j = 11; j >= 0; j--)
				{
					if (map[i, j] >= 8 && map[i, j] <= 14)
					{
						tetris[t_count, 0] = i;
						tetris[t_count, 1] = j;
						t_count++;
					}
				}
			}
			if ((map[tetris[0, 0] + 1, tetris[0, 1]] == 0 || map[tetris[0, 0] + 1, tetris[0, 1]] == 99 || map[tetris[0, 0] + 1, tetris[0, 1]] == map[tetris[0, 0], tetris[0, 1]]) &&
				 (map[tetris[1, 0] + 1, tetris[1, 1]] == 0 || map[tetris[1, 0] + 1, tetris[1, 1]] == 99 || map[tetris[1, 0] + 1, tetris[1, 1]] == map[tetris[0, 0], tetris[0, 1]]) &&
				 (map[tetris[2, 0] + 1, tetris[2, 1]] == 0 || map[tetris[2, 0] + 1, tetris[2, 1]] == 99 || map[tetris[2, 0] + 1, tetris[2, 1]] == map[tetris[0, 0], tetris[0, 1]]) &&
				 (map[tetris[3, 0] + 1, tetris[3, 1]] == 0 || map[tetris[3, 0] + 1, tetris[3, 1]] == 99 || map[tetris[3, 0] + 1, tetris[3, 1]] == map[tetris[0, 0], tetris[0, 1]]))
			{
				return false; // 下墜沒有撞到
			}
			else if ((map[tetris[0, 0] + 1, tetris[0, 1]] != 0 && map[tetris[0, 0] + 1, tetris[0, 1]] != 99 && map[tetris[0, 0] + 1, tetris[0, 1]] != map[tetris[0, 0], tetris[0, 1]]) ||
					  (map[tetris[1, 0] + 1, tetris[1, 1]] != 0 && map[tetris[1, 0] + 1, tetris[1, 1]] != 99 && map[tetris[1, 0] + 1, tetris[1, 1]] != map[tetris[0, 0], tetris[0, 1]]) ||
					  (map[tetris[2, 0] + 1, tetris[2, 1]] != 0 && map[tetris[2, 0] + 1, tetris[2, 1]] != 99 && map[tetris[2, 0] + 1, tetris[2, 1]] != map[tetris[0, 0], tetris[0, 1]]) ||
					  (map[tetris[3, 0] + 1, tetris[3, 1]] != 0 && map[tetris[3, 0] + 1, tetris[3, 1]] != 99 && map[tetris[3, 0] + 1, tetris[3, 1]] != map[tetris[0, 0], tetris[0, 1]]))
			{
				return true; // 下墜撞到
			}
			else
			{
				return false;
			}
		}

		private void timer_animation_Tick(object sender, EventArgs e)
		{
			update_map(); // 更新遊戲顯示的狀態
		}
	}
}
