/* Task 6: Write a program that reads a text file containing a list of strings,
 * sorts them and saves them to another text file.
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace FileLinesSorter
{
	internal class Program
	{
		private static void Main()
		{
			const string sourcePath = @"../../Students.txt";
			string targetPath = Directory.GetCurrentDirectory() + "\\NumeredFile.txt";

			try
			{
				CreateOrderedFile(sourcePath, targetPath);
				Console.WriteLine("Ordered file created successfully");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private static void CreateOrderedFile(string source, string target)
		{
			var lines = new List<string>();

			string currentLine;
			using (var streamReader = new StreamReader(source))
			{
				do
				{
					try
					{
						currentLine = streamReader.ReadLine();
					}
					catch (Exception ex)
					{
						throw new Exception("Error while reading the source file.", ex.InnerException);
					}

					if (!string.IsNullOrEmpty(currentLine))
					{
						lines.Add(currentLine);
					}
				} while (currentLine != null);
			}

			if (lines.Count < 1)
			{
				return;
			}

			using (var streamWriter = new StreamWriter(target))
			{
				try
				{
					lines.Sort();
					foreach (string line in lines)
					{
						streamWriter.WriteLine(line);
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Error while writing to the target file.", ex.InnerException);
				}
			}
		}
	}
}