using System;
using MobilePhoneDevice.Items;

namespace MobilePhoneDevice
{
	public static class GSMTest
	{
		public static void Start()
		{
			//Array of GSM objects
			var gsmDevices = new GSM[]
			{
				new GSM("HTC Mozart", "HTC"),
				new GSM("HTC One", "HTC"),
				new GSM("iPhone 4", "Apple"),
				new GSM("Samsung Galaxy S", "Samsung"),
				new GSM("Samsung Galaxy S2", "Samsung")
			};

			//Display info about each object
			foreach (var gsmDevice in gsmDevices)
			{
				Console.WriteLine(gsmDevice.ToString());
			}
			
			//Disaply iPhone4 info
			Console.WriteLine(GSM.IPhone4S.ToString());
		}
	}
}