/*
 * Author: Tsvetomir Nikolov
 * Email: cvetomir.nikolov@gmail.com
 */

using System;
using System.Numerics;

namespace Task3
{
	class Task3
	{
		static void Main()
		{
			const int charOffsetToNumber = 64;

			int n = int.Parse(Console.ReadLine());
			var letters = new char[n];

			for (int i = 0; i < n; i++)
			{
			    letters[i] = char.Parse(Console.ReadLine());
			}

			BigInteger lettersIndex = 0;
			int numberPosition = 0;
			foreach (var letter in letters)
			{
				int charNumber = letter - charOffsetToNumber;
			    int decimalPow = n - numberPosition - 1;
			    var decimalShift = (BigInteger) Math.Pow(26, decimalPow);
				BigInteger newNumber = charNumber * decimalShift;
			    lettersIndex += newNumber;

				numberPosition++;
			}
			
			Console.WriteLine(lettersIndex);
		}
	}
}
