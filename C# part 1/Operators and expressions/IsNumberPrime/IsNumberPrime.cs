/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 7: Write an expression that checks if given positive 
 * integer number n (n ≤ 100) is prime e.g. 37 is prime.
 * 
 */

using System;

namespace IsNumberPrime
{
	class IsNumberPrime
	{
		static void Main()
		{
			const string messageFormat = "{0} is prime -> {1}";
			Console.WriteLine(messageFormat, 1, IsPrimeNumber(1));
			Console.WriteLine(messageFormat, 5, IsPrimeNumber(5));
			Console.WriteLine(messageFormat, 10, IsPrimeNumber(10));
			Console.WriteLine(messageFormat, 23, IsPrimeNumber(23));
		}

		static bool IsPrimeNumber(int number)
        {
            int factor = number / 2;
 
            for (int i = 2; i <= factor; i++)
            {
				if ((number % i) == 0)
					return false;
            }
			
            return true;
        }
	}
}
