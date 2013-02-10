/*
 * Task 7: Write a method that reverses the digits of given decimal number.
 * Example: 256 -> 652 
 *
 */

using System;
using System.Diagnostics;
using System.Numerics;

namespace StringReversion
{
	internal class Program
	{
		private static void Main()
		{
			Debug.Assert(Reverse(123) == 321, "Basic logic problem");
			Debug.Assert(Reverse(-123) == -321, "Basic logic problem");
			Reverse(decimal.MaxValue); //Test case for type overflow
		}

		private static BigInteger Reverse(decimal number)
		{
			if (Math.Abs(number) < 10)
			{
				return (BigInteger) number;
			}

			bool isPositive = number >= 0;
			if (!isPositive)
			{
				number = Math.Abs(number);
			}

			char[] array = number.ToString().ToCharArray();
			Array.Reverse(array);
			BigInteger result = BigInteger.Parse(new string(array));

			if (!isPositive)
			{
				result *= -1;
			}

			return result;
		}
	}
}