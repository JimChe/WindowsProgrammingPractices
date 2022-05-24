using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f74084088_practice3_2
{
	class Program
	{
		private static void swap(ref int count, ref int size)
		{
			int tmp = count;
			count = size;
			size = tmp;
		}
		private static void permute(int []ring, int count, int size)
		{
			int sum = 0;
			if (count == size)
			{
				for(int i=1; i<size; i++)
				{
					if ( (ring[i]) + (ring[i+1]) == 2 || (ring[i]) + (ring[i + 1]) == 3 || (ring[i]) + (ring[i + 1]) == 5 || (ring[i]) + (ring[i + 1]) == 7 || (ring[i]) + (ring[i + 1]) == 11 || (ring[i]) + (ring[i + 1]) == 13 || (ring[i]) + (ring[i + 1]) == 17 || (ring[i]) + (ring[i + 1]) == 19 || (ring[i]) + (ring[i + 1]) == 23 || (ring[i]) + (ring[i + 1]) == 29 || (ring[i]) + (ring[i + 1]) == 31)
					{
						sum++;
					}
					if( ring[1]+ring[size]==2|| ring[1] + ring[size] == 3 || ring[1] + ring[size] == 5 || ring[1] + ring[size] == 7 || ring[1] + ring[size] == 11 || ring[1] + ring[size] == 13 || ring[1] + ring[size] == 17 || ring[1] + ring[size] == 19 || ring[1] + ring[size] == 23 || ring[1] + ring[size] == 29 || ring[1] + ring[size] == 31)
					{
						sum++;
					}
				}
				if( sum == (2*size-2) && ring[1]==1)
				{
					for (int i = 1; i <= size; i++)
					{
						Console.Write(ring[i]);
						Console.Write(' ');
					}
					Console.Write("\n");
				}
				sum = 0;
			}
			else
			{
				for (int i = count; i <= size; i++)
				{
					swap(ref ring[i], ref ring[count]);
					permute(ring, count + 1, size);
					swap(ref ring[i], ref ring[count]);
				}

			}
		}

		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());
			int[] ring = new int[size+2];
			int count=1;
			if (size < 2)
			{
				Console.Write("Too small!");
			}
			if (size > 16)
			{
				Console.Write("Too big!");
			}
			for(int i=1; i<=size; i++) // if input 3, a[1]=1, a[2]=2, a[3]=3...
			{
				ring[i] = i;
			}
			if (size>=2 && size<=16)
			{
				permute(ring, count, size);
			}
			Console.ReadKey();
		}
	}
}
