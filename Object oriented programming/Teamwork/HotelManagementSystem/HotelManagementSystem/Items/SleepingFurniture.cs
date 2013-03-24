using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
	public class SleepingFurniture : Furniture
	{
		public int SleepingSeats { get; private set; }

		public SleepingFurniture(int sleepingSeats, FurnitureQuality quality, string name) 
			: base(quality, name)
		{
			this.SleepingSeats = sleepingSeats;
		}
	}
}