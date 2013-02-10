/* Task 10: Write a program that extracts from given XML
 * file all the text without the tags.
 */

using System;
using System.IO;

namespace XmlTextExtractor
{
	internal class Program
	{
		private static void Main()
		{
			const string sourcePath = @"../../File.txt";
			RemoveFileXMLCode(sourcePath);
		}

		private static void RemoveFileXMLCode(string sourcePath)
		{
			string content = null;
			try
			{
				content = File.ReadAllText(sourcePath);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			if (content == null)
			{
				return;
			}

			int openBracketIndex;
			int closingBracketIndex;
			do
			{
				openBracketIndex = content.IndexOf("<");
				closingBracketIndex = content.IndexOf(">");
				if (openBracketIndex >= 0 || closingBracketIndex >= 0)
				{
					if (openBracketIndex < closingBracketIndex)
					{
						content = content.Remove(openBracketIndex, closingBracketIndex - openBracketIndex + 1);
					}
				}
			} while (openBracketIndex > 0 || closingBracketIndex > 0);

			try
			{
				File.WriteAllText(sourcePath, content);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to write to the file.", ex.InnerException);
			}
		}
	}
}