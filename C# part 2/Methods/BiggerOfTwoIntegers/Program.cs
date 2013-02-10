/*
 * Task 2: Write a method GetMax() with two parameters that returns the bigger of two integers.
 * Write a program that reads 3 integers from the console and prints the biggest of them using
 * the method GetMax().
 * 
 */

using System;

namespace BiggerOfTwoIntegers
{
	internal class Program
	{
		private static void Main()
		{
			Console.Write("A: ");
			int a = int.Parse(Console.ReadLine());

			Console.Write("B: ");
			int b = int.Parse(Console.ReadLine());

			Console.Write("C: ");
			int c = int.Parse(Console.ReadLine());

			int max = GetMax(a, b, c);
			Console.WriteLine("Max value is {0}.", max);
		}

		private static int GetMax(int a, int b)
		{
			return a > b ? a : b;
		}

		private static int GetMax(int a, int b, int c)
		{
			return GetMax(a, GetMax(b, c));
		}
	}
}