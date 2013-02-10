/* Task 3: Write a program to check if in a given expression the
 * brackets are put correctly.
 */

using System;

namespace BracketsChecker
{
	internal class Program
	{
		private static void Main()
		{
			string equation = "((a+b)/5-d)";
			Console.WriteLine(AreBracketsCorrent(equation));

			equation = ")(a+b)/5-d)";
			Console.WriteLine(AreBracketsCorrent(equation));
		}

		private static bool AreBracketsCorrent(string content)
		{
			int openBracketsCount = 0;
			int closingBracketsCount = 0;

			foreach (char character in content)
			{
				if (character == '(')
				{
					openBracketsCount++;
				}

				if (character == ')')
				{
					closingBracketsCount++;
				}
			}

			return openBracketsCount == closingBracketsCount;
		}
	}
}