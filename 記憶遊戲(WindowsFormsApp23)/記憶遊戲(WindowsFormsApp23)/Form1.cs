using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 記憶遊戲_WindowsFormsApp23_
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		PictureBox[] cards = new PictureBox[36]; // 宣告picturebox陣列(當記憶卡牌)
		//PictureBox[] cards2 = new PictureBox[72]; // 宣告picturebox陣列(當記憶卡牌)
		private void Form1_Load(object sender, EventArgs e)
		{
			button1.Visible = true; // 開始鍵
			label1.Visible = false;
			button2.Visible = button3.Visible = button4.Visible = false; //隱藏下一關 重新開始 結束遊戲
		}

		private void upload_pic(int i)
		{
			switch (i % 9)
			{
				case 0:
					cards[i].Image = Image.FromFile(@"iu\iu.jpg");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 1:
					cards[i].Image = Image.FromFile(@"iu\iu1.jpg");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 2:
					cards[i].Image = Image.FromFile(@"iu\iu2.png");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 3:
					cards[i].Image = Image.FromFile(@"iu\iu3.jpg");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 4:
					cards[i].Image = Image.FromFile(@"iu\iu4.jpg");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 5:
					cards[i].Image = Image.FromFile(@"iu\iu5.jpg");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 6:
					cards[i].Image = Image.FromFile(@"iu\iu6.jpg");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 7:
					cards[i].Image = Image.FromFile(@"iu\iu7.jpg");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 8:
					cards[i].Image = Image.FromFile(@"iu\iu8.jpg");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 9:
					cards[i].Image = Image.FromFile(@"iu\iu9.jpg");
					cards[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
			}
		}

		private int find_count = 0;
		private int[] find_record = new int[36]; // 紀錄所找過的牌
		private int level = 1;
		private int wrong_count = 0;
		private void choose_card(object sender, EventArgs e)
		{
			for (int i=0; i<18; i++) 
			{
				if (cards[i + 18].Image == (sender as PictureBox).Image)
				{
					cards[i + 18].Visible = false;
					find_record[find_count] = i;
					if (find_count % 2 == 1) // 如果找第偶數次表示應該要有一組牌
					{
						if (i < 9 && find_record[find_count - 1] != i + 9)
						{
							wrong_count++;
							for (int k = 0; k < 18; k++)
							{
								cards[k + 18].Visible = true;
								if (level == 2 && wrong_count == 3)
								{
									wrong_count = 0;
									rermd_cards();
								}
								find_count = -1;
							}
						}
						else if (i >= 9 && find_record[find_count - 1] != i - 9)
						{
							wrong_count++;
							for (int k = 0; k < 18; k++)
							{
								cards[k + 18].Visible = true;
								if (level == 2 && wrong_count == 3)
								{
									wrong_count = 0;
									rermd_cards();
								}
								find_count = -1;
							}
						}
					}
					find_count++;
				}
			}
			if (find_count == 18) // 全部的牌都翻完
			{
				timer_close_card2.Stop();
				MessageBox.Show("Win " + "Level" + level.ToString() + "\r\n" + "spent: " + (300 - timer_count).ToString() + "seconds");
				button2.Visible = true;
				find_count = 0;
				level++;
				wrong_count = 0;
				timer_count = 300 - level * 60;
				timer_close_card.Interval = 5000 - level * 1000;
			}
		}

		Random rmd = new Random(Guid.NewGuid().GetHashCode());
		private int[] rmd_card = new int[18];
		private void set_rmd_card() // 隨機洗牌
		{
			for (int i=0; i<18; i++)
			{
				int pos = rmd.Next(0, 18);
				if (rmd_card[pos] == 0)
				{
					rmd_card[pos] = i;
				}
				else if (rmd_card[pos] != 0)
				{
					i--;
				}
			}
		}

		private void set_level1() // 第一關(20張牌 2張一組共10組)
		{
			for (int i = 0; i < 18; i++) // 先加入的picturebox會放在檯面上(可以用visible == false蓋掉)
			{
				cards[rmd_card[i] + 18] = new PictureBox();
				cards[rmd_card[i] + 18].SetBounds(25 + 120 * (i % 6), 25 + 140 * (i / 6), 100, 120);
				cards[rmd_card[i] + 18].Image = Image.FromFile(@"iu\card.jpg");
				cards[rmd_card[i] + 18].SizeMode = PictureBoxSizeMode.StretchImage;
				Controls.Add(cards[rmd_card[i] + 18]);
				cards[rmd_card[i] + 18].Visible = false;
				cards[rmd_card[i] + 18].Click += new EventHandler(choose_card);
			}
			for (int i=0; i<18; i++) // 卡牌內容為0~17號 覆蓋用牌為18~35號 
			{
				cards[rmd_card[i]] = new PictureBox();
				cards[rmd_card[i]].SetBounds(25 + 120 * (i % 6), 25 + 140 * (i / 6), 100, 120);
			}
			for (int i = 0; i < 18; i++)
			{
				upload_pic(rmd_card[i]);
				Controls.Add(cards[rmd_card[i]]);
				cards[rmd_card[i]].Click += new EventHandler(choose_card);
			}
		}
		private void button1_Click(object sender, EventArgs e) // 當按下開始鍵時啟動第一關
		{
			label1.Visible = true;
			label1.Text = "記好囉!!!";
			button1.Visible = false; // 隱藏開始遊戲鍵
			set_rmd_card(); //隨機洗牌
			set_level1(); // 設定第一關
			timer_close_card.Start();
		}

	    private void rermd_cards()
		{
			for (int i = 0; i < 36; i++)
			{
				if (i < 18)
				{
					rmd_card[i] = 0;
				}
				cards[i].Visible = cards[i].Enabled = false;
				cards[i].Dispose();
			}
			set_rmd_card();
			set_level1(); // 設定第一關
			for (int i = 0; i < 18; i++)
			{
				cards[rmd_card[i] + 18].Visible = false;
			}
			timer_close_card.Start();
		}

		private void button2_Click(object sender, EventArgs e) // 當按下下一關鍵時啟動第二關
		{
			label1.Text = "記好囉!!!";
			button2.Visible = false; // 隱藏開始遊戲鍵
			rermd_cards();
		}
		private void button4_Click(object sender, EventArgs e) // 結束遊戲
		{
			System.Environment.Exit(0);
		}
		private void timer_close_card_Tick(object sender, EventArgs e) // 開場後3秒蓋牌
		{
			for (int i=0; i<18; i++)
			{
				cards[rmd_card[i] + 18].Visible = true;
			}
			timer_close_card2.Start();
			timer_close_card.Stop();
		}
		private int timer_count = 300;
		private void timer_close_card2_Tick(object sender, EventArgs e) // 開場後5秒蓋牌
		{
			label1.Text = "時間剩下: " + timer_count.ToString() + "秒";
			timer_count--;
			if (timer_count == 0)
			{
				timer_close_card2.Stop();
				MessageBox.Show("時間到!!");
			}
		}


		/*private void upload_pic2(int i)
		{
			switch (i)
			{
				case 0:
					cards2[i].Image = Image.FromFile(@"gentleman\seaer1u.jpg");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 1:
					cards2[i].Image = Image.FromFile(@"gentleman\wowu.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 2:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh1u.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 3:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh2u.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 4:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh3u.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 5:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh4u.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 6:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh5u.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 7:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh6u.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 8:
					cards2[i].Image = Image.FromFile(@"gentleman\seaer2u.jpg");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 9:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh8u.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 10:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh9u.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 11:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh10u.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 12:
					cards2[i].Image = Image.FromFile(@"gentleman\seaer1m.jpg");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 13:
					cards2[i].Image = Image.FromFile(@"gentleman\wowm.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 14:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh1m.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 15:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh2m.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 16:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh3m.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 17:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh4m.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 18:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh5m.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 19:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh6m.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 20:
					cards2[i].Image = Image.FromFile(@"gentleman\seaer2m.jpg");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 21:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh8m.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 22:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh9m.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 23:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh10m.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 24:
					cards2[i].Image = Image.FromFile(@"gentleman\seaer1d.jpg");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 25:
					cards2[i].Image = Image.FromFile(@"gentleman\wowd.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 26:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh1d.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 27:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh2d.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 28:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh3d.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 29:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh4d.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 30:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh5d.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 31:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh6d.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 32:
					cards2[i].Image = Image.FromFile(@"gentleman\seaer2d.jpg");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 33:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh8d.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 34:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh9d.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
				case 35:
					cards2[i].Image = Image.FromFile(@"gentleman\yueh10d.png");
					cards2[i].SizeMode = PictureBoxSizeMode.StretchImage;
					break;
			}
		}

		private int find_count2 = 0;
		private int[] find_record2 = new int[36]; // 紀錄所找過的牌
		private void choose_card2(object sender, EventArgs e)
		{
			for (int i = 0; i < 36; i++)
			{
				if (cards2[i + 36].Image == (sender as PictureBox).Image)
				{
					
					cards2[i + 36].Visible = false;
					find_record2[find_count2] = i;
					if (find_count2 % 3 == 2) // 如果找第3次倍數表示應該要有一組牌
					{
						if (i < 12 && (find_record2[find_count2 - 1] != i + 12 || find_record2[find_count2 - 2] != i + 24))
						{
							for (int k = 0; k < 36; k++)
							{
								cards2[k + 36].Visible = true;
								find_count2 = -1;
							}
						}
						else if (i >= 12 && i < 24 && (find_record2[find_count2 - 1] != i - 12 || find_record2[find_count2 - 2] != i + 12))
						{
							for (int k = 0; k < 36; k++)
							{
								cards2[k + 36].Visible = true;
								find_count2 = -1;
							}
						}
						else if (i >= 24 && i < 36 && (find_record2[find_count2 - 1] != i - 12 || find_record2[find_count2 - 2] != i - 24))
						{
							for (int k = 0; k < 36; k++)
							{
								cards2[k + 36].Visible = true;
								find_count2 = -1;
							}
						}
						else if (i < 12 && (find_record2[find_count2 - 1] != i + 24 || find_record2[find_count2 - 2] != i + 12))
						{
							for (int k = 0; k < 36; k++)
							{
								cards2[k + 36].Visible = true;
								find_count2 = -1;
							}
						}
						else if (i >= 12 && i < 24 && (find_record2[find_count2 - 1] != i + 12 || find_record2[find_count2 - 2] != i - 12))
						{
							for (int k = 0; k < 36; k++)
							{
								cards2[k + 36].Visible = true;
								find_count2 = -1;
							}
						}
						else if (i >= 24 && i < 36 && (find_record2[find_count2 - 1] != i - 24 || find_record2[find_count2 - 2] != i - 12))
						{
							for (int k = 0; k < 36; k++)
							{
								cards2[k + 36].Visible = true;
								find_count2 = -1;
							}
						}
					}
					find_count2++;
				}
			}
			if (find_count2 == 36) // 全部的牌都翻完
			{
				MessageBox.Show("Win level2");
				button3.Visible = button4.Visible = true;
				find_count2 = 0;
			}
		}
		private int[] rmd_card2 = new int[36];
		private void set_rmd_card2() // 隨機洗牌
		{
			for (int i = 0; i < 36; i++)
			{
				int pos = rmd.Next(0, 36);
				if (rmd_card2[pos] == 0)
				{
					rmd_card2[pos] = i;
				}
				else if (rmd_card2[pos] != 0)
				{
					i--;
				}
			}
		}
		private void set_level2()
		{
			this.Size = new Size(1500, 900);
			for (int i = 0; i < 36; i++) // 先加入的picturebox會放在檯面上(可以用visible == false蓋掉)
			{
				cards2[rmd_card2[i] + 36] = new PictureBox();
				cards2[rmd_card2[i] + 36].SetBounds(25 + 120 * (rmd_card2[i] % 9), 25 + 140 * (rmd_card2[i] / 9), 100, 120);
				cards2[rmd_card2[i] + 36].Image = Image.FromFile(@"iu\card.jpg");
				cards2[rmd_card2[i] + 36].SizeMode = PictureBoxSizeMode.StretchImage;
				Controls.Add(cards2[rmd_card2[i] + 36]);
				cards2[rmd_card2[i] + 36].Visible = false;
				cards2[rmd_card2[i] + 36].Click += new EventHandler(choose_card2);
			}
			for (int i = 0; i < 36; i++) // 卡牌內容為0~17號 覆蓋用牌為18~35號 
			{
				cards2[rmd_card2[i]] = new PictureBox();
				cards2[rmd_card2[i]].SetBounds(25 + 120 * (rmd_card2[i] % 9), 25 + 140 * (rmd_card2[i] / 9), 100, 120);
			}
			for (int i = 0; i < 36; i++)
			{
				upload_pic2(rmd_card2[i]);
				Controls.Add(cards2[rmd_card2[i]]);
				cards[rmd_card2[i]].Click += new EventHandler(choose_card2);
			}
		}*/
		/*private void timer_close_card2_Tick(object sender, EventArgs e) // 開場後5秒蓋牌
        {
	    for (int i = 0; i < 36; i++)
	    {
		    cards2[rmd_card2[i] + 36].Visible = true;
	    }
	    timer_close_card2.Stop();
    }*/
	}
}
