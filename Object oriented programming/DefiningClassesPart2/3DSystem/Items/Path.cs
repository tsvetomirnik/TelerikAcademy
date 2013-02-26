using System.Collections.Generic;

namespace DefiningClassesPart2.Items
{
	public class Path
	{
		public List<Point3D> Points { get; set; }

		public Path()
		{
			Points = new List<Point3D>();
		}
	}
}
