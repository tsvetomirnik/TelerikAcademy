/* Task 3: Write a program that reads a text file and inserts line numbers
 * in front of each of its lines. The result should be written to another
 * text file.
 */

using System;
using System.IO;

namespace LineNumbersInserter
{
	internal class Program
	{
		private static void Main()
		{
			const string sourcePath = @"../../Instructions.txt";
			string targetPath = Directory.GetCurrentDirectory() + "\\NumeredFile.txt";

			try
			{
				CreateNumeredFile(sourcePath, targetPath);
				Console.WriteLine("Successfully created!");
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private static void CreateNumeredFile(string source, string targetPath)
		{
			var streamReader = new StreamReader(source);
			var streamWriter = new StreamWriter(targetPath);

			string currentLine;
			int lineNumber = 1;
			try
			{
				do
				{
					currentLine = streamReader.ReadLine();
					if (currentLine != null && currentLine.Trim() != string.Empty)
					{
						streamWriter.WriteLine("{0}: {1}", lineNumber++, currentLine);
					}
					else
					{
						streamWriter.WriteLine(currentLine);
					}
				} while (currentLine != null);
			}
			catch (Exception ex)
			{
				//Clear the new file on error
				if (File.Exists(targetPath))
				{
					File.Delete(targetPath);
				}

				throw new Exception("Filed creating file.", ex.InnerException);
			}
			finally
			{
				streamReader.Close();
				streamWriter.Close();
			}
		}
	}
}