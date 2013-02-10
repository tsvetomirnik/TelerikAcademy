using System;
using System.Globalization;
using System.Text;

namespace ClassMatrix
{
	internal class Matrix
	{
		/// <summary>
		/// Creates new empty instanse of matrix class.
		/// </summary>
		public Matrix()
		{
			Content = new int[0,0];
		}

		/// <summary>
		/// Creates new instanse of matrix class with specific rows and cols size.
		/// </summary>
		public Matrix(int rows, int cols)
		{
			if (rows < 0 || cols < 0)
			{
				throw new Exception("Invalid dimentions size.");
			}

			Content = new int[rows,cols];
		}

		#region Static methods

		/// <summary>
		/// Sum two matrix objects.
		/// </summary>
		public static Matrix operator +(Matrix matrix1, Matrix matrix2)
		{
			if (matrix1.RowCount != matrix2.RowCount
			    || matrix1.ColsCount != matrix2.ColsCount)
			{
				throw new Exception("Different matrixes sizes.");
			}

			var resultMatrix = new Matrix(matrix1.RowCount, matrix1.ColsCount);
			for (int i = 0; i < matrix1.RowCount; i++)
			{
				for (int j = 0; j < matrix1.ColsCount; j++)
				{
					int value = matrix1.GetValue(i, j) + matrix2.GetValue(i, j);
					resultMatrix.SetValue(i, j, value);
				}
			}

			return resultMatrix;
		}

		/// <summary>
		/// Substract two matrix objects.
		/// </summary>
		public static Matrix operator -(Matrix matrix1, Matrix matrix2)
		{
			if (matrix1.RowCount != matrix2.RowCount
			    || matrix1.ColsCount != matrix2.ColsCount)
			{
				throw new Exception("Different matrixes sizes.");
			}

			var resultMatrix = new Matrix(matrix1.RowCount, matrix1.ColsCount);
			for (int i = 0; i < matrix1.RowCount; i++)
			{
				for (int j = 0; j < matrix1.ColsCount; j++)
				{
					int value = matrix1.GetValue(i, j) - matrix2.GetValue(i, j);
					resultMatrix.SetValue(i, j, value);
				}
			}

			return resultMatrix;
		}

		/// <summary>
		/// Multiply two matrix objects.
		/// </summary>
		public static Matrix operator *(Matrix matrix1, Matrix matrix2)
		{
			if (matrix1.RowCount != matrix2.ColsCount
			    || matrix1.ColsCount != matrix2.RowCount)
			{
				throw new Exception(
					"Unable to multiply matrixes when first matrix rows count differs than second matrix cols count.");
			}

			var resultMatrix = new Matrix(matrix1.RowCount, matrix2.ColsCount);

			for (int i = 0; i < matrix1.RowCount; ++i)
			{
				for (int j = 0; j < matrix2.ColsCount; ++j)
				{
					int sum = 0;
					for (int k = 0; k < matrix1.ColsCount; ++k)
					{
						sum += matrix1.GetValue(i, k)*matrix2.GetValue(k, j);
					}

					resultMatrix.SetValue(i, j, sum);
				}
			}

			return resultMatrix;
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Gets the number of rows in the matrix.
		/// </summary>
		public int RowCount
		{
			get { return Content.GetLength(0); }
		}

		/// <summary>
		/// Gets the number of cols in the matrix.
		/// </summary>
		public int ColsCount
		{
			get { return Content.GetLength(0); }
		}

		public void SetContent(int[,] content)
		{
			if (content == null)
			{
				throw new ArgumentNullException("content");
			}

			if (content.GetLength(0) != RowCount
			    || content.GetLength(1) != ColsCount)
			{
				throw new Exception("Wring content dimentions size.");
			}

			Content = content;
		}

		/// <summary>
		/// Set a value in a specific cell in the matrix
		/// </summary>
		public void SetValue(int row, int col, int value)
		{
			if (row < 0 || row >= RowCount)
			{
				throw new ArgumentOutOfRangeException("row");
			}

			if (col < 0 || col >= ColsCount)
			{
				throw new ArgumentOutOfRangeException("col");
			}

			Content[row, col] = value;
		}

		/// <summary>
		/// Set a value in a specific cell in the matrix
		/// </summary>
		public int GetValue(int row, int col)
		{
			if (row < 0 || row >= RowCount)
			{
				throw new ArgumentOutOfRangeException("row");
			}

			if (col < 0 || col >= ColsCount)
			{
				throw new ArgumentOutOfRangeException("col");
			}

			return Content[row, col];
		}

		/// <summary>
		/// Adds a matrix object to the current matrix.
		/// </summary>
		public void Add(Matrix matrix)
		{
			try
			{
				Matrix newMatrix = this + matrix;
				Content = newMatrix.Content;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Substract a matrix object from the current matrix.
		/// </summary>
		public void Substract(Matrix matrix)
		{
			try
			{
				Matrix newMatrix = this - matrix;
				Content = newMatrix.Content;
			}
			catch (Exception)
			{
				throw;
			}
		}

		/// <summary>
		/// Multiplying two matrix objects.
		/// </summary>
		public Matrix Multiply(Matrix matrix)
		{
			try
			{
				Matrix result = this*matrix;
				return result;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public override string ToString()
		{
			int maxLength = 0;
			for (int i = 0; i < RowCount; i++)
			{
				for (int j = 0; j < ColsCount; j++)
				{
					int currentLength = Content[i, j].ToString(CultureInfo.InvariantCulture).Length;
					if (currentLength > maxLength)
					{
						maxLength = currentLength;
					}
				}
			}

			int padding = maxLength + 1;

			var stringBuilder = new StringBuilder();
			for (int i = 0; i < RowCount; i++)
			{
				stringBuilder.Append("{");
				for (int j = 0; j < ColsCount; j++)
				{
					string value = Content[i, j].ToString();
					if (j < ColsCount - 1)
					{
						value += ",";
					}

					stringBuilder.Append(value.PadLeft(padding));
				}

				stringBuilder.Append("}");

				if (i < RowCount - 1)
				{
					stringBuilder.Append(",");
				}

				stringBuilder.Append(Environment.NewLine);
			}

			return stringBuilder.ToString();
		}

		#endregion

		public int[,] Content { private set; get; }
	}
}