/*
 * Task 4: Write a program that finds the maximal sequence of equal elements in an array.
 * 
 */

using System;

namespace MaxSequenceOfEqualElements
{
	internal class MaxSequenceOfEqualElements
	{
		private static void Main()
		{
			Console.Write("Insert array size: ");
			int size = GetIntegerFromConsole();

			Console.WriteLine();

			Console.WriteLine("INSERT ELEMENTS: ");
			var numbers = new int[size];
			FillArrayFromConsole(ref numbers);
			PrintMaxEqualSequence(numbers);
		}

		private static void PrintMaxEqualSequence(int[] numbers)
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

			Console.Write("Longest sequence of equal elements is: ");
			int sequenceFirstElement = longestSequenceEndIndex - (longestSequenceSize - 1);
			for (int i = 0; i < longestSequenceSize; i++)
			{
				Console.Write(numbers[sequenceFirstElement + i] + " ");
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