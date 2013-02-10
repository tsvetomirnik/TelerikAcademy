/*
 * Task 5: Write a method that checks if the element at given position in given array of
 * integers is bigger than its two neighbors (when such exist).
 */

using System;
using System.Diagnostics;

namespace NeighborElements
{
	internal class Program
	{
		private static void Main()
		{
			AssertMethodIsBiggerThanNeighbours();
		}

		private static void AssertMethodIsBiggerThanNeighbours()
		{
			bool actual, expected;
			var array = new[] {4, 2, 3, 4, 1};

			expected = false;
			actual = IsBiggerThanNeighbours(array, 0);
			Debug.Assert(actual == expected);

			expected = false;
			actual = IsBiggerThanNeighbours(array, 1);
			Debug.Assert(actual == expected);

			expected = true;
			actual = IsBiggerThanNeighbours(array, 3);
			Debug.Assert(actual == expected);

			expected = false;
			actual = IsBiggerThanNeighbours(array, 4);
			Debug.Assert(actual == expected);
		}

		private static bool IsBiggerThanNeighbours(int[] array, int index)
		{
			if (index < 0 || index > array.Length)
			{
				throw new ArgumentOutOfRangeException("index");
			}

			bool isBiggerThanLeftElement = false;
			if (index > 0)
			{
				isBiggerThanLeftElement = array[index] > array[index - 1];
			}

			bool isBiggerThanRightElement = false;
			if (index < array.Length - 1)
			{
				isBiggerThanRightElement = array[index] > array[index + 1];
			}

			return isBiggerThanLeftElement && isBiggerThanRightElement;
		}
	}
}