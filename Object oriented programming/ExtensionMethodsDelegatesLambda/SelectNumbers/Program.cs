using System;
using System.Collections.Generic;
using System.Linq;

namespace SelectNumbers
{
	class Program
	{
		static void Main()
		{
			var numbers = new[] { 1, 2, 3, 7, 21, 14, 63 };

			var sortedByLambda = SelectByLambda(numbers);
			PrintNumbers("Selected with Lambda", sortedByLambda);
			Console.WriteLine();

			var sortedByLinq = SelectByLinq(numbers);
			PrintNumbers("Selected with Linq", sortedByLinq);
		}

		private static void PrintNumbers(string title, IEnumerable<int> numbers)
		{
			Console.WriteLine(title);
			foreach (var n in numbers)
			{
				Console.Write("{0} ", n);
			}
			Console.WriteLine();
		}

		private static IEnumerable<int> SelectByLambda(IEnumerable<int> numbers)
		{
			return numbers.Where(x => x % 3 == 0 && x % 7 == 0).ToArray();
		}

		private static IEnumerable<int> SelectByLinq(IEnumerable<int> numbers)
		{
			var filteredNumbers =
				from n in numbers
				where n % 3 == 0 && n % 7 == 0
				select n;

			return filteredNumbers.ToArray();
		}
	}
}