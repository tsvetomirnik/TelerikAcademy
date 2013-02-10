/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 *
 * Task 8: Write a program that reads an integer number n from
 * the console and prints all the numbers in the interval [1..n],
 * each on a single line.
 * 
 */

using System;
using System.Globalization;

namespace PrintRange
{
    class PrintRange
    {
        static void Main()
        {
            int maxNumber;
            do
            {
                Console.Write("Choose interval max value [1:X]: ");
            } while (!int.TryParse(Console.ReadLine(), out maxNumber));

            for (int i = 1; i <= maxNumber; i++)
            {
                Console.WriteLine(i.ToString(CultureInfo.InvariantCulture));   
            }
        }
    }
}
