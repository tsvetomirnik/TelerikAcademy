/*
 * Author: Tsvetomir Nikolov
 * Email: cvetomir.nikolov@gmail.com
 */

using System;

namespace Task4
{
	internal class Task4
	{
		public const char Asterisk = '*';
		public const char Dot = '.';
		public static int Width;

		private static void Main()
		{
			int x = int.Parse(Console.ReadLine());
			int y = x;
			int z = (x + 1)/2;

			Width = (x - 1)*2 + (z - 1)*2 + 1;

			PrintHorns(z, y);
			PrintRhomb(x);
		}

		private static void PrintHorns(int z, int y)
		{
			int zBlank = z - 1;

			var firstLine = new string(Dot, Width - 2);
			firstLine = firstLine.Insert(zBlank, Asterisk.ToString());
			firstLine = firstLine.Insert(Width - z, Asterisk.ToString());
			zBlank--;

			Console.WriteLine(firstLine);

			int yBlank = zBlank + 2;
			for (int i = 0; i < y - 2; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					if (j == zBlank || j == Width - 1 - zBlank)
					{
						Console.Write(Asterisk);
					}
					else if (j == yBlank || j == Width - 1 - yBlank)
					{
						Console.Write(Asterisk);
					}
					else
					{
						Console.Write(Dot);
					}
				}

				zBlank--;
				yBlank++;
				Console.WriteLine();
			}
		}

		private static void PrintRhomb(int x)
		{
			int rhombHeight = x*2 - 1;
			int rhombОffset = Width/2;

			for (int i = 0; i < rhombHeight; i++)
			{
				for (int j = 0; j < Width; j++)
				{
					if (j == rhombОffset || j == Width - 1 - rhombОffset)
					{
						Console.Write(Asterisk);
					}
					else
					{
						Console.Write(Dot);
					}
				}

				//Expand or constrict the rhomb
				rhombОffset =
					i >= x - 1 
						? rhombОffset - 1
						: rhombОffset + 1;

				Console.WriteLine();
			}
		}
	}
}
