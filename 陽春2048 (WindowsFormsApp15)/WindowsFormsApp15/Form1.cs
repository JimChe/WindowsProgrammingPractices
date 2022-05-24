using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		Button[] cube = new Button[16]; // 顯示地圖的label陣列
		int[,] map = new int[6, 6]; // 宣告比對用地圖
		int[,,] record = new int[1000000, 4, 4]; // 記錄走的步與分數
		List<int> record_score = new List<int>();
		private int step = 0;
		private int score = 0;
		private bool whether_new = false; // 是否已新增
		Random rmd = new Random(Guid.NewGuid().GetHashCode());
		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Visible = false;
			label1.Text = "Used " + count.ToString() + " second(s) !!";
			button1.Visible = false;
			button2.Visible = false;
			button3.Visible = false;
			button4.Visible = false;
			button6.Visible = false;
			button6.Enabled = false;
			label3.Visible = false;
			label4.Visible = false;
			label5.Visible = false;
			label6.Visible = false;
			label7.Visible = false;
			label8.Visible = false;
			label9.Visible = false;
			label10.Visible = false;
			label11.Visible = false;
			label12.Visible = false;
			for (int i = 0; i < 16; i++)
			{
				cube[i] = new Button(); // 初始化label陣列物件
				cube[i].SetBounds(40 + 75 * (i % 4), 20 + 75 * (i / 4), 50, 50);
				cube[i].Text = "";
				Controls.Add(cube[i]);
			}
			int x = rmd.Next(1, 5);
			int y = rmd.Next(1, 5);
			int tf = rmd.Next(0, 10);
			if (tf == 0)
			{
				map[x, y] = 4;
			}
			else
			{
				map[x, y] = 2;
			}
			while (whether_new == false)
			{
				x = rmd.Next(1, 5);
				y = rmd.Next(1, 5);
				tf = rmd.Next(0, 10);
				if (map[x, y] == 0)
				{
					if (tf == 0)
					{
						map[x, y] = 4;
					}
					else
					{
						map[x, y] = 2;
					}
					whether_new = true;
				}
			}
			for (int i = 0; i < 6; i++) // 初始化比對用地圖
			{
				for (int j = 0; j < 6; j++)
				{
					if (i == 0 || i == 5 || j == 0 || j == 5)
					{
						map[i, j] = -1;
					}
				}
			}
			for (int i = 1; i < 5; i++) // 初始化比對用地圖
			{
				for (int j = 1; j < 5; j++)
				{
					if (map[i, j] != 0)
					{
						record[step, i - 1, j - 1] = map[i, j];
					}
				}
			}
			for (int i = 0; i < 16; i++)
			{
				cube[i].Visible = false;
			}
			record_score.Add(score);
			label13.Text = "Scores: " + score.ToString();
		}

		private void button1_Click(object sender, EventArgs e)// move up
		{
			for (int i=0; i<16; i++)
			{
				cube[i].Visible = true;
			}
			step++;
			button6.Enabled = true;
			whether_new = false;
			/*************移動方塊***************/
			for (int j = 1; j < 5; j++)
			{
				bool whether_coor = false;
				for (int i = 1; i < 5; i++) 
				{
					if (whether_coor == false && map[1, j] != 0 && map[2, j] != 0 && map[3, j] != 0 && map[4, j] != 0 && map[1, j] == map[2, j] && map[3, j] == map[4, j]) // 如果這行是兩組一樣的
					{
						map[1, j] *= 2;
						score += map[1, j];
						map[2, j] = map[3, j] * 2;
						score += map[2, j];
						map[3, j] = map[4, j] = 0;
						whether_coor = true; //已合併
					}
					int temp = i;
					while (map[temp, j] != 0 && map[temp - 1, j] == 0)
					{
						map[temp - 1, j] = map[temp, j]; // 將移動到的位置新增數字
						map[temp, j] = 0; // 將上一個位置歸0
						temp--;
					}
					if (whether_coor == false && map[temp, j] != 0 && map[temp - 1, j] != 0 && map[temp, j] == map[temp - 1, j]) // 如果自己與下一個值一樣，合併
					{
						map[temp, j] = 0; // 自己已消失比對地圖歸0
						map[temp - 1, j] *= 2; // 目標方塊的值2倍
						score += map[temp - 1, j];
						whether_coor = true; //已合併
					}
				}
			}

			/*************新增方塊***************/
			/*for (int i = 4; i > 0; i--) // NOTE: 若使用while迴圈判斷必須要額外加入終止條件，以防萬一原先的中止條件可能永遠無法達成的情況
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] == 0)
					{
						map[i, j] = 2;
						cube_count++; // 方塊數加1
						goto here; // 離開多層迴圈的方法用goto去here(在想去的地方打上here)
					}
				}
			}
		here:; // goto到這裡*/
			int count = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] != 0)
					{
						count++;
					}
				}
			}
			if (count == 16) // 地圖已滿不需要再新增
			{
				goto here;
			}
			int count2 = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] == record[step - 1, i - 1, j - 1])
					{
						count2++;
					}
				}
			}
			if (count2 == 16)
			{
				goto here;
			}
			int tf = rmd.Next(0, 10);
			while (whether_new == false)
			{
				int x = rmd.Next(1, 5);
				int y = rmd.Next(1, 5);
				if (map[x, y] == 0)
				{
					if (tf == 0)
					{
						map[x, y] = 4;
						whether_new = true;
					}
					else
					{
						map[x, y] = 2;
						whether_new = true;
					}
				}
			}
		here:;
			/**********************************/

			for (int i = 1; i < 5; i++) // 顯示用地圖
			{
				for (int j = 1; j < 5; j++)
				{
					record[step, i - 1, j - 1] = map[i, j];
					if (map[i, j] == 0)
					{
						cube[(i - 1) * 4 + j - 1].Visible = false;
					}
					else if (map[i, j] != 0)
					{
						cube[(i - 1) * 4 + j - 1].Text = map[i, j].ToString();
					}
				}
			}
			record_score.Add(score);
			label13.Text = "Scores: " + score.ToString();
			/**********************************/
			int count3 = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] != 0)
					{
						count3++;
					}
				}
			}
			if (count3 == 16) // 地圖已滿檢查是否輸
			{
				whether_lose();
				if (lose == true)
				{
					MessageBox.Show("You have no chance!!!");
					timer1.Stop();
				}
			}
			/**********************************/

		}

		private void button2_Click(object sender, EventArgs e) // move dowm
		{
			for (int i = 0; i < 16; i++)
			{
				cube[i].Visible = true;
			}
			step++;
			button6.Enabled = true;
			whether_new = false;
			/*************移動方塊***************/
			for (int j = 1; j < 5; j++) 
			{
				bool whether_coor = false;
				for (int i = 4; i > 0; i--)
				{
					if (whether_coor == false && map[1, j] != 0 && map[2, j] != 0 && map[3, j] != 0 && map[4, j] != 0 && map[4, j] == map[3, j] && map[2, j] == map[1, j]) // 如果這行是兩組一樣的
					{
						map[4, j] *= 2;
						score += map[4, j];
						map[3, j] = map[2, j] * 2;
						score += map[3, j];
						map[2, j] = map[1, j] = 0;
						whether_coor = true; //已合併兩組
					}
					int temp = i;
					while (map[temp, j] != 0 && map[temp + 1, j] == 0)
					{
						map[temp + 1, j] = map[temp, j]; // 將移動到的位置新增數字
						map[temp, j] = 0; // 將上一個位置歸0
						temp++;
					}
					if (whether_coor == false && map[temp, j] != 0 && map[temp + 1, j] != 0 && map[temp, j] == map[temp + 1, j]) // 如果自己與下一個值一樣，合併
					{
						map[temp, j] = 0; // 自己已消失比對地圖歸0
						map[temp + 1, j] *= 2; // 目標方塊的值2倍
						score += map[temp + 1, j];
						whether_coor = true; //已合併一組
					}
				}
			}

			/*************新增方塊***************/
			int count = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] != 0)
					{
						count++;
					}
				}
			}
			if (count == 16) // 地圖已滿不需要再新增
			{
				goto here;
			}
			int count2 = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] == record[step - 1, i - 1, j - 1])
					{
						count2++;
					}
				}
			}
			if (count2 == 16)
			{
				goto here;
			}
			int tf = rmd.Next(0, 10);
			while (whether_new == false)
			{
				int x = rmd.Next(1, 5);
				int y = rmd.Next(1, 5);
				if (map[x, y] == 0)
				{
					if (tf == 0)
					{
						map[x, y] = 4;
						whether_new = true;
					}
					else
					{
						map[x, y] = 2;
						whether_new = true;
					}
				}
			}
		here:;
			/**********************************/

			for (int i = 1; i < 5; i++) // 顯示用地圖
			{
				for (int j = 1; j < 5; j++)
				{
					record[step, i - 1, j - 1] = map[i, j];
					if (map[i, j] == 0)
					{
						cube[(i - 1) * 4 + j - 1].Visible = false;
					}
					else if (map[i, j] != 0)
					{
						cube[(i - 1) * 4 + j - 1].Text = map[i, j].ToString();
					}
				}
			}
			record_score.Add(score);
			label13.Text = "Scores: " + score.ToString();
			/**********************************/
			int count3 = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] != 0)
					{
						count3++;
					}
				}
			}
			if (count3 == 16) // 地圖已滿檢查是否輸
			{
				whether_lose();
				if (lose == true)
				{
					MessageBox.Show("You have no chance!!!");
					timer1.Stop();
				}
			}
			/**********************************/
		}

		private void button3_Click(object sender, EventArgs e) // move left
		{
			for (int i = 0; i < 16; i++)
			{
				cube[i].Visible = true;
			}
			step++;
			button6.Enabled = true;
			whether_new = false;
			/*************移動方塊***************/
			for (int i = 1; i < 5; i++) 
			{
				bool whether_coor = false;
				for (int j = 1; j < 5; j++)
				{
					if (whether_coor == false && map[i, 1] != 0 && map[i, 2] != 0 && map[i, 3] != 0 && map[i, 4] != 0 && map[i, 1] == map[i, 2] && map[i, 3] == map[i, 4]) // 如果這行是兩組一樣的
					{
						map[i, 1] *= 2;
						score += map[i, 1];
						map[i, 2] = map[i, 3] * 2;
						score += map[i, 2];
						map[i, 3] = map[i, 4] = 0;
						whether_coor = true; //一次合併兩組
					}
					int temp = j;
					while (map[i, temp] != 0 && map[i, temp - 1] == 0)
					{
						map[i, temp - 1] = map[i, temp]; // 將移動到的位置新增數字
						map[i, temp] = 0; // 將上一個位置歸0
						temp--;
					}
					if (whether_coor == false && map[i, temp] != 0 && map[i, temp - 1] != 0 && map[i, temp] == map[i, temp - 1]) // 如果自己與下一個值一樣，合併
					{
						map[i, temp] = 0; // 自己已消失比對地圖歸0
						map[i, temp - 1] *= 2; // 目標方塊的值2倍
						score += map[i, temp - 1];
						whether_coor = true;
					}
				}
			}

			/*************新增方塊***************/
			int count = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] != 0)
					{
						count++;
					}
				}
			}
			if (count == 16) // 地圖已滿不需要再新增
			{
				goto here;
			}
			int count2 = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] == record[step - 1, i - 1, j - 1])
					{
						count2++;
					}
				}
			}
			if (count2 == 16)
			{
				goto here;
			}
			int tf = rmd.Next(0, 10);
			while (whether_new == false)
			{
				int x = rmd.Next(1, 5);
				int y = rmd.Next(1, 5);
				if (map[x, y] == 0)
				{
					if (tf == 0)
					{
						map[x, y] = 4;
						whether_new = true;
					}
					else
					{
						map[x, y] = 2;
						whether_new = true;
					}
				}
			}
		here:;
			/**********************************/

			for (int i = 1; i < 5; i++) // 顯示用地圖
			{
				for (int j = 1; j < 5; j++)
				{
					record[step, i - 1, j - 1] = map[i, j];
					if (map[i, j] == 0)
					{
						cube[(i - 1) * 4 + j - 1].Visible = false;
					}
					else if (map[i, j] != 0)
					{
						cube[(i - 1) * 4 + j - 1].Text = map[i, j].ToString();
					}
				}
			}
			record_score.Add(score);
			label13.Text = "Scores: " + score.ToString();
			/**********************************/
			int count3 = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] != 0)
					{
						count3++;
					}
				}
			}
			if (count3 == 16) // 地圖已滿檢查是否輸
			{
				whether_lose();
				if (lose == true)
				{
					MessageBox.Show("You have no chance!!!");
					timer1.Stop();
				}
			}
			/**********************************/
		}

		private void button4_Click(object sender, EventArgs e) // move right
		{
			for (int i = 0; i < 16; i++)
			{
				cube[i].Visible = true;
			}
			step++;
			button6.Enabled = true;
			whether_new = false;
			/*************移動方塊***************/
			for (int i = 1; i < 5; i++) 
			{
				bool whether_coor = false;
				for (int j = 4; j > 0; j--)
				{
					if (whether_coor == false && map[i, 1] != 0 && map[i, 2] != 0 && map[i, 3] != 0 && map[i, 4] != 0 && map[i, 4] == map[i, 3] && map[i, 2] == map[i, 1]) // 如果這行是兩組一樣的
					{
						map[i, 4] *= 2;
						score += map[i, 4];
						map[i, 3] = map[i, 2] * 2;
						score += map[i, 3];
						map[i, 2] = map[i, 1] = 0;
						whether_coor = true; //已兩組
					}
					int temp = j;
					while (map[i, temp] != 0 && map[i, temp + 1] == 0)
					{
						map[i, temp + 1] = map[i, temp]; // 將移動到的位置新增數字
						map[i, temp] = 0; // 將上一個位置歸0
						temp++;
					}
					if (whether_coor == false && map[i, temp] != 0 && map[i, temp + 1] != 0 && map[i, temp] == map[i, temp + 1]) // 如果自己與下一個值一樣，合併
					{
						map[i, temp] = 0; // 自己已消失比對地圖歸0
						map[i, temp + 1] *= 2; // 目標方塊的值2倍
						score += map[i, temp + 1];
						whether_coor = true;
					}
				}
			}

			/*************新增方塊***************/
			int count = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] != 0)
					{
						count++;
					}
				}
			}
			if (count == 16) // 地圖已滿不需要再新增
			{
				goto here;
			}
			int count2 = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] == record[step - 1, i - 1, j - 1])
					{
						count2++;
					}
				}
			}
			if (count2 == 16)
			{
				goto here;
			}
			int tf = rmd.Next(0, 10);
			while (whether_new == false)
			{
				int x = rmd.Next(1, 5);
				int y = rmd.Next(1, 5);
				if (map[x, y] == 0)
				{
					if (tf == 0)
					{
						map[x, y] = 4;
						whether_new = true;
					}
					else
					{
						map[x, y] = 2;
						whether_new = true;
					}
				}
			}
		here:;
			/**********************************/

			for (int i = 1; i < 5; i++) // 顯示用地圖
			{
				for (int j = 1; j < 5; j++)
				{
					record[step, i - 1, j - 1] = map[i, j];
					if (map[i, j] == 0)
					{
						cube[(i - 1) * 4 + j - 1].Visible = false;
					}
					else if (map[i, j] != 0)
					{
						cube[(i - 1) * 4 + j - 1].Text = map[i, j].ToString();
					}
				}
			}
			record_score.Add(score);
			label13.Text = "Scores: " + score.ToString();
			/**********************************/
			int count3 = 0;
			for (int i = 4; i > 0; i--)
			{
				for (int j = 4; j > 0; j--)
				{
					if (map[i, j] != 0)
					{
						count3++;
					}
				}
			}
			if (count3 == 16) // 地圖已滿檢查是否輸
			{
				whether_lose();
				if (lose == true)
				{
					MessageBox.Show("You have no chance!!!");
					timer1.Stop();
				}
			}
			/**********************************/
		}
		private void button5_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < 16; i++)
			{
				cube[i].Visible = true;
			}
			timer1.Start();
			label2.Visible = false;
			button5.Visible = false;
			label1.Visible = true;
			button1.Visible = true;
			button2.Visible = true;
			button3.Visible = true;
			button4.Visible = true;
			button6.Visible = true;
			label3.Visible = true;
			label4.Visible = true;
			label5.Visible = true;
			label6.Visible = true;
			label7.Visible = true;
			label8.Visible = true;
			label9.Visible = true;
			label10.Visible = true;
			label11.Visible = true;
			label12.Visible = true;
			for (int i = 1; i < 5; i++) // 檢查比對用地圖是否有誤 
			{
				for (int j = 1; j < 5; j++)
				{
					if (map[i, j] == 0)
					{
						cube[(i - 1) * 4 + j - 1].Visible = false;
					}
					else if (map[i, j] != 0)
					{
						cube[(i - 1) * 4 + j - 1].Text = map[i, j].ToString();
					}
				}
			}
		}
		private int[] x = new int[] { -1, 0, 1, 0 };
		private int[] y = new int[] { 0, -1, 0, 1 };
		private bool lose = false;
		private void whether_lose()
		{
			int nope_count = 0;
			for (int i=1; i<5; i++)
			{
				for (int j=1; j<5; j++)
				{
					for (int k=0; k<4; k++) // 每一塊4個方位檢查
					{
						if (map[i, j] != map[i + x[k], j + y[k]])
						{
							nope_count++;
						}
					}
				}
			}
			if (nope_count == 64) // 如果所有的方塊周圍都沒有一樣的(4方位，16塊)
			{
				lose = true;
			}
		}

		private int count = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			label1.Text = "Used " + count.ToString() + " second(s) !!";
			count++;
		}

		private void button6_Click(object sender, EventArgs e) // 回上一步
		{
			for (int i = 0; i < 16; i++)
			{
				cube[i].Visible = true;
			}
			for (int i=1; i<5; i++)
			{
				for (int j=1; j<5; j++)
				{
					map[i, j] = record[step - 1, i - 1, j - 1];
				}
			}
			if (step > 0)
			{
				step--;
			}
			if (step == 0)
			{
				button6.Enabled = false;
			}
			for (int i = 1; i < 5; i++) // 顯示用地圖
			{
				for (int j = 1; j < 5; j++)
				{
					if (map[i, j] == 0)
					{
						cube[(i - 1) * 4 + j - 1].Visible = false; ;
					}
					else if (map[i, j] != 0)
					{
						cube[(i - 1) * 4 + j - 1].Text = map[i, j].ToString();
					}
				}
			}
			score = record_score[step];
			label13.Text = "Scores: " + score.ToString();
		}
	}
}
