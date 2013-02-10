/*
 * Author:	Tsvetomir Nikolov
 * Student:	number: 6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 7:	Write a program that reads a number N and calculates the sum of 
 *			the first N members of the sequence of Fibonacci:
 *			0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
 *			Each member of the Fibonacci sequence (except the first two)
 *			is a sum of the previous two members.
 * 
 */

using System;

namespace SumOfFibonacciNumbers
{
	class SumOfFibonacciNumbers
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Get sum of first N fibonacci numbers.");
			Console.Write("Insert N: ");
			int n = GetConsoleInteger();

			long sum = GetFactorialSum(n);
			Console.WriteLine("Sum of the first {0} fibonacci numbers is {1}.", n, sum);
		}

		private static long GetFactorialSum(int n)
		{
			long a = 0;
			long b = 1;
			long sum = 0;
			for (int i = 0; i < n; i++)
			{
				sum += a;
				long temp = a;
				a = b;
				b = temp + b;
			}
			return sum;
		}

		private static int GetConsoleInteger()
        {
            int number;
            bool isValid;
            do
            {
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out number);

                if (!isValid)
                {
                    Console.WriteLine("\"{0}\" is not valid integer number.", input);
                }

            } while (!isValid);

            return number;
        }
	}
}
