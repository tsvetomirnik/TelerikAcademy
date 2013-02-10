/* Task 16: Write a program that reads two dates in the format:
 * day.month.year and calculates the number of days between them.
 */

using System;
using System.Globalization;

namespace DatesTimespan
{
	internal class Program
	{
		private static void Main()
		{
			Console.Write("First date (day.month.year): ");
			DateTime date1 = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			Console.Write("Second date (day.month.year): ");
			DateTime date2 = DateTime.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

			if (date1 <= date2)
			{
				TimeSpan timespan = date2 - date1;
				Console.WriteLine("{0} total days between them.", timespan.TotalDays);
			}
			else
			{
				Console.WriteLine("First date is after second one.");
			}
		}
	}
}