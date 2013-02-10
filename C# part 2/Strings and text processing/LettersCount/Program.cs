/* Task 21: Write a program that reads a string from the console and prints all
 * different letters in the string along with information how many times each 
 * letter is found.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace LettersCount
{
	internal class Program
	{
		private static void Main()
		{
			const string sentence = "Peter Piper picked a peck of pickled peppers.";

			var wordCounts = new Dictionary<char, int>();
			foreach (char c in sentence)
			{
				if (!char.IsLetter(c))
				{
					continue;
				}

				if (!wordCounts.ContainsKey(c))
				{
					wordCounts.Add(c, 1);
				}
				else
				{
					wordCounts[c]++;
				}
			}

			IOrderedEnumerable<KeyValuePair<char, int>> orderedWordCounts = wordCounts.OrderByDescending(x => x.Value);
			foreach (var word in orderedWordCounts)
			{
				string timesString = word.Value > 0 ? "times" : "time";
				Console.WriteLine("{0}: {1} {2}", word.Key, word.Value, timesString);
			}
		}
	}
}