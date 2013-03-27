using System;
using System.Linq;

namespace AcademyEcosystem
{
	class Boar : Animal, ICarnivore, IHerbivore
	{
		public const int BiteSize = 2;

		public Boar(string name, Point location)
			: base(name, location, 4)
		{
		}
	
		public int EatPlant(Plant plant)
		{
			if (plant == null) 
			{
				return 0;
			}

			base.Size += 1;
			return plant.GetEatenQuantity(BiteSize);
		}

		public int TryEatAnimal(Animal animal)
		{
			if (animal == null) 
			{
				return 0;
			}

			if (base.Size >= animal.Size) 
			{
				return animal.GetMeatFromKillQuantity();
			}

 			return 0;
		}
	}
}
