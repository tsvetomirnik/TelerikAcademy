/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 6: Write an expression that checks if given point (x,  y) is within a circle K(O, 5).
 * 
 */

using System;

namespace CheckIsPointWithinACircle
{
	class CheckIsPointWithinACircle
	{
		static void Main()
		{
			const int circleRadius = 5;
			const double x = 4;
			const double y = 4;

			const string messageFormat = "For circle K(0,{0}), the point ({1},{2}) is within the circle -> {3}";
			bool isWithinTheCircle = IsWithinZeroCircle(circleRadius, x, y);
			Console.WriteLine(messageFormat, circleRadius, x, y, isWithinTheCircle);
		}

		private static bool IsWithinZeroCircle(double circleRadius, double x, double y)
		{
			double trianleHypotenuse = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
			return trianleHypotenuse <= circleRadius;
		}
	}
}
