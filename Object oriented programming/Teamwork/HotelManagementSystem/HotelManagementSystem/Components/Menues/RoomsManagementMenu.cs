using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Items;
using HotelManagementSystem.Storage;

namespace HotelManagementSystem.Components.Menues
{
	class RoomsManagementMenu : ConsoleMenuBase
	{
		private static readonly string title;
		private static readonly string[] menuItems;

		static RoomsManagementMenu() 
		{
			title = "Rooms management";

			menuItems = new string[] 
			{ 
				"New room",
				"Show rooms",
			};
		}

		public RoomsManagementMenu (ConsoleMenuBase parentMenu) 
			: base(parentMenu, RoomsManagementMenu.title, RoomsManagementMenu.menuItems)
		{
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
						AddNewRoom();
						break;
					case 1:
						ShowRooms();
						break;
				}

			} while (selectedIndex != this.QuitMenuItemIndex);

			base.Show();
		}

		private void AddNewRoom()
		{
			ConsoleManager.Reset();

			ConsoleManager.ShowTitle("Create new room");

			// TODO: Clear magic numbers
			int floor = ConsoleManager.GetInteger("Floor: ", 0, 100);
			int number = ConsoleManager.GetInteger("Number: ", 0, 300);
			decimal pricePerHour = (decimal)ConsoleManager.GetDouble("Number: ", 0, 1000);
			
			// TODO: Check is the number is unique
			var roomNumber = new RoomNumber();
			roomNumber.Floor = floor;
			roomNumber.Number = number;

			var room = new Room(roomNumber, pricePerHour);

			try
			{
				StorageManager.CurrentHotel.Rooms.Add(room);
				StorageManager.UpdateCurrentHotel();
			}
			catch (Exception ex)
			{
				ConsoleManager.ShowErrorMessage(ex.Message);
				ConsoleManager.WaitForUserReaction();
			}
		}

		private void ShowRooms()
		{
			if (!StorageManager.CurrentHotel.Rooms.Any()) 
			{
				ConsoleManager.ShowErrorMessage("There are no existing rooms.");
				ConsoleManager.WaitForUserReaction();
				return;
			}

			ConsoleManager.Reset();

			ConsoleManager.ShowTitle("Rooms");

			try
			{
				var tableTitles = new string[] { "Number", "Capacity", "Rented by" };

				var tibleItems = new List<TableItem>();
				foreach (var room in StorageManager.CurrentHotel.Rooms) 
				{
					var values = new List<string>
					{
						room.Number.ToString(),
						room.GetCapacity().ToString(),
						room.Owner == null? "free" : string.Format("{0} {1}.",  room.Owner.FirstName,  room.Owner.LastName[0])
					};

					tibleItems.Add(new TableItem(values));
				}

				ConsoleManager.ShowTable(tableTitles, tibleItems);
			}
			catch (Exception ex)
			{
				ConsoleManager.ShowErrorMessage(ex.Message);
			}
			
			ConsoleManager.WaitForUserReaction();
		}
	}
}
