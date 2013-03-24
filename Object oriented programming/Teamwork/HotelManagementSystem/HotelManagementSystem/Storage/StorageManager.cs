using System;
using System.Linq;
using HotelManagementSystem.Items;

namespace HotelManagementSystem.Storage
{
	public static class StorageManager
	{
		public const string HotelStorageFileName = "hotelData.xml";

		private static GenericStorage<Hotel> HotelStorage { get; set; }

		/// <summary>
		/// Global hotel instance
		/// </summary>
		public static Hotel CurrentHotel { get; set; }

		// Constructor
		static StorageManager() 
		{
			HotelStorage = new GenericStorage<Hotel>(HotelStorageFileName);
			
			StorageManager.LoadCurrentHotel();
		}

		/// <summary>
		/// Loads hotel data to the CurrentHotel object
		/// </summary>
		public static Hotel LoadCurrentHotel()
		{
			var storedHotel = HotelStorage.Load();
			if(storedHotel == null)
			{
				storedHotel = new Hotel();
			}

			StorageManager.CurrentHotel = storedHotel;
			return StorageManager.CurrentHotel;
		}

		/// <summary>
		/// Stores and reloads the CurrentHotel object
		/// </summary>
		public static void UpdateCurrentHotel() 
		{
			HotelStorage.Save(StorageManager.CurrentHotel);
			StorageManager.LoadCurrentHotel();
		}
	}
}
