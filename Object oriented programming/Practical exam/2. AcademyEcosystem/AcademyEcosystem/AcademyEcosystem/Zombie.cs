using System;
using System.Linq;

namespace AcademyEcosystem
{
	class Zombie : Animal
	{
		public const int MeatFromKill = 10;

		public Zombie(string name, Point location)
			: base(name, location, 0)
		{
		}

		public override int GetMeatFromKillQuantity()
		{
			return MeatFromKill;
		}
	}
}
