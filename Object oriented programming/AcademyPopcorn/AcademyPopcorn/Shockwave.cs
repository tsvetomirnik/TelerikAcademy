using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
	class Shockwave : TrailObject
	{
		public new const string CollisionGroupString = "shockwave";
		private readonly static char[][,] availableBodies;

		static Shockwave()
		{
			availableBodies = new char[][,]
			{
				new char[,] {{'a'}}, 
				new char[,] {{'b'}}, 
				new char[,] {{'z'}}, 
				new char[,] {{'w'}}, 
				new char[,] {{'3'}}, 
				new char[,] {{'7'}}, 
			};
		}

		public Shockwave(MatrixCoords topLeft, ushort lifetime) 
			: base(topLeft, new char[,]{}, lifetime)
		{
			SetRandomSymbol();
		}

		public override bool CanCollideWith(string otherCollisionGroupString)
		{
			return otherCollisionGroupString == Block.CollisionGroupString;
		}

		private void SetRandomSymbol()
		{
			int bodyIndex = RandomGenerator.GetInt(0, Shockwave.availableBodies.Count());
			base.body = Shockwave.availableBodies[bodyIndex];
		}
	}
}
