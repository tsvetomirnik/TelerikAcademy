/* Task 2: Write a program that reads a string, reverses it and
 * prints the result at the console.
 */

using System;

namespace StringReverser
{
	internal class Program
	{
		private static void Main()
		{
			const string word = "sample";
			Console.WriteLine(ReverseString(word));
		}

		private static string ReverseString(string content)
		{
			char[] chars = content.ToCharArray();
			Array.Reverse(chars);
			return new string(chars);
		}
	}
}