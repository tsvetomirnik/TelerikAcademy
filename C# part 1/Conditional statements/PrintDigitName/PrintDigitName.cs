/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 5: Write program that asks for a digit and depending on the input
 * shows the name of that digit (in English) using a switch statement.
 * 
 */

using System;

namespace PrintDigitName
{
	class PrintDigitName
	{
		static void Main()
		{
			byte number;
			bool isValid;
			do
			{
				Console.Write("Insert a digit (0-9): ");
				string input = Console.ReadLine();
				bool isParsed = byte.TryParse(input, out number);
				bool isInRange = 0 < number && number < 10;

				isValid = isParsed && isInRange;

				if(!isValid)
				{
					Console.WriteLine("\"{0}\" is not a valid digit.", input);
				}

			} while (!isValid);

			string numberName;
			switch (number)
			{
				case 0:
					numberName = "Zero";
					break;
				case 1:
					numberName = "One";
					break;
				case 2:
					numberName = "Two";
					break;
				case 3:
					numberName = "Three";
					break;
				case 4:
					numberName = "Four";
					break;
				case 5:
					numberName = "Five";
					break;
				case 6:
					numberName = "Six";
					break;
				case 7:
					numberName = "Seven";
					break;
				case 8:
					numberName = "Eight";
					break;
				case 9:
					numberName = "Nine";
					break;
				default:
					numberName = "Not valid digit";
					break;
			}

			Console.WriteLine("You have inserted {0}.", numberName.ToLower());
		}
	}
}
