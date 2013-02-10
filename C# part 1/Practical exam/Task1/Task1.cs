/*
 * Author: Tsvetomir Nikolov
 * Email: cvetomir.nikolov@gmail.com
 */

using System;

namespace Task1
{
	class Task1
	{
		static void Main()
		{
			string input = Console.ReadLine();
			var numbers = new char[input.Length + 1];

			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = '0';
			}

			input.ToCharArray().CopyTo(numbers, 1);
			numbers[input.Length]++;

			for (int i = numbers.Length-1; i >= 0 ; i--)
			{
			    if(int.Parse(numbers[i].ToString())/7 >= 1)
			    {
			    	numbers[i] = '0';
			        numbers[i-1] = (char)(numbers[i-1] + 1);
			    }
			}
			
			var result = new string(numbers);
			Console.WriteLine(result.TrimStart('0'));
		}
	}
}
