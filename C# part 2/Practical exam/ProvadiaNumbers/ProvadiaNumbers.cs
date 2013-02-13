/*
 * Sent on: 2/4/2013 8:02:55 PM
 * Status: Accepted!
 * Points: 100 / 100
 * Full report: View full report
 * Max time used: 0.054 sec.
 * Max memory used: 1,020 kB
 * Language: C# Code
 * Zero tests passed: True
 * Has full points: True
 */

using System;
using System.Globalization;
using System.Numerics;
using System.Text;

namespace ProvadiaNumbers
{
	internal class ProvadiaNumbers
	{
		private static void Main()
		{
			BigInteger n = BigInteger.Parse(Console.ReadLine());
			Console.WriteLine(DecimalTo256(n));
		}

		public static string DecimalTo256(BigInteger value)
		{
			if (value == 0)
			{
				return "A";
			}

			string sign = "";
			if (value < 0)
			{
				sign = "-";
				value = value*(-1);
			}

			var result = new StringBuilder();
			while (value > 0)
			{
				string n = GetChar(value);
				result.Insert(0, n);
				value = value/256;
			}

			return sign + result;
		}

		private static string GetChar(BigInteger value)
		{
			value = value%256;

			string result;
			if (value < 26)
			{
				result = ((char) (value + 65)).ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				if (value < 52) result = "a";
				else if (value < 78) result = "b";
				else if (value < 104) result = "c";
				else if (value < 130) result = "d";
				else if (value < 156) result = "e";
				else if (value < 182) result = "f";
				else if (value < 234) result = "h";
				else if (value < 256) result = "i";
				else
				{
					throw new IndexOutOfRangeException();
				}

				value = value%26;
				result += ((char) (value + 65)).ToString(CultureInfo.InvariantCulture);
			}

			return result;
		}
	}
}