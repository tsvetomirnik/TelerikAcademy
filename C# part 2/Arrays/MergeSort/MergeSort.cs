/*
 * Task 13: Write a program that sorts an array of integers using the merge sort algorithm.
 */

using System;

namespace MergeSort
{
	internal class MergeSort
	{
		private static void Main()
		{
			var numbers = new[] {4, 2, 3, 1, 6, 4, 3, 9, 7, 5};
			Sort(ref numbers, 0, numbers.Length - 1);

			Console.WriteLine("Sorted: ");
			foreach (int number in numbers)
			{
				Console.Write(number + " ");
			}

			Console.WriteLine();
		}

		private static void Sort(ref int[] numbers, int startIndex, int endIndex)
		{
			if (startIndex >= endIndex)
			{
				return;
			}

			int middle = (startIndex + endIndex)/2;
			int leftPointer = startIndex;
			int rightPointer = middle + 1;
			int tempPointer = startIndex;

			Sort(ref numbers, leftPointer, middle);
			Sort(ref numbers, rightPointer, endIndex);

			var tempArray = new int[numbers.Length];
			while (leftPointer <= middle && rightPointer <= endIndex)
			{
				if (numbers[leftPointer] < numbers[rightPointer])
				{
					tempArray[tempPointer++] = numbers[leftPointer++];
				}
				else
				{
					tempArray[tempPointer++] = numbers[rightPointer++];
				}
			}

			while (rightPointer <= endIndex)
			{
				tempArray[tempPointer++] = numbers[rightPointer++];
			}

			while (leftPointer <= middle)
			{
				tempArray[tempPointer++] = numbers[leftPointer++];
			}

			for (int i = startIndex; i <= endIndex; i++)
			{
				numbers[i] = tempArray[i];
			}
		}
	}
}