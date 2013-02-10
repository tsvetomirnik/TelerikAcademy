/*
 * Task 20: Write a program that reads two numbers N and K and generates 
 * all the variations of K elements from the set [1..N]. 
 */

using System;

namespace PrintAllVariations
{
	class PrintAllVariations
	{
		private static int _elementsCount;
		private static int _sizeOfSet;

		static void Main()
		{
			Console.Write("Insert elements count: ");
			_elementsCount = int.Parse(Console.ReadLine());

			Console.Write("Insert set size: ");
			_sizeOfSet = int.Parse(Console.ReadLine());

			int[] variations = new int[_sizeOfSet];

			GetVariations(variations, 0);
		}

		private static void GetVariations(int[] variations, int index)
		{
			if(variations.Length == index)
			{
				PrintVariation(variations);
			}
			else
			{
				for (int i = 1; i <= _elementsCount; i++)
				{
					variations[index] = i;
					GetVariations(variations, index + 1);
				}
			}
		}

		private static void PrintVariation(int[] variations)
		{
			Console.Write("{");
			for (int i = 0; i < variations.Length; i++)
			{
				Console.Write(variations[i]);

				if(i < variations.Length - 1)
				{
					Console.Write(", ");
				}
			}
			Console.WriteLine("}");
		}
	}
}
