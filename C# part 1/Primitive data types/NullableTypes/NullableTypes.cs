/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 13: Create a program that assigns null values to an integer
 * and to double variables. Try to print them on the console, try
 * to add some values or the null literal to them and see the result.
 * 
 */

using System;

namespace NullableTypes
{
	class NullableTypes
	{
		static void Main()
		{
			int? nullableInt = null;
			Console.WriteLine(nullableInt + 1);
			Console.WriteLine(nullableInt + null);

			double? nullableDouble = null;
			Console.WriteLine(nullableDouble + 1);
			Console.WriteLine(nullableDouble + null);
			//The result from operations with null are null and the console prints nothing
		}
	}
}
