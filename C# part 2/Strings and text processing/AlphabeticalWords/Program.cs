/* Task 24: Write a program that reads a list of words, separated by spaces and
 * prints the list in an alphabetical order.
 */

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AlphabeticalWords
{
	internal class Program
	{
		private static void Main()
		{
			const string sentence = "The quick brown fox jumps over the lazy dog.";

			var words = new List<string>();
			foreach (Match word in Regex.Matches(sentence, @"\w+"))
			{
				words.Add(word.Value);
			}

			words.Sort();
			foreach (string word in words)
			{
				Console.WriteLine(word);
			}
		}
	}
}