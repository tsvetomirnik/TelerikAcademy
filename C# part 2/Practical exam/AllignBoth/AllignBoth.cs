/*
 * Sent on: 2/4/2013 8:28:22 PM
 * Status: Accepted!
 * Points: 100 / 100
 * Full report: View full report
 * Max time used: 0.052 sec.
 * Max memory used: 1,016 kB
 * Language: C# Code
 * Zero tests passed: True
 * Has full points: True
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AllignBoth
{
	internal class AllignBoth
	{
		private static void Main()
		{
			int linesCount = int.Parse(Console.ReadLine());
			int width = int.Parse(Console.ReadLine());

			var words = new List<string>();
			for (int i = 0; i < linesCount; i++)
			{
				words.AddRange(Regex.Split(Console.ReadLine(), @"\W+"));
			}

			var clearedWord = new List<string>();
			for (int i = 0; i < words.Count; i++)
			{
				if (words[i].Trim() != string.Empty)
				{
					clearedWord.Add(words[i]);
				}
			}

			GetFormed(clearedWord, width);
		}

		private static void GetFormed(List<string> words, int width)
		{
			var lines = new List<string>();
			int from = 0;
			int last = 0;

			while (last < words.Count - 1)
			{
				last = GetWordsForLine(from, words, width);
				lines.Add(AddSpaces(words, from, last, width));
				from = last + 1;
			}

			for (int i = 0; i < lines.Count; i++)
			{
				Console.WriteLine(lines[i].Trim());
			}
		}

		private static string AddSpaces(List<string> words, int from, int last, int width)
		{
			var line = new StringBuilder();
			int spacesLeft;

			//For more than one word
			if (from != last)
			{
				for (int i = from; i <= last; i++)
				{
					line.Append(words[i]);

					if (i < last)
					{
						line.Append(" ");
					}
				}

				spacesLeft = width - line.Length;
				if (spacesLeft == 0)
				{
					return line.ToString();
				}

				int spacePerWord = spacesLeft/(last - from);
				for (int i = from; i < last; i++)
				{
					words[i] += new string(' ', spacePerWord);
				}

				line.Clear();
				for (int i = from; i <= last; i++)
				{
					line.Append(words[i]);
					if (i < last)
					{
						line.Append(" ");
					}
				}

				spacesLeft = width - line.Length;
				int wordIndex = from;
				while (spacesLeft > 0)
				{
					if (wordIndex + 1 < words.Count - 1)
					{
						words[wordIndex++] += " ";
					}

					spacesLeft--;
				}

				line.Clear();
				for (int i = from; i <= last; i++)
				{
					line.Append(words[i]);
					if (i < last)
					{
						line.Append(" ");
					}
				}

				return line.ToString();
			}
			else
			{
				spacesLeft = width - words[from].Length;
				if (spacesLeft > 0)
				{
					line.Append(words[from] + new string(' ', spacesLeft));
				}
				else
				{
					line.Append(words[from]);
				}

				return line.ToString();
			}
		}

		private static int GetWordsForLine(int fromIndex, List<string> words, int width)
		{
			var line = new StringBuilder();
			line.Append(words[fromIndex]);
			int currentWord = fromIndex;

			while (line.Length <= width && currentWord + 1 < words.Count)
			{
				var space = new string(' ', 1);
				line.Append(space + words[currentWord + 1]);

				if (line.Length <= width)
				{
					currentWord++;
				}
			}

			return currentWord;
		}
	}
}