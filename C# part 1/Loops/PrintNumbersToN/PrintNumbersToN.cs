/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 1:	Write a program that prints all the numbers from 1 to N.
 * 
 */

using System;

namespace PrintNumbersToN
{
    class PrintNumbersToN
    {
        static void Main(string[] args)
        {
            PrintToN(6);
        }

        private static void PrintToN(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
