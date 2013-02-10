/* Task 22: Write a program that reads a string from the console and 
 * lists all different words in the string along with information how
 * many times each word is found.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CountWords
{
	internal class Program
	{
		private static void Main()
		{
			const string sentence = "Peter Piper picked a peck of pickled peppers." +
			                        "A peck of pickled peppers Peter Piper picked." +
			                        "If Peter Piper picked a peck of pickled peppers," +
			                        "Where's the peck of pickled peppers Peter Piper picked?";

			var words = new List<string>();
			foreach (Match word in Regex.Matches(sentence, @"\w+"))
			{
				words.Add(word.Value);
			}

			var wordCounts = new Dictionary<string, int>();
			foreach (string word in words)
			{
				if (!wordCounts.ContainsKey(word))
				{
					wordCounts.Add(word, 1);
				}
				else
				{
					wordCounts[word]++;
				}
			}

			IOrderedEnumerable<KeyValuePair<string, int>> orderedWordCounts = wordCounts.OrderByDescending(x => x.Value);
			foreach (var word in orderedWordCounts)
			{
				string timesString = word.Value > 0 ? "times" : "time";
				Console.WriteLine("{0}: {1} {2}", word.Key, word.Value, timesString);
			}
		}
	}
}