/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 4:	Write a program that calculates N!/K! for given N and K (1<K<N).
 * 
 */

using System;
using System.Numerics;
using LoopsLibrary;

namespace DevideFactorials
{
    class DevideFactorials
    {
        static void Main(string[] args)
        {
            int k = GetConsoleNumber(1);
            int n = GetConsoleNumber(k);

            var result = n.Factorial() / k.Factorial();
            Console.WriteLine(result);
        }

        private static int GetConsoleNumber(int minValue)
        {
            int number;
            bool isValid;
            do
            {
                Console.Write("Insert number bigger than {0}: ", minValue);
                string input = Console.ReadLine();
                bool IsParsed = int.TryParse(input, out number);
                bool IsInRange = number > minValue;
                isValid = IsParsed && IsInRange;

                if (!IsParsed)
                {
                    Console.WriteLine("\"{0}\" is not valid integer number.", input);
                }

                if (!IsInRange)
                {
                    Console.WriteLine("Inserted number must be bigger than {0}.", minValue);
                }

            } while (!isValid);

            return number;
        }
    }
}
