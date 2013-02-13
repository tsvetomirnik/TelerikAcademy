/*
 * Sent on: 2/4/2013 5:20:41 PM
 * Status: Accepted!
 * Points: 100 / 100
 * Full report: View full report
 * Max time used: 0.034 sec.
 * Max memory used: 1 MB
 * Language: C# Code
 * Zero tests passed: True
 * Has full points: True
 */

using System;
using System.Collections.Generic;
using System.Numerics;

namespace Midget
{
	internal class Midget
	{
		private static void Main()
		{
			string sValley = Console.ReadLine();
			short[] valley = GetInputArray(sValley, new[]{','});

			int patternsCount = int.Parse(Console.ReadLine());

			var patterns = new List<short[]>();
			for (int i = 0; i < patternsCount; i++)
			{
				string sPattern = Console.ReadLine();
				patterns.Add(GetInputArray(sPattern, new[]{','}));
			}

			BigInteger maxCoins = int.MinValue;
			for (int i = 0; i < patternsCount; i++)
			{
				BigInteger curentCoins = GetCollectedCoins(valley, patterns[i]);
				if (curentCoins > maxCoins)
				{
					maxCoins = curentCoins;
				}
			}

			Console.WriteLine(maxCoins);
		}

		private static BigInteger GetCollectedCoins(short[] valley, short[] pattern)
		{
			var moves = new bool[valley.Length];
			BigInteger collectedCoins = 0;
			int patternIndex = 0;
			int valleyIndex = 0;

			do
			{
				if (valleyIndex < 0 || valleyIndex > valley.Length - 1)
				{
					break;
				}

				if (moves[valleyIndex])
				{
					break;
				}

				collectedCoins += valley[valleyIndex];
				moves[valleyIndex] = true;
				valleyIndex += pattern[patternIndex];

				if (patternIndex >= pattern.Length - 1)
				{
					patternIndex = 0;
				}
				else
				{
					patternIndex++;
				}
			} while (true); //Todo: fix this

			return collectedCoins;
		}

		private static short[] GetInputArray(string input, char[] separators)
		{
			string[] parts = input.Split(separators);
			var array = new short[parts.Length];
			for (int i = 0; i < parts.Length; i++)
			{
				array[i] = short.Parse(parts[i].Trim());
			}

			return array;
		}
	}
}