using System;

namespace GenericMatrix
{
	static class MatrixUsagesExamples
	{
		public static void Run()
		{
			var firstMatrix = new Matrix<int>(2, 2);
			firstMatrix[0, 0] = 1;
			firstMatrix[0, 1] = 2;
			firstMatrix[1, 0] = 3;
			firstMatrix[1, 1] = 4;

			var secondMatrix = new Matrix<int>(2, 2);
			secondMatrix[0, 0] = 2;
			secondMatrix[0, 1] = 3;
			secondMatrix[1, 0] = 4;
			secondMatrix[1, 1] = 5;

			Console.WriteLine("FIRST MATRIX:");
			Console.WriteLine(firstMatrix.ToString());
			Console.WriteLine();

			Console.WriteLine("SECOND MATRIX:");
			Console.WriteLine(firstMatrix.ToString());
			Console.WriteLine();

			Console.WriteLine("SUM OF THE MATRIXES:");
			Console.WriteLine((firstMatrix + secondMatrix).ToString());
			Console.WriteLine();

			Console.WriteLine("EXTRACT OF THE MATRIXES:");
			Console.WriteLine((firstMatrix - secondMatrix).ToString());
			Console.WriteLine();

			Console.WriteLine("MULTIPLICATION OF THE MATRIXES:");
			Console.WriteLine((firstMatrix * secondMatrix).ToString());
			Console.WriteLine();

			Console.WriteLine("GET MATRIX VALUE:");
			Console.WriteLine("Value on possition [0,1] from first matrix is {0}.", firstMatrix[0,1]);
			Console.WriteLine();

			Console.WriteLine("GET MATRIX DIMENSION SIZES:");
			Console.WriteLine("The first matrix has {0} rows.", firstMatrix.Rows);
			Console.WriteLine("The first matrix has {0} cols.", firstMatrix.Cols);
			Console.WriteLine();

			var zeroMatrix = new Matrix<int>(1, 1);
			secondMatrix[0, 0] = 0;
			secondMatrix[0, 1] = 0;

			Console.WriteLine("CHECK IS TRUE:");
			Console.WriteLine(firstMatrix? "First matrix is true..." : "First matrix is false...");
			Console.WriteLine(zeroMatrix? "Zero matrix is true..." : "Zero matrix is false...");
			Console.WriteLine();
		}
	}
}
