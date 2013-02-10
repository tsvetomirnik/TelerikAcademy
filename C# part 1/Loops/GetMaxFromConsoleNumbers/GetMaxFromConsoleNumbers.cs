/*
 * Author:	Tsvetomir Nikolov
 * Number:	6001771
 * Email:	cvetomir.nikolov@gmail.com
 * Task 3:	Write a program that reads from the console a sequence of N 
 *			integer numbers and returns the minimal and maximal of them.
 * 
 */

using System;

namespace GetMaxFromConsoleNumbers
{
    class GetMaxFromConsoleNumbers
    {
        static void Main(string[] args)
        {
            int numberCount = GetNumberCount();
            int maxNumber = 0;
            for (int i = 0; i < numberCount; i++)
            {
                var insertedNumber = GetConsoleNumber();
                if (insertedNumber > maxNumber) 
                {
                    maxNumber = insertedNumber;
                }
            }

            Console.WriteLine("Max number from inserted numbers is {0}.", maxNumber);
        }

        private static int GetNumberCount()
        {
            int numbersCount;
            bool isValid;
            do
            {
                Console.Write("Insert numbers count: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out numbersCount);

                if (!isValid)
                {
                    Console.WriteLine("{0} is not valid integer number.", input);
                }
            } while (!isValid);

            return numbersCount;
        }

        private static int GetConsoleNumber()
        {
            int number;
            bool isValid;
            do
            {
                Console.Write("Insert number: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out number);

                if (!isValid)
                {
                    Console.WriteLine("{0} is not valid integer number.", input);
                }
            } while (!isValid);

            return number;
        }
    }
}
