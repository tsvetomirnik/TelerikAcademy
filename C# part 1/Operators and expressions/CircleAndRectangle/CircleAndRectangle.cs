/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 9: Write an expression that checks for given point (x, y)
 * if it is within the circle K( (1,1), 3) and out of the
 * rectangle R(top=1, left=-1, width=6, height=2).
 * 
 */

using System;

namespace CircleAndRectangle
{
	class CircleAndRectangle
	{
		static void Main()
		{
			const int circleRadius = 3;
			const double circleX = 1;
			const double circleY = 1;
			const double rectX = -1;
			const double rectY = 1;
			const double rectWidth = 6;
			const double rectHeight = 2;
			const double pointX = -1;
			const double pointY = 2;

			bool isWithinCircle = IsWithinCircle(circleX, circleY, circleRadius, pointX, pointY);
			bool isWithinRectangle = IsWithinRectangle(rectX, rectY, rectWidth, rectHeight, pointX, pointY);

			Console.WriteLine("Point is within the circle and rectangle -> {0}", isWithinCircle && isWithinRectangle);
		}

		private static bool IsWithinCircle(double circleX, double circleY, double circleRadius, double pointX, double pointY)
		{
			double trianleHypotenuse = Math.Sqrt(Math.Pow(pointX - circleX, 2) + Math.Pow(pointY - circleY, 2));
			return trianleHypotenuse <= circleRadius;
		}

		private static bool IsWithinRectangle(double rectX, double rectY, double rectWidth, double rectHight, double pointX, double pointY)
		{
			bool width = pointX >= rectX && pointX <= rectX + rectWidth;
			bool height = pointY >= rectY && pointY <= rectY - rectHight; //If the coordinates are for top left angle
			return width && height;
		}
	}
}
