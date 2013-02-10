/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 11: * Write a program that converts a number in 
 * the range [0...999] to a text corresponding to its 
 * English pronunciation. 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumberName
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine(GetNumberName(12));
			Console.WriteLine(GetNumberName(52));
			Console.WriteLine(GetNumberName(70));
		}

		private static string GetNumberName(ushort number)
		{
			if(number > 999)
			{
				throw new ArgumentException("number must be less than 999");
			}

			if(number < 10)
			{
				return GetTo10(number);
			}else
			{
				string dec = null;
				switch (number)
				{
					case 20: dec = "Twenty"; break;
					case 30: dec = "Thirty"; break;
					case 40: dec = "Forty"; break;
					case 50: dec = "Fifty"; break;
					case 60: dec = "Sixty"; break;
					case 70: dec = "Sevety"; break;
					case 80: dec = "Eighty"; break;
					case 90: dec = "Ninty"; break;
				}

				if(number%10 == 0)
				{
					return dec + " " + GetTo20((ushort) (number%10)).ToLower();
				}
			}

			return null;
		}

		private static string GetTo10(ushort number)
		{
			if(number > 10)
			{
				throw new ArgumentException("number must be less than 10");
			}

			string result = null;
			switch (number)
			{
				case 0: result= "Zero"; break;
				case 1: result= "One"; break;
				case 2: result= "Two"; break;
				case 3: result= "Thee"; break;
				case 4: result= "Four"; break;
				case 5: result= "Five"; break;
				case 6: result= "Six"; break;
				case 7: result= "Seven"; break;
				case 8: result= "Eight"; break;
				case 9: result= "Nine"; break;
			}

			return result;
		}

		
		private static string GetTo20(ushort number)
		{
			if(number > 20)
			{
				throw new ArgumentException("number must be less than 20");
			}

			string result = null;
			switch (number)
			{
				case 1: result= "One"; break;
				case 2: result= "Two"; break;
				case 3: result= "Thee"; break;
				case 4: result= "Four"; break;
				case 5: result= "Five"; break;
				case 6: result= "Six"; break;
				case 7: result= "Seven"; break;
				case 8: result= "Eight"; break;
				case 9: result= "Nine"; break;
				case 10: result = "Ten"; break;
				case 11: result = "Eleven"; break;
				case 12: result = "Twelve"; break;
				case 13: result = "Thirteen"; break;
				case 14: result = "Fourteen"; break;
				case 15: result = "Fifteen"; break;
				case 16: result = "Sixteen"; break;
				case 17: result = "Seventeen"; break;
				case 18: result = "Eighteen"; break;
				case 19: result = "Ninteen"; break;
				case 20: result = "Twenty"; break;
				default: result = string.Empty; break;
			}

			return result;
		}
	}
}
