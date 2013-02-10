/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 *
 * Task 4: Write a program that reads two positive integer numbers and prints 
 * how many numbers p exist between them such that the reminder of the division
 * by 5 is 0 (inclusive).
 * 
 */

using System;

namespace DivisionBy5
{
    class DivisionBy5
    {
        static void Main()
        {
            int minValue;
            do
            {
                Console.Write("Insert min range value: ");
            } while (!int.TryParse(Console.ReadLine(), out minValue));

            int maxValue;
            do
            {
                Console.Write("Insert max range value: ");
            } while (!int.TryParse(Console.ReadLine(), out maxValue));

			if(minValue > maxValue)
			{
				Console.WriteLine("Max value must be bigger than the min value.");
				return;
			}

            int count = 0;

			if (minValue % 5 == 0)
				count++;

			//Get the interval length and devide by 5
			var modulusDifference = minValue % 5 - maxValue % 5;

			if (modulusDifference < 0)
				modulusDifference = 0;

            count += (maxValue - minValue + modulusDifference) / 5;
            Console.WriteLine("There are {0} numbers divisibles of 5 in range of [{1}:{2}].", count, minValue, maxValue);
        }
    }
}
