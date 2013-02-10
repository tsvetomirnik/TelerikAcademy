/* Task 4: Write a program that compares two text files line by
 * line and prints the number of lines that are the same and the
 * number of lines that are different. Assume the files have 
 * equal number of lines.
 */

using System;
using System.IO;

namespace LinesComparison
{
	internal class Program
	{
		private static void Main()
		{
			const string file1Path = @"../../File1.txt";
			const string file2Path = @"../../File2.txt";

			try
			{
				CompareLines(file1Path, file2Path);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private static void CompareLines(string path1, string path2)
		{
			var streamReader1 = new StreamReader(path1);
			var streamReader2 = new StreamReader(path2);

			int totalLines = 0;
			int equalLines = 0;

			string line1;
			string line2;
			try
			{
				do
				{
					line1 = streamReader1.ReadLine();
					line2 = streamReader2.ReadLine();

					totalLines++;
					if (line1 == line2)
					{
						equalLines++;
					}
				} while (line1 != null && line2 != null);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				streamReader1.Close();
				streamReader2.Close();
			}

			Console.WriteLine("Equal lines: {0}; Different lines: {1};", equalLines, totalLines - equalLines);
		}
	}
}