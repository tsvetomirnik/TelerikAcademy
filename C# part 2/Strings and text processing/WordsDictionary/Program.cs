/* Task 14: A dictionary is stored as a sequence of text lines containing
 * words and their explanations. Write a program that enters a word and
 * translates it by using the dictionary.
 */

using System;
using System.Collections.Generic;

namespace WordsDictionary
{
	internal class Program
	{
		private static void Main()
		{
			Console.Write("Search for a word: ");
			string word = Console.ReadLine();
			Console.WriteLine("{0} - {1}", word, GetDescription(word));
		}

		private static string GetDescription(string word)
		{
			word = word.Trim();
			var dictionary = new Dictionary<string, string>();
			dictionary.Add(".NET", "platform for applications from Microsoft");
			dictionary.Add("CLR", "managed execution environment for .NET");
			dictionary.Add("namespace", "hierarchical organization of classes");

			foreach (var entry in dictionary)
			{
				if (entry.Key.ToLowerInvariant() == word.ToLowerInvariant())
				{
					return entry.Value;
				}
			}

			return "not found";
		}
	}
}