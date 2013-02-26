using System;
using DefiningClassesPart2.Items;

namespace _3DSystem
{
	class _3DSystem
	{
		static void Main()
		{
			var path = new Path();
			path.Points.Add(new Point3D(1,2,3));
			PathStorage.Save(path);

			Console.WriteLine(PathStorage.Load().Points[0].ToString());
		}
	}
}
