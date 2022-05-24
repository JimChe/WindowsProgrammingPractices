using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
	class Unit
	{
		public Unit()
		{
			Console.WriteLine("目前單位 : 村民 x , 民兵 x , 弓箭手 x , 斥侯 x \n");
		}
		public void Set_HP()
		{

		}
		public int Get_HP()
		{
			return HP;
		}
		public int Get_Attack()
		{
			return Attack;
		}
		public string Get_Type()
		{
			return Type;
		}

		protected int HP;
		protected string Type;
		protected int Attack;
	}
}
