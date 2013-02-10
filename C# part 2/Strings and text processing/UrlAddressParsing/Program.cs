/* Task 12: Write a program that parses an URL address given 
 * in the format: [protocol]://[server]/[resource]
 */

using System;
using System.Text.RegularExpressions;

namespace UrlAddressParsing
{
	internal class Program
	{
		private static void Main()
		{
			const string url = "http://www.devbg.org/forum/index.php";
			const string urlExpression = "(.*)://(.*?)(/.*)";

			GroupCollection groups = Regex.Match(url, urlExpression).Groups;
			Console.WriteLine(groups[1]);
			Console.WriteLine(groups[2]);
			Console.WriteLine(groups[3]);
		}
	}
}