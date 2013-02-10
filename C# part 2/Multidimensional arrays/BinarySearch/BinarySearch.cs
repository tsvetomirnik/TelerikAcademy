/*
 * Task 4: Write a program, that reads from the console an array of N integers and an integer K,
 * sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 
 */

using System;

namespace BinarySearch
{
	internal class BinarySearch
	{
		private static void Main()
		{
			Console.Write("How many numbers do you want to insert: ");
			int n = int.Parse(Console.ReadLine());

			var numbers = new int[n];

			for (int i = 0; i < n; i++)
			{
				Console.Write("Insert #{0} number: ", i + 1);
				numbers[i] = int.Parse(Console.ReadLine());
			}

			Console.Write("Insert K and the program will find largest from the numbers which is less or equal to K: ");
			int k = int.Parse(Console.ReadLine());

			Array.Sort(numbers);
			int index = Array.BinarySearch(numbers, k);

			int maxNumber;
			if (index == -1)
			{
				Console.WriteLine("No such number.");
				return;
			}

			if (index >= 0)
			{
				maxNumber = numbers[index];
			}
			else
			{
				maxNumber = numbers[-index - 2];
			}

			Console.WriteLine("...and this number is {0}.", maxNumber);
		}
	}
}