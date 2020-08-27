using System;
using System.Collections.Generic;

namespace CycleListTest
{
	class Program
	{
		static void Main(string[] args)
		{
			var cycleList = new CycleList<int>();
			cycleList.GetNext();
			//var cycleList = new CycleList<int>() { 0, 1, 2, 3, 4 };
			for (int i = 0; i < 15; i++)
			{
				Console.Write(cycleList[i] + " ");
			}
			Console.WriteLine();
			cycleList.Reset();
			for (int i = 0; i < 15; i++)
			{
				Console.Write(cycleList.GetNext() + " ");
			}
		}
	}
}
