using System;
using System.Net;

namespace FileDownloader
{
	internal class Program
	{
		private static void Main()
		{
			const string fileAddress = "http://www.devbg.org/img/Logo-BASD.jpg";
			string targetPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\";

			Console.WriteLine("WHERE TO SAVE");
			Console.Write("Enter directory: ");
			Console.Write(targetPath);
			targetPath += Console.ReadLine();

			Console.Write("Enter filename: ");
			targetPath += Console.ReadLine() + ".jpg";

			using (var webClient = new WebClient())
			{
				try
				{
					webClient.DownloadFile(fileAddress, targetPath);
					Console.WriteLine("Download completed!");
				}
				catch (ArgumentNullException)
				{
					Console.WriteLine("Some of the addresses are not specified.");
				}
				catch (ArgumentException)
				{
					Console.WriteLine("Some of the addresses has invalid format.");
				}
				catch (WebException ex)
				{
					Console.Error.WriteLine("Some trubles appeared while tring to connect to the internet. " +
					                        "The reason is {0}.", ex.InnerException.ToString().ToLower());
				}
				catch (NotSupportedException ex)
				{
					Console.Error.WriteLine("ome trubles appeared while tring to download the resource. " +
					                        "The reason is {0}.", ex.InnerException.ToString().ToLower());
				}
			}
		}
	}
}