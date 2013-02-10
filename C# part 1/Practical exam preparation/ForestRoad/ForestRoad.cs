/*
 * Author: Tsvetomir Nikolov
 * Email: cvetomir.nikolov@gmail.com
 * Task: Forest Road
 * BGCoder result: 100%
 */

using System;

namespace ForestRoad
{
	class ForestRoad
	{
		static void Main()
		{
			const char asterisk = '*';
			const char dot = '.';

			byte width = byte.Parse(Console.ReadLine());
			byte height = (byte) (width * 2 - 1);

			byte asteriskOffset = 0;
			for (int i = 0; i < height; i++)
			{
				int widthWithoutAsterisk = width - 1; 

				Console.Write(new string(dot, asteriskOffset));
				Console.Write(asterisk);
				Console.Write(new string(dot, widthWithoutAsterisk - asteriskOffset));
			
				if(i < widthWithoutAsterisk)
				{
					asteriskOffset++;
				}
				else
				{
					asteriskOffset--;
				}

				Console.WriteLine();
			}
		}
	}
}

