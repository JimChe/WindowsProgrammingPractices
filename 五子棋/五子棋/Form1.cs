using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace 五子棋
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		Label game_name = new Label();
		Button[] selections = new Button[3];
		/* Game start interface */
		private void Form1_Load(object sender, EventArgs e)
		{
			/* background image */
			this.Size = new Size(800, 800);
			BackgroundImage = Image.FromFile(@"棋盤.jpg");
			BackgroundImageLayout = ImageLayout.Stretch;// 修正background image size問題

			/* Game name label */
			game_name.SetBounds(295, 100, 200, 100);
			game_name.Text = "五子棋";
			game_name.Font = new Font("細明體", 40, FontStyle.Bold);
			game_name.BackColor = Color.Transparent;
			Controls.Add(game_name);

			/* interface operation buttons */
			for (int i=0; i<3; i++)
			{
				selections[i] = new Button();
				selections[i].SetBounds(310, 230 + 120 * i, 150, 50);
				Controls.Add(selections[i]);
				selections[i].Click += new EventHandler(Button_select);
			}
			selections[0].Text = "玩家 vs 玩家";
			selections[1].Text = "玩家 vs 電腦";
			selections[2].Text = "離開遊戲";
		}

		/* Find which button was selected */
		private void Button_select(object sender, EventArgs e)
		{
			for (int i=0; i<3; i++)
			{
				if (selections[i] == sender as Button)
				{
					switch (i)
					{
						case 0:
							Game_start();
							break;
						case 1:
							Game_start();
							break;
						case 2:
							Application.Exit();
							break;
					}
				}
			}
		}

		Label[,] chesses = new Label[27, 27];
		int[,] situation = new int[27, 27];
		/* Game start interface (initialize the objects)*/
		private void Game_start()
		{
			/* hide the game name label and selecctions button */
			game_name.Visible = game_name.Enabled = false;
			for (int i = 0; i < 3; i++)
			{
				selections[i].Visible = selections[i].Enabled = false;
			}
			for (int i = 0; i < 27; i++)
			{
				for (int j = 0; j < 27; j++)
				{
					chesses[i, j] = new Label();
					chesses[i, j].SetBounds(-148 + 40 * j, -151 + 40 * i, 25, 25);
					MakeLabelRounded(chesses[i, j]);
					chesses[i, j].Click += new EventHandler(Pos_select);
					Controls.Add(chesses[i, j]);
					chesses[i, j].BackColor = Color.Transparent;
				}
			}
			for (int i = 0; i < 27; i++)
			{
				for (int j = 0; j < 27; j++)
				{
					if ((0 <= i && i <= 3) || (23 <= i && i <= 26) ||
						(0 <= j && j <= 3) || (23 <= j && j <= 26))
					{
						situation[i, j] = 3; // outside position, use for calculation
					}
					else
					{
						situation[i, j] = 0;
					}
				}
			}
		}

		/* Make round label */
		private void MakeLabelRounded(Label label)
		{
			GraphicsPath gp = new GraphicsPath();
			gp.AddEllipse(0, 0, label.Width, label.Height);
			label.Region = new Region(gp);
			label.Invalidate();
		}

		private bool Black_turn = true;
		private void Pos_select(object sender, EventArgs e)
		{
			int posx = 0, posy = 0; // record player's current step
			
			for (int i = 0; i < 27; i++)
			{
				for (int j = 0; j < 27; j++)
				{
					if (chesses[i, j] == sender as Label && situation[i, j] == 0)
					{
						if (Black_turn)
						{
							(sender as Label).BackColor = Color.Black;
							Black_turn = false;
							situation[i, j] = 1;
						}
						else
						{
							(sender as Label).BackColor = Color.White;
							Black_turn = true;
							situation[i, j] = 2;
						}

						posx = j;
						posy = i;				
					}
				}
			}

			Computer(posx, posy);

			/*label1.Text = "";
			for (int i=4; i<23; i++)
			{
				for (int j=4; j<23; j++)
				{
					label1.Text += situation[i, j].ToString() + " ";
				}
				label1.Text += "\r\n";
			}*/
		}

		private int totalscore = 0;
		private int computer_turn = 1;
		private void Computer(int x, int y)
		{
			for (int i=5; i>=4; i--)
			{
				if (Need_defend(i, false))
				{
					totalscore += computer_turn * 200 * i;
					computer_turn *= -1;
					goto here;
				}
				else if (Need_defend(i, true))
				{
					totalscore += computer_turn * 190 * i;
					computer_turn *= -1;
					goto here;
				}
			}
			for (int i = 3; i >= 2; i--)
			{
				if (Need_defend(i, false))
				{
					totalscore += computer_turn * 180 * i;
					computer_turn *= -1;
					goto here;
				}
			}
			for (int i = 3; i >= 1; i--)
			{
				if (Need_defend(i, true))
				{
					totalscore += computer_turn * 100 * i;
					computer_turn *= -1;
					goto here;
				}
			}
			RndMode();
		here:;
		}

		private bool Need_defend(int check_range, bool need)
		{
			for (int i = 4; i < 23; i++) // check the whole map's subarea
			{
				for (int j = 4; j < 23; j++)
				{
					int[] dirx = new int[4] { 0, 1, 1, 1 };
					int[] diry = new int[4] { 1, 0, 1, -1 };

					for (int k = 0; k < 4; k++) // check 4 direction(row, col, diagonal right, left oblique)
					{
						int enemy_count = 0; // count of enemt's chesses
						int friend_count = 0; // count of computer's chesses
						int defense_posx = 0; // record the point to defend
						int defense_posy = 0;

						for (int a = 0; a < check_range; a++) // subarea include 'check_range' point
						{
							if (need)
							{
								if (situation[i + dirx[k] * a, j + diry[k] * a] == 2)
								{
									goto here;
								}
								else if (situation[i + dirx[k] * a, j + diry[k] * a] == 1)
								{
									enemy_count++;
								}
								else if (situation[i + dirx[k] * a, j + diry[k] * a] == 0)
								{
									defense_posx = i + dirx[k] * a;
									defense_posy = j + diry[k] * a;
								}
							}
							else
							{
								if (situation[i + dirx[k] * a, j + diry[k] * a] == 1)
								{
									goto here;
								}
								else if (situation[i + dirx[k] * a, j + diry[k] * a] == 2)
								{
									friend_count++;
								}
								else if (situation[i + dirx[k] * a, j + diry[k] * a] == 0)
								{
									defense_posx = i + dirx[k] * a;
									defense_posy = j + diry[k] * a;
								}
							}
						}

						if (need)
						{
							if (enemy_count == check_range - 1)
							{
								chesses[defense_posx, defense_posy].BackColor = Color.White;
								Black_turn = true;
								situation[defense_posx, defense_posy] = 2;
								return true;
							}
						}
						else
						{
							if (friend_count == check_range - 1)
							{
								chesses[defense_posx, defense_posy].BackColor = Color.White;
								Black_turn = true;
								situation[defense_posx, defense_posy] = 2;
								return true;
							}
						}
						
					here:;
					}
				}
			}
			return false;
		}

		private void RndMode()
		{
			Random rnd = new Random(Guid.NewGuid().GetHashCode());
			int x, y;
			do
			{
				x = rnd.Next(4, 23);
				y = rnd.Next(4, 23);
			} while (situation[x, y] != 0);
			chesses[x, y].BackColor = Color.White;
			Black_turn = true;
			situation[x, y] = 2;
		}
	}
}
