using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp19
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		private int map_size = 8; // 預設地圖為簡單難度
		private int ground_size = 40;
		Button[,] b_map = new Button[24, 24];
		int[,] map = new int[26, 26];
		bool[,] map_visited = new bool[26, 26];

		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Visible = false;
			button1.Visible = button1.Enabled = true;
			level[0] = true;
			step = 0;
		}
		private bool[] level = new bool[3];
		private int mines_count = 0;
		private void 初級ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			level[0] = true;
			level[1] = false;
			level[2] = false;
			restart(sender, e);
			Size = new Size(520, 550);
			ground_size = 40;
			map_size = 8;
			timer_count = 0;
			label1.Visible = true;
			label1.Text = "Used: " + timer_count.ToString() + " second";
			button1.Visible = button1.Enabled = false;
			initial_mine_count = mines_count = 10;
			set_map();
			timer1.Start();
		}
		private void 中級ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			level[0] = false;
			level[1] = true;
			level[2] = false;
			restart(sender, e);
			Size = new Size(520, 570);
			ground_size = 30;
			map_size = 16;
			timer_count = 0;
			label1.Visible = true;
			label1.Text = "Used: " + timer_count.ToString() + " second";
			button1.Visible = button1.Enabled = false;
			initial_mine_count = mines_count = 40;
			set_map();
			timer1.Start();
		}

		private void 困難ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			level[0] = false;
			level[1] = false;
			level[2] = true;
			restart(sender, e);
			Size = new Size(530, 580);
			ground_size = 20;
			map_size = 24;
			timer_count = 0;
			label1.Visible = true;
			label1.Text = "Used: " + timer_count.ToString() + " second";
			button1.Visible = button1.Enabled = false;
			initial_mine_count = mines_count = 99;
			set_map();
			timer1.Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			timer_count = 0;
			label1.Visible = true;
			label1.Text = "Used: " + timer_count.ToString() + " second";
			button1.Visible = button1.Enabled = false;
			if (level[0] == true)
			{
				initial_mine_count = mines_count = 10;
			}
			else if (level[0] == true)
			{
				initial_mine_count = mines_count = 40;
			}
			else if (level[0] == true)
			{
				initial_mine_count = mines_count = 99;
			}	
			set_map();
			timer1.Start();
		}

		Random rmd = new Random(Guid.NewGuid().GetHashCode());
		private int initial_mine_count = 10; // 初始地雷數量
		private void set_map() // 設定有關遊戲地圖的物件
		{
			for (int i = 0; i < map_size + 2; i++) // 初始化比對用地圖
			{
				for (int j = 0; j < map_size + 2; j++)
				{
					if (i == 0 || i == map_size + 1 || j == 0 || j == map_size + 1)
					{
						map[i, j] = -1;
						map_visited[i, j] = true;
					}
					else
					{
						map[i, j] = 0;
						map_visited[i, j] = false;
					}
				}
			}
			for (int i = 0; i < map_size; i++) // 初始化button用地圖
			{
				for (int j = 0; j < map_size; j++)
				{
					b_map[i, j] = new Button();
					b_map[i, j].BackColor = Color.LightGreen;
					b_map[i, j].SetBounds(15 + ground_size * j, 40 + ground_size * i, ground_size, ground_size);
					b_map[i, j].Text = "";
					Controls.Add(b_map[i, j]);
					b_map[i, j].Click += new EventHandler(b_map_click);
					b_map[i, j].MouseWheel += new MouseEventHandler(b_map_flag);
				}
			}
		}

		private void restart(object sender, EventArgs e)
		{
			timer1.Stop();
			for (int i = 0; i < map_size; i++) // 將之前的地圖清除
			{
				for (int j = 0; j < map_size; j++)
				{
					is_flag[i, j] = false;
					b_map[i, j].Dispose();
				}
			}
			Form1_Load(sender, e);
		}

		private void b_map_click(object sender, EventArgs e)
		{
			for (int i = 0; i < map_size; i++) // 比對看點到哪個button
			{
				for (int j = 0; j < map_size; j++)
				{
					if (15 + ground_size * j == (sender as Button).Left && 40 + ground_size * i == (sender as Button).Top)
					{
						if (map[i + 1, j + 1] == 9) // 如果直接採雷
						{
							MessageBox.Show("BOOM!!!");
							restart(sender, e);
						}
						else // 如果沒有直接採雷
						{
							count_mine(j + 1, i + 1, sender, e);
						}
					}
				}
			}
			for (int i = 0; i < map_size; i++)
			{
				for (int j = 0; j < map_size; j++)
				{
					if (map_visited[i + 1, j + 1] == true && map[i + 1, j + 1] != 0)
					{
						b_map[i, j].Text = map[i + 1, j + 1].ToString();
					}
					if (map_visited[i + 1, j + 1] == true)
					{
						b_map[i, j].BackColor = Color.RosyBrown;
						b_map[i, j].ForeColor = Color.Yellow;
					}
				}
			}
		}

		private bool[,] is_flag = new bool[24, 24];
		private void b_map_flag(object sender, EventArgs e)
		{
			for (int i = 0; i < map_size; i++) // 比對看點到哪個button
			{
				for (int j = 0; j < map_size; j++)
				{
					if (15 + ground_size * j == (sender as Button).Left && 40 + ground_size * i == (sender as Button).Top)
					{
						if (is_flag[i, j] == false)
						{
							is_flag[i, j] = true;
							b_map[i, j].BackColor = Color.Red;
						}
						else if (is_flag[i, j] == true)
						{
							is_flag[i, j] = false;
							b_map[i, j].BackColor = Color.LightGreen;
						}
					}
				}
			}
			for (int i = 0; i < map_size; i++)
			{
				for (int j = 0; j < map_size; j++)
				{
					if (map_visited[i + 1, j + 1] == true && map[i + 1, j + 1] != 0)
					{
						b_map[i, j].Text = map[i + 1, j + 1].ToString();
					}
					if (map_visited[i + 1, j + 1] == true)
					{
						b_map[i, j].BackColor = Color.RosyBrown;
						b_map[i, j].ForeColor = Color.Yellow;
					}
				}
			}
		}

		private static int[] direction_x = new int[] { -1, -1, -1, 0, 1, 1, 1, 0 };
		private static int[] direction_y = new int[] { -1, 0, 1, 1, 1, 0, -1, -1 };
		private int step = 0;
		private void count_mine(int inputx, int inputy, object sender, EventArgs e) // map[Y軸座標, X軸座標]!!!
		{
			map_visited[inputy, inputx] = true;
			b_map[inputy - 1, inputx - 1].Enabled = false;
			if (step == 0) // 走的第一步不會是地雷(走了第一步再設定地雷)
			{
				while (initial_mine_count > 0) //設定地雷位置
				{
					int x = rmd.Next(1, map_size + 1);
					int y = rmd.Next(1, map_size + 1);
					if (map[x, y] == 0 && map_visited[x, y] == false)
					{
						map[x, y] = 9; // 9表示為地雷
						initial_mine_count--;
					}
				}
			}
			int count = 0; // 累計按下的button周圍有多少地雷
			for (int i = 0; i < 8; i++)
			{
				if (map[inputy + direction_y[i], inputx + direction_x[i]] == 9)
				{
					count++; //  如果周圍有地雷，count數+1(最多8方位都有地雷，最少8方位都沒有地雷)
				}
			}
			map[inputy, inputx] = count;
			if (count == 0) // 若周圍都沒有地雷則呼叫自己擴展格子
			{
				for (int i=0; i<8; i++) 
				{
					if(map_visited[inputy + direction_y[i], inputx + direction_x[i]] == false)
					{
						count_mine(inputx + direction_x[i], inputy + direction_y[i], sender, e);
					}
				}
			}
			step++;
			if (step == map_size * map_size - mines_count)
			{
				MessageBox.Show("Win!!!");
				restart(sender, e);
			}
		}

		private int timer_count = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = "Used: " + timer_count.ToString() + " second";
			timer_count++;
		}
	}
}
