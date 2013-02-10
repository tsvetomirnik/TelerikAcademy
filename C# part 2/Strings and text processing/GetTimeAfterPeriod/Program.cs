/* Task 17: Write a program that reads a date and time given in the format:
 * day.month.year hour:minute:second and prints the date and time after 6 
 * hours and 30 minutes (in the same format) along with the day of week in
 * Bulgarian.
 */

using System;
using System.Globalization;

namespace GetTimeAfterPeriod
{
	internal class Program
	{
		private static void Main()
		{
			Console.Write("First date (day.month.year hour:minute:second): ");
			DateTime date = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			var timespan = new TimeSpan(6, 30, 0);
			DateTime resultDate = date + timespan;

			Console.WriteLine("The time after {0} will be", timespan.ToString());
			Console.WriteLine("{0} {1}", resultDate.ToString("dd.MM.yyyy hh:mm:ss"),
			                  date.ToString("dddd", new CultureInfo("bg-BG")));
		}
	}
}