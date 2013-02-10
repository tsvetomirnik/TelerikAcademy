/*
 * Task 6: Write a method that returns the index of the first element in array that
 * is bigger than its neighbors, or -1, if there’s no such element. 
 */

using System;

namespace NeighborElements2
{
	internal class Program
	{
		private static void Main()
		{
			GetFirstBiggerThanNeighbours(new[] {4, 2, 3, 4, 1});
			GetFirstBiggerThanNeighbours(new[] {3, 2, 1});
		}

		private static int GetFirstBiggerThanNeighbours(int[] array)
		{
			int firstBiggerThanNeighbours = -1;
			for (int i = 0; i < array.Length; i++)
			{
				if (IsBiggerThanNeighbours(array, i))
				{
					firstBiggerThanNeighbours = i;
					break;
				}
			}

			return firstBiggerThanNeighbours;
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