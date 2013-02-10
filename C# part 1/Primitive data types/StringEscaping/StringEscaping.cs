/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 8: Declare two string variables and assign them with following value:
 * The "use" of quotations causes difficulties.
 *	Do the above in two different ways: with and without using quoted strings.
 * 
 */

namespace StringEscaping
{
	class StringEscaping
	{
		static void Main()
		{
			const string escapedWithSlashes = "The \"use\" of quotations causes difficulties.";
			const string withoutQuotes = "The use of quotations causes difficulties.";
		}
	}
}
