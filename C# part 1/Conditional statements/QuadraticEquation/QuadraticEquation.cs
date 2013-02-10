/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 6: Write a program that enters the coefficients a, b and c of a
 * quadratic equation a*x2 + b*x + c = 0 and calculates and prints its 
 * real roots. Note that quadratic equations may have 0, 1 or 2 real roots.
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
			double a = GetInputDouble("A");
			double b = GetInputDouble("B");
			double c = GetInputDouble("C");

			string equationResult = FindRoots(a, b, c);
			Console.WriteLine("{0}x^2 + {1}x + {2} = {3}", a, b, c, equationResult.ToLower(CultureInfo.InvariantCulture));
		}

		private static double GetInputDouble(string name)
		{
			double number;
			bool isParsed;
			do
			{
				Console.Write("Insert {0}: ", name);
				string input = Console.ReadLine();
				input = input.Replace('.', ',');
				isParsed = double.TryParse(input, out number);

				if(!isParsed)
				{
					Console.WriteLine("\"{0}\" is not a valid number.", input);
				}

			} while (!isParsed);

			return number;
		}

		private static string FindRoots(double a, double b, double c)
	    {
		    string result;
		    if (a != 0)
		    {
			    double discriminant = (b*b) - (4*a*c);
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
