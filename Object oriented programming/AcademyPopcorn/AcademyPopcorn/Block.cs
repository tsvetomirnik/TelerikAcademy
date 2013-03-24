using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Block : GameObject
    {
        public new const string CollisionGroupString = "block";

        public Block(MatrixCoords topLeft)
            : this(topLeft, new char[,] { { '#' } })
        {
        }

		protected Block(MatrixCoords topLeft, char[,] body)
            : base(topLeft, body)
        {
        }

        public override void Update()
        {
            
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == Ball.CollisionGroupString ||
				otherCollisionGroupString  == UnstoppableBall.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override string GetCollisionGroupString()
        {
            return Block.CollisionGroupString;
        }
    }
}
