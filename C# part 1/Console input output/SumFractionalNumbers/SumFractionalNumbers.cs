/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 *
 * Task 10: Write a program to calculate the sum 
 * (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
 * 
 */

using System;

namespace SumFractionalNumbers
{
    class SumFractionalNumbers
    {
        static void Main()
        {
            const double allowedAccuracity = 0.001;
            decimal sum = 1;
	        decimal denominator = 2;
            double accuracity;

            do 
            {
                decimal oldSum = sum;

                if (denominator % 2 == 0)
                    sum += 1 / denominator;
                else
                    sum -= 1 / denominator;

                denominator++;
                accuracity = (double) Math.Abs(sum - oldSum);
            } while (accuracity >= allowedAccuracity);

            Console.WriteLine("{0:F10}", sum);  
        }
    }
}
