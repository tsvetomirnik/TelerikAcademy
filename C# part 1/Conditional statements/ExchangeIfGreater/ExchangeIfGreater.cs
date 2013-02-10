/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 1: Write an if statement that examines two integer variables
 * and exchanges their values if the first one is greater than the second one.
 * 
 */

using System;

namespace ExchangeIfGreater
{
	class ExchangeIfGreater
	{
		static void Main()
		{
			int a = 30;
			int b = 20;

			Console.WriteLine("Before A={0} B={1}", a, b);
			ExchangeIfFirstIsBigger(ref a, ref b);
			Console.WriteLine("After A={0} B={1}", a, b);

			Console.WriteLine();
			
			a = 10;
			b = 12;
			Console.WriteLine("Before A={0} B={1}", a, b);
			ExchangeIfFirstIsBigger(ref a, ref b);
			Console.WriteLine("After A={0} B={1}", a, b);
		}

		private static void ExchangeIfFirstIsBigger(ref int a, ref int b)
		{
			if (a > b)
			{
				Exchange(ref a, ref b);
			}
		}

		private static void Exchange(ref int a, ref int b)
		{
			a = a + b;
			b = a - b;
			a = a - b;
		}
	}
}
