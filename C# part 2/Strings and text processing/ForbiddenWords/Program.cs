/* Task 9: We are given a string containing a list of forbidden words
 * and a text containing some of these words. Write a program that
 * replaces the forbidden words with asterisks. 
 */

using System;

namespace ForbiddenWords
{
	internal class Program
	{
		private static void Main()
		{
			var forbiddenWords = new[]
			                     	{
			                     		"PHP", "CLR", "Microsoft"
			                     	};

			string content = "Microsoft announced its next generation PHP compiler today." +
			                 " It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";

			Console.WriteLine(HideForbiddenWord(content, forbiddenWords));
		}

		private static string HideForbiddenWord(string content, string[] forbiddenWords)
		{
			const char hiddenChar = '*';
			foreach (string forbiddenWord in forbiddenWords)
			{
				content = content.Replace(forbiddenWord, new string(hiddenChar, forbiddenWord.Length));
			}

			return content;
		}
	}
}