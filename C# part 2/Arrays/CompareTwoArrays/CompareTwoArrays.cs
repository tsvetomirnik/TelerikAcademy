/*
 * Task 2: Write a program that reads two arrays from the console and
 * compares them element by element.
 * 
 */

using System;

namespace CompareTwoArrays
{
	internal class CompareTwoArrays
	{
		private static void Main()
		{
			Console.Write("Insert arrays size: ");
			int size = GetIntegerFromConsole();

			Console.WriteLine();

			Console.WriteLine("FIRST ARRAY: ");
			var firstArray = new int[size];
			FillArrayFromConsole(ref firstArray);

			Console.WriteLine();

			Console.WriteLine("SECOND ARRAY: ");
			var secondArray = new int[size];
			FillArrayFromConsole(ref secondArray);

			Console.WriteLine();

			bool areEquals = AreEquals(firstArray, secondArray);
			string equalString = areEquals ? "The arrays are equal." : "The arrays are not equal.";
			Console.WriteLine(equalString);
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

		private static bool AreEquals(int[] firstArray, int[] secondArray)
		{
			if (firstArray.Length != secondArray.Length)
			{
				return false;
			}

			for (int i = 0; i < firstArray.Length; i++)
			{
				if (firstArray[i] != secondArray[i])
				{
					return false;
				}
			}

			return true;
		}
	}
}