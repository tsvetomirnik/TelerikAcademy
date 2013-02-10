/* Task 5: You are given a text. Write a program that changes the text
 * in all regions surrounded by the tags <upcase> and </upcase> to
 * uppercase. The tags cannot be nested. 
 */

using System;
using System.Security;

namespace UpcaseText
{
	internal class Program
	{
		private static void Main()
		{
			const string content = "We are living in a <upcase>yellow submarine</upcase>." +
			                       " We don't have <upcase>anything</upcase> else.";

			string uppercased = GetUppercasedByTags(content);
			Console.WriteLine(uppercased);
		}

		private static string GetUppercasedByTags(string content)
		{
			const string openTag = "<upcase>";
			const string closeTag = "</upcase>";

			int openTagsCount = GetSubstringCount(content, openTag);
			int closeTagsCount = GetSubstringCount(content, closeTag);
			if (openTagsCount != closeTagsCount)
			{
				throw new XmlSyntaxException("Some open or close tags are missing.");
			}

			if (openTagsCount < 1)
			{
				return content;
			}

			int currentOpenTagIndex;
			int currentCloseTagIndex;
			do
			{
				currentOpenTagIndex = content.IndexOf(openTag, StringComparison.OrdinalIgnoreCase);
				if (currentOpenTagIndex < 0)
				{
					break;
				}

				content = content.Remove(currentOpenTagIndex, openTag.Length);

				currentCloseTagIndex = content.IndexOf(closeTag, StringComparison.OrdinalIgnoreCase);
				if (currentCloseTagIndex < 0)
				{
					break;
				}

				content = content.Remove(currentCloseTagIndex, closeTag.Length);

				string upperText = content.Substring(currentOpenTagIndex, currentCloseTagIndex - currentOpenTagIndex).ToUpper();
				content = content.Remove(currentOpenTagIndex, currentCloseTagIndex - currentOpenTagIndex);
				content = content.Insert(currentOpenTagIndex, upperText);
			} while (currentOpenTagIndex > 0 && currentCloseTagIndex > 0);

			return content;
		}

		private static int GetSubstringCount(string content, string substring)
		{
			int subCount = 0;
			int subIndex;
			do
			{
				subIndex = content.IndexOf(substring, StringComparison.InvariantCultureIgnoreCase);
				if (subIndex > 0)
				{
					content = content.Remove(subIndex, substring.Length);
					subCount++;
				}
			} while (subIndex >= 0);

			return subCount;
		}
	}
}