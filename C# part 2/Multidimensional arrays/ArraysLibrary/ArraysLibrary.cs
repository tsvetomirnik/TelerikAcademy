using System;

namespace ArraysLibrary
{
	public static class ArraysLibrary
	{
		public static void Print(this int[] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				Console.Write(array[i].ToString().PadLeft(5));
			}
		}

		public static void Print(this int[,] array)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					Console.Write(array[i, j].ToString().PadLeft(5));
				}

				Console.WriteLine();
			}
		}

		public static void FillRand(this int[] array, int minValue, int maxValue)
		{
			var rand = new Random();
			for (int i = 0; i < array.GetLength(0); i++)
			{
				array[i] = rand.Next(minValue, maxValue);
			}
		}

		public static void FillRand(this int[,] array, int minValue, int maxValue)
		{
			var rand = new Random();
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = 0; j < array.GetLength(1); j++)
				{
					array[i, j] = rand.Next(minValue, maxValue);
				}
			}
		}
	}
}