using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp17
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		Button[] walls = new Button[18]; // 初始化牆壁物件
		Label[] foods = new Label[189]; // 初始化食物
		Label[] monsters = new Label[4]; // 初始化怪物
		Label player = new Label();
		private void Form1_Load(object sender, EventArgs e)
		{
			set_map();
			gen_monster();
			label2.Text = "Score: " + score.ToString();
			label2.ForeColor = Color.Yellow;
			timer_monsters_run.Start();
		}

		private void set_map() // 生產地圖物件(牆壁 食物)
		{
			this.BackColor = Color.Black;
			player.SetBounds(545, 275, 35, 35);
			player.BackColor = Color.Yellow;
			Controls.Add(player);
			for (int i=0; i<18; i++) // 生成中間牆壁
			{
				walls[i] = new Button(); // 生成物件
				walls[i].SetBounds(45 + 90 * (i / 3), 45 + 90 * (i % 3), 45, 45); // 設定大小位置
				walls[i].BackColor = Color.Black;
				walls[i].Enabled = false;
				Controls.Add(walls[i]); // 加入form上
			}
			for (int i=0; i<189; i++) // 生成食物
			{
				foods[i] = new Label();
				foods[i].SetBounds(20 + 30 * (i / 10), 20 + 30 * (i % 10), 5, 5);
				foods[i].BackColor = Color.Yellow;
				Controls.Add(foods[i]);
			}
		}

		private void gen_monster()
		{
			for (int i=0; i<4; i++)
			{
				monsters[i] = new Label();
				monsters[i].SetBounds(5 + 45 * i, 5, 35, 35);
				Controls.Add(monsters[i]);
				switch (i) // 四色怪物
				{
					case 0:
						monsters[i].BackColor = Color.Red;
						break;
					case 1:
						monsters[i].BackColor = Color.Green;
						break;
					case 2:
						monsters[i].BackColor = Color.Blue;
						break;
					case 3:
						monsters[i].BackColor = Color.Purple;
						break;
				}
			}
			for (int i=0; i<16; i++) // 初始化怪物一開始跑的方向
			{
				if (i == 1 || i == 7 || i == 9 || i == 15)
				{
					monsters_status[i] = true;
				}
				else
				{
					monsters_status[i] = false;
				}
			}
		}

		/***********用bool值判斷player應該要跑的方向************/
		private bool go_up = false;
		private bool go_down = false;
		private bool go_left = false;
		private bool go_right = false;
		/********************************/
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{ //若按下某個方向時，將其他方向的許可關掉
			if (e.KeyCode == Keys.Up && (go_down == true || player.Top % 90 >= 1 && player.Top % 90 <= 9 && player.Left % 90 >= 1 && player.Left % 90 <= 9) ) 
			{
				timer_run.Start();
				go_up = true;
				go_down = false;
				go_left = false;
				go_right = false;
			}
			if (e.KeyCode == Keys.Down && (go_up == true || player.Top % 90 >= 1 && player.Top % 90 <= 9 && player.Left % 90 >= 1 && player.Left % 90 <= 9) )
			{
				timer_run.Start();
				go_up = false;
				go_down = true;
				go_left = false;
				go_right = false;
			}
			if (e.KeyCode == Keys.Left && (go_right == true || player.Top % 90 >= 1 && player.Top % 90 <= 9 && player.Left % 90 >= 1 && player.Left % 90 <= 9) )
			{
				timer_run.Start();
				go_up = false;
				go_down = false;
				go_left = true;
				go_right = false;
			}
			if (e.KeyCode == Keys.Right && (go_left == true || player.Top % 90 >= 1 && player.Top % 90 <= 9 && player.Left % 90 >= 1 && player.Left % 90 <= 9) )
			{
				timer_run.Start();
				go_up = false;
				go_down = false;
				go_left = false;
				go_right = true;
			}
		}

		private void whether_hit_walls()
		{
			for (int i = 0; i < 18; i++) // 如果撞到牆壁就停止
			{
				if (player.Left <= walls[i].Left + 45 && player.Left + 35 >= walls[i].Left && player.Top <= walls[i].Top + 45 && player.Top + 35 >= walls[i].Top)
				{
					timer_run.Stop();
				}
			}
			if (player.Top <= 0 || player.Top >= 280 || player.Left <= 0 || player.Left >= 550)
			{ // 如果撞到邊框就停止
				if (player.Top <= 0)
				{
					player.Top += 5;
				}
				else if (player.Top >= 280)
				{
					player.Top -= 5;
				}
				if (player.Left <= 0)
				{
					player.Left += 5;
				}
				else if (player.Left >= 550)
				{
					player.Left -= 5;
				}
				timer_run.Stop();
			}
		}

		private int score = 0;
		private int eaten_foods = 0;
		private void eat()
		{
			for (int i=0; i<189; i++)
			{
				if (foods[i].Visible == true && player.Top <= foods[i].Top && player.Top + 30 >= foods[i].Top + 5 && player.Left <= foods[i].Left && player.Left + 30 >= foods[i].Left + 5)
				{
					foods[i].Visible = false;
					score++;
					label2.Text = "Score: " + score.ToString();
					eaten_foods++;
				}
				if (eaten_foods == 189)
				{
					timer_run.Stop();
					MessageBox.Show("Win");
				}
			}
		}

		private bool[] monsters_status = new bool[16];
		private void set_monsters_status(int which_monster, int direction)
		{
			if (direction == 0)
			{
				monsters_status[4 * which_monster] = true;
				monsters_status[4 * which_monster + 1] = false;
				monsters_status[4 * which_monster + 2] = false;
				monsters_status[4 * which_monster + 3] = false;
			}
			else if (direction == 1)
			{
				monsters_status[4 * which_monster] = false;
				monsters_status[4 * which_monster + 1] = true;
				monsters_status[4 * which_monster + 2] = false;
				monsters_status[4 * which_monster + 3] = false;
			}
			else if (direction == 2)
			{
				monsters_status[4 * which_monster] = false;
				monsters_status[4 * which_monster + 1] = false;
				monsters_status[4 * which_monster + 2] = true;
				monsters_status[4 * which_monster + 3] = false;
			}
			else if (direction == 3)
			{
				monsters_status[4 * which_monster] = false;
				monsters_status[4 * which_monster + 1] = false;
				monsters_status[4 * which_monster + 2] = false;
				monsters_status[4 * which_monster + 3] = true;
			}
		}

		Random rmd = new Random(Guid.NewGuid().GetHashCode());
		private void timer_monsters_run_Tick(object sender, EventArgs e)
		{
			for (int i=0; i<4; i++)
			{
				/**************判斷怪物目前的狀況決定要持續跑的方向***************/
				if (monsters_status[4 * i] == true) 
				{
					monsters[i].Top -= 1;
				}
				else if (monsters_status[4 * i + 1] == true)
				{
					monsters[i].Top += 1;
				}
				else if (monsters_status[4 * i + 2] == true)
				{
					monsters[i].Left -= 1;
				}
				else if (monsters_status[4 * i + 3] == true)
				{
					monsters[i].Left += 1;
				}
				/********************/

				/**************如果有辦法追蹤玩家以追蹤為優先***********/
				if (monsters[i].Left - 4 <= player.Left && monsters[i].Left + 4 >= player.Left && monsters[i].Top > player.Top && monsters[i].Top % 90 == 5 && monsters[i].Left % 90 == 5) // 如果玩家在怪物同一垂直線的上方
				{
					set_monsters_status(i, 0);
				}
				else if (monsters[i].Left - 4 <= player.Left && monsters[i].Left + 4 >= player.Left && monsters[i].Top < player.Top && monsters[i].Top % 90 == 5 && monsters[i].Left % 90 == 5) // 如果玩家在怪物同一垂直線的下方
				{
					set_monsters_status(i, 1);
				}
				else if (monsters[i].Top - 4 <= player.Top && monsters[i].Top + 4 >= player.Top && monsters[i].Left > player.Left && monsters[i].Top % 90 == 5 && monsters[i].Left % 90 == 5) // 如果玩家在怪物同一水平線的左方
				{
					set_monsters_status(i, 2);
				}
				else if (monsters[i].Top - 4 <= player.Top && monsters[i].Top + 4 >= player.Top && monsters[i].Left < player.Left && monsters[i].Top % 90 == 5 && monsters[i].Left % 90 == 5) // 如果玩家在怪物同一水平線的右方
				{
					set_monsters_status(i, 3);
				}
				/********************************/

				/***************判斷怪物遇到叉路時的走向*************/
				/*****四角落******/
				else if (monsters[i].Top == 5 && monsters[i].Left == 5) // 左上角
				{
					int direction = rmd.Next(0, 2);
					if (direction == 0) //往下
					{
						set_monsters_status(i, 1);
					}
					else if (direction == 1) // 往右
					{
						set_monsters_status(i, 3);
					}
				}
				else if (monsters[i].Top == 5 && monsters[i].Left == 545) // 右上角
				{
					int direction = rmd.Next(0, 2);
					if (direction == 0) // 往下
					{
						set_monsters_status(i, 1);
					}
					else if (direction == 1) // 往左
					{
						set_monsters_status(i, 2);
					}
				}
				else if (monsters[i].Top == 275 && monsters[i].Left == 5) // 左下角
				{
					int direction = rmd.Next(0, 2);
					if (direction == 0) // 往上
					{
						set_monsters_status(i, 0);
					}
					else if (direction == 1) //往右
					{
						set_monsters_status(i, 3);
					}
				}
				else if (monsters[i].Top == 275 && monsters[i].Left == 545) // 右下角
				{
					int direction = rmd.Next(0, 2);
					if (direction == 0) //往左
					{
						set_monsters_status(i, 2);
					}
					else if (direction == 1) // 往上
					{
						set_monsters_status(i, 0);
					}
				}
				/********四個邊**********/
				else if (monsters[i].Top == 5 && monsters[i].Left % 90 == 5) // 上邊
				{
					int direction = rmd.Next(0, 3);
					if (direction == 0) //往下
					{
						set_monsters_status(i, 1);
					}
					else if (direction == 1) // 往右
					{
						set_monsters_status(i, 3);
					}
					else if (direction == 2) // 往左
					{
						set_monsters_status(i, 2);
					}
				}
				else if (monsters[i].Top == 275 && monsters[i].Left % 90 == 5) // 下邊
				{
					int direction = rmd.Next(0, 3);
					if (direction == 0) //往上
					{
						set_monsters_status(i, 0);
					}
					else if (direction == 1) // 往右
					{
						set_monsters_status(i, 3);
					}
					else if (direction == 2) // 往左
					{
						set_monsters_status(i, 2);
					}
				}
				else if (monsters[i].Top % 90 == 5 && monsters[i].Left == 5) // 左邊
				{
					int direction = rmd.Next(0, 3);
					if (direction == 0) //往上
					{
						set_monsters_status(i, 0);
					}
					else if (direction == 1) // 往右
					{
						set_monsters_status(i, 3);
					}
					else if (direction == 2) // 往下
					{
						set_monsters_status(i, 1);
					}
				}
				else if (monsters[i].Top % 90 == 5 && monsters[i].Left == 545) // 右邊
				{
					int direction = rmd.Next(0, 3);
					if (direction == 0) //往上
					{
						set_monsters_status(i, 0);
					}
					else if (direction == 1) // 往左
					{
						set_monsters_status(i, 2);
					}
					else if (direction == 2) // 往下
					{
						set_monsters_status(i, 1);
					}
				}
				/*****中間其他十字路口*****/
				else if (monsters[i].Top % 90 == 5 && monsters[i].Left % 90 == 5)
				{
					int direction = rmd.Next(0, 4);
					if (direction == 0) //往上
					{
						set_monsters_status(i, 0);
					}
					else if (direction == 1) // 往左
					{
						set_monsters_status(i, 2);
					}
					else if (direction == 2) // 往下
					{
						set_monsters_status(i, 1);
					}
					else if (direction == 3) // 往右
					{
						set_monsters_status(i, 3);
					}
				}

				/**********判斷怪物是否撞到小精靈***************/
				if (player.Left <= monsters[i].Left + 33 && player.Left + 33 >= monsters[i].Left && player.Top <= monsters[i].Top + 33 && player.Top + 33 >= monsters[i].Top) 
				{
					timer_run.Stop();
					timer_monsters_run.Stop();
					MessageBox.Show("Lose!!" + "\r\n" + "Score: " + score.ToString());
				}
			}
		}

		private void timer_run_Tick(object sender, EventArgs e)
		{
			if (go_up == true)
			{
				player.Top -= 1;
			}
			else if (go_down == true)
			{
				player.Top += 1;
			}
			else if (go_left == true)
			{
				player.Left -= 1;
			}
			else if (go_right == true)
			{
				player.Left += 1;
			}
			whether_hit_walls();
			eat();
		}
	}
}
