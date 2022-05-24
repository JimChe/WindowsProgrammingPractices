using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
	class Program
	{
		static void Main(string[] args)
		{
			int foods = 500, woods = 500, golds = 500;
			int instruction;
			// 判斷遊戲是否贏了
			bool isWin = false;
			// 宣告各種指令
			int round = 0, TC = 1, Barracks = 2, ArcheryRange = 3, Stable = 4, 
				Villager = 5, Militia = 6, Archer = 7, Scout = 8,
				skip = 9, units_status = 10, TC_status = 11, Feudal = 12, rich = 13;
			while (isWin==false)
			{
				instruction = int.Parse(Console.ReadLine()); // 讀入指令
				switch (instruction)
				{
					case 1:
						if (woods >= 200 && golds >= 100)
						{
							round++;
							//生成一個城鎮中心，加入陣列或是直接再造一個新物件
							woods -= 200;
							golds -= 100;
						}
						else if (woods<200||golds<100){
							Console.WriteLine("資源不足");
							round--;
						}
				        break;
					case 2:
						if (woods >= 100)
						{
							round++;
							//生成一個兵營，加入陣列或是直接再造一個新物件
							woods -= 100;
						}
						else if (woods < 100)
						{
							Console.WriteLine("資源不足");
							round--;
						}
						break;
					case 3:
						if (woods >= 150 && golds >= 50)
						{
							round++;
							//生成一個射箭場，加入陣列或是直接再造一個新物件
							woods -= 150;
							golds -= 50;
						}
						else if (woods < 150 || golds < 50)
						{
							Console.WriteLine("資源不足");
							round--;
						}
						break;
					case 4:
						if (woods >= 200)
						{
							round++;
							//生成一個兵營，加入陣列或是直接再造一個新物件
							woods -= 200;
						}
						else if (woods < 200)
						{
							Console.WriteLine("資源不足");
							round--;
						}
						break;
					case 5:
						if (foods >= 50)
						{
							round++;
							//生成一個村民，加入陣列或是直接再造一個新物件
							foods -= 50;
						}
						else if (foods < 50)
						{
							Console.WriteLine("資源不足");
							round--;
						}
						break;
					case 6: 
						if (foods >= 100 && golds >= 50)
						{
							round++;
							//生成一個民兵，加入陣列或是直接再造一個新物件
							foods -= 100;
							golds -= 50;
						}
						else if (foods < 100 || golds<50)
						{
							Console.WriteLine("資源不足");
							round--;
						}
						break;
					case 7:
						if (woods >= 75 && golds >= 25)
						{
							round++;
							//生成一個弓箭手，加入陣列或是直接再造一個新物件
							woods -= 75;
							golds -= 25;
						}
						else if (woods < 75 || golds < 25)
						{
							Console.WriteLine("資源不足");
							round--;
						}
						break;
					case 8:
						if (foods >= 80)
						{
							round++;
							//生成一個斥侯，加入陣列或是直接再造一個新物件
							foods -= 80;
						}
						else if (foods < 80)
						{
							Console.WriteLine("資源不足");
							round--;
						}
						break;
				}
			}
		}
	}
}
