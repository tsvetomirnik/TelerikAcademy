/*
 * Task 4: Write a method that counts how many times given number appears in given array.
 * Write a test program to check if the method is working correctly.
 */

using System;

namespace CountArrayElement
{
	internal class Program
	{
		private static void Main()
		{
			var array = new[] {1, 2, 1, 1, 2};
			int number = 1;
			Console.WriteLine("The number {0} is contained {1} times in the array:", number, GetCount(array, number));

			foreach (int n in array)
			{
				Console.Write("{0} ", n);
			}

			Console.WriteLine();
		}

		private static int GetCount(int[] array, int number)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}

			if (array.Length < 1)
			{
				return 0;
			}

			int numberCount = 0;
			foreach (int element in array)
			{
				if (element == number)
				{
					numberCount++;
				}
			}

			return numberCount;
		}
	}
}