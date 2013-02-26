using System;
using System.Text;

namespace MobilePhoneDevice.Items
{
	/// <summary>
	/// Initializes a new instance of Display class.
	/// </summary>
	internal class Display
	{
		private double size;
		private int colorsNumber;

		//Default constructor
		public Display() : this(0, 0)
		{
		}

		public Display(double size, int colorsNumber)
		{
			Size = size;
			ColorsNumber = colorsNumber;
		}

		/// <summary>
		/// Display size in inches
		/// </summary>
		public double Size
		{
			get
			{
				return this.size;
			}
			set
			{
				if (value < 0.01)
					throw new ArgumentOutOfRangeException("Size", "Size cannot be less than 0.01 inches.");

				this.size = value;
			}
		}

		/// <summary>
		/// All available colors count
		/// </summary>
		public int ColorsNumber
		{
			get
			{
				return this.colorsNumber;
			}
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("ColorsNumber", "ColorsNumber cannot be a negative number.");

				this.colorsNumber = value;
			}
		}

		public override string ToString()
		{
			var info = new StringBuilder();
			info.AppendLine(string.Format("Size: [{0} inch]", Size));
			info.AppendLine(string.Format("ColorsNumber: [{0}]", ColorsNumber));
			return info.ToString();
		}
	}
}