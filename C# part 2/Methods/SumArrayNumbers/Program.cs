/*
 * Task 8: Write a method that adds two positive integer numbers represented as arrays of digits 
 * (each array element arr[i] contains a digit; the last digit is kept in arr[0]). Each of the 
 * numbers that will be added could have up to 10 000 digits.
 */

using System;

namespace SumArrayNumbers
{
	internal class Program
	{
		private static void Main()
		{
			PrintSum(
				new byte[] {2, 4},
				new byte[] {3, 5});

			PrintSum(
				new byte[] {9, 9, 9},
				new byte[] {1});

			PrintSum(
				new byte[] {9, 3, 5},
				new byte[] {4, 6, 8, 1, 2});
		}

		private static void PrintSum(byte[] number1, byte[] number2)
		{
			byte[] sum = Sum(number1, number2);

			Array.Reverse(sum);
			foreach (byte digit in sum)
			{
				Console.Write(digit);
			}

			Console.WriteLine();
		}

		private static byte[] Sum(byte[] number1, byte[] number2)
		{
			int maxRange = Math.Max(number1.Length, number2.Length);

			Array.Resize(ref number1, maxRange);
			Array.Resize(ref number2, maxRange);
			var sum = new byte[maxRange + 1];

			bool carry = false;
			for (int i = 0; i < maxRange; i++)
			{
				var currentSum = (byte) (number1[i] + number2[i]);

				if (carry)
				{
					currentSum += 1;
					carry = false;
				}

				if (currentSum > 9)
				{
					carry = true;
					sum[i] = (byte) (currentSum%10);
				}
				else
				{
					sum[i] = currentSum;
				}
			}

			//Add leading 1
			if (carry)
			{
				sum[maxRange] = 1;
			}

			//Remove leading zero
			if (!carry)
			{
				Array.Resize(ref sum, sum.Length - 1);
			}

			return sum;
		}
	}
}