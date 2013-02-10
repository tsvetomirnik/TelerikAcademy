/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 3: Write a program that finds the biggest of 
 * three integers using nested if statements.
 * 
 */

using System;

namespace BiggestFromThree
{
	class BiggestFromThree
	{
		static void Main()
		{
			int a = 1;
			int b = 5;
			int c = 3;
			int biggest;

			if(a >= b && a >= c)
			{
				biggest = a;
			}
			else if(b >= a && b >= c)
			{
				biggest = b;
			}
			else
			{
				biggest = c;
			}

			Console.WriteLine("Biggest number is {0}.", biggest);
		}
	}
}
