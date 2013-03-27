using System;
using System.Linq;

namespace AcademyEcosystem
{
	public class Lion : Animal, ICarnivore
	{
		public Lion(string name, Point location)
			: base(name, location, 6)
		{
		}

		public int TryEatAnimal(Animal animal)
		{
			if (animal == null) 
			{
				return 0;
			}

			if (base.Size >= animal.Size/2) 
			{
				base.Size += 1;
				return animal.GetMeatFromKillQuantity();
			}

			return 0;
		}
	}
}
