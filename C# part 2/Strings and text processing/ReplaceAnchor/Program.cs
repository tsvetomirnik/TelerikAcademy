/* Task 15: Write a program that replaces in a HTML document given as
 * string all the tags <a href="…">…</a> with corresponding tags 
 * [URL=…]…[/URL]. 
 */

using System;

namespace ReplaceAnchor
{
	internal class Program
	{
		private static void Main()
		{
			const string content = "<p>Please visit <a href=\"http://academy.telerik.com\">" +
			                       "our site</a> to choose a training course. Also visit <a " +
			                       "href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

			Console.WriteLine(ConvertAnchors(content));
		}

		private static string ConvertAnchors(string text)
		{
			text = text.Replace("<a href=\"", "[URL=");
			text = text.Replace("\">", "]");
			text = text.Replace("</a>", "[/URL]");
			return text;
		}
	}
}