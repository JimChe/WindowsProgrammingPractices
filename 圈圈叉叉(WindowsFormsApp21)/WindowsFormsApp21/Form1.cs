using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp21
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Button[,] map = new Button[3, 3];
		private void Form1_Load(object sender, EventArgs e)
		{
			for (int i=0; i<3; i++)
			{
				for (int j=0; j<3; j++)
				{
					map[i, j] = new Button();
					map[i, j].SetBounds(15 + 90 * i, 15 + 90 * j, 80, 80);
					map[i, j].BackColor = Color.White;
					Controls.Add(map[i, j]);
					map[i, j].Click += new EventHandler(choose);
				}
			}
		}

		Random rmd = new Random(Guid.NewGuid().GetHashCode());
		private int step = 1; // 紀錄回合數

		private void whether_can_win(int i, int j)
		{
			for (int k = 0; k < 3; k++)
			{
				if (map[k, 0].Text == "X" && map[k, 1].Text == "X" && map[k, 2].Text == "")
				{
					map[k, 2].Text = "X";
					MessageBox.Show("Lose!");
				}
				else if (map[k, 1].Text == "X" && map[k, 2].Text == "X" && map[k, 0].Text == "")
				{
					map[k, 0].Text = "X";
					MessageBox.Show("Lose!");
				}
			}
			for (int k = 0; k < 3; k++)
			{
				if (map[0, k].Text == "X" && map[1, k].Text == "X" && map[2, k].Text == "")
				{
					map[2, k].Text = "X";
					MessageBox.Show("Lose!");
				}
				else if (map[1, k].Text == "X" && map[2, k].Text == "X" && map[0, k].Text == "")
				{
					map[0, k].Text = "X";
					MessageBox.Show("Lose!");
				}
			}
			if (map[0, 0].Text == "X" && map[1, 1].Text == "X" && map[2, 2].Text == "")
			{
				map[2, 2].Text = "X";
				MessageBox.Show("Lose!");
			}
			if (map[2, 0].Text == "X" && map[1, 1].Text == "X" && map[0, 2].Text == "")
			{
				map[0, 2].Text = "X";
				MessageBox.Show("Lose!");
			}
			if (map[0, 2].Text == "X" && map[1, 1].Text == "X" && map[2, 0].Text == "")
			{
				map[2, 0].Text = "X";
				MessageBox.Show("Lose!");
			}
			if (map[2, 2].Text == "X" && map[1, 1].Text == "X" && map[0, 0].Text == "")
			{
				map[0, 0].Text = "X";
				MessageBox.Show("Lose!");
			}
		}

		private int defend()
		{
			for (int k = 0; k < 3; k++)
			{
				if (map[k, 0].Text == "O" && map[k, 1].Text == "O" && map[k, 2].Text == "")
				{
					map[k, 2].Text = "X";
					return 1;
				}
				else if (map[k, 1].Text == "O" && map[k, 2].Text == "O" && map[k, 0].Text == "")
				{
					map[k, 0].Text = "X";
					return 1;
				}
			}
			for (int k = 0; k < 3; k++)
			{
				if (map[0, k].Text == "O" && map[1, k].Text == "O" && map[2, k].Text == "")
				{
					map[2, k].Text = "X";
					return 1;
				}
				else if (map[1, k].Text == "O" && map[2, k].Text == "O" && map[0, k].Text == "")
				{
					map[0, k].Text = "X";
					return 1;
				}
			}
			if (map[0, 0].Text == "O" && map[1, 1].Text == "O" && map[2, 2].Text == "")
			{
				map[2, 2].Text = "X";
				return 1;
			}
			if (map[2, 0].Text == "O" && map[1, 1].Text == "O" && map[0, 2].Text == "")
			{
				map[0, 2].Text = "X";
				return 1;
			}
			if (map[0, 2].Text == "O" && map[1, 1].Text == "O" && map[2, 0].Text == "")
			{
				map[2, 0].Text = "X";
				return 1;
			}
			if (map[2, 2].Text == "O" && map[1, 1].Text == "O" && map[0, 0].Text == "")
			{
				map[0, 0].Text = "X";
				return 1;
			}
			if (map[0, 0].Text == "O" && map[2, 0].Text == "O" && map[1, 0].Text == "")
			{
				map[1, 0].Text = "X";
				return 1;
			}
			if (map[0, 0].Text == "O" && map[0, 2].Text == "O" && map[0, 1].Text == "")
			{
				map[0, 1].Text = "X";
				return 1;
			}
			if (map[0, 2].Text == "O" && map[2, 2].Text == "O" && map[1, 2].Text == "")
			{
				map[1, 2].Text = "X";
				return 1;
			}
			if (map[2, 0].Text == "O" && map[2, 2].Text == "O" && map[2, 1].Text == "")
			{
				map[2, 1].Text = "X";
				return 1;
			}
			return 0;
		}
		private void choose(object sender, EventArgs e)
		{
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					if (15 + 90 * i == (sender as Button).Left && 15 + 90 * j == (sender as Button).Top)
					{
						if (step == 1) // 玩家電腦各下第一步
						{
							map[i, j].Text = "O";
							map[i, j].Enabled = false;
							if (i * 3 + j != 4) // 如果玩家沒有占領中間，電腦就占領中間
							{
								map[1, 1].Text = "X";
								map[1, 1].Enabled = false;
							}
							else if (map[1, 1].Text == "O") // 如果玩家占領中間，電腦下角落
							{
								int selection = rmd.Next(0, 4);
								switch (selection)
								{
									case 0:
										map[0, 0].Text = "X";
										map[0, 0].Enabled = false;
										break;
									case 1:
										map[0, 2].Text = "X";
										map[0, 2].Enabled = false;
										break;
									case 2:
										map[2, 0].Text = "X";
										map[2, 0].Enabled = false;
										break;
									case 3:
										map[2, 2].Text = "X";
										map[2, 2].Enabled = false;
										break;
								}

							}
							step++; // 下次下的時候判定變成用step2的方法判定
						}
						else if (step == 2) // 玩家電腦各下第二步
						{
							map[i, j].Text = "O";
							map[i, j].Enabled = false;
							/*********************如果玩家再下一個就贏，電腦防守**********************/
							if (defend() == 1)
							{
								goto here;
							}
							/*****************************/

							/*********************OX交叉情況**********************/
							if (map[1, 0].Text == "O" && map[0, 1].Text == "O")  
							{
								map[0, 0].Text = "X";
								goto here;
							}
							if (map[1, 0].Text == "O" && map[2, 1].Text == "O")
							{
								map[2, 0].Text = "X";
								goto here;
							}
							if (map[0, 1].Text == "O" && map[1, 2].Text == "O")
							{
								map[0, 2].Text = "X";
								goto here;
							}
							if (map[2, 1].Text == "O" && map[1, 2].Text == "O")
							{
								map[2, 2].Text = "X";
								goto here;
							}
							/************************************/

							/********************OX十字情況*****************/
							if (map[1, 0].Text == "O" && map[1, 2].Text == "O") 
							{
								int selection = rmd.Next(0, 2);
								if (selection == 0)
								{
									map[0, 1].Text = "X";
									goto here;
								}
								if (selection == 1)
								{
									map[2, 1].Text = "X";
									goto here;
								}
							}
							if (map[0, 1].Text == "O" && map[0, 2].Text == "O")
							{
								int selection = rmd.Next(0, 2);
								if (selection == 0)
								{
									map[1, 0].Text = "X";
									goto here;
								}
								if (selection == 1)
								{
									map[1, 2].Text = "X";
									goto here;
								}
							}
							/**************************/

							/*********************其他情況*******************/
							if (map[2, 0].Text == "O" && map[0, 1].Text == "O") 
							{
								map[1, 0].Text = "X";
								goto here;
							}
							if (map[2, 2].Text == "O" && map[0, 1].Text == "O") 
							{
								map[1, 2].Text = "X";
								goto here;
							}
							if (map[0, 0].Text == "O" && map[2, 1].Text == "O") 
							{
								map[1, 0].Text = "X";
								goto here;
							}
							if (map[0, 2].Text == "O" && map[2, 1].Text == "O") 
							{
								map[1, 2].Text = "X";
								goto here;
							}
							if (map[1, 0].Text == "O" && map[0, 2].Text == "O") 
							{
								map[0, 1].Text = "X";
								goto here;
							}
							if (map[1, 0].Text == "O" && map[2, 2].Text == "O")
							{
								map[2, 1].Text = "X";
								goto here;
							}
							if (map[1, 2].Text == "O" && map[0, 0].Text == "O") 
							{
								map[0, 1].Text = "X";
							    goto here;
							}
							if (map[1, 2].Text == "O" && map[2, 0].Text == "O") 
							{
								map[2, 1].Text = "X";
								goto here;
							}
							/**********************/
						here:;
							step++;
						}
					    else if (step == 3)
						{
							map[i, j].Text = "O";
							for (int k=0; k<3; k++)
							{
								if (map[k, 0].Text == "O" && map[k, 1].Text == "O" && map[k, 2].Text == "O")
								{
									MessageBox.Show("Win!!!");
								}
								if (map[0, k].Text == "O" && map[1, k].Text == "O" && map[2, k].Text == "O")
								{
									MessageBox.Show("Win!!!");
								}
							}
							if (map[0, 0].Text == "O" && map[1, 1].Text == "O" && map[2, 2].Text == "O")
							{
								MessageBox.Show("Win!!!");
							}
							if (map[2, 0].Text == "O" && map[1, 1].Text == "O" && map[0, 2].Text == "O")
							{
								MessageBox.Show("Win!!!");
							}
							int space_count = 0;
							for (int m = 0; m < 3; m++)
							{
								for (int n = 0; n < 3; n++)
								{
									if (map[m, n].Text != "")
									{
										space_count++;
									}
								}
							}
							if (space_count == 9)
							{
								MessageBox.Show("Draw!!");
							}
							/*************************優先檢查是否有贏的機會**************/
							whether_can_win(i, j);
							/*********************若玩家再下一步就贏了，防守*************/
							if (defend() == 1)
							{
								goto here;
							}
							bool X = false;
							while (X == false)
							{
								int x = rmd.Next(0, 3);
								int y = rmd.Next(0, 3);
								if (map[x, y].Text == "")
								{
									map[x, y].Text = "X";
									X = true;
								}
							}
						here:;
						}
					}
				}
			}
		}
	}
}
