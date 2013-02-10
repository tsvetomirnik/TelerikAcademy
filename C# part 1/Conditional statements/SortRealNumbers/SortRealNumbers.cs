/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 4: Sort 3 real values in descending order using nested if statements.
 * 
 */

using System;

namespace SortRealNumbers
{
	class SortRealNumbers
	{
		static void Main()
		{
			double a = 6.5;
			double b = 12.2;
			double c = -5.0;

			Console.WriteLine("Input: \r\n [{0}, {1}, {2}]", a, b, c);

			if(a < b)
			{
				Exchange(ref a, ref b);
			}

			if(a < c)
			{
				Exchange(ref a, ref c);
			}

			if(b < c)
			{
				Exchange(ref b, ref c);
			}

			Console.WriteLine();
			Console.WriteLine("Sorted: \r\n [{0}, {1}, {2}]", a, b, c);
		}

		private static void Exchange(ref double a, ref double b)
		{
			double tempA = a;
			a = b;
			b = tempA;
		}
	}
}
