/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 8:	Write a program that calculates the greatest common divisor 
 *			of given two numbers. Use the Euclidean algorithm.
 * 
 */

using System;

namespace GCDofTwoNumbers
{
	class GCDofTwoNumbers
	{
		static void Main(string[] args)
		{
			const int a = 21;
			const int b = 6;
			int gcd = GCD(a, b);
			Console.WriteLine("GCD({0}, {1}) = {2}", a, b, gcd);
		}

		static int GCD(int a, int b)
		{
			int remainder;
			while(b != 0)
			{
				remainder = a % b;
				a = b;
				b = remainder;
			}
			
			return a;
		}
	}
}
