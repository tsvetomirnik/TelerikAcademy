/* Task 14: Write methods to calculate minimum, maximum, average, sum and
 * product of given set of integer numbers. Use variable number of arguments.
 */

using System;

namespace SetOfIntegerNumbers
{
	internal class Program
	{
		private static void Main()
		{
			var numbers = new[] {4, 1, 6, 4};

			Console.WriteLine("Numbers: ");
			foreach (int number in numbers)
			{
				Console.Write("{0} ", number);
			}
			Console.WriteLine();

			Console.WriteLine("Max number is {0}.", GetMax(numbers[0], numbers[1], numbers[2], numbers[3]));
			Console.WriteLine("Min number is {0}.", GetMin(numbers[0], numbers[1], numbers[2], numbers[3]));
			Console.WriteLine("Sum is {0}.", GetSum(numbers[0], numbers[1], numbers[2], numbers[3]));
			Console.WriteLine("Average number is {0}.", GetAverage(numbers[0], numbers[1], numbers[2], numbers[3]));
			Console.WriteLine("Product is {0}.", GetProduct(numbers[0], numbers[1], numbers[2], numbers[3]));
		}

		private static int GetMax(params int[] numbers)
		{
			int maxNumber = numbers[0];
			foreach (int number in numbers)
			{
				maxNumber = Math.Max(number, maxNumber);
			}

			return maxNumber;
		}

		private static int GetMin(params int[] numbers)
		{
			int minNumber = numbers[0];
			foreach (int number in numbers)
			{
				minNumber = Math.Min(number, minNumber);
			}

			return minNumber;
		}

		private static int GetSum(params int[] numbers)
		{
			int sum = 0;
			foreach (int number in numbers)
			{
				sum += number;
			}

			return sum;
		}

		private static double GetAverage(params int[] numbers)
		{
			int sum = 0;
			foreach (int number in numbers)
			{
				sum += number;
			}

			return (double) sum/numbers.Length;
		}

		private static int GetProduct(params int[] numbers)
		{
			int product = 0;
			foreach (int number in numbers)
			{
				product *= number;
			}

			return product;
		}
	}
}