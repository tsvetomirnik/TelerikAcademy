using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
	class ExplodingBlock : Block
	{
		private readonly static char[,] ObjectBody;
		public new const string CollisionGroupString = "exploding_block";
		private const ushort ShockwaveRadius = 5;

		private bool shockwavesProduced;

		static ExplodingBlock()
		{
			ExplodingBlock.ObjectBody = new char[,] {{'(', 'B', ')'}};
		}
		
		public ExplodingBlock(MatrixCoords topLeft) 
			: this(topLeft, ExplodingBlock.ObjectBody)
		{
		}

		protected ExplodingBlock(MatrixCoords topLeft, char[,] body) 
			: base(topLeft, body)
		{
		}

		public override string GetCollisionGroupString()
		{
			return ExplodingBlock.CollisionGroupString;
		}

		public override IEnumerable<GameObject> ProduceObjects()
		{
			if(IsDestroyed && !shockwavesProduced)
			{
				shockwavesProduced = true;

				List<GameObject> waves = new List<GameObject>();

				//Add left and right waves 
				for (int i = -1; i <= this.body.GetLength(0); i++)
				{
					waves.Add(new Shockwave(new MatrixCoords(this.TopLeft.Row-i, this.TopLeft.Col-1), ShockwaveRadius));
					waves.Add(new Shockwave(new MatrixCoords(this.TopLeft.Row-i, this.TopLeft.Col + this.body.GetLength(1)), ShockwaveRadius));
				}

				//Add top and bottom waves
				for (int i = -1; i <= this.body.GetLength(1); i++)
				{
					waves.Add(new Shockwave(new MatrixCoords(this.TopLeft.Row+1, this.TopLeft.Col+i), ShockwaveRadius));
					waves.Add(new Shockwave(new MatrixCoords(this.TopLeft.Row - this.body.GetLength(0), this.TopLeft.Col+i), ShockwaveRadius));
				}

				return waves;
				//	{
				//	new Shockwave(new MatrixCoords(this.TopLeft.Row-1, this.TopLeft.Col+1), ShockwaveRadius),
				//	new Shockwave(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col+1), ShockwaveRadius),
				//	new Shockwave(new MatrixCoords(this.TopLeft.Row+1, this.TopLeft.Col+1), ShockwaveRadius),
				//	new Shockwave(new MatrixCoords(this.TopLeft.Row+1, this.TopLeft.Col), ShockwaveRadius),
				//	new Shockwave(new MatrixCoords(this.TopLeft.Row+1, this.TopLeft.Col-1), ShockwaveRadius),
				//	new Shockwave(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col-1), ShockwaveRadius),
				//	new Shockwave(new MatrixCoords(this.TopLeft.Row-1, this.TopLeft.Col-1), ShockwaveRadius),
				//	new Shockwave(new MatrixCoords(this.TopLeft.Row, this.TopLeft.Col), ShockwaveRadius),
				//};
			}

			return base.ProduceObjects();
		}
	}
}
