/* Task 2: Write a method ReadNumber(int start, int end) that enters an integer
 * number in given range [start…end]. If an invalid number or non-number text
 * is entered, the method should throw an exception. 
 * 
 */

using System;

namespace ConsoleNumberReader
{
	internal class Program
	{
		private static void Main()
		{
			const int numbersToInsert = 3;
			Console.WriteLine("You have to insert {0} numbers in a specific range.", numbersToInsert);
			var numbers = new int[numbersToInsert];

			Console.Write("Insert min range value: ");
			int min = int.Parse(Console.ReadLine());

			Console.Write("Insert max range value: ");
			int max = int.Parse(Console.ReadLine());

			int insertedNumbersCount = 0;
			while (insertedNumbersCount < numbersToInsert)
			{
				try
				{
					Console.Write("#{0}: ", insertedNumbersCount + 1);
					numbers[insertedNumbersCount] = ReadNumber(min, max);
					insertedNumbersCount++;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Console.WriteLine("Try to insert a valid number.");
				}
			}
		}

		private static int ReadNumber(int start, int end)
		{
			int number;
			try
			{
				number = int.Parse(Console.ReadLine());
			}
			catch (ArgumentNullException ex)
			{
				throw new ArgumentNullException("Null is not a valid value.", ex);
			}
			catch (FormatException ex)
			{
				throw new FormatException("Invalid integer number.", ex);
			}
			catch (OverflowException ex)
			{
				throw new OverflowException("Out of range of integer numbers.", ex);
			}

			if (number < start || number > end)
			{
				throw new IndexOutOfRangeException(string.Format("The value not in the range of [{0}:{1}].", start, end));
			}

			return number;
		}
	}
}