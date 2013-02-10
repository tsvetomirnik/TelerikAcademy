/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 */
using System;

namespace WriteAgeAfterTenYears
{
	class WriteAgeAfterTenYears
	{
		static void Main()
		{
			const string insertAgeText = "Your age: ";
			const string invalidAgeText = "Type in a valid number.";
			const string finalAgeText = "After {0} years you will be {1} years old.";
			const int yearsOffset = 10;

			int age;
			bool isInputValid;
			do
			{
				Console.Write(insertAgeText);
				isInputValid = int.TryParse(Console.ReadLine(), out age);

				if(!isInputValid)
				{
					Console.WriteLine(invalidAgeText);	
				}
					
			} while(!isInputValid);

			int finalAge = age + yearsOffset;
			Console.WriteLine(finalAgeText, yearsOffset, finalAge);
		}
	}
}
