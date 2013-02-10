/* Task 9: Write a program that deletes from given text file all
 * odd lines. The result should be in the same file.
 */

using System;
using System.IO;

namespace OddLinesRemover
{
	internal class Program
	{
		private static void Main()
		{
			const string sourcePath = @"../../InputFile.txt";

			try
			{
				RemoveFileOddLines(sourcePath);
				Console.WriteLine("Odd lines removed successfully.");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private static void RemoveFileOddLines(string source)
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
				int lineIndex = 0;
				string currentLine;
				do
				{
					currentLine = streamReader.ReadLine();
					if (lineIndex%2 == 0)
					{
						streamWriter.WriteLine(currentLine);
					}

					lineIndex++;
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