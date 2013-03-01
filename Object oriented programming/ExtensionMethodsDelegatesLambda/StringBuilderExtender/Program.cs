using System;
using System.Text;

namespace StringBuilderExtender
{
	class Program
	{
		static void Main()
		{
			const int SubstringBeginning = 7;
			const int SubstringLength = 5;
			const string Greeting = "Hello, World!";
			var stringBuilder = new StringBuilder("Hello, World!");

			Console.WriteLine(Greeting);
			var substring = stringBuilder.Substring(SubstringBeginning, SubstringLength).ToString();
			Console.WriteLine("The string from index [{0}] with length [{1}] is [{2}]",
				SubstringBeginning,
				SubstringLength,
				substring);
		}
	}
}