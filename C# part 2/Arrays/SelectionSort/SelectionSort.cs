/*
 * Task 7: Sorting an array means to arrange its elements in increasing order.
 * Write a program to sort an array. Use the "selection sort" algorithm: Find 
 * the smallest element, move it at the first position, find the smallest from 
 * the rest, move it at the second position, etc.
 */

using System;

namespace SelectionSort
{
	internal class SelectionSort
	{
		private static void Main()
		{
			Console.Write("Insert array size: ");
			int arraySize = GetIntegerFromConsole();

			Console.WriteLine();

			Console.WriteLine("INSERT ELEMENTS: ");
			var numbers = new int[arraySize];
			FillArrayFromConsole(ref numbers);

			Console.WriteLine();

			for (int i = 0; i < arraySize; i++)
			{
				int maxNumberIndex = i;
				int maxNumber = numbers[maxNumberIndex];
				for (int j = i; j < arraySize; j++)
				{
					if (maxNumber < numbers[j])
					{
						maxNumber = numbers[j];
						maxNumberIndex = j;
					}
				}

				//Swap values
				numbers[maxNumberIndex] = numbers[i];
				numbers[i] = maxNumber;
			}

			Console.Write("Sorted array: ");
			foreach (int number in numbers)
			{
				Console.Write(number + " ");
			}

			Console.WriteLine();
		}

		private static void FillArrayFromConsole(ref int[] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				Console.Write("Insert #{0} element: ", i + 1);
				array[i] = GetIntegerFromConsole();
			}
		}

		private static int GetIntegerFromConsole()
		{
			bool isInputValid = false;
			int number;
			do
			{
				if (int.TryParse(Console.ReadLine(), out number))
				{
					isInputValid = true;
				}
				else
				{
					Console.WriteLine("Not valid number.");
				}
			} while (!isInputValid);

			return number;
		}
	}
}