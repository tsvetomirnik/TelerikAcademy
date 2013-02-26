using System;

namespace GenericLists
{
	class Program
	{
		static void Main()
		{
			var stringCollecton = new GenericList<string>(6);
			stringCollecton.Add("H");
			stringCollecton.Add("e");
			stringCollecton.Add("l");
			stringCollecton.Add("l");
			stringCollecton.Add("o");

			//ToString method
			Console.WriteLine(stringCollecton.ToString());

			//Get count
			Console.WriteLine("There are {0} elements", stringCollecton.Count);

			string worldWord = "world";

			//Insert element
			Console.WriteLine("Add {0} word", worldWord);
			stringCollecton.InsertAt(5, worldWord);
			Console.WriteLine(stringCollecton.ToString());

			//Remove element
			Console.WriteLine("Remove {0} word", worldWord);
			stringCollecton.RemoveAt(stringCollecton.GetPosition(worldWord));
			Console.WriteLine(stringCollecton.ToString());

			//Get element position
			Console.WriteLine("'{0}' is on {1} position", stringCollecton[3], stringCollecton.GetPosition(stringCollecton[3]));

			//Get max
			Console.WriteLine("Max element is {0}", stringCollecton.Max());
			Console.WriteLine("Min element is {0}", stringCollecton.Min());
		}
	}
}
