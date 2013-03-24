using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace HotelManagementSystem.Components
{
	public static class ConsoleManager
	{
		private const char SeparatorSymbol = '=';
		public const string ErrorSymbol = "<!>";

		/// <summary>
		/// Waits till the user insert to console integer number
		/// </summary>
		public static int GetInteger(string message, int min, int max)
		{
			string input;
			int value;
			bool isValid = false;
			do
			{
				ShowText(message);
				input = Console.ReadLine();
				isValid = int.TryParse(input, out value);

				if (isValid) 
				{
					isValid = value >= min;
					isValid = value <= max;
					if (!isValid) 
					{
						ShowTextLine(string.Format("Must be in range between {0} and {1}", min, max));
					}
				}
			} while (!isValid);

			return value;
		}

		/// <summary>
		/// Waits till the user insert to console double number
		/// </summary>
		public static double GetDouble(string message, double min, double max)
		{
			if (message == null) 
			{
				throw new ArgumentNullException("message", "Invalid null value");
			}

			string input;
			double value;
			bool isValid = false;
			do
			{
				ShowText(message);
				input = Console.ReadLine();
				isValid = double.TryParse(input, out value);

				if (isValid) 
				{
					isValid = value >= min;
					isValid = value <= max;
					if (!isValid) 
					{
						ShowTextLine("Must be in range between" + min + " and " + max + ".");
					}
				}
			} while (!isValid);

			return value;
		}

		/// <summary>
		/// Waits till the user insert to console some text
		/// </summary>
		public static string GetText(string message, uint minLength = 1)
		{
			if (message == null) 
			{
				throw new ArgumentNullException("message", "Invalid null value");
			}

			string input;
			bool isValid = false;
			do
			{
				ShowText(message);
				input = Console.ReadLine();
				isValid = input != null;

				if (isValid) 
				{
					isValid = input.Length >= minLength;
					if (!isValid) 
					{
						ShowTextLine(string.Format("Must be at least {0} symbols long.", minLength ));
					}
				}
			} while (!isValid);
			return input;
		}

		/// <summary>
		/// Shows title element
		/// </summary>
		public static void ShowTitle(string text)
		{
			var titleLine = string.Format("{0} {1} {0}", new string(SeparatorSymbol, 3), text);

			ShowTextLine(new string(SeparatorSymbol, titleLine.Length));
			ShowTextLine(titleLine);
			ShowTextLine(new string(SeparatorSymbol, titleLine.Length));

			ShowTextLine(string.Empty);
		}

		/// <summary>
		/// Shows text on the same line
		/// </summary>
		public static void ShowText(string text)
		{
			if (text == null) 
			{
				throw new ArgumentNullException("text", "Invalid null value");
			}

			Console.Write(text);
		}

		/// <summary>
		/// Shows message and moves to next line
		/// </summary>
		public static void ShowTextLine(string text)
		{
			if (text == null) 
			{
				throw new ArgumentNullException("text", "Invalid null value");
			}

			Console.WriteLine(text);
		}

		/// <summary>
		/// Shows error messsage
		/// </summary>
		internal static void ShowErrorMessage(string text)
		{
			ShowTextLine(string.Format("{0} {1}", ErrorSymbol, text));
		}

		/// <summary>
		/// Shows values with leading number in front of them
		/// </summary>
		public static void ListValuesByIndex(string[] menuItems)
		{
			for (int i = 0; i < menuItems.Length; i++)
			{
				ShowTextLine(string.Format(" {0}. {1}", i+1, menuItems[i]));
			}
		}

		/// <summary>
		/// Shows data table
		/// </summary>
		public static void ShowTable(string[] header, List<TableItem> items) 
		{
			const string itemsSeparator = " - ";

			if (items.Count == 0) 
			{
				throw new ArgumentException("No items to show");
			}

			var headerBuilder = new StringBuilder();
			foreach (var headerItem in header)
			{
				headerBuilder.Append(headerItem);
				headerBuilder.Append(itemsSeparator);
			}

			ConsoleManager.ShowTextLine(headerBuilder.ToString());
			ConsoleManager.ShowTextLine(new string('-', headerBuilder.Length));

			foreach (var item in items)
			{
				foreach (var property in item.Items) 
				{
					ConsoleManager.ShowText(property);
					ConsoleManager.ShowText(itemsSeparator);
				}

				ConsoleManager.ShowTextLine(string.Empty);
			}
		}

		/// <summary>
		/// Shows menu and waits the user to select item
		/// </summary>
		/// <param name="message">Menu title message</param>
		/// <param name="menuItems">String items</param>
		public static int ShowMenu(string message, string[] menuItems)
		{
			const int MenuWidth = 20;
			string separator = new string(SeparatorSymbol, MenuWidth);

			ShowTextLine(message.ToUpper());
			ShowTextLine(separator);
			ListValuesByIndex(menuItems);
			ShowTextLine(separator);

			int selectedIndex = GetInteger("choose item: ", 1, menuItems.Length + 1);
			return selectedIndex - 1;
		}

		/// <summary>
		/// Waits till the user press any key
		/// </summary>
		public static void WaitForUserReaction()
		{
			ShowText("Press any key to continue...");
			Console.ReadKey();
		}

		/// <summary>
		/// Reset the console text
		/// </summary>
		public static void Reset()
		{
			Console.Clear();
		}
	}
}