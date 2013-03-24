using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
	public struct RoomNumber
	{
		private int floor;
		private int number;

		public int Floor 
		{
			get { return this.floor; }
			set
			{
				if (value < 0) 
				{
					throw new ArgumentOutOfRangeException("Floor", "Invalid negative value.");
				}

				this.floor = value;
			}
		}

		public int Number 
		{
			get { return this.number; }
			set
			{
				if (value < 0) 
				{
					throw new ArgumentOutOfRangeException("Number", "Invalid negative value.");
				}

				this.number = value;
			}
		}

		public override string ToString() 
		{
			return this.Floor.ToString() + this.Number.ToString();
		}
	}
}
