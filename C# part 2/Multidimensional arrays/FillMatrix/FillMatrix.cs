/*
* Task 1: Write a program that fills and prints a matrix of size (n, n).
*/

using System;
using ArraysLibrary;

namespace FillMatrix
{
	internal class FillMatrix
	{
		private static void Main()
		{
			Console.Write("Insert dimentions size: ");
			int dimention = int.Parse(Console.ReadLine());
			Console.WriteLine();

			Console.WriteLine("Ordered Matrix By Cols");
			int[,] matrix = CreateOrderedMatrixByCols(dimention, dimention);
			matrix.Print();
			Console.WriteLine();

			Console.WriteLine("Snake Matrix");
			matrix = CreateSnakeMatrix(dimention, dimention);
			matrix.Print();
			Console.WriteLine();

			Console.WriteLine("Diagonal Matrix");
			matrix = CreateDiagonalMatrix(dimention, dimention);
			matrix.Print();
			Console.WriteLine();
		}

		private static int[,] CreateOrderedMatrixByCols(int rows, int cols)
		{
			var matrix = new int[rows,cols];
			int value = 1;
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
					matrix[j, i] = value++;
				}
			}

			return matrix;
		}

		private static int[,] CreateSnakeMatrix(int rows, int cols)
		{
			var matrix = new int[rows,cols];

			int value = 1;
			for (int i = 0; i < rows; i++)
			{
				bool startFormTop = i%2 == 0;
				if (startFormTop)
				{
					for (int j = 0; j < cols; j++)
					{
						matrix[j, i] = value++;
					}
				}
				else
				{
					for (int j = cols - 1; j >= 0; j--)
					{
						matrix[j, i] = value++;
					}
				}
			}

			return matrix;
		}

		private static int[,] CreateDiagonalMatrix(int rows, int cols)
		{
			var matrix = new int[rows,cols];
			int diagonalsCount = rows + cols - 1;
			int value = 1;

			for (int i = 0; i < diagonalsCount; i++)
			{
				int minDimentionValue = Math.Min(rows, cols);
				int diagonalLength = i < minDimentionValue
				                     	? i + 1
				                     	: diagonalsCount - i;

				int longestDiagonalIndex = (diagonalsCount/2 + 1);
				int startRowIndex;
				int startColIndex;
				if (i < longestDiagonalIndex)
				{
					startRowIndex = rows - i - 1;
					startColIndex = 0;
				}
				else
				{
					startRowIndex = 0;
					startColIndex = cols - (diagonalsCount - i);
				}

				for (int j = 0; j < diagonalLength; j++)
				{
					matrix[startRowIndex, startColIndex] = value++;
					startRowIndex++;
					startColIndex++;
				}
			}

			return matrix;
		}
	}
}