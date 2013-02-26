using System;
using System.Text;

namespace GenericMatrix
{
	internal class Matrix<T>
	{
		private readonly T[,] matrix;
		private int cols;
		private int rows;

		public Matrix(int rows, int cols)
		{
			Rows = rows;
			Cols = cols;
			matrix = new T[Rows,Cols];
		}

		public int Rows
		{
			get { return rows; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException(null, "The matrix rows count cannot be a negative number.");
				}

				rows = value;
			}
		}

		public int Cols
		{
			get { return cols; }
			private set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException(null, "The matrix columns count cannot be a negative number.");
				}

				cols = value;
			}
		}

		public T this[int row, int col]
		{
			get
			{
				if (row < 0 || row >= matrix.GetLength(0))
				{
					throw new ArgumentOutOfRangeException("row", "The row value is out of the range of possible row values.");
				}

				if (col < 0 || col >= matrix.GetLength(0))
				{
					throw new ArgumentOutOfRangeException("col", "The col value is out of the range of possible row values.");
				}

				return matrix[row, col];
			}
			set { matrix[row, col] = value; }
		}

		public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
		{
			return matrix1.Add(matrix2);
		}

		public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
		{
			return matrix1.Subtract(matrix2);
		}

		public static Matrix<T> operator *(Matrix<T> matrix1, Matrix<T> matrix2)
		{
			return matrix1.Multiply(matrix2);
		}

		public static bool operator true(Matrix<T> matrix)
		{
			return IsZeroMatrix(matrix);
		}

		public static bool operator false(Matrix<T> matrix)
		{
			return !IsZeroMatrix(matrix);
		}

		private static bool IsZeroMatrix(Matrix<T> matrix)
		{
			if (matrix.Rows == 0 || matrix.Cols == 0)
			{
				return true;
			}

			for (int i = 0; i < matrix.Rows; i++)
			{
				for (int j = 0; j < matrix.Cols; j++)
				{
					if ((dynamic) matrix[i, j] != 0)
					{
						return false;
					}
				}
			}

			return true;
		}

		public Matrix<T> Add(Matrix<T> matrix2)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException(null, "Invocation matrix cannot be null.");
			}

			if (matrix2 == null)
			{
				throw new ArgumentNullException("matrix2");
			}

			if (Rows != matrix2.Rows || Cols != matrix2.Cols)
			{
				throw new ArgumentException("The matrixes has different dimension sizes.");
			}

			var resultMatrix = new Matrix<T>(Rows, Cols);
			for (int row = 0; row < resultMatrix.rows; row++)
			{
				for (int col = 0; col < resultMatrix.cols; col++)
				{
					resultMatrix[row, col] = (dynamic) matrix[row, col] + matrix2[row, col];
				}
			}

			return resultMatrix;
		}

		private Matrix<T> Subtract(Matrix<T> matrix2)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException(string.Empty, "Invocation matrix cannot be null.");
			}

			if (matrix2 == null)
			{
				throw new ArgumentNullException("matrix2");
			}

			if (Rows != matrix2.Rows || Cols != matrix2.Cols)
			{
				throw new ArgumentException("The matrixes has different dimension sizes.");
			}

			var resultMatrix = new Matrix<T>(Rows, Cols);
			for (int row = 0; row < resultMatrix.rows; row++)
			{
				for (int col = 0; col < resultMatrix.cols; col++)
				{
					resultMatrix[row, col] = (dynamic) matrix[row, col] - matrix2[row, col];
				}
			}

			return resultMatrix;
		}

		private Matrix<T> Multiply(Matrix<T> matrix2)
		{
			if (Cols != matrix2.Rows)
			{
				throw new ArgumentException("Invalid matrixes dimension sizes. " +
					"First matrix cols size must be equal to second matrix rows size.");
			}

			var resultMatrix = new Matrix<T>(Rows, matrix2.Cols);
			for (int i = 0; i < resultMatrix.Rows; i++)
			{
				for (int j = 0; j < resultMatrix.Cols; j++)
				{
					resultMatrix[i, j] = default(T);
					for (int k = 0; k < Cols; k++)
					{
						resultMatrix[i, j] += (dynamic) matrix[i, k]*matrix2[k, j];
					}
				}
			}

			return resultMatrix;
		}

		public override string ToString()
		{
			const string OpenBracket = "{";
			const string ClosingBracket = "}";

			var result = new StringBuilder();
			result.Append(OpenBracket);
			for (int i = 0; i < this.Rows; i++)
			{
				result.Append(OpenBracket);
				for (int j = 0; j < this.Cols; j++)
				{
					result.Append(matrix[i, j]);

					if(j < this.Cols-1)
					{
						result.Append(", ");
					}
				}
				
				result.Append(ClosingBracket);

				if(i < this.Rows-1)
				{
					result.Append(", ");
				}
				
			}

			result.Append(ClosingBracket);

			return result.ToString();
		}
	}
}