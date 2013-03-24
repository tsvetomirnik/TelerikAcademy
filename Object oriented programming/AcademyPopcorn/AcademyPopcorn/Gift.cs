using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
	class Gift : MovingObject
	{
		public new const string CollisionGroupString = "gift";
		private readonly static char[,] ObjectBody;

		private int moveUpdateStep;
		private int updatesCounter;

		static Gift()
		{
			Gift.ObjectBody = new char[,]
			{
				{' ', '*', ' '},
				{'[', '_', ']'},
			};
		}

		public Gift(MatrixCoords topLeft, int moveUpdateStep) 
			: base(topLeft, Gift.ObjectBody, new MatrixCoords(0, 0))
		{
			this.moveUpdateStep = moveUpdateStep;
		}

		public override bool CanCollideWith(string otherCollisionGroupString)
		{
			return otherCollisionGroupString == Ball.CollisionGroupString ||
			       otherCollisionGroupString == UnstoppableBall.CollisionGroupString ||
			       otherCollisionGroupString == Shockwave.CollisionGroupString ||
			       otherCollisionGroupString == Racket.CollisionGroupString;
		}

		public override void RespondToCollision(CollisionData collisionData)
		{
			IsDestroyed = true;
		}

		public override void Update()
		{
			updatesCounter++;
			if(updatesCounter % moveUpdateStep == 0)
			{
				this.TopLeft = new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col);
			}
		}
	}
}
