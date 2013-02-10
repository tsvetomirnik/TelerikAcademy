/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 3: Write a program that safely compares floating-point numbers with 
 * precision of 0.000001. 
 * Examples:
 * (5.3 ; 6.01) -> false;  
 * (5.00000001 ; 5.00000003) -> true
 * 
 */

using System;

namespace FloatCompare
{
	class FloatCompare
	{
		static void Main()
		{
			Compare(5.3f, 6.1f);
			Compare(5.00000001f, 5.00000001f);
		}

		public static void Compare(float first, float second)
		{
			bool areEquals = Math.Abs(first - second) < 0.000001;
			Console.WriteLine("{0} and {1} are equals -> {2}", first, second, areEquals);
		}
	}
}
