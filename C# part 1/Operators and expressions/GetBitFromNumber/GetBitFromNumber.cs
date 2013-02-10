/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 11: Write an expression that extracts from a given integer i the value of
 * a given bit number b. Example: i=5; b=2 -> value=1.
 * 
 */

using System;

namespace GetBitFromNumber
{
	class GetBitFromNumber
	{
		static void Main()
		{
			Console.WriteLine(CheckForOneBit(1, 0));
			Console.WriteLine(CheckForOneBit(1, 1));
			Console.WriteLine(CheckForOneBit(5, 2));
		}

		public static byte CheckForOneBit(int number, int position)
		{
			if(GetBiteBinaryNumber(number).Length < position || position < 0)
			{
				throw new ArgumentOutOfRangeException("position");
			}

			int mask = 1 << position;
			int result = number & mask;
			result = result >> position;
			
			Console.WriteLine("number  : " + GetBiteBinaryNumber(number) + " at position " + position);
			Console.WriteLine("mask    : " + GetBiteBinaryNumber(mask));
			Console.WriteLine("result  : " + GetBiteBinaryNumber(result));
			Console.WriteLine("inverted: " + GetBiteBinaryNumber(~result));

			return (byte)result;
		}

		public static string GetBiteBinaryNumber(int number)
		{
			return Convert.ToString(number, 2).PadLeft(32, '0');
		}
	}
}