/*
 * Task 1: Write a program that allocates array of 20 integers and initializes each element 
 * by its index multiplied by 5. Print the obtained array on the console.
 * 
 */

using System;

namespace PrintMultipliedIntegers
{
	internal class PrintMultipliedIntegers
	{
		private static void Main()
		{
			const int arraySize = 20;
			var array = new int[arraySize];

			for (int i = 0; i < arraySize; i++)
			{
				array[i] = i*5;
				Console.WriteLine("#{0}:{1}", i, array[i]);
			}
		}
	}
}