using System;
using System.Linq;

namespace HotelManagementSystem.Components.Menues
{
	class ItemsManagementMenu : ConsoleMenuBase
	{
		public const int PhoneNumberLength = 6;

		private static readonly string title;
		private static readonly string[] menuItems;
		
		static ItemsManagementMenu()
		{
			title = "Items management *Beta";

			menuItems = new string[]
			{
				"Add item",
				"Show items",
				"Select item",
				"Manage item"
			};
		}

		public ItemsManagementMenu(ConsoleMenuBase parentMenu) 
			: base(parentMenu, ItemsManagementMenu.title, ItemsManagementMenu.menuItems)
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
				ConsoleManager.ShowTextLine("Still in beta.");
			}
			while (selectedIndex != this.QuitMenuItemIndex);

			base.Show();
		}
	}
}