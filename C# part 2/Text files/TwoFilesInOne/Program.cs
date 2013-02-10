/* Task 2: Write a program that concatenates two text files into another text file.
 */

using System;
using System.IO;

namespace TwoFilesInOne
{
	internal class Program
	{
		private static void Main()
		{
			const string file1Path = @"../../File1.txt";
			const string file2Path = @"../../File2.txt";
			string targetPath = Directory.GetCurrentDirectory() + "\\ResultFile.txt";

			try
			{
				string content1 = GetFileContent(file1Path);
				WriteTextToFile(targetPath, content1);
				string content2 = GetFileContent(file2Path);
				WriteTextToFile(targetPath, content2);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		private static void WriteTextToFile(string path, string content)
		{
			using (var streamWriter = new StreamWriter(path, true))
			{
				streamWriter.WriteLine(content);
			}
		}

		//private static void PrintFileContent(string path1, string path2, string targetPath)
		//{
		//    var streamReader1 = new StreamReader(path1);
		//    var streamReader2 = new StreamReader(path2);
		//    var steamWriter = new StreamWriter(targetPath);

		//    string line1;
		//    string line2;
		//    try
		//    {
		//        do
		//        {
		//            line1 = streamReader1.ReadLine();
		//            line2 = streamReader2.ReadLine();
		//            s

		//        } while (line1 == null && line2 == null);
		//    }
		//    catch (Exception)
		//    {

		//        throw;
		//    }
		//    finally
		//    {
		//        streamReader1.Close();
		//        streamReader2.Close();
		//        steamWriter.Close();
		//    }
		//}

		private static string GetFileContent(string path)
		{
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(string.Format("File \"{0}\" was not found.", path));
			}

			try
			{
				string content = File.ReadAllText(path);
				return content;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}