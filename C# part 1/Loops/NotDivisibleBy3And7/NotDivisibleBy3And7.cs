/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 2:	Write a program that prints all the numbers from 1 to N,
 *			that are not divisible by 3 and 7 at the same time.
 * 
 */

using System;

namespace NotDivisibleBy3And7
{
	class NotDivisibleBy3And7
	{
		static void Main(string[] args)
		{
			const int n = 100;
			PrintToN(n);
		}

		private static void PrintToN(int n)
		{
			for (int i = 1; i <= n; i++)
			{
				if (i % 3 != 0 || i % 7 != 0)
				{
					Console.WriteLine(i);
				}
			}
		}
	}
}
