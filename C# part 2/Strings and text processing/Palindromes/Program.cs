/* Task 20: Write a program that extracts from a given text all palindromes,
 * e.g. "ABBA", "lamal", "exe".
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace Palindromes
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			const string text = "ABBA, not palindome, lamal, exe;";

			var palindromes = new List<string>();
			var word = new StringBuilder();
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] != ' ' && !char.IsPunctuation(text[i]))
				{
					word.Append(text[i]);
				}
				else
				{
					if (IsPalindrome(word.ToString()))
					{
						palindromes.Add(word.ToString());
					}

					word.Clear();
				}
			}

			foreach (string palindrome in palindromes)
			{
				Console.Write("{0} ", palindrome);
			}
			Console.WriteLine();
		}

		private static bool IsPalindrome(string word)
		{
			if (string.IsNullOrEmpty(word.Trim()))
			{
				return false;
			}

			if (word[0] == word[word.Length - 1])
			{
				return true;
			}

			return false;
		}
	}
}