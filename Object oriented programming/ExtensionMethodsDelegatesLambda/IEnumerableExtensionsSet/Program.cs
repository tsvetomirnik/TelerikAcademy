using System;

namespace IEnumerableExtensionsSet
{
	class Program
	{
		static void Main()
		{
			var items = new[]
			{
				1.2,
				2.3,
				3.4
			};

			Console.Write("Elements: ");
			foreach (var item in items)
			{
				Console.Write("{0} ", item);
			}
			Console.WriteLine();
			
			Console.WriteLine("Sum: " + items.Sum());
			Console.WriteLine("Product: " + items.Product());
			Console.WriteLine("Min: " + items.Min());
			Console.WriteLine("Max: " + items.Max());
			Console.WriteLine("Average: " + items.Average());
		}
	}
}