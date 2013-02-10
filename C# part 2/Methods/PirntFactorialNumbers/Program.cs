/* Task 10: Write a program to calculate n! for each n in the range [1..100].
 * Hint: Implement first a method that multiplies a number represented as array
 * of digits by given integer number.
 * 
 */

using System;
using System.Text;

namespace PirntFactorialNumbers
{
	internal class Program
	{
		private static void Main()
		{
			byte[] factorial = {1};
			for (int i = 1; i <= 100; i++)
			{
				factorial = Multiply(factorial, i);
				Console.WriteLine("{0}! = {1}", i, ByteToString(factorial));
				Array.Reverse(factorial);
			}

			byte[] a = Sum(new byte[] {2, 4}, new byte[] {2, 4});
			byte[] b = Sum(a, new byte[] {4, 8});
			Console.WriteLine(b);
		}

		private static string ByteToString(byte[] array)
		{
			Array.Reverse(array);
			var result = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				result.Append(array[i]);
			}

			return result.ToString();
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

		private static byte[] Multiply(byte[] x, int y)
		{
			byte[] result = {0};
			for (int i = 0; i < y; i++)
			{
				result = Sum(result, x);
			}

			return result;
		}
	}
}