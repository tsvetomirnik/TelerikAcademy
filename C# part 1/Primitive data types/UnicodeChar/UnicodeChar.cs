/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 5: Declare a character variable and assign it with the symbol 
 * that has Unicode code 72. Hint: first use the Windows Calculator
 * to find the hexadecimal representation of 72.
 * 
 */

using System;

namespace UnicodeChar
{
	class UnicodeChar
	{
		static void Main()
		{
			const char unicodeChar = '\u0048';
			Console.WriteLine(unicodeChar);
		}
	}
}
