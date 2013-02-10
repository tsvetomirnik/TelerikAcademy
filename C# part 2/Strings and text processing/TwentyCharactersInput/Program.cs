/* Task 6: Write a program that reads from the console a string of maximum
 * 20 characters. If the length of the string is less than 20, the rest of
 * the characters should be filled with '*'. Print the result string into
 * the console.
 */

using System;

namespace TwentyCharactersInput
{
	internal class Program
	{
		private static void Main()
		{
			const int requiredLength = 20;
			Console.Write("Insert something: ");
			Console.WriteLine(GetConsoleInput(requiredLength));
		}

		private static string GetConsoleInput(int requiredLength)
		{
			string input = Console.ReadLine();
			if (input == null)
			{
				return string.Empty;
			}

			if (input.Length < requiredLength)
			{
				input = input.Insert(input.Length, new string('*', requiredLength - input.Length));
			}

			return input;
		}
	}
}