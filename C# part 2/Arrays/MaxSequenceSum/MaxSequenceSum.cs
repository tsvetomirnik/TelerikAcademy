/*
 * Task 8: Write a program that finds the sequence of maximal sum in given array.
 */

using System;

namespace MaxSequenceSum
{
	internal class MaxSequenceSum
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

			int sequenceElementsCount;
			bool isValidInput;
			do
			{
				Console.Write("How many elements to sum to get the maximum sum: ");
				sequenceElementsCount = GetIntegerFromConsole();
				isValidInput = sequenceElementsCount <= arraySize;

				if (!isValidInput)
				{
					Console.WriteLine("This value must less than the array size.");
				}
			} while (!isValidInput);

			int maxSumSequenceEndIndex = 0;
			int maxSum = numbers[0];
			int currentSum = 0;
			for (int i = 0; i < arraySize; i++)
			{
				if (i%sequenceElementsCount == 0)
				{
					currentSum = 0;
				}

				currentSum += numbers[i];

				if (currentSum > maxSum)
				{
					maxSum = currentSum;
					maxSumSequenceEndIndex = i;
				}
			}

			Console.Write("Max sequence of {0} numbers having biggest sum are: ", sequenceElementsCount);
			for (int i = 0; i < sequenceElementsCount; i++)
			{
				int firstIndex = maxSumSequenceEndIndex - (sequenceElementsCount - 1);
				Console.Write("{0} ", numbers[i + firstIndex]);
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