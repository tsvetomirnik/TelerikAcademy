using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NumeralSystemTransforms
{
	public static class NumeralTransforms
	{
		/// <summary>
		/// Converts decimal numbers to their binary representation
		/// </summary>
		public static string DecimalToBinary(int value)
		{
			var binrayNumber = new StringBuilder();
			while (value > 0)
			{
				binrayNumber.Insert(0, value%2);
				value = value/2;
			}

			return binrayNumber.ToString();
		}

		/// <summary>
		/// Converts binary numbers to their decimal representation
		/// </summary>
		public static int BinaryToDecimal(string value)
		{
			char[] charArray = value.ToCharArray();
			Array.Reverse(charArray);
			value = new string(charArray);

			int decimalNumber = 0;
			for (int i = 0; i < value.Length; i++)
			{
				byte cuurentValue = byte.Parse(value[i].ToString());
				decimalNumber += (int) (cuurentValue*Math.Pow(2, i));
			}

			return decimalNumber;
		}

		/// <summary>
		/// Converts decimal numbers to their hexadecimal representation
		/// </summary>
		public static string DecimalToHexadecimal(int value)
		{
			var hexadecimalNumber = new StringBuilder();
			while (value > 0)
			{
				hexadecimalNumber.Insert(0, (GetChar(value%16)));
				value = value/16;
			}

			return hexadecimalNumber.ToString();
		}

		/// <summary>
		/// Converts hexadecimal numbers to their decimal representation
		/// </summary>
		public static int HexadecimalToDecimal(string value)
		{
			char[] charArray = value.ToCharArray();
			Array.Reverse(charArray);
			value = new string(charArray);

			int decimalNumber = 0;
			for (int i = 0; i < value.Length; i++)
			{
				byte currentValue = GetNumber(value[i]);
				decimalNumber += (int) (currentValue*Math.Pow(16, i));
			}

			return decimalNumber;
		}

		/// <summary>
		/// Converts hexadecimal numbers to binary numbers
		/// </summary>
		public static string HexadecimalToBinary(string value)
		{
			var binaryNumber = new StringBuilder();
			for (int i = 0; i < value.Length; i++)
			{
				binaryNumber.Append(GetBitesFromHex(value[i].ToString()));
			}

			return binaryNumber.ToString();
		}

		/// <summary>
		/// Converts binary numbers to hexadecimal numbers
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string BinaryToHexadecimal(string value)
		{
			var binaryNumber = new StringBuilder();
			for (int i = 0; i < value.Length; i += 4)
			{
				binaryNumber.Append(GetHexFromBites(value.Substring(i, 4)));
			}

			return binaryNumber.ToString();
		}

		/// <summary>
		/// Convert from any numeral system of given base to any other numeral system of base 
		/// </summary>
		public static string ChangeBase(string value, byte targetBase)
		{
			int hex = HexadecimalToDecimal(value);

			var hexadecimalNumber = new StringBuilder();
			while (hex > 0)
			{
				hexadecimalNumber.Insert(0, (GetChar(hex%targetBase)));
				hex = hex/targetBase;
			}

			return hexadecimalNumber.ToString();
		}

		public static string ToBinary(this short value)
		{
			int size = Marshal.SizeOf(value.GetType());
			return Convert.ToString((int) value, 2).PadLeft(size, '0');
		}

		private static char GetChar(int value)
		{
			if (value < 10)
			{
				return (char) ('0' + value);
			}

			return (char) ('A' + (value - 10));
		}

		private static byte GetNumber(char c)
		{
			var value = (byte) (c - '0');
			if (value < 10)
			{
				return value;
			}

			return (byte) ('A' - c + 10);
		}

		private static string GetBitesFromHex(string hex)
		{
			switch (hex.ToUpper())
			{
				case "0":
					return "0000";
				case "1":
					return "0001";
				case "2":
					return "0010";
				case "3":
					return "0011";
				case "4":
					return "0100";
				case "5":
					return "0101";
				case "6":
					return "0110";
				case "7":
					return "0111";
				case "8":
					return "1000";
				case "9":
					return "1001";
				case "A":
					return "1010";
				case "B":
					return "1011";
				case "C":
					return "1100";
				case "D":
					return "1101";
				case "E":
					return "1110";
				case "F":
					return "1111";
				default:
					throw new Exception("Wrong hex format.");
			}
		}

		private static char GetHexFromBites(string bites)
		{
			switch (bites)
			{
				case "0000":
					return '0';
				case "0001":
					return '1';
				case "0010":
					return '2';
				case "0011":
					return '3';
				case "0100":
					return '4';
				case "0101":
					return '5';
				case "0110":
					return '6';
				case "0111":
					return '7';
				case "1000":
					return '8';
				case "1001":
					return '9';
				case "1010":
					return 'A';
				case "1011":
					return 'B';
				case "1100":
					return 'C';
				case "1101":
					return 'D';
				case "1110":
					return 'E';
				case "1111":
					return 'F';
				default:
					throw new Exception("Wrong binary format.");
			}
		}
	}
}