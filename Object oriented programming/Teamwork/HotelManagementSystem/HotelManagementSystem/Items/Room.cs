using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace HotelManagementSystem.Items
{
	[DataContract]
	public class Room : RentableBase
	{
		[DataMember]
		private decimal pricePerHour;

		/// <summary>
		/// Initializes new Room instance with specific number and price
		/// </summary>
		/// <param name="number">The room number</param>
		/// <param name="pricePerHour">The price for a room per one hour</param>
		public Room(RoomNumber number, decimal pricePerHour)
		{
			Items = new List<Item>();

			this.Number = number;
			this.PricePerHour = pricePerHour;
		}

		[DataMember]
		public RoomNumber Number { get; set; }

		[DataMember]
		public List<Item> Items { get; set; }

		/// <summary>
		/// Returns the room price per one hour
		/// </summary>
		/// <param name="pricePerHour">The price for a room per one hour</param>
		/// <exception cref="ArgumentOutOfRangeException"/>
		public decimal PricePerHour
		{
			get
			{
				return this.pricePerHour;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Price", "Invalid negative value.");
				}

				this.pricePerHour = value;
			}
		}

		/// <summary>
		/// Calculate the final price that the client have to pay
		/// </summary> 
		/// <param name="time">
		/// The number of hours that the room is occupied
		/// </param>
		/// <returns>The calculated price</returns>
		public decimal CalculatePrice(int hours)
		{
			return PricePerHour * hours;
		}

		/// <summary>Calculates the bed capacity of the hotel</summary> 
		/// <param name="count">The number of bers</param>
		/// <typeparam name="Item">Type of the list objects to collect</typeparam>
		/// <exception cref="Exception"/>
		/// <returns>Number of beds in the hotel</returns>
		public int GetCapacity()
		{
			return Items.FindAll(x => x is SleepingFurniture).Sum(x => (x as SleepingFurniture).SleepingSeats);
		}
	}
}