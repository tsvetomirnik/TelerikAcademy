using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagementSystem.Items;
using HotelManagementSystem.Storage;

namespace HotelManagementSystem.Components.Menues
{
	class ClientsManagementMenu : ConsoleMenuBase
	{
		public const int PhoneNumberLength = 6;

		private static readonly string title;
		private static readonly string[] menuItems;

		static ClientsManagementMenu()
		{
			title = "Client management";

			menuItems = new string[]
			{
				"Add client",
				"Show clients",
				"Select client",
				"Manage client"
			};
		}

		private Client currentClient;

		public ClientsManagementMenu(ConsoleMenuBase parentMenu) 
			: base(parentMenu, ClientsManagementMenu.title, ClientsManagementMenu.menuItems)
		{
		}

		public override void Show()
		{
			int selectedIndex;
			do
			{
				ConsoleManager.Reset();
				ConsoleManager.ShowTitle(Title);

				if (this.currentClient != null) 
				{
					ConsoleManager.ShowText("Current client: ");
					ConsoleManager.ShowTextLine(string.Format("{0} {1}", currentClient.FirstName, currentClient.LastName));
					ConsoleManager.ShowTextLine(string.Empty);
				}

				selectedIndex = ConsoleManager.ShowMenu("Options:", this.MenuItems);

				switch (selectedIndex) 
				{
					case 0:
						AddClient();
						break;
					case 1:
						ShowClientsTable();
						break;
					case 2:
						GetClient();
						break;
					case 3:
						ManageClient();
						break;
				}
			}
			while (selectedIndex != this.QuitMenuItemIndex);

			base.Show();
		}

		private void AddClient()
		{
			ConsoleManager.Reset();

			ConsoleManager.ShowTitle("Create new client");
			var firstName = ConsoleManager.GetText("First name: ");
			var lastName = ConsoleManager.GetText("Last name: ");

			string ssn;
			do
			{
				ssn = ConsoleManager.GetText("SSN: ", StringUtility.SSNLength);
			}
			while (!IsValidSSN(ssn));
			
			var phone = ConsoleManager.GetText("Phone number: ", PhoneNumberLength);
			var client = new Client(firstName, lastName, ssn);
			client.PhoneNumber = phone;

			try
			{
				StorageManager.CurrentHotel.Clients.Add(client);
				StorageManager.UpdateCurrentHotel();
			}
			catch (Exception ex)
			{
				ConsoleManager.ShowErrorMessage(ex.Message);
				ConsoleManager.WaitForUserReaction();
			}
		}
  
		private bool IsValidSSN(string value)
		{
			try
			{
				value.GetSSN();
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		private void ShowClientsTable()
		{
			if (!StorageManager.CurrentHotel.Clients.Any()) 
			{
				ConsoleManager.ShowErrorMessage("There are no available clients");
				ConsoleManager.WaitForUserReaction();
				return;
			}

			ConsoleManager.Reset();

			ConsoleManager.ShowTitle("Clients");

			try
			{
				var tableTitles = new string[] { "Name", "Registration date", "SSN", "Phone" };

				var tibleItems = new List<TableItem>();
				foreach (var client in StorageManager.CurrentHotel.Clients) 
				{
					var values = new List<string>
					{
						client.FirstName + " " + client.LastName,
						client.DateRegistered.ToShortDateString(),
						client.SSN,
						client.PhoneNumber
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

		private void GetClient()
		{
			if (!StorageManager.CurrentHotel.Clients.Any()) 
			{
				ConsoleManager.ShowErrorMessage("There are no available clients");
				ConsoleManager.WaitForUserReaction();
				return;
			}

			ConsoleManager.Reset();

			string[] menuItems = StorageManager.CurrentHotel.Clients.Select(x => x.FirstName + " " + x.LastName).ToArray();
			int selectedIndex = ConsoleManager.ShowMenu("Select client:", menuItems);
			currentClient = StorageManager.CurrentHotel.Clients[selectedIndex];
		}

		private void ManageClient()
		{
			if (currentClient == null) 
			{
				ConsoleManager.ShowErrorMessage("No client is selected");
				ConsoleManager.WaitForUserReaction();
				return;
			}

			ConsoleManager.Reset();

			var manageClientManagementMenu = new SingleClientManagementMenu(this, this.currentClient);
			manageClientManagementMenu.Show();
		}
	}
}