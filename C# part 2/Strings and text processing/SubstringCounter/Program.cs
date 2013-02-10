/* Task 4: Write a program that finds how many times a substring is contained
 * in a given text (perform case insensitive search).
 */

using System;

namespace SubstringCounter
{
	internal class Program
	{
		private static void Main()
		{
			const string content = "We are living in an yellow submarine. We don't have " +
			                       "anything else. Inside the submarine is very tight. So " +
			                       "we are drinking all the day. We will move out of it in 5 days.";

			Console.WriteLine(GetSubstringCount(content, "in"));
		}

		private static int GetSubstringCount(string content, string substring)
		{
			int subCount = 0;
			int subIndex;
			do
			{
				subIndex = content.IndexOf(substring, StringComparison.InvariantCultureIgnoreCase);
				if (subIndex > 0)
				{
					content = content.Remove(subIndex, substring.Length);
					subCount++;
				}
			} while (subIndex >= 0);

			return subCount;
		}
	}
}