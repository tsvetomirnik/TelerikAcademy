/*
 * Task 3: Write a method that returns the last digit of given integer as an English word.
 * Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".
 */

using System;

namespace LastDigit
{
	internal class Program
	{
		private static void Main()
		{
			Console.Write("Insert a number: ");
			int number = int.Parse(Console.ReadLine());
			Console.WriteLine("The last digit is {0}.", GetLastDigit(number));
		}

		private static string GetLastDigit(int number)
		{
			var digitNames = new[]
			                 	{
			                 		"zero", "one", "two", "tree", "four", "five", "six", "seven", "eight", "nine"
			                 	};

			return digitNames[number%10];
		}
	}
}