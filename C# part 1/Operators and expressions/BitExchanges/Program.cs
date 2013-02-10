/*
 * Author: Tsvetomir Nikolov
 * 
 * Task 13: Write a program that exchanges bits 3, 4 and 5
 * with bits 24, 25 and 26 of given 32-bit unsigned integer.
 * 
 */

using System;

namespace BitExchanges
{
	class Program
	{
		static void Main()
		{
			uint number = 4177461305;
			Console.WriteLine(GetBiteBinaryNumber(number));
			ExchangeBits(number);

		}

		public static uint ExchangeBits(uint number)
		{
			//for bits 3,4,5
			uint firstMask = number >> 3;
			firstMask = firstMask << 29;
			firstMask = firstMask >> 29;
			Console.WriteLine(GetBiteBinaryNumber(firstMask));

			//for bits 24,25,26
			uint secondMask = number >> 24;
			secondMask = secondMask << 29;
			secondMask = secondMask  >> 29;
			Console.WriteLine(GetBiteBinaryNumber(secondMask));

			//uint mask = 5 << 3;
			uint newMask = uint.MaxValue | (firstMask << 21);
			number = number | newMask;
			Console.WriteLine(GetBiteBinaryNumber(number));

			return 0;

			//if(GetBiteBinaryNumber(number).Length < position || position < 0)
			//{
			//	throw new ArgumentOutOfRangeException("position");
			//}

			//int mask = ~(1 << position);
			//int result = number | mask;
			//result = result >> position;

			//Console.WriteLine("number  : " + GetBiteBinaryNumber(number) + " at position " + position);
			//Console.WriteLine("mask    : " + GetBiteBinaryNumber(mask));
			//Console.WriteLine("result  : " + GetBiteBinaryNumber(result));
			//Console.WriteLine("inverted: " + GetBiteBinaryNumber(~result));

			//return ~result == 0;
		}

		public static string GetBiteBinaryNumber(uint number)
		{
			return Convert.ToString(number, 2).PadLeft(32, '0');
		}
	}
}
