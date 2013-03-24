using System;
using System.Linq;
using HotelManagementSystem.Storage;

namespace HotelManagementSystem.Components.Menues
{
	class MainMenu : ConsoleMenuBase
	{
		private static readonly string title;
		private static readonly string[] menuItems;

		static MainMenu() 
		{
			title = string.IsNullOrEmpty(StorageManager.CurrentHotel.Name)
					? "Management system" : StorageManager.CurrentHotel.Name;
			
			menuItems = new string[]
			{
				"Clients",
				"Rooms",
				"Items",
				"Hotel"
			};
		}

		public MainMenu(ConsoleMenuBase parentMenu) 
			: base(parentMenu, MainMenu.title, MainMenu.menuItems)
		{
		}

		public override void Show()
		{
			int selectedIndex;
			do
			{
				ConsoleManager.Reset();
				ConsoleManager.ShowTitle(Title);

				selectedIndex = ConsoleManager.ShowMenu("Main menu:", this.MenuItems);

				switch (selectedIndex)
				{
					case 0:
						ShowClientsManagementMenu();
						break;
					case 1:
						ShowRoomsManagementMenu();
						break;
					case 2:
						ShowItemsManagementMenu();
						break;
					case 3:
						ShowHotelInfoManagementMenu();
						break;
				}
			}while (selectedIndex != this.QuitMenuItemIndex);

			base.Show();
		}

		private void ShowClientsManagementMenu()
		{
			var clientsManagementMenu = new ClientsManagementMenu(this);
			clientsManagementMenu.Show();
		}

		private void ShowRoomsManagementMenu()
		{
			var roomsManagementMenu = new RoomsManagementMenu(this);
			roomsManagementMenu.Show();
		}

		private void ShowItemsManagementMenu()
		{
			var itemsManagementMenu = new ItemsManagementMenu(this);
			itemsManagementMenu.Show();
		}

		private void ShowHotelInfoManagementMenu()
		{
			var hotelInfoManagementMenu = new HotelInfoManagementMenu(this);
			hotelInfoManagementMenu.Show();
		}
	}
}