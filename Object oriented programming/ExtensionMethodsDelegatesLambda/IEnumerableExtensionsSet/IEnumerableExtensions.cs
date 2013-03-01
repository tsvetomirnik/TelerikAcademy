using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableExtensionsSet
{
	public static class IEnumerableExtensions
	{
		/// <summary>
		/// Get sum of enumeration elements
		/// </summary>
		public static T Sum<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}

			dynamic sum = default(T);
			foreach (var item in enumerable)
			{
				sum += item;
			}

			return sum;
		}

		/// <summary>
		/// Get product of enumeration elements
		/// </summary>
		public static T Product<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}

			dynamic product = 1;
			foreach (var item in enumerable)
			{
				product *= item;
			}

			return product;
		}

		/// <summary>
		/// Get min value from enumeration elements
		/// </summary>
		public static T Min<T>(this IEnumerable<T> enumerable) where T : IComparable
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}

			if (!enumerable.Any())
			{
				return default(T);
			}

			dynamic min = enumerable.First();
			foreach (var item in enumerable)
			{
				if (item < min)
				{
					min = item;
				}
			}

			return min;
		}

		/// <summary>
		/// Get max value from enumeration elements
		/// </summary>
		public static T Max<T>(this IEnumerable<T> enumerable) where T : IComparable
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}

			if (!enumerable.Any())
			{
				return default(T);
			}

			dynamic max = enumerable.First();
			foreach (var item in enumerable)
			{
				if (item > max)
				{
					max = item;
				}
			}

			return max;
		}

		/// <summary>
		/// Get average value of enumeration elements
		/// </summary>
		public static T Average<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}

			return (dynamic)enumerable.Sum() / enumerable.Count();
		}
	}
}