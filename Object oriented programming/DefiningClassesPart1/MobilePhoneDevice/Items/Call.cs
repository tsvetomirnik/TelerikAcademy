using System;

namespace MobilePhoneDevice.Items
{
	/// <summary>
	/// Initializes a new instance of Call class.
	/// </summary>
	internal class Call
	{
		private string dialedNumber;
		private DateTime startedTime;
		private int duration;

		public Call(DateTime startedTime, string dialedNumber) : this(startedTime, dialedNumber, 0)
		{
		}

		public Call(DateTime startedTime, string dialedNumber, int duration)
		{
			this.DialedNumber = dialedNumber;
			this.StartedTime = startedTime;
			this.Duration = duration;
		}

		/// <summary>
		/// Beginning time of the call
		/// </summary>
		public DateTime StartedTime
		{
			get
			{
				return startedTime;
			}
			private set
			{
				this.startedTime = value;
			}
		}

		/// <summary>
		/// The number of the other actor in this call
		/// </summary>
		public string DialedNumber
		{
			get
			{
				return dialedNumber;
			}
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}

				if (value.Length != 10)
				{
					throw new ArgumentOutOfRangeException("DialedNumber", "The number should consist of exactly 10 digits.");
				}

				foreach (var symbol in value)
				{
					if (!char.IsDigit(symbol))
					{
						throw new ArgumentException("There are invalid charactes in the number.");
					}
				}

				this.dialedNumber = value;
			}
		}

		/// <summary>
		/// Duration of the call in seconds
		/// </summary>
		public int Duration
		{
			get
			{
				return duration;
			}
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Duration", "The duration cannot be a negative number.");

				duration = value;
			}
		}

		/// <summary>
		/// Returns string representation of the call object
		/// </summary>
		public override string ToString()
		{
			return string.Format("Call on {0} to number {1} lasted {2} seconds.", StartedTime, DialedNumber, Duration);
		}
	}
}