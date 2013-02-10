/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 2: Write a program that shows the sign (+ or -) of the
 * product of three real numbers without calculating it. Use a
 * sequence of if statements.
 * 
 */

using System;

namespace SignOfProduct
{
	class SignOfProduct
	{
		static void Main()
		{
			double a = 10.6;
			double b = -10.1;
			double c = -2.3;
			bool isPositive = false;

			if(a >= 0 && b >= 0 && c >= 0)
			{
				isPositive = true;
			}

			if(a >= 0 && b < 0 && c < 0)
			{
				isPositive = true;
			}

			if(a < 0 && b >= 0 && c < 0)
			{
				isPositive = true;
			}

			if(a < 0 && b < 0 && c >= 0)
			{
				isPositive = true;
			}

			string sign = isPositive? "+" : "-";
			Console.WriteLine("The product of {0}, {1} and {2} is with {3x} sign.", a, b, c, sign);
		}
	}
}
