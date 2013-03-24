using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
	class PlayerRacket : MovingObject
	{
		public PlayerRacket(MatrixCoords topLeft, char[,] body, MatrixCoords speed) 
			: base(topLeft, new[,]{{'x'}}, speed)
		{
		}

		//TODO: Move it from here
		protected virtual void ShootPlayerRacket()
		{
		}
	}
}
