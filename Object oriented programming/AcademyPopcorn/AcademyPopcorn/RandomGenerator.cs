using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
	public static class RandomGenerator
	{
		private static readonly Random random;

		static RandomGenerator()
		{
			random = new Random();
		}

		public static int GetInt(int min, int max)
		{
			return random.Next(min, max);
		} 
	}
}
