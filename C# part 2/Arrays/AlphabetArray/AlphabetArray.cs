/*
 * Task 12: Write a program that creates an array containing all letters from
 * the alphabet (A-Z). Read a word from the console and print the index of
 * each of its letters in the array.
 */

using System;

namespace AlphabetArray
{
	internal class AlphabetArray
	{
		private static void Main()
		{
			var alphabetArray = new char[26];
			for (int i = 0; i < alphabetArray.Length; i++)
			{
				alphabetArray[i] = (char) (i + 65);
			}

			string word;
			do
			{
				Console.Write("Insert a word [A-Z]: ");
				word = Console.ReadLine();
			} while (word == null);

			Console.WriteLine("Word by indexes: ");
			foreach (char character in word)
			{
				int index = GetIndex(alphabetArray, character);
				Console.Write(index + " ");
			}

			Console.WriteLine();
		}

		private static int GetIndex(char[] numbers, char numberToFind)
		{
			int startedIndex = 0;
			int endIndex = numbers.Length - 1;
			while (startedIndex <= endIndex)
			{
				int middleIndex = (endIndex + startedIndex)/2;
				if (numberToFind == numbers[middleIndex])
				{
					return middleIndex;
				}
				if (numberToFind > numbers[middleIndex])
				{
					startedIndex = middleIndex + 1;
				}
				if (numberToFind < numbers[middleIndex])
				{
					endIndex = middleIndex - 1;
				}
			}

			return -1;
		}
	}
}