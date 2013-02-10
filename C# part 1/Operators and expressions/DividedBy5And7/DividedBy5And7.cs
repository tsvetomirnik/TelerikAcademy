/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 2: Write a boolean expression that checks for given integer
 * if it can be divided (without remainder) by 7 and 5 in the same time.
 * 
 */

using System;

namespace DividedBy5And7
{
	class DividedBy5And7
	{
		static void Main()
		{
			const string messageFormat = "{0} can be divide by 5 and 7 -> {1}";
			Console.WriteLine(messageFormat, 0, CanBeDividedBy5And7(0));
			Console.WriteLine(messageFormat, 5, CanBeDividedBy5And7(5));
			Console.WriteLine(messageFormat, 7, CanBeDividedBy5And7(7));
			Console.WriteLine(messageFormat, 35, CanBeDividedBy5And7(35));
		}

		public static bool CanBeDividedBy5And7(int number)
		{
			return number%5 == 0 && number%7 == 0;
		}
	}
}
