/*
 * Task 5: You are given an array of strings. Write a method that sorts the array by 
 * the length of its elements (the number of characters composing them).
 */

using System;

namespace StringsSorter
{
	internal class StringsSorter
	{
		private static void Main()
		{
			Console.Write("How many word do you want to insert: ");
			int n = int.Parse(Console.ReadLine());

			var words = new string[n];
			for (int i = 0; i < n; i++)
			{
				Console.Write("Insert #{0} string: ", i + 1);
				words[i] = Console.ReadLine();
			}

			SortUsingLambda(ref words);
			Console.WriteLine("SORTED WORDS BY LENGTH");
			PrintArray(words);
		}

		private static void SortUsingLambda(ref string[] array)
		{
			Array.Sort(array, (x, y) =>
			                  	{
			                  		if (x.Length < y.Length)
			                  		{
			                  			return -1;
			                  		}

			                  		if (x.Length > y.Length)
			                  		{
			                  			return 1;
			                  		}

			                  		return 0;
			                  	});
		}

		private static void PrintArray(string[] words)
		{
			foreach (string word in words)
			{
				Console.WriteLine(word);
			}
		}
	}
}