/* Task 1: Write a program that reads an integer number and 
 * calculates and prints its square root. If the number is 
 * invalid or negative, print "Invalid number". In all cases
 * finally print "Good bye". Use try-catch-finally.
 */

using System;

namespace SquareRoot
{
	internal class Program
	{
		private static void Main()
		{
			int number = GetConsoleNumber();
			PrintSquareRoot(number);
		}

		private static int GetConsoleNumber()
		{
			int? number = null;
			do
			{
				Console.Write("Insert a number: ");

				string consoleInput = string.Empty;
				try
				{
					consoleInput = Console.ReadLine();
					number = int.Parse(consoleInput);
				}
				catch (Exception)
				{
					Console.Error.WriteLine("\"{0}\" is not a valid number.", consoleInput);
				}
			} while (number == null);

			return (int) number;
		}

		private static void PrintSquareRoot(int number)
		{
			try
			{
				int square = GetSquareRoot(number);
				Console.WriteLine("{0}^2 = {1}", number, square);
			}
			catch (Exception e)
			{
				Console.Error.WriteLine(e.Message);
			}
			finally
			{
				Console.WriteLine("Good bye!");
			}
		}

		/// <summary>
		/// Returns a square root of positive numbers
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"/>
		/// <returns></returns>
		private static int GetSquareRoot(int number)
		{
			if (number < 0)
			{
				throw new ArgumentOutOfRangeException("number", "Cannot get negative number square root.");
			}

			return number*number;
		}
	}
}