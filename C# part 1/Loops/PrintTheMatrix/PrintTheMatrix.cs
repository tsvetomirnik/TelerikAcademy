/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 12:	Write a program that reads from the console a positive integer
 *			number N (N < 20) and outputs a matrix like the following:
 *			1 2 3
 *			2 3 4
 *			3 4 5
 * 
 */

using System;
using LoopsLibrary;

namespace PrintTheMatrix
{
	class PrintTheMatrix
	{
		static void Main(string[] args)
		{
			uint dimensionSize = GetMatrixSizeFromConsole();
			int[,] matrix = new int[dimensionSize, dimensionSize];

			FillMatrix(ref matrix);
			matrix.Print();
		}

		private static int[,] FillMatrix(ref int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = i + j;
				}
			}
			return matrix;
		}

		private static uint GetMatrixSizeFromConsole()
        {
            uint number;
			bool isValid = false;
            do
            {
				Console.Write("Enter matrix dimension size: ");
                string input = Console.ReadLine();
                var isParsed = uint.TryParse(input, out number);

				if (!isParsed)
				{
					Console.WriteLine("\"{0}\" is not a positive number.", input);
				}
				else 
				{
					var isInRange = number > 0 && number < 20;
					if (!isInRange)
					{
						Console.WriteLine("\"{0}\" must be in range of (0 - 20).", number);
					}
					else 
					{
						isValid = true;
					}
				}

				
            } while (!isValid);

            return number;
        }
	}
}
