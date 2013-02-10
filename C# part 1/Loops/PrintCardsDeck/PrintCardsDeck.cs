/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 11:	Write a program that prints all possible cards from a standard deck 
 *			of 52 cards (without jokers). The cards should be printed with their 
 *			English names. Use nested for loops and switch-case.
 * 
 */

using System;
using System.Text;

namespace PrintCardsDeck
{
	class PrintCardsDeck
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 13; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					var rank = GetRank(i);
					char suit = GetSuit(j);
					Console.WriteLine(rank + suit);
				}
			}
		}

		private static string GetRank(int index)
		{
			string rank;
			switch (index)
			{
				case 0:
					rank = "A";
					break;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
					rank = (index + 1).ToString();
					break;
				case 10:
					rank = "J";
					break;
				case 11:
					rank = "Q";
					break;
				case 12:
					rank = "K";
					break;
				default:
					throw new Exception("Not valid card index.");
			}

			return rank;
		}

		private static char GetSuit(int index)
		{
			const char clubsSuit = '\u2663';
			const char diamondsSuit = '\u2666'; 
			const char heartsSuit = '\u2665';
			const char spadesSuit = '\u2660';

			char suit;
			switch (index)
			{
				case 0:
					suit = clubsSuit;
					break;
				case 1:
					suit = diamondsSuit;
					break;
				case 2:
					suit = heartsSuit;
					break;
				case 3:
					suit = spadesSuit;
					break;
				default:
					throw new ArgumentOutOfRangeException("index");
			}

			return suit;
		}
	}
}
