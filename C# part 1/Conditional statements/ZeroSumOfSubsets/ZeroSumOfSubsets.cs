/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 9:We are given 5 integer numbers. Write a program that checks if the
 * sum of some subset of them is 0. Example: 3, -2, 1, 1, 8  1+1-2=0.
 *
 */

using System;

namespace ZeroSumOfSubsets
{
	class ZeroSumOfSubsets
	{
		static void Main(string[] args)
		{
			int a = 3;
			int b = -2;
			int c = 1;
			int d = 1;
			int e = -4;
			Console.WriteLine("Input: A={0} B={1} C={2} D={3} E={4}", a, b, c, d, e);
			Console.WriteLine();

			ShowSubsetZeroSum(a, b, c, d, e);
		}

		private static void ShowSubsetZeroSum(int a, int b, int c, int d, int e) 
		{
			if (a + b + c + d + e == 0)
			{
				Console.WriteLine("{0} + {1} + {2} + {3} + {4} = 0", a, b, c, d, e);
			}
			
			if (a + b + c + d == 0)
			{
				Console.WriteLine("{0} + {1} + {2} + {3} = 0", a, b, c, d);
			}
			
			if (a + b + c == 0)
			{
				Console.WriteLine("{0} + {1} + {2} = 0", a, b, c);
			}
			
			if (a + b + d == 0)
			{
				Console.WriteLine("{0} + {1} + {2} = 0", a, b, d);
			}
			
			if (a + d + e == 0)
			{
				Console.WriteLine("{0} + {1} + {2} = 0", a, d, e);
			}
			
			if (a + c + d == 0)
			{
				Console.WriteLine("{0} + {1} + {2} = 0", a, c, d);
			}
			
			if (a + c + e == 0)
			{
				Console.WriteLine("{0} + {1} + {2} = 0", a, c, e);
			}
			
			if (a + b == 0)
			{
				Console.WriteLine("{0} + {1} = 0", a, b);
			}
			
			if (a + c == 0)
			{
				Console.WriteLine("{0} + {1} = 0", a, c);
			}
			
			if (a + d == 0)
			{
				Console.WriteLine("{0} + {1} = 0", a, d);
			}
			
			if (a + e == 0)
			{
				Console.WriteLine("{0} + {1} = 0", a, e);
			}
			
			if (b + c == 0)
			{
				Console.WriteLine("{0} + {1} = 0", b, c);
			}
			
			if (b + c + d == 0)
			{
				Console.WriteLine("{0} + {1} + {2} = 0", b, c, d);
			}
			
			if (b + c + e == 0)
			{
				Console.WriteLine("{0} + {1} + {2} = 0", b, c, e);
			}
			
			if (b + d == 0)
			{
				Console.WriteLine("{0} + {1} = 0", b, d);
			}
			
			if (b + e == 0)
			{
				Console.WriteLine("{0} + {1} = 0", b, e);
			}
			
			if (c + d == 0)
			{
				Console.WriteLine("{0} + {1} = 0", c, d);
			}
			
			if (c + e == 0)
			{
				Console.WriteLine("{0} + {1} = 0", c, e);
			}
			 
			if (d + e == 0)
			{
				Console.WriteLine("{0} + {1} = 0", d, e);
			}
			 
			if (b + c + d + e == 0)
			{
				Console.WriteLine("{0} + {1} + {2} + {3} = 0", b, c, d, e);
			}
			
			if (c + d + e == 0)
			{
				Console.WriteLine("{0} + {1} + {2} = 0", c, d, e);
			}
		}
	}
}
