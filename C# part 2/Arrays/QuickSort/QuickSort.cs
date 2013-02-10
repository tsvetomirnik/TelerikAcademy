/*
 * Task 14: Write a program that sorts an array of strings using the quick sort algorithm. 
 */

using System;

namespace QuickSort
{
	internal class QuickSort
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

		private static void Sort(ref int[] numbers, int leftIndex, int rightIndex)
		{
			if (leftIndex >= rightIndex)
			{
				return;
			}

			int midIndex = (leftIndex + rightIndex)/2;
			int pivot = numbers[midIndex];

			int i = leftIndex;
			int j = rightIndex;

			while (i <= j)
			{
				while (numbers[i] < pivot)
				{
					i++;
				}

				while (numbers[j] > pivot)
				{
					j--;
				}

				if (i <= j)
				{
					int temp = numbers[j];
					numbers[j] = numbers[i];
					numbers[i] = temp;

					i++;
					j--;
				}
			}

			Sort(ref numbers, leftIndex, j);
			Sort(ref numbers, i, rightIndex);
		}
	}
}