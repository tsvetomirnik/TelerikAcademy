/*
 * Author: Tsvetomir Nikolov
 * Email: cvetomir.nikolov@gmail.com
 * Task: Cartesian Coordinate System
 * BGCoder result: 100%
 */

using System;

namespace Cartesian_Coordinate_System
{
	class CartesianCoordinateSystem
	{
		static void Main()
		{
			decimal x = decimal.Parse(Console.ReadLine());
			decimal y = decimal.Parse(Console.ReadLine());

			int coordinateIndex = GetCartesianNumber(x, y);
			Console.WriteLine(coordinateIndex);
		}

		private static int GetCartesianNumber(decimal x, decimal y)
		{
			const int zeroCoordinateIndex = 0;
			const int firstQuadrateIndex = 1;
			const int secondQuadrateIndex = 2;
			const int thirdQuadrateIndex = 3;
			const int fourthQuadrateIndex = 4;
			const int xLineIndex = 5;
			const int yLineIndex = 6;
			
			if(x != 0 && y != 0)
			{
				if(x > 0)
				{
					if(y > 0)
					{
						return firstQuadrateIndex;
					}
					
					return fourthQuadrateIndex;
				}
				else
				{
					if(y > 0)
					{
						return secondQuadrateIndex;
					}
					
					return thirdQuadrateIndex;
				}
			}
			else
			{
				if(x == 0)
				{
					if(y == 0)
					{
						return zeroCoordinateIndex;
					}

					return xLineIndex;
				}

				return yLineIndex;
			}
		}
	}
}
