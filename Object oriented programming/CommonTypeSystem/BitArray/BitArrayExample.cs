using System;
using System.Linq;

namespace BitArray
{
	class BitArrayExample
	{
		static void Main(string[] args)
		{
			BitArray64 bitArray = new BitArray64(358);

			Console.WriteLine(bitArray.ToString());

			ShowIndexValue(bitArray, 0);
			ShowIndexValue(bitArray, 1);
			ShowIndexValue(bitArray, 2);
			ShowIndexValue(bitArray, 3);
			Console.WriteLine();

			// New array isntance with same value
			BitArray64 bitArray2 = new BitArray64(358);
			Console.WriteLine("Array 2:");
			Console.WriteLine(bitArray2.ToString());
			Console.WriteLine();

			Console.WriteLine("The arrays are equals -> {0}.", bitArray == bitArray2);
		}
  
		private static void ShowIndexValue(BitArray64 array, int index)
		{
			Console.WriteLine("Value at index {0} is {1}.", index, array[index]);
		}
	}
}