/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 4: Write an expression that checks for given integer 
 * if its third digit (right-to-left) is 7 e.g. 1732 -> true.
 * 
 */

using System;
using System.Globalization;

namespace IsThirdDigit7
{
	class IsThirdDigit7
	{
		static void Main()
		{
			const int value = 1732;
			const string messageFormat = "The 3rd digit from {0} is {1}.";
			Console.WriteLine(messageFormat, value, GetDigit(value, 2));
		}

		public static int GetDigit(int number, int position)
		{
			if(position < 0 || position > number.ToString(CultureInfo.InvariantCulture).Length)
			{
				throw new ArgumentOutOfRangeException("position");
			}

			var tail = number % Math.Pow(10, position + 1);
			return (int) (tail / Math.Pow(10, position));
		}
	}
}
