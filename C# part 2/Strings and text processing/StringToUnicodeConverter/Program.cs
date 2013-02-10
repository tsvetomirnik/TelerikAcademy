/* Task 10: Write a program that converts a string to a sequence of C#
 * Unicode character literals. Use format strings. 
 */

using System;
using System.Text;

namespace StringToUnicodeConverter
{
	internal class Program
	{
		private static void Main()
		{
			Console.WriteLine(ToUnicode("Hi!"));
		}

		private static string ToUnicode(string text)
		{
			var stringBuilder = new StringBuilder();
			foreach (char c in text)
			{
				stringBuilder.Append(string.Format("\\u{0:X4}", (int) c));
			}

			return stringBuilder.ToString();
		}
	}
}