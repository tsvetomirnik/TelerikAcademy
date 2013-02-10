/*
 * Task 1: Write a method that asks the user for his name and prints "Hello, <name>"
 * (for example, "Hello, Peter!"). Write a program to test this method.
 * 
 */

using System;

namespace HelloMethod
{
	internal class Program
	{
		private static void Main()
		{
			PrintUserName();
		}

		private static void PrintUserName()
		{
			Console.Write("Please, insert your username: ");
			string name = Console.ReadLine();

			if (name == null)
			{
				name = "stranger";
			}

			Console.WriteLine("Hello, {0}.", name);
		}
	}
}