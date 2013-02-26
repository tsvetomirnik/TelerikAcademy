using System;
using System.Text;

namespace MobilePhoneDevice.Items
{
	/// <summary>
	/// Initializes a new instance of Battery class.
	/// </summary>
	internal class Battery
	{
		private int hoursIdle = 0;
		private int hoursTalk = 0;
		private string model = null;
		private BatteryType? type = null;

		//Default constructor
		public Battery()
		{
		}

		public Battery(string model)
		{
			this.Model = model;
		}

		public string Model
		{
			get
			{
				return model;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException("Model", "Null is not a valid value for model.");

				model = value;
			}
		}

		public int HoursIdle
		{
			get
			{
				return hoursIdle;
			}
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("HoursIdle", "HoursIdle value cannot be a negative number.");

				hoursIdle = value;
			}
		}

		public int HoursTalk
		{
			get
			{
				return hoursTalk;
			}
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("HoursTalk", "HoursTalk value cannot be a negative number.");

				hoursTalk = value;
			}
		}

		public BatteryType? Type
		{
			get
			{
				return type;
			}
			set
			{
				if (value == null)
					throw new ArgumentNullException("BatteryType", "Null is not a valid value for BatteryType.");

				type = value;
			}
		}

		public override string ToString()
		{
			var info = new StringBuilder();
			info.AppendLine(string.Format("Model: [{0}]", Model));
			info.AppendLine(string.Format("HoursIdle: [{0}]", HoursIdle));
			info.AppendLine(string.Format("HoursTalk: [{0}]", HoursTalk));
			info.AppendLine(string.Format("BatteryType: [{0}]", Type));
			return info.ToString();
		}
	}
}