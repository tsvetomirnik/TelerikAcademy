/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 8: Write a program that, depending on the user's choice inputs
 * int, double or string variable. If the variable is integer or double,
 * increases it with 1. If the variable is string, appends "*" at its end.
 * The program must show the value of that variable as a console output.
 * Use switch statement.
 * 
 */

using System;

namespace GetInputType
{
	class GetInputType
	{
		static void Main()
		{
			int typeSelected = GetSelectedType();

			string result;
			switch (typeSelected)
			{
				case 0:
					result = AskForString();
					result += "*";
					break;
				
				case 1:
					int intNumber = AskForInteger();
					result = (intNumber + 1).ToString();
					break;
					
				case 2:
					double doubleNumber = AskForDouble();
					result = (doubleNumber + 1).ToString();
					break;
				default:
					result = "Wrong command";
					break;
			}

			Console.WriteLine("Result: {0}", result);
		}

		private static int GetSelectedType()
		{
			int typeIndex;
			bool isValid;
			do
			{
				Console.WriteLine("Choose stype to insert: \r\n 0 for string \r\n 1 for integer \r\n 2 for real number");
				Console.Write("choose: ");
				string input = Console.ReadLine();
				bool isParsed = int.TryParse(input, out typeIndex);
				isValid = isParsed && (typeIndex >= 0 && typeIndex < 3);

				if(!isValid)
				{
					Console.WriteLine("\"{0}\" is not a valid index for type.", input);
				}

			} while (!isValid);

			return typeIndex;
		}

		private static string AskForString()
		{
			Console.Write("Insert string: ");
			var input = Console.ReadLine();
			return input;
		}

		private static int AskForInteger()
		{
			int number;
			bool isParsed;
			do
			{
				Console.Write("Insert an integer number: ");
				string input = Console.ReadLine();
				isParsed = int.TryParse(input, out number);

				if(!isParsed)
				{
					Console.WriteLine("\"{0}\" is not a valid integer number.", input);
				}

			} while (!isParsed);

			return number;
		}

		private static double AskForDouble()
		{
			double number;
			bool isParsed;
			do
			{
				Console.Write("Insert a real number number: ");
				string input = Console.ReadLine();
				input = input.Replace(',', '.');
				isParsed = double.TryParse(input, out number);

				if(!isParsed)
				{
					Console.WriteLine("\"{0}\" is not a valid real number.", input);
				}

			} while (!isParsed);

			return number;
		}
	}
}
