using System;
using System.Collections.Generic;

namespace Attributes
{
	public static class AttributesReader
	{
		public static List<T> Read<T>(Type objType) where T : Attribute
		{
			object[] attributes = objType.GetCustomAttributes(false);

			var currentAttributes = new List<T>();
			foreach (Attribute attribute in attributes)
			{
				if (attribute.GetType() == typeof(T))
				{
					currentAttributes.Add((T)attribute);
				}
			}

			return currentAttributes;
		}
	}
}