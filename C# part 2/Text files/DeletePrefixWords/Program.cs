/* Task 11: Write a program that deletes from a text file all
 * words that start with the prefix "test". Words contain only
 * the symbols 0...9, a...z, A...Z, 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DeletePrefixWords
{
	internal class Program
	{
		private static void Main()
		{
			const string sourcePath = @"../../Instructions.txt";

			try
			{
				FileRemovePrefix(sourcePath, "test");
				Console.WriteLine("File prefixes removed successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private static void FileRemovePrefix(string source, string prefix)
		{
			if (!File.Exists(source))
			{
				throw new FileNotFoundException();
			}

			const string targetPath = @"../../temp.txt";
			var streamReader = new StreamReader(source);
			var streamWriter = new StreamWriter(targetPath);

			try
			{
				string currentLine;
				do
				{
					currentLine = streamReader.ReadLine();
					if (currentLine != null)
					{
						var words = new List<string>();
						foreach (Match word in Regex.Matches(currentLine, @"\w+"))
						{
							words.Add(word.Value);
						}

						foreach (string word in words)
						{
							if (word.Length <= prefix.Length)
							{
								continue;
							}

							if (word.Substring(0, prefix.Length) == prefix)
							{
								int wordIndex = currentLine.IndexOf(word, StringComparison.OrdinalIgnoreCase);
								currentLine = currentLine.Remove(wordIndex, word.Length);
							}
						}
					}

					streamWriter.WriteLine(currentLine);
				} while (currentLine != null);
			}
			catch (Exception ex)
			{
				throw new Exception("Something went wrong while tring to read the file.", ex.InnerException);
			}
			finally
			{
				streamReader.Close();
				streamWriter.Close();
			}

			try
			{
				ReplaceFile(source, targetPath);
			}
			catch (Exception)
			{
				throw;
			}
		}

		private static void ReplaceFile(string source, string targetPath)
		{
			try
			{
				File.Copy(targetPath, source, true);
			}
			catch (Exception ex)
			{
				throw new Exception("Unable to replace file.", ex.InnerException);
			}
			finally
			{
				try
				{
					File.Delete(targetPath);
				}
				catch (Exception)
				{
					throw new Exception("Unable to clear failed temporary file.");
				}
			}
		}
	}
}