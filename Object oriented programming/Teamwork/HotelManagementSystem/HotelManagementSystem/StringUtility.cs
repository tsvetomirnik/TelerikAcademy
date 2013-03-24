using System;
using System.Linq;

namespace HotelManagementSystem
{
	public static class StringUtility
	{
		public const int SSNLength = 9;

		public static char[] GetSSN(this string ssn) 
		{
			if (ssn == null) 
			{
				throw new ArgumentNullException("SSN", "Invalid null value.");
			}

			if (ssn.Length != 9) 
			{
				throw new FormatException("Invalid value length. The value must consist of 9 digits.");
			}

			//Check for non digits
			foreach(var digit in ssn)
			{
				if (!char.IsDigit(digit)) 
				{
					throw new FormatException("Invalid value characters. The value must consist of 9 digits.");
				}
			}

			return ssn.ToCharArray();
		}
	}
}
