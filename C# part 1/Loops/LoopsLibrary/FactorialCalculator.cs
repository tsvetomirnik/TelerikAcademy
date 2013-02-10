/*
 * Author:	Tsvetomir Nikolov
 * Student:	number: 6001771
 * Email:	cvetomir.nikolov@gmail.com
 */

using System;
using System.Numerics;

namespace LoopsLibrary
{
    public static class FactorialCalculator
    {
		/// <summary>
		/// Get factorial of specific number
		/// </summary>
		/// <param name="number">Number to get factorial</param>
		/// <returns></returns>
		public static BigInteger Factorial(this int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("number cannot be negative number");
            }
			else if (number < 2) 
			{
				return 1;
			}

            BigInteger product = number;
            do
            {
                number--;
                product *= number;
            } while (number > 1);

            return product;
        }
    }
}
