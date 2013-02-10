/*
 * Author: Tsvetomir Nikolov
 * Email: cvetomir.nikolov@gmail.com
 */

using System;
using System.Numerics;

namespace Task2
{
	class Task2
	{
		static void Main()
		{
			const int charOffsetToNumber = 64;

			string firstElement = Console.ReadLine();
			string secondElement = Console.ReadLine();
			int lineToShow = int.Parse(Console.ReadLine());

			if(lineToShow > 0)
			{
				Console.WriteLine(firstElement);
			}

			BigInteger a = firstElement[0] - charOffsetToNumber;
			BigInteger b = secondElement[0] - charOffsetToNumber;
			
			int offset = 0;
			for (int i = 0; i < (lineToShow-1)*2; i++)
			{
				BigInteger temp = a;
				a = b;
				b = temp + b;

				while(b > 26)
				{
					b = b%26;
				}

				char element = (char) (a + charOffsetToNumber);
				Console.Write(element);

				//Add offset or new line
				if(i%2 == 0)
				{
					Console.Write(new string(' ', offset++));
				}
				else
				{
					Console.WriteLine();
				}
			}
		}
	}
}
