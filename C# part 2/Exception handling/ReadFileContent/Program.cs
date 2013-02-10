using System;
using System.IO;
using System.Security;

namespace ReadFileContent
{
	internal class Program
	{
		private static void Main()
		{
			string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
			Console.WriteLine("SELECT A FILE TO READ");
			Console.Write("PATH: ");
			Console.Write(filePath);
			filePath += Console.ReadLine();

			try
			{
				string content = File.ReadAllText(filePath);
				Console.WriteLine("FILE CONTENT");
				Console.WriteLine(content);
			}
			catch (ArgumentNullException)
			{
				Console.WriteLine("Not selected file path.");
			}
			catch (ArgumentException)
			{
				Console.WriteLine("File is not found.");
			}
			catch (DirectoryNotFoundException)
			{
				Console.WriteLine("Not found directory from given path.");
			}
			catch (FileNotFoundException)
			{
				Console.WriteLine("There is no such a file.");
			}
			catch (PathTooLongException)
			{
				Console.WriteLine("Selected path is too long.");
			}
			catch (IOException)
			{
				Console.WriteLine("Unable to read file.");
			}
			catch (UnauthorizedAccessException)
			{
				Console.WriteLine("You don't have permitions to read this file.");
			}
			catch (NotSupportedException)
			{
				Console.WriteLine("Unable to operate with the specified file.");
			}
			catch (SecurityException)
			{
				Console.WriteLine("Unable to read this file for security reasons");
			}
		}
	}
}