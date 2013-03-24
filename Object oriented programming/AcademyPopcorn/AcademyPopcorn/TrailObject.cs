using System;
using System.Linq;

namespace AcademyPopcorn
{
	class TrailObject : GameObject
	{
		private readonly static char[,] ObjectBody;

		private ushort lifetime;

		static TrailObject()
		{
			TrailObject.ObjectBody = new char[,] {{'*'}};
		}

		public TrailObject(MatrixCoords topLeft, ushort lifetime) 
			: this(topLeft, TrailObject.ObjectBody, lifetime)
		{
		}

		protected TrailObject(MatrixCoords topLeft, char[,] body, ushort lifetime) 
			: base(topLeft, body)
		{
			this.lifetime = lifetime;
		}

		public override void Update()
		{
			if(IsDestroyed)
				return;
			
			lifetime--;
			if(lifetime == 0)
			{
				IsDestroyed = true;
			}
		}
	}
}
