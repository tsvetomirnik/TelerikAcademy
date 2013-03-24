using System.Collections.Generic;

namespace AcademyPopcorn
{
	class MeteoriteBall : Ball
	{
		public const int TrailLength = 3;

		public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed) 
			: base(topLeft, speed)
		{
		}

		public override IEnumerable<GameObject> ProduceObjects()
		{
			return new List<GameObject>
			{
				new TrailObject(this.GetTopLeft(), TrailLength)
			};
		}
	}
}
