using System;
using System.Linq;
using HotelManagementSystem.Components;
using HotelManagementSystem.Components.Menues;
using HotelManagementSystem.Properties;
using HotelManagementSystem.Storage;

namespace HotelManagementSystem
{
	public class HotelManagementSystem
	{
		public HotelManagementSystem()
		{
			LoadData();
		}

		private void LoadData()
		{
			try
			{
				StorageManager.LoadCurrentHotel();
			}
			catch (Exception ex)
			{
				ConsoleManager.ShowErrorMessage(ex.Message);
				ConsoleManager.WaitForUserReaction();
			}
		}

		public void Start() 
		{
			ShowInitialScreen();
			CallMainMenu();
			CallAboutInformation();
		}
  
		private void ShowInitialScreen()
		{
			ConsoleManager.Reset();

			ConsoleManager.ShowTitle(Resources.ProgramTitle);
			ConsoleManager.ShowTextLine(Resources.ProgramDescription);
			ConsoleManager.WaitForUserReaction();
			ConsoleManager.Reset();
		}

		private void CallMainMenu()
		{
			MainMenu mainMenu = new MainMenu(null);
			mainMenu.Show();
		}

		private void CallAboutInformation()
		{
			ConsoleManager.ShowTextLine("For contact or more informatoin visit 'www.goofyproject.codeplex.com'");
		}
	}
}