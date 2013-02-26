using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneDevice.Items
{
	/// <summary>
	/// Initializes a new instance of GSM class.
	/// </summary>
	internal class GSM
	{
		private static readonly GSM iPhone4S;

		private string manufacturer;
		private string model;
		private decimal price;
		private string owner;
		private Battery battery;
		private Display display;
		private readonly List<Call> callHistory;

		public GSM(string model, string manufacturer) : this(model, manufacturer, 0M)
		{
		}

		public GSM(string model, string manufacturer, decimal price)
		{
			Model = model;
			Manufacturer = manufacturer;
			this.Price = price;
			this.callHistory = new List<Call>();
		}

		//Static constructor
		static GSM()
		{
			iPhone4S = new GSM("iPhone 4S", "Apple")
			{
				Price = 1140.30m,
				Owner = "Ivan Jekov",
				battery = new Battery("Alk")
				{
					HoursIdle = 200,
					HoursTalk = 40,
					Type = BatteryType.LiIon
				},
				Display = new Display(4.5, 10240)
			};
		}

		public static GSM IPhone4S
		{
			get
			{
				return iPhone4S;
			}
		}

		public string Model
		{
			get
			{
				return model;
			}
			private set
			{
				if (value == null)
					throw new ArgumentNullException("Model", "Null is not a valid value for model.");

				model = value;
			}
		}

		public string Manufacturer
		{
			get
			{
				return manufacturer;
			}
			private set
			{
				if (value == null)
					throw new ArgumentNullException("Manufacturer", "Null is not a valid value for manufacturer.");

				manufacturer = value;
			}
		}

		public decimal Price 
		{ 
			get
			{
				return this.price;
			}
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException("Price", "Price cannot be a negative value.");

				this.price = value;
			}
		}

		public string Owner 
		{
			get
			{
				return this.owner;
			}
			set
			{
				this.owner = value;
			}
		}

		public Battery Battery
		{
			get
			{
				return this.battery;
			}
			set
			{
				this.battery = value;
			}
		}

		public Display Display
		{
			get
			{
				return this.display;
			}
			set
			{
				this.display = value;
			}
		}

		public List<Call> CallHistory
		{
			get
			{
				return this.callHistory;
			}
		}

		/// <summary>
		/// Adds a call record to the callHistory collection
		/// </summary>
		public void AddCall(Call call)
		{
			if (call == null)
			{
				throw new ArgumentNullException();
			}

			callHistory.Add(call);
		}

		/// <summary>
		/// Deletes all call records from the callHistory collection
		/// </summary>
		public void DeleteCall(Call call)
		{
			if (call == null)
			{
				throw new ArgumentNullException();
			}

			callHistory.Remove(call);
		}

		/// <summary>
		/// Deletes all call records from the calls collection
		/// </summary>
		public void ClearHistory()
		{
			callHistory.Clear();
		}
		
		/// <summary>
		/// Prints all call records to the console
		/// </summary>
		public void PrintCallHistory()
		{
			Console.WriteLine("CALL HISTORY:");

			if (this.CallHistory.Count < 1)
			{
				Console.WriteLine("No history");
				return;
			}

			foreach (var call in this.CallHistory)
			{
				Console.WriteLine(call.ToString());
			}
		}

		/// <summary>
		/// Calculates the due amount from the calls collection by a specific rate
		/// </summary>
		public decimal GetCallsTotalPrise(decimal pricePerMinute)
		{
			decimal total = 0M;
			foreach (var call in callHistory)
			{
				total += ((decimal)call.Duration / 60) * pricePerMinute;
			}

			return total;
		}

		public override string ToString()
		{
			string indent = Environment.NewLine + "\t";

			var info = new StringBuilder();
			info.AppendLine(string.Format("Model: [{0}]", Model));
			info.AppendLine(string.Format("Price: [{0:c}]", Price));
			info.AppendLine(string.Format("Owner: [{0}]", Owner ?? "Unknown"));

			string batteryStirng = Battery == null ? "Unknown" : indent + Battery.ToString().Replace(Environment.NewLine, indent);
			info.AppendLine(string.Format("Battery: [{0}]", batteryStirng));

			string displayStirng = Display == null ? "Unknown" : indent + Display.ToString().Replace(Environment.NewLine, indent);
			info.AppendLine(string.Format("Display: [{0}]", displayStirng));

			return info.ToString();
		}
	}
}