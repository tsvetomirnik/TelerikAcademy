using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Items;
using HotelManagementSystem.Storage;

namespace HotelManagementSystem.Components.Menues
{
	class HotelInfoManagementMenu : ConsoleMenuBase
	{
		private static readonly string title;
		private static readonly string[] menuItems;

		static HotelInfoManagementMenu()
		{
			title = "Hotel info management";

			menuItems = new string[]
			{
				"Set name",
				"Set address",
				"Show info"
			};
		}

		public HotelInfoManagementMenu(ConsoleMenuBase parentMenu) 
			: base(parentMenu, HotelInfoManagementMenu.title, HotelInfoManagementMenu.menuItems)
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
						SetName();
						break;
					case 1:
						SetAddress();
						break;
					case 2:
						ShowInfo();
						break;
				}
			}
			while (selectedIndex != this.QuitMenuItemIndex);

			base.Show();
		}

		private void SetName()
		{
			ConsoleManager.Reset();
			ConsoleManager.ShowTitle("Hotel info");

			string name = ConsoleManager.GetText("Name: ", 1);

			try
			{
				StorageManager.CurrentHotel.Name = name;
				StorageManager.UpdateCurrentHotel();
			}
			catch (Exception)
			{
				ConsoleManager.ShowErrorMessage("Unable to save hotel name.");
				ConsoleManager.WaitForUserReaction();
			}
		}

		private void SetAddress()
		{
			ConsoleManager.Reset();
			ConsoleManager.ShowTitle("Hotel info");

			string address = ConsoleManager.GetText("Address: ", 10);

			try
			{
				StorageManager.CurrentHotel.Address = address;
				StorageManager.UpdateCurrentHotel();
			}
			catch (Exception)
			{
				ConsoleManager.ShowErrorMessage("Unable to save hotel address.");
				ConsoleManager.WaitForUserReaction();
			}
		}

		private void ShowInfo()
		{
			ConsoleManager.Reset();
			ConsoleManager.ShowTitle("Hotel info");

			ConsoleManager.ShowText("Name: ");
			ConsoleManager.ShowTextLine(StorageManager.CurrentHotel.Name);
			
			ConsoleManager.ShowText("Address: ");
			ConsoleManager.ShowTextLine(StorageManager.CurrentHotel.Address);

			ConsoleManager.WaitForUserReaction();
		}
	}
}