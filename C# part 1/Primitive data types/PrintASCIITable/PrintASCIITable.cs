/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 12: Find online more information about ASCII (American Standard Code
 * for Information Interchange) and write a program that prints the entire 
 * ASCII table of characters on the console.
 * 
 */

using System;

namespace PrintASCIITable
{
	class PrintASCIITable
	{
		static void Main()
		{
			//Show only printable characters
            for (byte counter = 32; counter < 128; counter++)
            {
               Console.WriteLine((char) counter);
            }
		}
	}
}
