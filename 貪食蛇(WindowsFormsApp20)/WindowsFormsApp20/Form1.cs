using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp20
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		List<Label> snake_body = new List<Label>(); // 宣告存放button的list表示蛇的身體
		Random rmd = new Random(Guid.NewGuid().GetHashCode()); //亂數生成一開始蛇的位置
		private int snake_lenth = 0; // 累計蛇身的長度(多少個label)
		Label[] food = new Label[10000]; // 生產食物
		private int food_count = 0;
		private void Form1_Load(object sender, EventArgs e)
		{
			for (int i=0; i<10000; i++)
			{
				food[i] = new Label();
			}
			BackColor = Color.White;
			for (int i=0; i<5; i++) // 初始化蛇的身體(5節)
			{
				if (i == 0)
				{
					Label b = new Label();
					b.SetBounds(300 + 10 * i, 150, 10, 10);
					b.BackColor = Color.Black; // 黑色表示為蛇頭
					Controls.Add(b);
					snake_body.Add(b);
					snake_lenth++;
				}
				else
				{
					Label b = new Label();
					b.SetBounds(300 + 10 * i, 150, 10, 10);
					b.BackColor = Color.Purple; // 紅色表示為蛇身
					Controls.Add(b);
					snake_body.Add(b);
					snake_lenth++;
				}
			}
			food[food_count].SetBounds(100, 150, 10, 10); // 設定食物位置
			food[food_count].BackColor = Color.Red;
			Controls.Add(food[food_count]);
			timer_run.Start();
		}
		private bool can_up = false;
		private bool can_down = false;
		private bool can_left = true;
		private bool can_right = false;
		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
			{
				can_up = true;
				can_down = false;
				can_left = false;
				can_right = false;
			}
			else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
			{
				can_up = false;
				can_down = true;
				can_left = false;
				can_right = false;
			}
			else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
			{
				can_up = false;
				can_down = false;
				can_left = true;
				can_right = false;
			}
			else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
			{
				can_up = false;
				can_down = false;
				can_left = false;
				can_right = true;
			}
		}

		private void eat_and_grow()
		{
			food[food_count].Dispose(); // 食物消失
			Label b = new Label(); // 蛇長大
			b.SetBounds(snake_body[snake_lenth - 1].Left, snake_body[snake_lenth - 1].Top, 10, 10);
			b.BackColor = Color.Purple; // 紅色表示為蛇身
			Controls.Add(b);
			snake_body.Add(b);
			snake_lenth++;
			int x = rmd.Next(0, 59); // 隨機生成食物位置
			int y = rmd.Next(0, 32);
			food_count++;
			food[food_count].SetBounds(10 * x, 10 * y, 10, 10);
			food[food_count].BackColor = Color.Red;
			Controls.Add(food[food_count]);
		}

		private void timer_run_Tick(object sender, EventArgs e)
		{
			if (snake_body[0].Left == food[food_count].Left && snake_body[0].Top == food[food_count].Top) // 這裡是蛇吃東西長大的code(吃完先長大再走)
			{
				eat_and_grow();
			}
			for (int i = snake_lenth - 1; i > 0; i--) // 先移動頭部以後的身體，在決定頭的下一步
			{
				if (snake_body[i - 1].Top + 10 == snake_body[i].Top)
				{
					snake_body[i].Top -= 10;
				}
			    else if (snake_body[i - 1].Top - 10 == snake_body[i].Top)
				{
					snake_body[i].Top += 10;
				}
				else if (snake_body[i - 1].Left + 10 == snake_body[i].Left)
				{
					snake_body[i].Left -= 10;
				}
				else if (snake_body[i - 1].Left - 10 == snake_body[i].Left)
				{
					snake_body[i].Left += 10;
				}
			}
			if (can_up == true)
			{
				snake_body[0].Top -= 10;
				if (snake_body[0].Top <= -1) // 若撞到上方的牆
				{
					timer_run.Stop();
					MessageBox.Show("Lose");
				}
			}
			else if (can_down == true)
			{
				snake_body[0].Top += 10;
				if (snake_body[0].Top >= 315) // 若撞到上方的牆
				{
					timer_run.Stop();
					MessageBox.Show("Lose");
				}
			}
			else if (can_left == true)
			{
				snake_body[0].Left -= 10;
				if (snake_body[0].Left <= -1) // 若撞到上方的牆
				{
					timer_run.Stop();
					MessageBox.Show("Lose");
				}
			}
			else if (can_right == true)
			{
				snake_body[0].Left += 10;
				if (snake_body[0].Left >= 585) // 若撞到上方的牆
				{
					timer_run.Stop();
					MessageBox.Show("Lose");
				}
			}
			for (int i = 4; i < snake_body.LongCount(); i++) // 若撞到自己的身體
			{
				if (snake_body[0].Top <= snake_body[i].Top + 9 && snake_body[0].Top >= snake_body[i].Top - 9 && snake_body[0].Left <= snake_body[i].Left + 9 && snake_body[0].Left >= snake_body[i].Left - 9)
				{
					timer_run.Stop();
					MessageBox.Show("Lose");
				}
			}
		}
	}
}
