using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fruity.Core;

namespace FruityCli
{
	class Program
	{
		static void Main(string[] args)
		{
			var fruitmachine = new FruitMachineViewModel(100);

			while (Console.ReadKey().Key == ConsoleKey.Enter)
			{
				fruitmachine.Spin();
				Console.WriteLine($"{fruitmachine.Reel1} | {fruitmachine.Reel2} | {fruitmachine.Reel3}");
			}			
		}
	}
}
