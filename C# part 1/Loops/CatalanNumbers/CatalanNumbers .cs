/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 10:	Write a program to calculate the Nth Catalan number by given N.
 * 
 */

using System;
using System.Numerics;
using LoopsLibrary;

namespace CatalanNumbers
{
	class CatalanNumbers 
	{
		static void Main(string[] args)
		{
			Console.Write("Find catalan number for index: ");
			var index = GetConsoleUnsignInteger();
			var catalan = GetCatalanNumber(index);
			Console.WriteLine("#{0} catalan number is {1}.", index, catalan);
		}

		private static BigInteger GetCatalanNumber(uint index)
		{
			int n = (int) index;
			var a = (2 * n).Factorial();
			var b = (n + 1).Factorial();
			var c = n.Factorial();

			BigInteger catalanNumber = a / (b * c);
			return catalanNumber;
		}

		private static uint GetConsoleUnsignInteger()
        {
            uint number;
            bool isValid;
            do
            {
                string input = Console.ReadLine();
                isValid = uint.TryParse(input, out number);

                if (!isValid)
                {
                    Console.WriteLine("\"{0}\" is not a positive number.", input);
                }

            } while (!isValid);

            return number;
        }
	}
}
