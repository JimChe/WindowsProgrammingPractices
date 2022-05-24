using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9
{
	public partial class Form1 : Form
	{
		Button[] walls = new Button[50];
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			pictureBox2.Visible = false;
			this.BackColor = Color.LightSkyBlue;
			for (int i = 0; i < 50; i++)
			{
				this.Controls.Remove(walls[i]);
			}
			button1.Visible = true;
			button1.Enabled = true;
			button2.Visible = false;
			button2.Enabled = false;
			button3.Visible = false;
			button3.Enabled = false;
			pictureBox1.Visible = false;
		}
		private void set_level1()
		{
			button1.Visible = false;
			button1.Enabled = false;
			for (int i = 0; i < 50; i++)
			{
				walls[i] = new Button();
			}
			walls[0].SetBounds(-5, -5, 100, 370);
			walls[0].BackColor = Color.Black;
			Controls.Add(walls[0]);
			walls[0].Text = 0.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[0].MouseEnter += new EventHandler(walls_touch);
			walls[1].SetBounds(90, -5, 203, 160);
			walls[1].BackColor = Color.Black;
			Controls.Add(walls[1]);
			walls[1].Text = 1.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[1].MouseEnter += new EventHandler(walls_touch);
			walls[2].SetBounds(90, 221, 203, 180);
			walls[2].BackColor = Color.Black;
			Controls.Add(walls[2]);
			walls[2].Text = 2.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[2].MouseEnter += new EventHandler(walls_touch);
			walls[3].SetBounds(290, -5, 223, 192);
			walls[3].BackColor = Color.Black;
			Controls.Add(walls[3]);
			walls[3].Text = 3.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[3].MouseEnter += new EventHandler(walls_touch);
			walls[4].SetBounds(290, 201, 223, 200);
			walls[4].BackColor = Color.Black;
			Controls.Add(walls[4]);
			walls[4].Text = 4.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[4].MouseEnter += new EventHandler(walls_touch);
			walls[5].SetBounds(510, -5, 100, 370);
			walls[5].BackColor = Color.Black;
			Controls.Add(walls[5]);
			walls[5].Text = 5.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[5].MouseEnter += new EventHandler(walls_touch);
			walls[6].SetBounds(499, 192, 12, 12);
			walls[6].BackColor = Color.Red;
			Controls.Add(walls[6]);
			walls[6].Text = 6.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[6].MouseEnter += new EventHandler(destination1_touch);

		}

		private void walls_touch(object sender, EventArgs e)
		{
			for (int i = 0; i < 20; i++)
			{
				if (i.ToString() == (sender as Button).Text)
				{
					//MessageBox.Show("Lose");
					//Form1_Load(sender, e);
				}
			}
		}

		private void destination1_touch(object sender, EventArgs e)
		{
			set_level2();
		}

		private void set_level2()
		{
			for (int i = 0; i < 50; i++)
			{
				walls[i].Dispose();
			}
			button1.Visible = false;
			button1.Enabled = false;
			for (int i = 0; i < 50; i++)
			{
				walls[i] = new Button();
			}
			walls[0].SetBounds(-5, -5, 25, 370);
			walls[0].BackColor = Color.Black;
			Controls.Add(walls[0]);
			walls[0].Text = 0.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[0].MouseEnter += new EventHandler(walls_touch);
			walls[1].SetBounds(18, 300, 7, 80);
			walls[1].BackColor = Color.Black;
			Controls.Add(walls[1]);
			walls[1].Text = 1.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[1].MouseEnter += new EventHandler(walls_touch);
			walls[2].SetBounds(18, -5, 92, 248);
			walls[2].BackColor = Color.Black;
			Controls.Add(walls[2]);
			walls[2].Text = 2.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[2].MouseEnter += new EventHandler(walls_touch);
			walls[3].SetBounds(24, 247, 75, 200);
			walls[3].BackColor = Color.Black;
			Controls.Add(walls[3]);
			walls[3].Text = 3.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[3].MouseEnter += new EventHandler(walls_touch);
			walls[4].SetBounds(108, -5, 30, 320);
			walls[4].BackColor = Color.Black;
			Controls.Add(walls[4]);
			walls[4].Text = 4.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[4].MouseEnter += new EventHandler(walls_touch);
			walls[5].SetBounds(93, 322, 58, 40);
			walls[5].BackColor = Color.Black;
			Controls.Add(walls[5]);
			walls[5].Text = 5.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[5].MouseEnter += new EventHandler(walls_touch);
			walls[6].SetBounds(135, -5, 118, 50);
			walls[6].BackColor = Color.Black;
			Controls.Add(walls[6]);
			walls[6].Text = 6.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[6].MouseEnter += new EventHandler(walls_touch);
			walls[7].SetBounds(148, 55, 95, 370);
			walls[7].BackColor = Color.Black;
			Controls.Add(walls[7]);
			walls[7].Text = 7.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[7].MouseEnter += new EventHandler(walls_touch);
			walls[8].SetBounds(250, -5, 265, 195);
			walls[8].BackColor = Color.Black;
			Controls.Add(walls[8]);
			walls[8].Text = 8.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[8].MouseEnter += new EventHandler(walls_touch);
			walls[9].SetBounds(235, 203, 278, 260);
			walls[9].BackColor = Color.Black;
			Controls.Add(walls[9]);
			walls[9].Text = 9.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[9].MouseEnter += new EventHandler(walls_touch);
			walls[10].SetBounds(510, -5, 100, 370);
			walls[10].BackColor = Color.Black;
			Controls.Add(walls[10]);
			walls[10].Text = 10.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[10].MouseEnter += new EventHandler(walls_touch);
			walls[11].SetBounds(15, 280, 15, 15);
			walls[11].BackColor = Color.Red;
			Controls.Add(walls[11]);
			walls[12].SetBounds(24, 245, 10, 10);
			walls[12].BackColor = Color.Red;
			Controls.Add(walls[12]);
			walls[12].Text = 12.ToString(); // 判斷code所生成的button是否有滑鼠移動進來
			walls[12].MouseEnter += new EventHandler(surprise);
		}

		private void surprise(object sender, EventArgs e)
		{
			for (int i = 0; i < 20; i++)
			{
				walls[i].Dispose();
			}
			pictureBox1.Visible = true;
			timer1.Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			set_level1();
		}		

		private void button2_Click(object sender, EventArgs e)
		{
			Form1_Load(sender, e);
			timer1.Stop();
			time_count = 0;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			System.Environment.Exit(0);
		}

		private int time_count = 0;
		private void timer1_Tick(object sender, EventArgs e)
		{
			if (time_count == 30)
			{
				button2.Visible = true;
				button2.Enabled = true;
				button3.Visible = true;
				button3.Enabled = true;
			}
			time_count++;
		}
	}
}
