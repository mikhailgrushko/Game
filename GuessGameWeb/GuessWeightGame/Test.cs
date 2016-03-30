using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuessWeightGame
{
	[Synchronization]
	public class Test
	{
		public void Calculate()
		{
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(new Random().Next(5));
				Console.Write(" {0},", i);
			}
			Console.WriteLine();
		}
	}
	/*public class Test
	{
		/*
		public void Calculate()
		{
			for (int i = 0; i < 10; i++)
			{
				Thread.Sleep(new Random().Next(5));
				Console.Write(" {0},", i);
			}
			Console.WriteLine();
		}*/
	/*// sync
	public object tLock = new object();
		public int Num;
		public void Calculate()
		{
			lock (tLock)
			{
				Console.Write(" {0} is Executing", Thread.CurrentThread.Name);

				Num += 1;
				Console.Write(" {0},", Num);
				Console.WriteLine();
			}
		}
	}*/
}
