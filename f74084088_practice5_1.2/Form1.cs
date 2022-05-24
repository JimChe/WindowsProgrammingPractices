using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f74084088_practice5_1._2
{
	public partial class Form1 : Form
	{
		int wrong_count = 0;
		public Form1()
		{
			InitializeComponent();
		}
		private void Form1_Load(object sender, EventArgs e) // 回到初始狀態
		{
			int[] rndnum = new int[10];
			Random Rnd = new Random(); //加入Random，產生的數字不會重覆
			label1.Text = Rnd.Next(0, 10000).ToString("D4"); // 隨機產生四位數驗證碼
			// 將驗證碼欄位清空
			label2.Text = "";
			label3.Text = "";
			label4.Text = "";
			label5.Text = "";
			button2.Text = "1";
			button3.Text = "2";
			button4.Text = "3";
			button5.Text = "4";
			button6.Text = "5";
			button7.Text = "6";
			button8.Text = "7";
			button9.Text = "8";
			button10.Text = "9";
			button11.Text = "0";

			// 鍵盤數字
			/*
			for (int i=0; i<10; i++)
			{
				rndnum[i] = i;
			}
			int n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result2 = rndnum[n];
			button2.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result3 = rndnum[n];
			button3.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result4 = rndnum[n];
			button4.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result5 = rndnum[n];
			button5.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result6 = rndnum[n];
			button6.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result7 = rndnum[n];
			button7.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result8 = rndnum[n];
			button8.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result9 = rndnum[n];
			button9.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result10 = rndnum[n];
			button10.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			n = Rnd.Next(0, 10);
			while (rndnum[n] == 99)
			{
				n = Rnd.Next(0, 10);
			}
			int result11 = rndnum[n];
			button11.Text = Convert.ToString(rndnum[n]);
			rndnum[n] = 99; // 表示已經被選
			*/
		}
		private void btn1_Click(object sender, EventArgs e)
		{
			Form1_Load(sender, e);
		}

		private void btn2_Click(object sender, EventArgs e)
		{
			if (label2.Text == "")
			{
				label2.Text = "1";
			}
			else if (label2.Text != "")
			{
				if (label3.Text == "")
				{
					label3.Text = "1";
				}
				else if (label3.Text != "")
				{
					if (label4.Text == "")
					{
						label4.Text = "1";
					}
					else if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "1";
							if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count >= 3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}
					}
				}
			}
		}

		private void btn3_Click(object sender, EventArgs e)
		{
			if (label2.Text != "")
			{
				if (label3.Text != "")
				{
					if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "2";
							if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count >= 3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}	
					}
					else if (label4.Text == "")
					{
						label4.Text = "2";
					}
				}
				else if (label3.Text == "")
				{
					label3.Text = "2";
				}
			}
			else if (label2.Text == "")
			{
				label2.Text = "2";
			}
		}

		private void btn4_Click(object sender, EventArgs e)
		{
			if (label2.Text != "")
			{
				if (label3.Text != "")
				{
					if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "3";
							if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count >= 3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}	
					}
					else if (label4.Text == "")
					{
						label4.Text = "3";
					}
				}
				else if (label3.Text == "")
				{
					label3.Text = "3";
				}
			}
			else if (label2.Text == "")
			{
				label2.Text = "3";
			}
		}

		private void btn5_Click(object sender, EventArgs e)
		{
			if (label2.Text != "")
			{
				if (label3.Text != "")
				{
					if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "4";						
							if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count >= 3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}
					}
					else if (label4.Text == "")
					{
						label4.Text = "4";
					}
				}
				else if (label3.Text == "")
				{
					label3.Text = "4";
				}
			}
			else if (label2.Text == "")
			{
				label2.Text = "4";
			}
		}

		private void btn6_Click(object sender, EventArgs e)
		{
			if (label2.Text != "")
			{
				if (label3.Text != "")
				{
					if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "5";
							if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count >= 3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}
					}
					else if (label4.Text == "")
					{
						label4.Text = "5";
					}
				}
				else if (label3.Text == "")
				{
					label3.Text = "5";
				}
			}
			else if (label2.Text == "")
			{
				label2.Text = "5";
			}
		}

		private void btn7_Click(object sender, EventArgs e)
		{
			if (label2.Text != "")
			{
				if (label3.Text != "")
				{
					if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "6";
					        if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count >= 3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}	
					}
					else if (label4.Text == "")
					{
						label4.Text = "6";
					}
				}
				else if (label3.Text == "")
				{
					label3.Text = "6";
				}
			}
			else if (label2.Text == "")
			{
				label2.Text = "6";
			}
		}

		private void btn8_Click(object sender, EventArgs e)
		{
			if (label2.Text != "")
			{
				if (label3.Text != "")
				{
					if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "7";
							if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count >= 3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}
						
					}
					else if (label4.Text == "")
					{
						label4.Text = "7";
					}
				}
				else if (label3.Text == "")
				{
					label3.Text = "7";
				}
			}
			else if (label2.Text == "")
			{
				label2.Text = "7";
			}
		}

		private void btn9_Click(object sender, EventArgs e)
		{
			if (label2.Text != "")
			{
				if (label3.Text != "")
				{
					if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "8";
							if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count >= 3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}
					}
					else if (label4.Text == "")
					{
						label4.Text = "8";
					}
				}
				else if (label3.Text == "")
				{
					label3.Text = "8";
				}
			}
			else if (label2.Text == "")
			{
				label2.Text = "8";
			}
		}

		private void btn10_Click(object sender, EventArgs e)
		{
			if (label2.Text != "")
			{
				if (label3.Text != "")
				{
					if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "9";
							if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count >= 3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}
						
					}
					else if (label4.Text == "")
					{
						label4.Text = "9";
					}
				}
				else if (label3.Text == "")
				{
					label3.Text = "9";
				}
			}
			else if (label2.Text == "")
			{
				label2.Text = "9";
			}
		}

		private void btn11_Click(object sender, EventArgs e)
		{
			if (label2.Text != "")
			{
				if (label3.Text != "")
				{
					if (label4.Text != "")
					{
						if (label5.Text == "")
						{
							label5.Text = "0";
							if (int.Parse(label2.Text) * 1000 + int.Parse(label3.Text) * 100 + int.Parse(label4.Text) * 10 + int.Parse(label5.Text) == int.Parse(label1.Text))
							{
								MessageBox.Show("驗證碼正確");
								Application.Exit();
							}
							wrong_count++;
							MessageBox.Show(string.Format("驗證碼錯誤{0}次", wrong_count));
							if (wrong_count>=3)
							{
								Application.Exit();
							}
							Form1_Load(sender, e);
						}	
					}
					else if (label4.Text == "")
					{
						label4.Text = "0";
					}
				}
				else if (label3.Text == "")
				{
					label3.Text = "0";
				}	
			}
			else if (label2.Text == "")
			{
				label2.Text = "0";
			}	
		}
	}
}
