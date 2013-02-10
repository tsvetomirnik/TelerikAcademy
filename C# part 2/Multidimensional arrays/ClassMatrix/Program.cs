/*
 * Task 6: Write a class Matrix, to holds a matrix of integers. Overload the operators for adding,
 * subtracting and multiplying of matrices, indexer for accessing the matrix content and ToString().
 */

using System;

namespace ClassMatrix
{
	internal class Program
	{
		private static void Main()
		{
			var matrix1 = new Matrix(2, 2);
			matrix1.SetContent(
				new[,]
					{
						{1, 3},
						{4, 7}
					}
				);

			Console.WriteLine("Matrix 1:");
			PrintMatrix(matrix1);

			var matrix2 = new Matrix(2, 2);
			matrix2.SetContent(
				new[,]
					{
						{7, -1},
						{8, 12}
					}
				);

			Console.WriteLine("Matrix 2:");
			PrintMatrix(matrix2);

			Console.WriteLine("Sum of the matrixes:");
			PrintMatrix(matrix1 + matrix2);

			Console.WriteLine("Substracting:");
			PrintMatrix(matrix1 - matrix2);

			Console.WriteLine("Multiplying:");
			PrintMatrix(matrix1*matrix2);
		}

		private static void PrintMatrix(Matrix m)
		{
			Console.WriteLine(m.ToString());
		}
	}
}