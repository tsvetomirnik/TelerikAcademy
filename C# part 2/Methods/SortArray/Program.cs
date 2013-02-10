/*
 * Task 9: Write a method that return the maximal element in a portion of array of 
 * integers starting at given index. Using it write another method that sorts an 
 * array in ascending / descending order.
 */

using System;
using System.Collections.Generic;

namespace SortArray
{
	internal class Program
	{
		private static void Main()
		{
			var numbers = new[] {3, 3, 1, 2, 6, 4, 2, 1, 3, 4, 6, 4, 1, 2, 3, 1};

			Console.WriteLine("Ascending order: ");
			PrintArray(Sort(numbers));

			Console.WriteLine("Descending order: ");
			PrintArray(Sort(numbers, true));
		}

		private static int GetMax(int[] numbers, int startIndex)
		{
			if (numbers == null)
			{
				throw new NullReferenceException("numbers");
			}

			if (startIndex < 0 || startIndex >= numbers.Length)
			{
				throw new ArgumentOutOfRangeException("startIndex");
			}

			int maxNumber = numbers[startIndex];
			for (int i = startIndex + 1; i < numbers.Length; i++)
			{
				if (numbers[i] >= maxNumber)
				{
					maxNumber = numbers[i];
				}
			}

			return maxNumber;
		}

		private static int[] Sort(int[] numbers, bool descending = false)
		{
			if (numbers == null)
			{
				throw new NullReferenceException("numbers");
			}

			if (numbers.Length < 2)
			{
				return numbers;
			}

			var sorted = new int[numbers.Length];
			Array.Copy(numbers, sorted, numbers.Length);

			for (int i = 0; i < numbers.Length; i++)
			{
				int maxNumber = GetMax(sorted, i);
				int maxNumberIndex = Array.LastIndexOf(sorted, maxNumber);

				//Swap values
				sorted[maxNumberIndex] = sorted[i];
				sorted[i] = maxNumber;
			}

			if (descending)
			{
				Array.Reverse(sorted);
			}

			return sorted;
		}

		private static void PrintArray(IEnumerable<int> array)
		{
			foreach (int number in array)
			{
				Console.Write(number + " ");
			}

			Console.WriteLine();
		}
	}
}