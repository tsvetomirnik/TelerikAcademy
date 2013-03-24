using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
	public class Furniture : Item
	{
		/// <summary>
		/// Quality price of the Furniture instance
		/// </summary>
		public FurnitureQuality Quality { get; set; }

		/// <summary>
		/// Initialize new Furniture instance with specified quality and name
		/// </summary>
		/// <param name="quality">Quality value</param>
		/// <param name="name">Item name</param>
		public Furniture(FurnitureQuality quality, string name) 
			: base(name, "furniture")
		{
			this.Quality = quality;
		}
	}
}