/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 *
 * Task 6: Write a program that reads the coefficients a, b and c 
 * of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).
 * 
 */

using System;
using System.Globalization;

namespace QuadraticEquation
{
    class QuadraticEquation
    {
        static void Main()
        {
            double a;
            do
            {
                Console.Write("Insert a: ");
            } while (!double.TryParse(Console.ReadLine(), out a));

            double b;
            do
            {
                Console.Write("Insert b: ");
            } while (!double.TryParse(Console.ReadLine(), out b));

            double c;
            do
            {
                Console.Write("Insert c: ");
            } while (!double.TryParse(Console.ReadLine(), out c));

	        Console.WriteLine(FindRoots(a, b, c));
        }

	    private static string FindRoots(double a, double b, double c)
	    {
		    string result;
		    if (a != 0)
		    {
			    double discriminant = (b*b) - (4*a*c);
			    Console.WriteLine(discriminant);
			    if (discriminant > 0)
			    {
				    double root1 = (-b + discriminant)/2*a;
				    double root2 = (-b - discriminant)/2*a;
				    result = string.Format("{0},{1}", root1, root2);
			    }
			    else if (discriminant < 0)
			    {
				    result = "No real roots";
			    }
			    else
			    {
				    var root = -b/(2*a);
				    result = root.ToString(CultureInfo.InvariantCulture);
			    }
		    }
		    else
		    {
			    if (b == 0)
			    {
				    result = c == 0 ? "Every x" : "No real roots";
			    }
			    else
			    {
				    double root = -c/b;
				    result = root.ToString(CultureInfo.InvariantCulture);
			    }
		    }

		    return result;
	    }
    }
}
