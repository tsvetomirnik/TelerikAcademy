/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 1: Write an expression that checks if given integer is odd or even.
 * 
 */

using System;

namespace OddOrEven
{
	class OddOrEven
	{
		static void Main()
		{
			const string messageFormat = "{0} is {1}";
			const string odd = "odd";
			const string even = "even";

			int number = 2;
			Console.WriteLine(messageFormat, number, IsOdd(number)? odd : even);

			number = 3;
			Console.WriteLine(messageFormat, number, IsOdd(number)? odd : even);

			number = 9;
			Console.WriteLine(messageFormat, number, IsOdd(number)? odd : even);

			number = 24;
			Console.WriteLine(messageFormat, number, IsOdd(number)? odd : even);
			
		}

		public static bool IsOdd(int number)
		{
			return number%2 == 0;
		}
	}
}