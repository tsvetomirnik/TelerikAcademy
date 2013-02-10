/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 8: Write an expression that calculates trapezoid's area by given sides a and b and height h.
 * 
 */
using System;

namespace TrapezoidArea
{
	class TrapezoidArea
	{
		static void Main()
		{
			const double a = 5;
			const double b = 10;
			const double h = 12;
			var area = GetTrapezoidArea(a, b, h);
			Console.WriteLine("Trapezoid A={0} B={1} H={2} has area of {3}.", a, b, h, area);
		}

		public static double GetTrapezoidArea(double a, double b, double h)
		{
			return (a + b) / 2 * h;
		}
	}
}