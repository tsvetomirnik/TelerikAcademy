/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 *
 * Task 5: Write a program that gets two numbers from the
 * console and prints the greater of them. Don’t use if statements.
 * 
 */

using System;

namespace PrintMaxValue
{
    class PrintMaxValue
    {
        static void Main()
        {
            int a;
            do
            {
                Console.Write("insert a: ");
            } while (!int.TryParse(Console.ReadLine(), out a));

            int b;
            do
            {
                Console.Write("insert b: ");
            } while (!int.TryParse(Console.ReadLine(), out b));

            Console.WriteLine("{0} is greater", Math.Max(a, b));
        }
    }
}
