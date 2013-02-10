/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 *
 * Task 7: Write a program that gets a number n and after that
 * gets more n numbers and calculates and prints their sum. 
 * 
 */

using System;

namespace SumXNumbers
{
    class SumXNumbers
    {
        static void Main()
        {

            int numbersCount;
            do
            {
                Console.Write("Insert numbers count: ");
                int.TryParse(Console.ReadLine(), out numbersCount);
            } while (numbersCount <= 0);

            int sum = 0;

            for (int i = 0; i < numbersCount; i++)
            {
                int number;

                do{
                    Console.Write("#{0} number: ", i+1);
                } while (!int.TryParse(Console.ReadLine(), out number));

                sum += number;
            }

	        Console.WriteLine("The sum of the inserted numbers is {0}.", sum);
        }
    }
}
