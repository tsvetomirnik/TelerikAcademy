/*
 * Task 3: We are given a matrix of strings of size N x M. Sequences in the matrix we
 * define as sets of several neighbor elements located on the same line or column.
 * Write a program that finds the longest sequence of equal strings in the matrix.
 */

using System;

namespace LongestSequenceOfEqualStrings
{
	internal class LongestSequenceOfEqualStrings
	{
		private static void Main()
		{
			var syllables = new[,]
			                	{
			                		{"xa", "hi", "hi", "tra", "la"},
			                		{"xa", "hi", "ho", "tra", "xa"},
			                		{"xa", "hi", "ho", "tra", "tra"},
			                		{"la", "la", "ho", "tra", "la"},
			                		{"la", "ho", "xa", "tra", "la"},
			                		{"la", "hi", "ho", "xa", "la"}
			                	};

			GetLongestSequence(syllables);
		}

		private static void GetLongestSequence(string[,] matrix)
		{
			int maxSameElementsCount = 0;
			var maxSameElements = new string[0];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					string[] currentSameElements = GetMaxSameNeighborElements(matrix, i, j);
					if (currentSameElements.Length > maxSameElementsCount)
					{
						maxSameElementsCount = currentSameElements.Length;
						maxSameElements = currentSameElements;
					}
				}
			}

			Console.Write("Max sequence of same elements is: ");
			foreach (string element in maxSameElements)
			{
				Console.Write("{0} ", element);
			}
			Console.WriteLine();
		}

		private static string[] GetMaxSameNeighborElements(string[,] matrix, int row, int col)
		{
			string[] horisontalSequenceItems = GetEqualHorisontalSequence(matrix, row, col);
			string[] verticalSequenceItems = GetEqualVerticalSequence(matrix, row, col);

			if (horisontalSequenceItems.Length > verticalSequenceItems.Length)
			{
				return horisontalSequenceItems;
			}

			return verticalSequenceItems;
		}

		private static string[] GetEqualVerticalSequence(string[,] matrix, int row, int col)
		{
			string currentValue = matrix[row, col];
			int equalItemsCount = 0;
			int firstSequenceRowIndex = row;
			for (int i = row - 1; i >= 0; i--)
			{
				if (matrix[i, col] != currentValue)
				{
					break;
				}

				equalItemsCount++;
				firstSequenceRowIndex = i;
			}

			int matrixLastColIndex = matrix.GetLength(1);
			for (int i = row + 1; i < matrixLastColIndex; i++)
			{
				if (matrix[i, col] != currentValue)
				{
					break;
				}

				equalItemsCount++;
			}

			var equalElementsArray = new string[equalItemsCount];
			for (int i = 0; i < equalItemsCount; i++)
			{
				equalElementsArray[i] = matrix[i + firstSequenceRowIndex, col];
			}

			return equalElementsArray;
		}

		private static string[] GetEqualHorisontalSequence(string[,] matrix, int row, int col)
		{
			string currentValue = matrix[row, col];
			int equalItemsCount = 0;
			int firstSequenceColIndex = col;
			for (int i = col - 1; i >= 0; i--)
			{
				if (matrix[row, i] != currentValue)
				{
					break;
				}

				equalItemsCount++;
				firstSequenceColIndex = i;
			}

			int matrixLastColIndex = matrix.GetLength(1);
			for (int i = col + 1; i < matrixLastColIndex; i++)
			{
				if (matrix[row, i] != currentValue)
				{
					break;
				}

				equalItemsCount++;
			}

			var equalElementsArray = new string[equalItemsCount];
			for (int i = 0; i < equalItemsCount; i++)
			{
				equalElementsArray[i] = matrix[row, i + firstSequenceColIndex];
			}

			return equalElementsArray;
		}
	}
}