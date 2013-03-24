using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
	class UnpassableBlock : Block
	{
		public new const string CollisionGroupString = "unpassable_block";

		public UnpassableBlock(MatrixCoords topLeft) 
			: base(topLeft, new char[,] {{'&'}})
		{
		}

		public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }

		public override bool CanCollideWith(string otherCollisionGroupString)
		{
			return false;
		}

		public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = false;
        }
	}
}
