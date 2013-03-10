using System;

namespace CustomException
{
	class CustomExceptionUsage
	{
		static void Main()
		{
			//InvalidRangeException<int> example
			PrintConsoleNumber();

			Console.WriteLine();

			//InvalidRangeException<DateTime> example
			PrintConsoleDateTime();
		}

		private static void PrintConsoleNumber()
		{
			const int minNumber = 0;
			const int maxNumber = 100;
			Console.Write("Insert number [{0}:{1}]: ", minNumber, maxNumber);
			try
			{
				Console.WriteLine("Inserted number: " + GetConsoleNumber(minNumber, maxNumber));
			}
			catch (InvalidRangeException<int> ire)
			{
				Console.WriteLine("InvalidRangeException catched:");
				Console.WriteLine("Number {0} is not in defined range of [{1}:{2}].",
					ire.OutrangeValue, ire.MinValue, ire.MaxValue);
			}
			catch (Exception)
			{
				Console.WriteLine("Another exception catched.");
			}
		}

		public static int GetConsoleNumber(int min, int max)
		{
			int number = int.Parse(Console.ReadLine());
			if (number < min || number > max)
			{
				throw new InvalidRangeException<int>("Number is not in range.", number, min, max);
			}

			return number;
		}

		private static void PrintConsoleDateTime()
		{
			var minDate = new DateTime(1980, 1, 1);
			var maxDate = new DateTime(2013, 12, 31);
			Console.Write("Insert date [{0}, {1}]: ", minDate.ToShortDateString(), maxDate.ToShortDateString());
			try
			{
				Console.WriteLine("Inserted datetime: " + GetConsoleDateTime(minDate, maxDate));
			}
			catch (InvalidRangeException<DateTime> ire)
			{
				Console.WriteLine("<!> InvalidRangeException catched:");
				Console.WriteLine("DateTime {0} is not in defined range of [{1}:{2}].",
					ire.OutrangeValue.ToShortDateString(), ire.MinValue.ToShortDateString(),
					ire.MaxValue.ToShortDateString());
			}
			catch (Exception)
			{
				Console.WriteLine("Another exception catched.");
			}
		}

		private static DateTime GetConsoleDateTime(DateTime min, DateTime max)
		{
			DateTime date = DateTime.Parse(Console.ReadLine());
			if (date < min || date > max)
			{
				throw new InvalidRangeException<DateTime>("Date is not in range.", date, min, max);
			}

			return date;
		}
	}
}