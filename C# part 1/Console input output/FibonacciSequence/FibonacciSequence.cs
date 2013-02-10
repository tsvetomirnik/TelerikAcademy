/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 *
 * Task 9: Write a program to print the first 100 members 
 * of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5 …
 * 
 */

using System;

namespace FibonacciSequence
{
    class FibonacciSequence
    {
        static void Main()
        {
            const int sequenceLength = 100;
			long a = 0;
            long b = 1;

            for (int i = 0; i < sequenceLength; i++)
            {
				Console.WriteLine("#{0}:{1}", i+1 ,a);
                long temp = a;
                a = b;
                b = temp + b;
            }
        }
    }
}
