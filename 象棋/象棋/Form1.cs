using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 象棋
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		/***** 1~7: 紅方將~兵(from big to small) / 8~14: 黑方將~兵(from big to small) ******/

		/* set the comparation map */
		int[,] map = new int[10, 9];

		/* set the click map */
		Label[,] click_map = new Label[10, 9];

		/* initialize the click map */
		private void initialize_click_map()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					click_map[i, j] = new Label();
					click_map[i, j].SetBounds(60 * j, 60 * i, 60, 60);
					click_map[i, j].Font = new Font("細明體", 24, FontStyle.Bold);
					click_map[i, j].BackColor = Color.Transparent;
					Controls.Add(click_map[i, j]);
					click_map[i, j].Click += new EventHandler(find_destination);
					click_map[i, j].Visible = click_map[i, j].Enabled = false;
				}
			}
		}

		/* initialize the chesses*/
		private void initilaize_map_chesses(int i, int j, string chess_name, Color team)
		{
			click_map[i, j].Text = chess_name;
			click_map[i, j].BackColor = Color.BurlyWood;
			click_map[i, j].ForeColor = team;
			click_map[i, j].Size = new Size(40, 40);
		}

		/* initialize the comparison map */
		private void initialize_map()
		{
			/* initialize the map */
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					/* 紅方 */
					if (i == 0)
					{
						switch (j)
						{
							/* 紅方車 */
							case 0:
								map[i, j] = 4;
								initilaize_map_chesses(i, j, "車", Color.Red);
								break;
							case 8:
								map[i, j] = 4;
								initilaize_map_chesses(i, j, "車", Color.Red);
								break;

							/* 紅方馬 */
							case 1:
								map[i, j] = 5;
								initilaize_map_chesses(i, j, "馬", Color.Red);
								break;
							case 7:
								map[i, j] = 5;
								initilaize_map_chesses(i, j, "馬", Color.Red);
								break;

							/* 紅方象 */
							case 2:
								map[i, j] = 3;
								initilaize_map_chesses(i, j, "相", Color.Red);
								break;
							case 6:
								map[i, j] = 3;
								initilaize_map_chesses(i, j, "相", Color.Red);
								break;

							/* 紅方士 */
							case 3:
								map[i, j] = 2;
								initilaize_map_chesses(i, j, "仕", Color.Red);
								break;
							case 5:
								map[i, j] = 2;
								initilaize_map_chesses(i, j, "仕", Color.Red);
								break;

							/* 紅方帥 */
							case 4:
								map[i, j] = 1;
								initilaize_map_chesses(i, j, "帥", Color.Red);
								break;
						}
					}

					/* 紅方炮 */
					else if (i == 2 && (j == 1 || j == 7))
					{
						map[i, j] = 6;
						initilaize_map_chesses(i, j, "炮", Color.Red);
					}

					/* 紅方兵 */
					else if (i == 3 && j % 2 == 0)
					{
						map[i, j] = 7;
						initilaize_map_chesses(i, j, "兵", Color.Red);
					}

					/* 黑方 */
					else if (i == 9)
					{
						switch (j)
						{
							/* 黑方車 */
							case 0:
								map[i, j] = 11;
								initilaize_map_chesses(i, j, "車", Color.Black);
								break;
							case 8:
								map[i, j] = 11;
								initilaize_map_chesses(i, j, "車", Color.Black);
								break;

							/* 黑方馬 */
							case 1:
								map[i, j] = 12;
								initilaize_map_chesses(i, j, "馬", Color.Black);
								break;
							case 7:
								map[i, j] = 12;
								initilaize_map_chesses(i, j, "馬", Color.Black);
								break;

							/* 黑方象 */
							case 2:
								map[i, j] = 10;
								initilaize_map_chesses(i, j, "象", Color.Black);
								break;
							case 6:
								map[i, j] = 10;
								initilaize_map_chesses(i, j, "象", Color.Black);
								break;

							/* 黑方士 */
							case 3:
								map[i, j] = 9;
								initilaize_map_chesses(i, j, "士", Color.Black);
								break;
							case 5:
								map[i, j] = 9;
								initilaize_map_chesses(i, j, "士", Color.Black);
								break;

							/* 黑方將 */
							case 4:
								map[i, j] = 8;
								initilaize_map_chesses(i, j, "將", Color.Black);
								break;
						}
					}

					/* 黑方炮 */
					else if (i == 7 && (j == 1 || j == 7))
					{
						map[i, j] = 13;
						initilaize_map_chesses(i, j, "包", Color.Black);
					}

					/* 黑方卒 */
					else if (i == 6 && j % 2 == 0)
					{
						map[i, j] = 14;
						initilaize_map_chesses(i, j, "卒", Color.Black);
					}
				}
			}
		}

		/* display the chesses */
		private void display_map()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					click_map[i, j].Visible = click_map[i, j].Enabled = true;
				}
			}
		}

		private Label chosen_chess;

		/* initialize the form */
		private void Form1_Load(object sender, EventArgs e)
		{
			label1.Visible = label1.Enabled = true;
			start_button.Visible = start_button.Enabled = true;
			end_button.Visible = end_button.Enabled = true;

			/* initialize the map */
			initialize_click_map();

			/* initialize the comparison map */
			initialize_map();

			/* initialize the Label that record the chosen chess */
			chosen_chess = new Label();
			chosen_chess.Visible = chosen_chess.Enabled = false;
		}

		/* start the game */
		private void start_button_Click(object sender, EventArgs e)
		{
			BackgroundImage = Image.FromFile(@"象棋棋盤.gif"); // 建立圖片檔案
			BackgroundImageLayout = ImageLayout.Stretch;// 修正background image size問題
			label1.Visible = label1.Enabled = false;
			start_button.Visible = start_button.Enabled = false;
			end_button.Visible = end_button.Enabled = false;

			/* display the chesses on the map */
			display_map();

			/* 電腦為紅方 */
			if (is_red == true)
			{
				computer_control();
			}
		}

		/* exit the game */
		private void end_button_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		/* go to the destination */
		private void go_to_the_desitnation(int i, int j)
		{
			click_map[i, j].Text = chosen_chess.Text;
			click_map[i, j].ForeColor = chosen_chess.ForeColor;
			click_map[i, j].Size = chosen_chess.Size;
			chosen_chess.Text = "";
			chosen_chess.BackColor = Color.Transparent;
			chosen = false;
		}

		/* click the label that your destination */
		private void find_destination(object sender, EventArgs e)
		{
			for (int i=0; i<10; i++)
			{
				for (int j=0; j<9; j++)
				{
					if (click_map[i, j].ForeColor == Color.Black && click_map[i, j].Left == (sender as Label).Left && click_map[i, j].Top == (sender as Label).Top)
					{
						/* if had not chosen chess, choose it */
						if (chosen == false && click_map[i, j].Text != "")
						{
							chosen_chess = click_map[i, j];
							chosen_chess.Text = click_map[i, j].Text;
							chosen_chess.ForeColor = click_map[i, j].ForeColor;
							chosen_chess.Size = click_map[i, j].Size;
							click_map[i, j].BackColor = Color.DarkRed;
							chosen = true;
						}

						/* if had chosen chess, move it */
						else if (chosen == true)
						{
							if (whether_valid_path(click_map[i, j].Left, click_map[i, j].Top) == 1)
							{
								/*if (is_red == true && 
								   (click_map[i, j].Text == "" || click_map[i, j].ForeColor == Color.Black))
								{
									go_to_the_desitnation(i, j);
									is_red = false;
								}*/
								/*else */if (is_red == false &&
								   (click_map[i, j].Text == "" || click_map[i, j].ForeColor == Color.Red))
								{
									go_to_the_desitnation(i, j);
									is_red = true;
									
									/* 玩家動完換電腦 */
									computer_control();
								}
							}

							/* if move fail */
							else
							{
								chosen = false;
							}
						}
					}
				}
			}
			update_map();
		}
		
		/* update the new status of map */
		private void update_map()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					if (click_map[i, j].Text != "")
					{
						click_map[i, j].Size = new Size(40, 40);
						click_map[i, j].BackColor = Color.BurlyWood;
					}
					else
					{
						click_map[i, j].Size = new Size(60, 60);
						click_map[i, j].BackColor = Color.Transparent;
					}
				}
			}
		}

		/* compare the valid path of general */
		private int general_valid_path_comparison(int Left, int Top) // Left and Top is clicking desnitation's Left and Top
		{
			if ((Top == chosen_chess.Top - 60 && Left == chosen_chess.Left) ||
			(Left == chosen_chess.Left - 60 && Top == chosen_chess.Top) ||
			(Left == chosen_chess.Left + 60 && Top == chosen_chess.Top) ||
			(Top == chosen_chess.Top + 60 && Left == chosen_chess.Left))
			{
				if (Left >= 180 && Left <= 300)
				{
					if (chosen_chess.ForeColor == Color.Red && Top >= 0 && Top <= 120)
					{
						return 1;
					}
					else if (chosen_chess.ForeColor == Color.Black && Top >= 420 && Top <= 540)
					{
						return 1;
					}
				}
			}
			return 0;
		}

		/* compare the valid path of mandarins(士) */
		private int mandarins_valid_path_comparison(int Left, int Top) // Left and Top is clicking desnitation's Left and Top
		{
			if ((Top == chosen_chess.Top - 60 && Left == chosen_chess.Left - 60) ||
			(Top == chosen_chess.Top - 60 && Left == chosen_chess.Left + 60) ||
			(Top == chosen_chess.Top + 60 && Left == chosen_chess.Left - 60) ||
			(Top == chosen_chess.Top + 60 && Left == chosen_chess.Left + 60))
			{
				if (Left >= 180 && Left <= 300)
				{
					if (chosen_chess.ForeColor == Color.Red && Top >= 0 && Top <= 120)
					{
						return 1;
					}
					else if (chosen_chess.ForeColor == Color.Black && Top >= 420 && Top <= 540)
					{
						return 1;
					}
				}
			}
			return 0;
		}

		/* compare the valid path of bishops(相) */
		private int bishops_valid_path_comparison(int Left, int Top) // Left and Top is clicking desnitation's Left and Top
		{
			/* click_map[chosen_chess.Top / 60, chosen_chess.Left / 60] = ""表示判斷是否遮相眼 */
			if ((Top == chosen_chess.Top - 120 && Left == chosen_chess.Left - 120 && click_map[chosen_chess.Top / 60 - 1, chosen_chess.Left / 60 - 1].Text == "") ||
			(Top == chosen_chess.Top - 120 && Left == chosen_chess.Left + 120 && click_map[chosen_chess.Top / 60 - 1, chosen_chess.Left / 60 + 1].Text == "") ||
			(Top == chosen_chess.Top + 120 && Left == chosen_chess.Left - 120 && click_map[chosen_chess.Top / 60 + 1, chosen_chess.Left / 60 - 1].Text == "") ||
			(Top == chosen_chess.Top + 120 && Left == chosen_chess.Left + 120) && click_map[chosen_chess.Top / 60 + 1, chosen_chess.Left / 60 + 1].Text == "")
			{
				if (chosen_chess.ForeColor == Color.Red && Top >= 0 && Top <= 240)
				{
					return 1;
				}
				else if (chosen_chess.ForeColor == Color.Black && Top >= 300 && Top <= 540)
				{
					return 1;
				}
			}
			return 0;
		}

		/* compare the valid path of chariots(車) */
		private int chariots_valid_path_comparison(int Left, int Top)
		{
			/* 橫衝 */
			if (Top == chosen_chess.Top)
			{
				/* 左衝 */
				if (Left < chosen_chess.Left)
				{
					for (int i = Left / 60 + 1; i < chosen_chess.Left / 60; i++)
					{
						/* 如果目的地路途中碰到障礙物移動無效 */
						if (click_map[Top / 60, i].Text != "")
						{
							return 0;
						}
					}
				}

				/* 右衝 */
				if (Left > chosen_chess.Left)
				{
					for (int i = chosen_chess.Left / 60 + 1; i < Left / 60; i++)
					{
						/* 如果目的地路途中碰到障礙物移動無效 */
						if (click_map[Top / 60, i].Text != "")
						{
							return 0;
						}
					}
				}
				return 1;
			}
			/* 直撞 */
			else if (Left == chosen_chess.Left)
			{
				/* 上撞 */
				if (Top < chosen_chess.Top)
				{
					for (int i = Top / 60 + 1; i < chosen_chess.Top / 60; i++)
					{
						/* 如果目的地路途中碰到障礙物移動無效 */
						if (click_map[i, Left / 60].Text != "")
						{
							return 0;
						}
					}
				}

				/* 下撞 */
				if (Top > chosen_chess.Top)
				{
					for (int i = chosen_chess.Top / 60 + 1; i < Top / 60; i++)
					{
						/* 如果目的地路途中碰到障礙物移動無效 */
						if (click_map[i, Left / 60].Text != "")
						{
							return 0;
						}
					}
				}
				return 1;
			}
			return 0;
		}

		/* compare the valid path of horses(馬) */
		private int horses_valid_path_comparison(int Left, int Top)
		{
			/* click_map[chosen_chess.Top / 60, chosen_chess.Left / 60] = ""表示判斷是否拐馬腳 */
			if ((Top == chosen_chess.Top - 120 && Left == chosen_chess.Left - 60 && click_map[chosen_chess.Top / 60 - 1, chosen_chess.Left / 60].Text == "") ||
			    (Top == chosen_chess.Top - 60 && Left == chosen_chess.Left - 120 && click_map[chosen_chess.Top / 60, chosen_chess.Left / 60 - 1].Text == "") ||
			    (Top == chosen_chess.Top + 60 && Left == chosen_chess.Left - 120 && click_map[chosen_chess.Top / 60, chosen_chess.Left / 60 - 1].Text == "") ||
			    (Top == chosen_chess.Top + 120 && Left == chosen_chess.Left - 60) && click_map[chosen_chess.Top / 60 + 1, chosen_chess.Left / 60].Text == "" ||
			    (Top == chosen_chess.Top + 120 && Left == chosen_chess.Left + 60 && click_map[chosen_chess.Top / 60 + 1, chosen_chess.Left / 60].Text == "") ||
			    (Top == chosen_chess.Top + 60 && Left == chosen_chess.Left + 120 && click_map[chosen_chess.Top / 60, chosen_chess.Left / 60 + 1].Text == "") ||
			    (Top == chosen_chess.Top - 60 && Left == chosen_chess.Left + 120 && click_map[chosen_chess.Top / 60, chosen_chess.Left / 60 + 1].Text == "") ||
			    (Top == chosen_chess.Top - 120 && Left == chosen_chess.Left + 60) && click_map[chosen_chess.Top / 60 - 1, chosen_chess.Left / 60].Text == "")
			{
				return 1;
			}
			return 0;
		}

		/* compare the valid path of cannons(炮) */
		private int cannons_valid_path_comparison(int Left, int Top)
		{
			/* move as the chariots */
			if (chariots_valid_path_comparison(Left, Top) == 1)
			{
				return 1;
			}

			/* if not move, maybe eat(destination has chess) */
			else if (click_map[Top / 60, Left / 60].Text != "")
			{
				/* through the mountain */
				if (through_the_mountain(Left, Top) == 1)
				{
					return 1;
				}
			}

			/* above both not */
			return 0;
		}

		/* compare the valid path of soldiers(兵) */
			private int soldiers_valid_path_comparison(int Left, int Top)
		{
			if (Left >= 0 && Left <= 480)
			{
				if (chosen_chess.ForeColor == Color.Red && Top >= 180 && Top <= 540)
				{
					if (Top == chosen_chess.Top + 60 && Left == chosen_chess.Left)
					{
						return 1;
					}
					else if (Top >= 300 && Top <= 540 &&
					   (Left == chosen_chess.Left - 60 && Top == chosen_chess.Top ||
						Left == chosen_chess.Left + 60 && Top == chosen_chess.Top))
					{
						return 1;
					}
				}
				else if (chosen_chess.ForeColor == Color.Black && Top >= 0 && Top <= 360)
				{
					if (Top == chosen_chess.Top - 60 && Left == chosen_chess.Left)
					{
						return 1;
					}
					else if (Top >= 0 && Top <= 240 &&
					   (Left == chosen_chess.Left - 60 && Top == chosen_chess.Top ||
						Left == chosen_chess.Left + 60 && Top == chosen_chess.Top))
					{
						return 1;
					}
				}
			}
			return 0;
		}

		/* 判斷炮是否飛山成功 */
		private int through_the_mountain(int Left, int Top)
		{
			int mountain_count = 0;
			/* 橫飛 */
			if (Top == chosen_chess.Top)
			{
				/* 左飛 */
				if (Left < chosen_chess.Left)
				{
					for (int i = Left / 60 + 1; i < chosen_chess.Left / 60; i++)
					{
						/* 計算目的地路途中碰到的障礙物數量 */
						if (click_map[Top / 60, i].Text != "")
						{
							mountain_count++;
						}
					}
				}

				/* 右飛 */
				if (Left > chosen_chess.Left)
				{
					for (int i = chosen_chess.Left / 60 + 1; i < Left / 60; i++)
					{
						/* 計算目的地路途中碰到的障礙物數量 */
						if (click_map[Top / 60, i].Text != "")
						{
							mountain_count++;
						}
					}
				}
				return 1;
			}
			/* 直飛 */
			else if (Left == chosen_chess.Left)
			{
				/* 上飛 */
				if (Top < chosen_chess.Top)
				{
					for (int i = Top / 60 + 1; i < chosen_chess.Top / 60; i++)
					{
						/* 計算目的地路途中碰到的障礙物數量 */
						if (click_map[i, Left / 60].Text != "")
						{
							mountain_count++;
						}
					}
				}

				/* 下飛 */
				if (Top > chosen_chess.Top)
				{
					for (int i = chosen_chess.Top / 60 + 1; i < Top / 60; i++)
					{
						/* 計算目的地路途中碰到的障礙物數量 */
						if (click_map[i, Left / 60].Text != "")
						{
							mountain_count++;
						}
					}
				}
				if (mountain_count == 1)
				{
					return 1;
				}
				else
				{
					return 0;
				}
			}
			return 0;
		}

		/* find the valid path */
		private int whether_valid_path(int Left, int Top)
		{
			/* 如果選擇的是將軍，而且移動的範圍是有效範圍(9格內) */
			if ((chosen_chess.Text == "帥" || chosen_chess.Text == "將") && 
				general_valid_path_comparison(Left, Top) == 1)
			{
				return 1;
			}

			/* 如果選擇的是士，而且移動的範圍是有效範圍(斜線) */
			if ((chosen_chess.Text == "仕" || chosen_chess.Text == "士") &&
				mandarins_valid_path_comparison(Left, Top) == 1)
			{
				return 1;
			}

			/* 如果選擇的是相，而且移動的範圍是有效範圍(田字且不遮相眼) */
			if ((chosen_chess.Text == "相" || chosen_chess.Text == "象") && 
				bishops_valid_path_comparison(Left, Top) == 1)
			{
				return 1;
			}

			/* 如果選擇的是車，而且移動的範圍是有效範圍(直或橫) */
			if (chosen_chess.Text == "車" && chariots_valid_path_comparison(Left, Top) == 1)
			{
				return 1;
			}

			/* 如果選擇的是馬，而且移動的範圍是有效範圍(日字且不拐馬腳) */
			if (chosen_chess.Text == "馬" && horses_valid_path_comparison(Left, Top) == 1)
			{
				return 1;
			}

			/* 如果選擇的是炮，而且移動的範圍是有效範圍(移動同車，吃棋飛山) */
			if ((chosen_chess.Text == "炮" || chosen_chess.Text == "包") && 
				cannons_valid_path_comparison(Left, Top) == 1)
			{
				return 1;
			}

			/* 如果選擇的是兵，而且移動的範圍是有效範圍(往前，過河後可以左右) */
			if ((chosen_chess.Text == "兵" || chosen_chess.Text == "卒") && 
				soldiers_valid_path_comparison(Left, Top) == 1)
			{
				return 1;
			}

			return 0;	
		}

		/* red attack forst */
		private bool is_red = true;

		/* if had chosen the chess */
		private bool chosen = false;


		/****** The part of computer controlling ******/

		/* 紀錄當下預測的最高分數, index[0]=score, [1]=Top, [2]=Left */
		private int[] best_path = new int[3];

		/* 電腦控制(預測2回合) */
		private void computer_control()
		{
			temp_store();
			predict_conditions();
			original_map();
			go_to_the_desitnation(best_path[1] / 60, best_path[2] / 60);
		}

		/* 暫存目前的棋盤盤面 */
		private void temp_store()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					switch (click_map[i, j].Text)
					{
						case "帥":
							current[i, j] = 1;
							break;
						case "將":
							current[i, j] = 8;
							break;
						case "士":
							if (click_map[i, j].ForeColor == Color.Red)
							{
								current[i, j] = 2;
							}
							else
							{
								current[i, j] = 9;
							}
							break;
						case "相":
							current[i, j] = 3;
							break;
						case "象":
							current[i, j] = 10;
							break;
						case "車":
							if (click_map[i, j].ForeColor == Color.Red)
							{
								current[i, j] = 4;
							}
							else
							{
								current[i, j] = 11;
							}
							break;
						case "馬":
							if (click_map[i, j].ForeColor == Color.Red)
							{
								current[i, j] = 5;
							}
							else
							{
								current[i, j] = 12;
							}
							break;
						case "炮":
							current[i, j] = 6;
							break;
						case "包":
							current[i, j] = 13;
							break;
						case "兵":
							current[i, j] = 7;
							break;
						case "卒":
							current[i, j] = 14;
							break;
					}
				}
			}
		}

		/* 暫存目前的棋盤盤面 */
		private int[,] current = new int[10, 9];

		/* 歸還原本的棋盤盤面 */
		private void original_map()
		{
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					click_map[i, j].Size = new Size(40, 40);
					switch (current[i, j])
					{
						case 1:
							click_map[i, j].Text = "帥";
							click_map[i, j].ForeColor = Color.Red;
							break;
						case 2:
							click_map[i, j].Text = "士";
							click_map[i, j].ForeColor = Color.Red;
							break;
						case 3:
							click_map[i, j].Text = "相";
							click_map[i, j].ForeColor = Color.Red;
							break;
						case 4:
							click_map[i, j].Text = "車";
							click_map[i, j].ForeColor = Color.Red;
							break;
						case 5:
							click_map[i, j].Text = "馬";
							click_map[i, j].ForeColor = Color.Red;
							break;
						case 6:
							click_map[i, j].Text = "炮";
							click_map[i, j].ForeColor = Color.Red;
							break;
						case 7:
							click_map[i, j].Text = "兵";
							click_map[i, j].ForeColor = Color.Red;
							break;
						case 8:
							click_map[i, j].Text = "將";
							click_map[i, j].ForeColor = Color.Black;
							break;
						case 9:
							click_map[i, j].Text = "士";
							click_map[i, j].ForeColor = Color.Black;
							break;
						case 10:
							click_map[i, j].Text = "象";
							click_map[i, j].ForeColor = Color.Black;
							break;
						case 11:
							click_map[i, j].Text = "車";
							click_map[i, j].ForeColor = Color.Black;
							break;
						case 12:
							click_map[i, j].Text = "馬";
							click_map[i, j].ForeColor = Color.Black;
							break;
						case 13:
							click_map[i, j].Text = "包";
							click_map[i, j].ForeColor = Color.Black;
							break;
						case 14:
							click_map[i, j].Text = "卒";
							click_map[i, j].ForeColor = Color.Black;
							break;
						default:
							click_map[i, j].Text = "";
							click_map[i, j].BackColor = Color.Transparent;
							click_map[i, j].Size = new Size(60, 60);
							break;
					}
				}
			}
		}

		/* 預測幾手 */
		private int predict_count = 4;

		/* 預測走向 */
		private void predict_conditions()
		{
			int highest_score = 0;

			/* 電腦為紅方，先從紅方開始預測走向 */
			this_round(Color.Red, ref highest_score);
			return;
		}


		/* 判斷當下自己移動可能的情況 */
		private void this_round(Color color, ref int highest_score)
		{
			predict_count--;
			/* 最外層for: 掃視地圖看紅色旗子(電腦可以動的)在哪 */
			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					/* 如果選中將軍，判斷將軍的動法是否合理 */
					//	if (color == Color.Red && click_map[i, j].Text == "帥")
					//	{
					//		highest_score += general_condition(i, j, color);

					/* 預測玩家走向 */
					//		this_round(Color.Black, ref highest_score);
					//	}
					//	else if (color == Color.Black && click_map[i, j].Text == "將")
					//	{
					//		general_condition(i, j, color);

					/* 預測下一回合的電腦走向 */
					//		this_round(Color.Red, ref highest_score);
					//	}

					/* 如果選中將士，判斷士的動法是否合理 */
					//	if (click_map[i, j].Text == "士")
					//	{
					//		if (color == Color.Red)
					//		{
					//			mandarins_condition(i, j, color);

					/* 預測玩家走向 */
					//			this_round(Color.Black, ref highest_score);
					//		}
					//		else if (color == Color.Black)
					//		{
					//			mandarins_condition(i, j, color);

					/* 預測下一回合的電腦走向 */
					//			this_round(Color.Red, ref highest_score);
					//		}	
					//	}

					//	if (highest_score > best_path[0])
					//	{
					//		best_path[0] = highest_score;
					//		best_path[1] = i;
					//		best_path[2] = j;
					//	}

					if (click_map[i, j].ForeColor == Color.Red)
					{
						for (int a = 0; a < 10; a++)
						{
							for (int b = 0; b < 9; b++)
							{
								if (click_map[a, b].ForeColor != Color.Red && whether_valid_path(a * 60, b * 60) == 1)
								{
									highest_score += get_score(a, b);
									for (int m = 0; m < 10; m++)
									{
										for (int n = 0; n < 9; n++)
										{
											if (click_map[i, j].ForeColor == Color.Black)
											{
												for (int c = 0; c < 10; c++)
												{
													for (int d = 0; d < 9; d++)
													{
														if (click_map[a, b].ForeColor != Color.Black && whether_valid_path(a * 60, b * 60) == 1)
														{
															highest_score -= get_score(c, d);
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					if (highest_score > best_path[0])
					{
						best_path[0] = highest_score;
						best_path[1] = i;
						best_path[2] = j;
					}
				}
			}
		}


		/* 判斷移動將軍的步伐是否為全部情況的最高分(i, j代表電腦選到棋子的位置) */
		private int general_condition(int i, int j, Color color)
		{
			/* 判斷將軍可能移動的4個方位 */
			int[] x = new int[4] { -1, 1, 0, 0 };
			int[] y = new int[4] { 0, 0, -1, 1 };
			for (int k = 0; k < 4; k++)
			{
				/* 先判斷步伐是否會吃到自己 */
				if (click_map[i + x[k], j + y[k]].ForeColor != color)
				{
					/* 再判斷步伐是否合理 */
					if (general_valid_path_comparison((i + x[k]) * 60, (j + y[k]) * 60) == 1)
					{
						return get_score(i + x[k], j + y[k]);
					}
				}
			}
			return 0;
		}

		private int mandarins_condition(int i, int j, Color color)
		{
			/* 判斷士可能移動的4個方位 */
			int[] x = new int[4] { -1, -1, 1, 1 };
			int[] y = new int[4] { -1, 1, -1, 1 };
			for (int k = 0; k < 4; k++)
			{
				/* 先判斷步伐是否會吃到自己 */
				if (click_map[i + x[k], j + y[k]].ForeColor != color)
				{
					/* 再判斷步伐是否合理 */
					if (mandarins_valid_path_comparison((i + x[k]) * 60, (j + y[k]) * 60) == 1)
					{
						/*int temp = computer_score(i + x[k], j + y[k]) - player_score_simulation(i + x[k], j + y[k]);
						if (temp > best_path[0]) // best_path[0]紀錄分數
						{
							 紀錄目前得分最高的分數以及那一步的Top跟Left 
							best_path[0] = temp;
							best_path[1] = (i + x[k]) * 60;
							best_path[2] = (j + y[k]) * 60;
						}*/
						return get_score(i + x[k], j + y[k]);
					}
				}
			}
			return 0;
		}

		/* 計算所走步伐的分數 */
		private int get_score(int destination_i, int destination_j)
		{
			/* click_map[i, j].Text 表示吃到的棋子 */
			switch (click_map[destination_i, destination_j].Text)
			{
				case "將":
				case "帥":
					return 1000;
				case "車":
					return 400;
				case "包":
				case "炮":
					return 350;
				case "馬":
					return 300;
				case "兵":
				case "卒":
					return 150;
				case "象":
				case "相":
					return 80;
				case "士":
					return 75;
				default:
					return 0;
			}
		}
	}
}
