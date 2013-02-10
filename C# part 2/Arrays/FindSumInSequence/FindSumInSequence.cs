/*
 * Task 10: Write a program that finds in given array of integers a sequence 
 * of given sum S (if present). 
 */

using System;

namespace FindSumInSequence
{
	internal class FindSumInSequence
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

			Console.Write("Insert sum: ");
			int sumToFind = GetIntegerFromConsole();

			int currentSum = 0;
			for (int elementsInSequence = 1; elementsInSequence <= arraySize; elementsInSequence++)
			{
				int availableSequencesCount = arraySize - elementsInSequence + 1;
				for (int startIndexOfSequence = 0; startIndexOfSequence < availableSequencesCount; startIndexOfSequence++)
				{
					for (int j = startIndexOfSequence; j < startIndexOfSequence + elementsInSequence; j++)
					{
						currentSum += numbers[j];
					}

					if (currentSum == sumToFind)
					{
						Console.Write("The number {0} is a result of the sequence elements: ", sumToFind);
						PrintResultSequence(numbers, startIndexOfSequence, elementsInSequence);
						break;
					}

					currentSum = 0;
				}
			}
		}

		private static void PrintResultSequence(int[] array, int startedIndex, int sequenceCount)
		{
			for (int i = startedIndex; i < startedIndex + sequenceCount; i++)
			{
				Console.Write(array[i] + " ");
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