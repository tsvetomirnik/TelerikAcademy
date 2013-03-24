using System;
using System.Linq;
using HotelManagementSystem.Components;

namespace HotelManagementSystem.Components.Menues
{
	public abstract class ConsoleMenuBase
	{
		private const string BackText = "Back";
		private const string QuitText = "Quit";

		// TODO: Create menu item class
		private string[] menuItems;
		private int quitMenuItemIndex;
		
		public ConsoleMenuBase(ConsoleMenuBase parentMenu, string title, string[] menuItems) 
		{
			this.ParentMenu = parentMenu;
			this.Title = title;
			this.menuItems = menuItems;
			this.quitMenuItemIndex = menuItems.Count();

			AddQuitItemToMenu();
		}

		protected ConsoleMenuBase ParentMenu { get; set; }

		public string Title { get; set; }

		private void AddQuitItemToMenu()
		{
			// Set back or quit menu item 
			int newSize = menuItems.Count() + 1;
			Array.Resize(ref menuItems, newSize);

			menuItems[newSize - 1] = ParentMenu == null? QuitText : BackText;
		}

		public int QuitMenuItemIndex 
		{
			get 
			{
				return quitMenuItemIndex;
			}
		}

		public string[] MenuItems 
		{
			get 
			{
				return this.menuItems;
			}
		}

		public virtual void Show() 
		{
			ConsoleManager.Reset();
		}
	}
}
