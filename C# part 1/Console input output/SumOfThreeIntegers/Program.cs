using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfThreeIntegers
{
	class SumOfThreeIntegers
	{
		static void Main(string[] args)
		{
            int a;
            do
            {
                Console.Write("Insert A: ");
            } while (!int.TryParse(Console.ReadLine(), out a));

            int b;
            do
            {
                Console.Write("Insert B: ");
            } while (!int.TryParse(Console.ReadLine(), out b));

            int c;
            do
            {
                Console.Write("insert c: ");
            } while (!int.TryParse(Console.ReadLine(), out c));

            int sum = a + b + c;
            Console.WriteLine("Sum of values = {0}", sum);
		}
	}
}
