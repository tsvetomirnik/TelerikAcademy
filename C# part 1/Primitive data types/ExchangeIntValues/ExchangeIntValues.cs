/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 11: Declare  two integer variables and assign them with 5 and 10
 * and after that exchange their values.
 * 
 */

using System;

namespace ExchangeIntValues
{
	class ExchangeIntValues
	{
		static void Main()
		{
			int firstValue = 5;
			int secondValue = 10;

			Console.WriteLine("Before: a={0} b={1}", firstValue, secondValue);

			firstValue = firstValue + secondValue;
			secondValue = firstValue - secondValue;
			firstValue = firstValue - secondValue;
			
			Console.WriteLine("After: a={0} b={1}", firstValue, secondValue);
		}
	}
}
