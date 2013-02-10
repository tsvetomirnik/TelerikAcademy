/* Task 1: Write a program that reads a text file and prints on the 
 * console its odd lines.
 */

using System;
using System.IO;
using System.Text;

namespace OddLinesPrinter
{
	internal class Program
	{
		private static void Main()
		{
			const string filePath = @"../../Students.txt";

			try
			{
				PrintFileContent(filePath);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private static void PrintFileContent(string path)
		{
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(string.Format("File \"{0}\" was not found.", path));
			}

			using (var streamReader = new StreamReader(path, Encoding.UTF8))
			{
				bool isOdd = false;
				string line;
				do
				{
					try
					{
						line = streamReader.ReadLine();
					}
					catch (IOException)
					{
						throw new IOException("Unbale to read file.");
					}

					if (isOdd)
					{
						Console.WriteLine(line);
					}

					isOdd = !isOdd;
				} while (line != null);
			}
		}
	}
}