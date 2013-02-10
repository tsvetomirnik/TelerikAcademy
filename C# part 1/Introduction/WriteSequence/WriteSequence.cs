/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 */
using System;

namespace WriteSequence
{
	class WriteSequence
	{
		static void Main()
		{
			const int firstSequenceNumber = 2;

			for (int i = 0; i < 10; i++)
			{
				int number = i + firstSequenceNumber;
				
				//Check for odd numbers
				if (number % 2 != 0)
					number *= -1;

				Console.WriteLine(number);
			}
		}
	}
}
