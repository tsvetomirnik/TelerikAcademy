/*
 * Task 6: Write a program that reads two integer numbers N and K and 
 * an array of N elements from the console. Find in the array those K
 * elements that have maximal sum.
 */

using System;

namespace ElementsWithMaximalSum
{
	internal class ElementsWithMaximalSum
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

			int maxElementToFind;
			bool isValidInput;
			do
			{
				Console.Write("How many elements to sum to get the maximum sum: ");
				maxElementToFind = GetIntegerFromConsole();
				isValidInput = maxElementToFind <= arraySize;

				if (!isValidInput)
				{
					Console.WriteLine("This value must less than the array size.");
				}
			} while (!isValidInput);

			var maxNumbers = new int[maxElementToFind];

			for (int i = 0; i < maxElementToFind; i++)
			{
				int maxNumberIndex = 0;
				int maxNumber = numbers[maxNumberIndex];
				for (int j = 0; j < arraySize - i; j++)
				{
					if (maxNumber < numbers[j])
					{
						maxNumber = numbers[j];
						maxNumberIndex = j;
					}
				}

				maxNumbers[i] = maxNumber;

				//Send to the end of the array
				int indexToSendTo = numbers.Length - i - 1;
				numbers[maxNumberIndex] = numbers[indexToSendTo];
				numbers[indexToSendTo] = maxNumber;
			}

			Console.Write("Maximum with {0} numbers can be reached with numbers: ", maxElementToFind);
			foreach (int number in maxNumbers)
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