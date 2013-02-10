/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 */
using System;

namespace WriteBinaryNumbers
{
	class WriteBinaryNumbers
	{
		static void Main()
		{
			for (int i = 0; i < 3; i++)
			{
				int decimalNumber = i * 4 + 1;
				Console.WriteLine(Convert.ToString(decimalNumber, 2));
			}
		}
	}
}
