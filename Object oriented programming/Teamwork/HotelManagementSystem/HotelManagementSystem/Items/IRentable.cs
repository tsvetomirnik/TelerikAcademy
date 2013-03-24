using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
	public interface IRentable
	{
		Client Owner { get; set; }

		DateTime DateTimeRented { get; set; }

		bool IsRented { get; }
	}
}