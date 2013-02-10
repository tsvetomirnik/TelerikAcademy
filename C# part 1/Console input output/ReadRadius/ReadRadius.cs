/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 *
 * Task 2: Write a program that reads the radius r
 * of a circle and prints its perimeter and area.
 * 
 */

using System;

namespace ReadRadius
{
    class ReadRadius
    {
        static void Main()
        {
            double radius;
            do
            {
                Console.Write("Insert circle radius: ");
            } while (!double.TryParse(Console.ReadLine(), out radius));

            double area = Math.PI * Math.Pow(radius, 2);
            Console.WriteLine("The area for radius {0} is {1:0.##}", radius, area);

            double circumference = 2 * Math.PI * radius;
            Console.WriteLine("The circumference for radius {0} is {1:0.##}", radius, circumference);
        }
    }
}
