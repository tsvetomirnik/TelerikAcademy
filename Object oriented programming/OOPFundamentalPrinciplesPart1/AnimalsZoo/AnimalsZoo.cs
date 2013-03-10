using System;
using AnimalsZoo.Items;

namespace AnimalsZoo
{
	class AnimalsZoo
	{
		static void Main()
		{
			var animals = new Animal[]
				{
					new Tomcat("Tom", 7.2),
					new Tomcat("Gosho", 3.1),
					new Kitten("Dani", 3.2), 
					new Frog("Froggy", 0.7, Gender.Male), 
					new Dog("Buddy", 5.3, Gender.Male), 
					new Kitten("Ten", 2.8), 
					new Frog("Mary", 4.2, Gender.Female) 
				};

			Console.WriteLine("Frog average age is: {0}", Animal.GetAverageAge<Frog>(animals));
			Console.WriteLine("Cat average age is: {0}", Animal.GetAverageAge<Cat>(animals));
			Console.WriteLine("Kitten average age is: {0}", Animal.GetAverageAge<Kitten>(animals));
		}
	}
}