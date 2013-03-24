using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
	class UnstoppableBall : Ball
	{
		public new const string CollisionGroupString = "unstoppable_ball";

		public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed) 
			: base(topLeft, speed)
		{
		}

		public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

		public override bool CanCollideWith(string otherCollisionGroupString)
		{
			return otherCollisionGroupString == UnpassableBlock.CollisionGroupString || 
				otherCollisionGroupString == Block.CollisionGroupString ||
				otherCollisionGroupString == Racket.CollisionGroupString;
		}

		public override void RespondToCollision(CollisionData collisionData)
		{
			foreach (var hitObjectsString in collisionData.hitObjectsCollisionGroupStrings)
			{
				if(hitObjectsString != Block.CollisionGroupString)
				{
					if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
					{
						this.Speed.Row *= -1;
					}
					if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
					{
						this.Speed.Col *= -1;
					}
				}
			}
		}
	}
}
