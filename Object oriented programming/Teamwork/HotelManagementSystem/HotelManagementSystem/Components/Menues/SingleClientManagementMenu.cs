using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Items;
using HotelManagementSystem.Storage;

namespace HotelManagementSystem.Components.Menues
{
	class SingleClientManagementMenu : ConsoleMenuBase
	{
		private static readonly string title;
		private static readonly string[] menuItems;
		private bool hasToQuit;

		static SingleClientManagementMenu() 
		{
			title = "Manage client";

			menuItems = new string[] 
			{
				"Information",
				"Rent room",
				"Return room",
				"Show rented rooms",
				"Remove client"
			};
		}
		
		private readonly Client currentClient;

		public SingleClientManagementMenu(ConsoleMenuBase parentMenu, Client currentClient) 
			: base(parentMenu, SingleClientManagementMenu.title, SingleClientManagementMenu.menuItems)
		{
			if (currentClient == null) 
			{
				throw new ArgumentNullException("currentClient", "Invalid null value");
			}

			this.currentClient = currentClient;
		}

		public override void Show()
		{
			int selectedIndex;
			do
			{
				ConsoleManager.Reset();
				ConsoleManager.ShowTitle(Title);

				selectedIndex = ConsoleManager.ShowMenu("Options:", this.MenuItems);

				switch (selectedIndex) 
				{
					case 0:
						ShowInformation();
						break;
					case 1:
						RentRoom();
						break;
					case 2:
						ReturnRoom();
						break;
					case 3:
						ShowRentedRooms();
						break;
					case 4:
						RemoveClient();
						break;
				}
			}
			while ((selectedIndex != this.QuitMenuItemIndex) && !hasToQuit);

			base.Show();
		}

		private void ShowInformation()
		{
			ConsoleManager.Reset();

			ConsoleManager.ShowTitle("Client information");

			ConsoleManager.ShowText("Registration date: ");
			ConsoleManager.ShowTextLine(currentClient.DateRegistered.ToShortDateString());

			ConsoleManager.ShowText("Name: ");
			ConsoleManager.ShowTextLine(string.Format("{0} {1}", currentClient.FirstName, currentClient.LastName));

			ConsoleManager.ShowText("Phone number: ");
			ConsoleManager.ShowTextLine(currentClient.PhoneNumber);

			ConsoleManager.ShowText("SSN: ");
			ConsoleManager.ShowTextLine(currentClient.SSN);

			ConsoleManager.WaitForUserReaction();
		}

		private void RentRoom()
		{
			var availableRooms = StorageManager.CurrentHotel.GetAvialableRooms();

			if (!availableRooms.Any()) 
			{
				ConsoleManager.ShowErrorMessage("There are no available rooms to rent");
				ConsoleManager.WaitForUserReaction();
				return;
			}

			ConsoleManager.Reset();

			ConsoleManager.ShowTitle("Rent a room");
			ConsoleManager.ShowTextLine(string.Format("Rent a room for client {0} {1}.", currentClient.FirstName, currentClient.LastName));

			string[] menuItems = availableRooms
											   .Select(x => string.Format("#{0} for {1} persons ${2} per day",
												   x.Number.ToString(), x.GetCapacity(), x.CalculatePrice(24)))
											   .ToArray();

			int selectedIndex = ConsoleManager.ShowMenu("Select room:", menuItems);
			Room selectedRoom = StorageManager.CurrentHotel.Rooms.Where(x => x.Equals(availableRooms[selectedIndex])).First();
			
			currentClient.ReturnRentedObject(selectedRoom);

			try
			{
				StorageManager.UpdateCurrentHotel();
			}
			catch (Exception ex)
			{
				ConsoleManager.ShowErrorMessage(ex.Message);
				ConsoleManager.WaitForUserReaction();
			}
		}
		
		private void ReturnRoom()
		{
			var clientRentedRooms = StorageManager.CurrentHotel.Rooms.Where(x => x.Owner == currentClient).ToList();

			if (!clientRentedRooms.Any()) 
			{
				ConsoleManager.ShowErrorMessage("This client doesn't have any rented rooms.");
				ConsoleManager.WaitForUserReaction();
				return;
			}

			ConsoleManager.Reset();

			ConsoleManager.ShowTitle("Return a room");
			ConsoleManager.ShowTextLine(string.Format("Return a room for client {0} {1}.", currentClient.FirstName, currentClient.LastName));

			string[] menuItems = clientRentedRooms
												  .Select(x => string.Format("#{0} for {1} persons ${2} per day",
													  x.Number.ToString(), x.GetCapacity(), x.CalculatePrice(24)))
												  .ToArray();

			int selectedIndex = ConsoleManager.ShowMenu("Select room:", menuItems);
			Room selectedRoom = StorageManager.CurrentHotel.Rooms.Where(x => x.Equals(clientRentedRooms[selectedIndex])).First();

            currentClient.TryRentObject(selectedRoom);

			try
			{
				StorageManager.UpdateCurrentHotel();
			}
			catch (Exception ex)
			{
				ConsoleManager.ShowErrorMessage(ex.Message);
				ConsoleManager.WaitForUserReaction();
			}
		}

		private void ShowRentedRooms()
		{
			ConsoleManager.Reset();

			ConsoleManager.ShowTitle("Currently rented rooms");

			ConsoleManager.ShowTextLine(string.Format("Rooms rended by {0} {1}.", currentClient.FirstName, currentClient.LastName));

			var rentedRooms = StorageManager.CurrentHotel
											.Rooms
											.Where(x => x.Owner == currentClient)
											.ToList();

			if (rentedRooms.Count == 0)
			{
				ConsoleManager.ShowTextLine("This client does't have any currently rented rooms.");
				ConsoleManager.WaitForUserReaction();
				return;
			}

			var tableTitles = new string[] { "Number", "Date rented", "Days spend", "Price" };

			var tibleItems = new List<TableItem>();
			foreach (Room room in rentedRooms) 
			{
				TimeSpan timeOwned = DateTime.Now - room.DateTimeRented;

				var values = new List<string>
				{
					room.Number.ToString(),
					room.DateTimeRented.ToShortDateString(),
					timeOwned.TotalDays.ToString(),
					"$" + room.CalculatePrice((int)timeOwned.TotalHours).ToString("#.00")
				};

				tibleItems.Add(new TableItem(values));
			}

			ConsoleManager.ShowTable(tableTitles, tibleItems);
		}

		private void RemoveClient()
		{
			StorageManager.CurrentHotel.Clients.Remove(currentClient);

			try
			{
				StorageManager.UpdateCurrentHotel();
			}
			catch (Exception ex)
			{
				ConsoleManager.ShowErrorMessage(ex.Message);
				ConsoleManager.WaitForUserReaction();
				return;
			}

			ConsoleManager.ShowTextLine("Successfully removed.");
			ConsoleManager.WaitForUserReaction();
			hasToQuit = true;

			try
			{
				StorageManager.UpdateCurrentHotel();
			}
			catch (Exception ex)
			{
				ConsoleManager.ShowErrorMessage(ex.Message);
				ConsoleManager.WaitForUserReaction();
			}
		}
	}
}