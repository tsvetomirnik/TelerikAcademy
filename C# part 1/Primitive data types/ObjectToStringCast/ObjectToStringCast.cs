/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 7: Declare two string variables and assign them with
 * “Hello” and “World”. Declare an object variable and assign
 * it with the concatenation of the first two variables (mind
 * adding an interval). Declare a third string variable and 
 * initialize it with the value of the object variable (you
 * should perform type casting).
 * 
 */

using System;

namespace ObjectToStringCast
{
	class ObjectToStringCast
	{
		static void Main()
		{
			const string helloPart = "Hello";
			const string worldPart = "World";
			object greeting = string.Format("{0}, {1}!", helloPart, worldPart);
			string greetingString = greeting.ToString();
			Console.WriteLine(greetingString);
		}
	}
}
