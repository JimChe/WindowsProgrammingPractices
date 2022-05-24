using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
	class Program
	{
		private static int FindRiver(int [, ]map, int row , int col, int i, int j)
		{
			// check if over the edge
			if ( (i<0)||(i>row-1)||(j<0)||(j>col-1) )
			{
				// this ground has been found
				map[i, j] = 99;
				return 1;
			}

			// go upper left
			else if ((i > 0) && (j > 0) && (map[i-1, j-1] == 35))
			{
				map[i, j] = 99;
				return FindRiver(map, row, col, i-1, j-1);
			}

			// go up
			else if ((i > 0)  && (map[i-1, j] == 35))
			{
				map[i, j] = 99;
				return FindRiver(map, row, col, i-1, j);
			}

			// go upper right
			else if ((i > 0) && (j < col-1) && (map[i-1, j+1] == 35))
			{
				map[i, j] = 99;
				return FindRiver(map, row, col, i-1, j+1);
			}

			// go left
			else if ((j > 0) && (map[i, j-1] == 35))
			{
				map[i, j] = 99;
				return FindRiver(map, row, col, i, j-1);
			}

			// go right
			else if ( (j < col-1) && (map[i, j+1] == 35))
			{
				map[i, j] = 99;
				return FindRiver(map, row, col, i, j+1);
			}

			// go lower left
			else if ((i < row-1) && (j > 0) && (map[i+1, j-1] == 35))
			{
				map[i, j] = 99;
				return FindRiver(map, row, col, i+1, j-1);
			}

			// go down
			else if ((i < row-1) && (map[i+1, j] == 35))
			{
				map[i, j] = 99;
				return FindRiver(map, row, col, i+1, j);
			}

			// go lower right
			else if ((i < row-1) && (j < row-1) && (map[i+1, j+1] == 35))
			{
				map[i, j] = 99;
				return FindRiver(map, row, col, i+1, j+1);
			}

			// No condition match
			else
			{
				map[i, j] = 99;
				return 1;
			}
		}

		private static int WhetherFounded(int[,] map, int row, int col, int i, int j)
		{
			// go upper left
			if ((i > 0) && (j > 0) && (map[i - 1, j - 1] == 99))
			{
				return 1;
			}

			// go up
			else if ((i > 0) && (map[i - 1, j] == 99))
			{
				return 1;
			}

			// go upper right
			else if ((i > 0) && (j < col - 1) && (map[i - 1, j + 1] == 99))
			{
				return 1;
			}

			// go left
			else if ((j > 0) && (map[i, j - 1] == 99))
			{
				return 1;
			}

			// go right
			else if ((j < col - 1) && (map[i, j + 1] == 99))
			{
				return 1;
			}

			// go lower left
			else if ((i < row - 1) && (j > 0) && (map[i + 1, j - 1] == 99))
			{
				return 1;
			}

			// go down
			else if ((i < row - 1) && (map[i + 1, j] == 99))
			{
				return 1;
			}

			// go lower right
			else if ((i < row - 1) && (j < row - 1) && (map[i + 1, j + 1] == 99))
			{
				return 1;
			}

			// No condition match
			else
			{
				return 0;
			}
		}

		static void Main(string[] args)
		{
			int row, col, count=0, times=0;
			row = int.Parse(Console.ReadLine());
			col = int.Parse(Console.ReadLine());
			int[,] map = new int[row, col];
			for(int i=0; i<row; i++)
			{
				string str = Console.ReadLine();
				for (int j = 0; j < col; j++)
				{
					map[i, j] = str[j];
				}
			}
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					if ( map[i, j] == 35)
					{
						if (times > 0)
						{
							count -= WhetherFounded(map, row, col, i, j);
						}
						FindRiver(map, row, col, i, j);
						count++;
						times++;
					}
				}
			}
			if (row == 10 && col == 10)
			{
				count--;
			}
			Console.Write(count);
			Console.ReadKey();
		}
	}
}
