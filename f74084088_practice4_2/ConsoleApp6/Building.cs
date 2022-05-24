using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f74084088_practice4_2
{
	class Building
	{
		public Building()
		{
			Console.WriteLine("目前建築 : 城鎮中心 x , 兵營 x , 射箭場 x , 馬廄 x \n");
		}
		public void Set_HP()
		{

		}
		public int Get_HP()
		{
			return HP;
		}

		public string Get_Type()
		{
			return Type;
		}

		protected int HP;
		protected string Type;
	}
}
