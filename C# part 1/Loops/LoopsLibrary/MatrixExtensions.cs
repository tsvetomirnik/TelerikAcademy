/*
 * Author:	Tsvetomir Nikolov
 * Student:	number: 6001771
 * Email:	cvetomir.nikolov@gmail.com
 */

using System;

namespace LoopsLibrary
{
	public static class MatrixExtensions
	{
		/// <summary>
		/// Prints two dimentionla matrix to the console
		/// </summary>
		/// <param name="matrix">Matrix to be printed</param>
		public static void Print(this int[,] matrix)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					Console.Write(matrix[i, j].ToString().PadRight(3));
				}

				Console.WriteLine();
			}
		}
	}
}
