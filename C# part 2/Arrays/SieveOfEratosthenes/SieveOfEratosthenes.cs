/*
* Task 15: Write a program that finds all prime numbers in the range [1...10 000 000].
* Use the sieve of Eratosthenes algorithm 
*/

using System;

namespace SieveOfEratosthenes
{
	internal class SieveOfEratosthenes
	{
		private static void Main()
		{
			int[] primes = PrintPrimes(100000);

			foreach (int prime in primes)
			{
				Console.WriteLine(prime);
			}
		}

		private static int[] PrintPrimes(int maxNumber)
		{
			var primes = new int[maxNumber];
			int lastPrimeIndex = 0;

			for (int i = 2; i < maxNumber; i++)
			{
				bool isPrime = true;

				for (int j = 0; j < lastPrimeIndex; j++)
				{
					if (i%primes[j] == 0)
					{
						isPrime = false;
					}
				}

				if (isPrime)
				{
					primes[lastPrimeIndex++] = i;
				}
			}

			var onlyPrimesArray = new int[lastPrimeIndex];

			for (int i = 0; i < lastPrimeIndex; i++)
			{
				if (primes[0] == 0)
				{
					break;
				}

				onlyPrimesArray[i] = primes[i];
			}

			return onlyPrimesArray;
		}
	}
}