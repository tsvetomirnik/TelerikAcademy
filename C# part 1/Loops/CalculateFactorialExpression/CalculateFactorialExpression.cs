/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 5:	Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).
 * 
 */

using System;
using System.Numerics;
using LoopsLibrary;

namespace CalculateFactorialExpression
{
    class CalculateFactorialExpression
    {
        static void Main(string[] args)
        {
            int n = GetConsoleNumber(1);
            int k = GetConsoleNumber(n);

            var result = (n.Factorial() * k.Factorial()) / (k - n).Factorial();
            Console.WriteLine("N! * K! / (K - N)! \r\nwhere \r\nN={0} K={1} \r\nequals {2}", n, k, result);
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
