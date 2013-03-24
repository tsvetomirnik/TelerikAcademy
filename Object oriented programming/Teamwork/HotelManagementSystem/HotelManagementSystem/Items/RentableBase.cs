using System;
using System.Linq;
using System.Runtime.Serialization;

namespace HotelManagementSystem.Items
{
	[DataContract]
	public abstract class RentableBase : IRentable
	{
		public bool IsRented
		{
			get
			{
				return Owner != null;
			}
		}

		[DataMember]
		public DateTime DateTimeRented { get; set; }

		[DataMember]
		public Client Owner { get; set; }
	}
}