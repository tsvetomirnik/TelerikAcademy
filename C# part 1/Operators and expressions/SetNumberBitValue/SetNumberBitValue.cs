/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 12: We are given integer number n, value v (v=0 or 1) and a position p.
 * Write a sequence of operators that modifies n to hold the value v at the 
 * position p from the binary representation of n.
 * 
 */

using System;

namespace SetNumberBitValue
{
	class SetNumberBitValue
	{
		static void Main()
		{
			CheckForOneBit(5, 2, 0);
			CheckForOneBit(5, 1, 1);
			CheckForOneBit(5, 0, 1);
			CheckForOneBit(5, 1, 0);
			CheckForOneBit(5, 0, 0);
			CheckForOneBit(5, 2, 0);
		}

		public static int CheckForOneBit(int number, byte position, byte bit)
		{
			if(GetBiteBinaryNumber(number).Length < position)
			{
				throw new ArgumentOutOfRangeException("position");
			}

			if(bit > 1)
			{
				throw new ArgumentOutOfRangeException("bit");
			}

			int mask;
			int result;
			if(bit == 0)
			{
				mask = ~(1 << position);
				result = number & mask;
			}
			else
			{
				mask = 1<<position;
				result = number | mask;
			}

			Console.WriteLine("set number: " + GetBiteBinaryNumber(number) + " at position " + position + " to " + bit);
			Console.WriteLine("mask      : " + GetBiteBinaryNumber(mask));
			Console.WriteLine("result    : " + GetBiteBinaryNumber(result));
			Console.WriteLine();

			return result;
		}

		public static string GetBiteBinaryNumber(int number)
		{
			return Convert.ToString(number, 2).PadLeft(32, '0');
		}
	}
}
