using System;
using System.Text;

namespace StringBuilderExtender
{
	public static class StringBuilderExtensions
	{
		/// <summary>
		/// Gets parts of string starting at specified position with specified length
		/// </summary>
		/// <param name="str">String source</param>
		/// <param name="index">Starting index, beginning of the substring to return</param>
		/// <param name="length">Desired length of the substring to return</param>
		public static StringBuilder Substring(this StringBuilder str, int index, int length)
		{
			if (str == null)
			{
				throw new ArgumentNullException("str", "Null is not a valid value for the operation.");
			}

			if (index + length > str.Length)
			{
				throw new ArgumentOutOfRangeException("str", "Selected string is not long enought due the given method attributes");
			}

			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index", "Starting index cannot be a negative value.");
			}

			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length", "Length of the string cannot be a negative value.");
			}

			return new StringBuilder(new string(str.ToString().ToCharArray(index, length)));
		}
	}
}