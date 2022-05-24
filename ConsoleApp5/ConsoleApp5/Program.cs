using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
	class Program
	{
		static void Main(string[] args)
		{
			permute("", "123");
		}

		static void permute(string result, string now)
		{
			if(now == "")
			{
				Console.Write(result);
			}
			else
			{
				for(int i=0; i<now.Length; i++)
				{
					permute(result + now[i], now.Substring(0, i) + now.Substring(i + 1));
				}
			}
		}
	}
}
