/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 10: Write a boolean expression that returns if the bit at position p (counting from 0)
 * in a given integer number v has value of 1. Example: v=5; p=1 -> false
 * 
 */

using System;

namespace CheckForBitOneNumberBit
{
	class CheckForBitOneNumberBit
	{
		static void Main()
		{
			Console.WriteLine(CheckForOneBit(1, 0));
			Console.WriteLine(CheckForOneBit(1, 1));
			Console.WriteLine(CheckForOneBit(5, 2));
		}

		public static bool CheckForOneBit(int number, int position)
		{
			if(GetBiteBinaryNumber(number).Length < position || position < 0)
			{
				throw new ArgumentOutOfRangeException("position");
			}

			int mask = ~(1 << position);
			int result = number | mask;
			result = result >> position;

			Console.WriteLine("number  : " + GetBiteBinaryNumber(number) + " at position " + position);
			Console.WriteLine("mask    : " + GetBiteBinaryNumber(mask));
			Console.WriteLine("result  : " + GetBiteBinaryNumber(result));
			Console.WriteLine("inverted: " + GetBiteBinaryNumber(~result));

			return ~result == 0;
		}

		public static string GetBiteBinaryNumber(int number)
		{
			return Convert.ToString(number, 2).PadLeft(32, '0');
		}
	}
}
