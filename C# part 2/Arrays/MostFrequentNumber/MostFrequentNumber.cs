/*
 * Task 9: Write a program that finds the most frequent number in an array
 */

using System;

namespace MostFrequentNumber
{
	internal class MostFrequentNumber
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

			//Sort them
			SortArray(ref numbers);

			//Get first number from longest sequnce of equal elements
			int mostResentNumberIndex = GetLongestSequenceOfEqualElementFirstIndex(numbers);

			if (mostResentNumberIndex > 0)
			{
				Console.WriteLine("Most frequent number is {0}.", numbers[mostResentNumberIndex]);
			}
			else
			{
				Console.WriteLine("Every number is contained only once.");
			}
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

		private static void SortArray(ref int[] numbers)
		{
			for (int i = 0; i < numbers.Length; i++)
			{
				int maxNumberIndex = i;
				int maxNumber = numbers[maxNumberIndex];
				for (int j = i; j < numbers.Length; j++)
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
		}

		private static int GetLongestSequenceOfEqualElementFirstIndex(int[] numbers)
		{
			int longestSequenceEndIndex = 0;
			int longestSequenceSize = 0;
			int currentSequnceSize = 1;
			for (int i = 0; i < numbers.Length - 1; i++)
			{
				if (numbers[i] == numbers[i + 1])
				{
					currentSequnceSize++;

					if (longestSequenceSize < currentSequnceSize)
					{
						longestSequenceSize = currentSequnceSize;
						longestSequenceEndIndex = i + 1;
					}
				}
				else
				{
					currentSequnceSize = 1;
				}
			}

			if (longestSequenceSize < 2)
			{
				return -1;
			}

			return longestSequenceEndIndex - (longestSequenceSize - 1);
		}
	}
}