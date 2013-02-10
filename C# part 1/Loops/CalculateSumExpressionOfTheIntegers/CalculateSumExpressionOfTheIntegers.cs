/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 6:	Write a program that, for a given two integer numbers N and X,
 *			calculates the sumS = 1 + 1!/X + 2!/X^2 + … + N!/X^N
 * 
 */

using System;
using LoopsLibrary;
using System.Numerics;

namespace CalculateSumExpressionOfTheIntegers
{
	class CalculateSumExpressionOfTheIntegers
	{
		static void Main(string[] args)
		{
			Console.Write("Insert N: ");
			int n = GetConsoleNumber();

			Console.Write("Insert X: ");
			int x = GetConsoleNumber();

			const string expression = "S = 1 + 1!/X + 2!/X^2 + ... + N!/X^N";

			Console.WriteLine(Environment.NewLine + expression);
			Console.WriteLine(new string('-', expression.Length));

			BigInteger sum = 0;
			for (int i = 0; i < n; i++)
			{
				sum += i.Factorial() / (BigInteger) Math.Pow(x, i);				
				Console.WriteLine(i + "!/" + x + "^" + i + " + ");
			}

			Console.WriteLine("= {0}", sum);
		}

		private static int GetConsoleNumber()
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
