using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f74084088_practice3_1
{
	class Program
	{
		private static int FindRiver(int[,] map, int row, int col, int i, int j, ref int num_rivers)
		{
			int count = 1;//數總共需要扣掉幾次重複的河
			map[i, j] = num_rivers;

			// go upper left
			if (map[i - 1, j - 1] == 35)
			{
				map[i - 1, j - 1] = num_rivers; // 目前河流都編為1號河，若遇到#就將其編為1號
			}

			// go up
			else if (map[i - 1, j] == 35)
			{
				map[i - 1, j] = num_rivers;
			}

			// go upper right
			else if (map[i - 1, j + 1] == 35)
			{
				map[i - 1, j + 1] = num_rivers;
			}

			// go left
			else if (map[i, j - 1] == 35)
			{
				map[i, j - 1] = num_rivers;
			}

			// go right
			else if (map[i, j + 1] == 35)
			{
				map[i, j + 1] = num_rivers;
			}

			// go lower left
			else if (map[i + 1, j - 1] == 35)
			{
				map[i + 1, j - 1] = num_rivers;
			}

			// go down
			else if (map[i + 1, j] == 35)
			{
				map[i + 1, j] = num_rivers;
			}

			// go lower right
			else if (map[i + 1, j + 1] == 35)
			{
				map[i + 1, j + 1] = num_rivers;
			}

			// 若周圍都是土地，則將河流編號+1(附近沒有河流，自己不會跟別人碰到)
			else if ( (map[i - 1, j - 1] == 42 || map[i - 1, j - 1] == 0) && (map[i - 1, j] == 42 || map[i - 1, j] == 0) && (map[i - 1, j + 1] == 42 || map[i - 1, j + 1] == 0) && (map[i, j - 1] == 42 || map[i, j - 1] == 0) && (map[i, j + 1] == 42 || map[i, j + 1] == 0) && (map[i + 1, j - 1] == 42 || map[i + 1, j - 1] == 0) && (map[i + 1, j] == 42 || map[i + 1, j] == 42) && (map[i + 1, j + 1] == 42 || map[i + 1, j + 1] == 0) )
			{
				num_rivers++;
			}

			// 檢查周邊有沒有#後，檢查是否有標示已走過的河流需要編號
			for(int k=201; k<=300; k++) // 若遇到N種河就扣N(重複)
			{
				if (map[i - 1, j - 1] == k)
				{
					for (int a = 1; a <= row; a++)
					{
						for(int b = 1; b <= col; b++)
						{
							if (map[a,b] == k && k != num_rivers)
							{
								map[a, b] = num_rivers;
							}
						}
					}
						count--;
						continue;
				}

				// go up
				else if (map[i - 1, j] == k)
				{

						for (int a = 1; a <= row; a++)
						{
							for (int b = 1; b <= col; b++)
							{
								if (map[a, b] == k && k != num_rivers)
								{
									map[a, b] = num_rivers;
								}
							}
						}
						count--;
						continue;
				}

				// go upper right
				else if (map[i - 1, j + 1] == k)
				{

						for (int a = 1; a <= row; a++)
						{
							for (int b = 1; b <= col; b++)
							{
								if (map[a, b] == k && k != num_rivers)
								{
									map[a, b] = num_rivers;
								}
							}
						}
						count--;
						continue;
				}

				// go left
				else if (map[i, j - 1] == k)
				{

					for (int a = 1; a <= row; a++)
					{
						for (int b = 1; b <= col; b++)
						{
							if (map[a, b] == k && k != num_rivers)
							{
								map[a, b] = num_rivers;
							}
						}
					}
					count--;
					continue;
				}
				// go right
				else if (map[i, j + 1] == k)
				{

					for (int a = 1; a <= row; a++)
					{
						for (int b = 1; b <= col; b++)
						{
							if (map[a, b] == k && k != num_rivers)
							{
								map[a, b] = num_rivers;
							}
						}
					}
					count--;
					continue;
				}
				// go lower left
				else if (map[i + 1, j - 1] == k)
				{

					for (int a = 1; a <= row; a++)
					{
						for (int b = 1; b <= col; b++)
						{
							if (map[a, b] == k && k != num_rivers)
							{
								map[a, b] = num_rivers;
							}
						}
					}
					count--;
					continue;
				}
				// go down
				else if (map[i + 1, j] == k)
				{
					for (int a = 1; a <= row; a++)
					{
						for (int b = 1; b <= col; b++)
						{
							if (map[a, b] == k && k != num_rivers)
							{
								map[a, b] = num_rivers;
							}
						}
					}
					count--;
					continue;
				}
				// go lower right
				else if (map[i + 1, j + 1] == k)
				{
					for (int a = 1; a <= row; a++)
					{
						for (int b = 1; b <= col; b++)
						{
							if (map[a, b] == k && k != num_rivers)
							{
								map[a, b] = num_rivers;
							}
						}
					}
					count--;
					continue;
				}
			}
			return count;
		}
		static void Main(string[] args)
		{
			int row, col, count = 0, num_rivers=201;
			row = int.Parse(Console.ReadLine());
			col = int.Parse(Console.ReadLine());
			int [,] map = new int[row+2, col+2];
			for (int i = 1; i <= row; i++)
			{
				string str = Console.ReadLine();
				for (int j = 0; j < col; j++)
				{
					map[i, j+1] = str[j];
				}
			}		
			for (int i = 1; i <= row; i++)
			{
				for (int j = 1; j <= col; j++)
				{
					if (map[i, j] == 35)
					{
						count += FindRiver(map, row, col, i, j, ref num_rivers);
					}
				}
			}
			if (count > 100)
			{
				Console.Write("Too many rivers!!!");
			}
			Console.Write(count);
			Console.ReadKey();
		}
	}
}
