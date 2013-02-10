/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 3: Write an expression that calculates rectangle’s area by given width and height.
 * 
 */

using System;

namespace RectangleArea
{
	class RectangleArea
	{
		static void Main()
		{
			const int width = 3;
			const int height = 4;
			const string messageFormat = "Rectangle with width = {0} and height = {1} has area = {2}.";
			Console.WriteLine(messageFormat, width, height, GetRectangleArea(width, height));
		}

		public static double GetRectangleArea(double width, double height)
		{
			return width * height;
		}
	}
}
