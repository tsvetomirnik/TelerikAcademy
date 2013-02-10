/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 7: Write a program that finds the greatest of given 5 variables.
 * 
 */

using System;

namespace BiggestFromFiveNumbers
{
	class BiggeстFromFiveNumbers
	{
		static void Main()
		{
			int a = 5;
			int b = 25;
			int c = 12;
			int d = 36;
			int f = 1;

			int biggest = GetMax(a, GetMax(b, GetMax(c, GetMax(d, f))));
			Console.WriteLine("Biggest number is {0}.", biggest);
		}

		private static int GetMax(int a, int b)
		{
			if (a > b)
			{
				return a;	
			}
			
			return b;
		}
	}
}
