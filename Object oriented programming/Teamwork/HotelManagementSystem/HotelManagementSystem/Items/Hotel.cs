using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace HotelManagementSystem.Items
{
	[DataContract]
	public class Hotel
	{
		[DataMember]
		public string Name { get; set; }
		
		[DataMember]
		public string Address { get; set; }

		[DataMember]
		public List<Client> Clients { get; set; }

		[DataMember]
		public List<Room> Rooms { get; set; }

		/// <summary>
		/// Initializes new Hotel instance
		/// </summary>
		public Hotel() 
			: this(string.Empty, string.Empty)
		{
		}

		/// <summary>
		/// Initializes new Hotel instance with specific name and adress 
		/// </summary>
		public Hotel(string name, string address)
		{
			this.Name = name;
			this.Address = address;
			this.Rooms = new List<Room>();
			this.Clients = new List<Client>();
		}

		/// <summary>
		/// Returns a list of all available rooms in the hotel
		/// </summary>
		public List<Room> GetAvialableRooms()
		{
			return this.Rooms.FindAll(x => !x.IsRented);
		}
	}
}