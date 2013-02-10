/*
 * Task 2: Write a program that reads a rectangular matrix of size N x M and 
 * finds in it the square 3 x 3 that has maximal sum of its elements.
 */

using System;
using ArraysLibrary;

namespace FindMatrixSquare
{
	internal class FindMatrixSquare
	{
		private static void Main()
		{
			Console.Write("Rows count: ");
			int rows = int.Parse(Console.ReadLine());

			Console.Write("Columns count: ");
			int cols = int.Parse(Console.ReadLine());

			Console.Write("Search for max squares sum for matrix with dimentions size of: ");
			int squareDimentionSize = int.Parse(Console.ReadLine());

			if (rows < squareDimentionSize || cols < squareDimentionSize)
			{
				Console.WriteLine("The matrix doesn't have any {0}:{0} sized square inside it.", squareDimentionSize);
				return;
			}

			var array = new int[rows,cols];
			array.FillRand(0, 100);

			int maxSum = int.MinValue;
			for (int i = 0; i <= array.GetLength(0) - squareDimentionSize; i++)
			{
				for (int j = 0; j <= array.GetLength(1) - squareDimentionSize; j++)
				{
					int currentSum = GetRectangleSum(array, i, j, squareDimentionSize);
					if (currentSum > maxSum)
					{
						maxSum = currentSum;
					}
				}
			}

			array.Print();
			Console.WriteLine("Max sum for [{0}:{0}] matrix inside is {1}.", squareDimentionSize, maxSum);
		}

		private static int GetRectangleSum(int[,] array, int startI, int startJ, int squareDimentionSize)
		{
			if (array.GetLength(0) < squareDimentionSize
			    || array.GetLength(1) < squareDimentionSize)
			{
				throw new ArgumentOutOfRangeException("squareDimentionSize",
				                                      "SquareDimentionSize is bigger than one of the array dimentions.");
			}

			int sum = 0;
			for (int i = startI; i < startI + squareDimentionSize; i++)
			{
				for (int j = startJ; j < startJ + squareDimentionSize; j++)
				{
					sum += array[i, j];
				}
			}

			return sum;
		}
	}
}