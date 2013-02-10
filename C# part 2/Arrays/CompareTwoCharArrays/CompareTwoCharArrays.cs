/*
 * Task 3: Write a program that compares two char arrays lexicographically (letter by letter).
 * 
 */

using System;

namespace CompareTwoCharArrays
{
	internal class CompareTwoCharArrays
	{
		private static void Main()
		{
			Console.Write("Insert arrays size: ");
			int size = GetIntegerFromConsole();

			Console.WriteLine();

			Console.WriteLine("FIRST ARRAY: ");
			var firstArray = new char[size];
			FillCharsFromConsole(ref firstArray);

			Console.WriteLine();

			Console.WriteLine("SECOND ARRAY: ");
			var secondArray = new char[size];
			FillCharsFromConsole(ref secondArray);

			Console.WriteLine();

			switch (Compare(firstArray, secondArray))
			{
				case -1:
					Console.WriteLine("First array is before second.");
					break;
				case 0:
					Console.WriteLine("The arrays are equal.");
					break;
				case 1:
					Console.WriteLine("Second array is before first.");
					break;
			}
		}

		private static void FillCharsFromConsole(ref char[] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				Console.Write("Insert #{0} element: ", i + 1);
				array[i] = GetCharFromConsole();
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
					Console.WriteLine("Not valid number. Insert new value.");
				}
			} while (!isInputValid);

			return number;
		}

		private static char GetCharFromConsole()
		{
			bool isInputValid = false;
			char symbol;
			do
			{
				if (char.TryParse(Console.ReadLine(), out symbol))
				{
					isInputValid = true;
				}
				else
				{
					Console.WriteLine("Not valid char. Insert new value.");
				}
			} while (!isInputValid);

			return symbol;
		}

		private static int Compare(char[] firstArray, char[] secondArray)
		{
			const int firstIsBeforeSecond = -1;
			const int secondIsBeforeFirst = 1;

			int minLength = Math.Min(firstArray.Length, secondArray.Length);

			int compareResult = 0; //0 for equal arrays

			for (int i = 0; i < minLength; i++)
			{
				if (firstArray[i] < secondArray[i])
				{
					compareResult = firstIsBeforeSecond;
					break;
				}

				if (firstArray[i] > secondArray[i])
				{
					compareResult = secondIsBeforeFirst;
					break;
				}
			}

			//Longest array is before shortest
			if (compareResult == 0)
			{
				if (firstArray.Length > minLength)
				{
					compareResult = firstIsBeforeSecond;
				}

				if (secondArray.Length > minLength)
				{
					compareResult = secondIsBeforeFirst;
				}
			}

			return compareResult;
		}
	}
}