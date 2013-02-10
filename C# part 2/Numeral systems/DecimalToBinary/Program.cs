using System;
using NumeralSystemTransforms;

namespace DecimalToBinary
{
	internal class Program
	{
		private static void Main()
		{
			//Task 1: Write a program to convert decimal numbers to their binary representation.
			Console.WriteLine(NumeralTransforms.DecimalToBinary(21));

			//Task 2: Write a program to convert binary numbers to their decimal representation.
			Console.WriteLine(NumeralTransforms.BinaryToDecimal("000010011111"));

			//Task 3: Write a program to convert decimal numbers to their hexadecimal representation.
			Console.WriteLine(NumeralTransforms.DecimalToHexadecimal(12882));

			//Task 4: Write a program to convert hexadecimal numbers to their decimal representation.
			Console.WriteLine(NumeralTransforms.HexadecimalToDecimal("FF1CAA"));

			//Task 5: Write a program to convert hexadecimal numbers to binary numbers (directly).
			Console.WriteLine(NumeralTransforms.HexadecimalToBinary("FF1CAA"));

			//Task 6: Write a program to convert binary numbers to hexadecimal numbers (directly).
			Console.WriteLine(NumeralTransforms.BinaryToHexadecimal("10101101"));

			//Task 7: Write a program to convert from any numeral system of given base s to any 
			//other numeral system of base d (2 ≤ s, d ≤  16).
			Console.WriteLine(NumeralTransforms.ChangeBase("187635", 3));

			//Task 8: Write a program that shows the binary representation of given 16-bit signed
			//integer number (the C# type short).
			Console.WriteLine(((short) 123).ToBinary());
		}
	}
}