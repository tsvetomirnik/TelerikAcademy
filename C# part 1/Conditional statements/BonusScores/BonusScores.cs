/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 10: Write a program that applies bonus scores to given scores in the
 * range [1..9]. The program reads a digit as an input. If the digit is between
 * 1 and 3, the program multiplies it by 10; if it is between 4 and 6, multiplies
 * it by 100; if it is between 7 and 9, multiplies it by 1000. If it is zero or
 * if the value is not a digit, the program must report an error. 
 * Use a switch statement and at the end print the calculated new value in the console.
 * 
 */

using System;

namespace BonusScores
{
	class BonusScores
	{
		static void Main()
		{
			const string bonusString = "Bonus score: {0} points.";
			var digit = GetConsoleDigit();

			switch (digit)
			{
				case 1:
				case 2:
				case 3:
					Console.WriteLine(bonusString, digit * 10);
					break;
				case 4:
				case 5:
				case 6:
					Console.WriteLine(bonusString, digit * 100);
					break;
				case 7:
				case 8:
				case 9:
					Console.WriteLine(bonusString, digit * 1000);
					break;
				default:
					Console.WriteLine("Wrong score value.");
					break;
			}
		}

		private static byte GetConsoleDigit()
		{
			byte number;
			bool isValid;
			do
			{
				Console.Write("Insert your score (0-9): ");
				string input = Console.ReadLine();
				bool isParsed = byte.TryParse(input, out number);
				bool isInRange = 0 < number && number < 10;

				isValid = isParsed && isInRange;

				if(!isValid)
				{
					Console.WriteLine("\"{0}\" is not a valid digit.", input);
				}

			} while (!isValid);

			return number;
		}
	}
}
