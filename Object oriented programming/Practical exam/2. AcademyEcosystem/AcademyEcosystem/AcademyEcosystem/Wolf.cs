using System;
using System.Linq;

namespace AcademyEcosystem
{
	public class Wolf : Animal, ICarnivore
	{
		public Wolf(string name, Point location)
			: base(name, location, 4)
		{
		}

		public int TryEatAnimal(Animal animal)
		{
			if (animal == null) 
			{
				return 0;
			}

			if (base.Size >= animal.Size || animal.State == AnimalState.Sleeping) 
			{
				return animal.GetMeatFromKillQuantity();
			}

			return 0;
		}
	}
}
