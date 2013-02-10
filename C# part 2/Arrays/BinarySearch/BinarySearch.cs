/*
 * Task 11: Write a program that finds the index of given element in a
 * sorted array of integers by using the binary search algorithm 
 */

using System;

namespace BinarySearch
{
	internal class BinarySearch
	{
		private static void Main()
		{
			var numbers = new[] {1, 1, 2, 4, 5, 7, 7, 7, 9, 10, 12, 12, 18};

			Console.WriteLine("Array: ");
			foreach (int t in numbers)
			{
				Console.Write(t + " ");
			}

			Console.WriteLine();

			for (int i = numbers[0]; i <= numbers[numbers.Length - 1]; i++)
			{
				int index = GetIndex(numbers, i);
				if (index != -1)
				{
					Console.WriteLine("{0} is on index {1}", i, GetIndex(numbers, i));
				}
			}
		}

		private static int GetIndex(int[] numbers, int numberToFind)
		{
			int startedIndex = 0;
			int endIndex = numbers.Length - 1;
			while (startedIndex <= endIndex)
			{
				int middleIndex = (endIndex + startedIndex)/2;
				if (numberToFind == numbers[middleIndex])
				{
					return middleIndex;
				}
				if (numberToFind > numbers[middleIndex])
				{
					startedIndex = middleIndex + 1;
				}
				if (numberToFind < numbers[middleIndex])
				{
					endIndex = middleIndex - 1;
				}
			}

			return -1;
		}
	}
}