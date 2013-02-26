using System;
using System.Linq;
using MobilePhoneDevice.Items;

namespace MobilePhoneDevice
{
	public static class GSMCallHistoryTest
	{
		public static void Start()
		{
			//Create an instance of the GSM class.
			var myPhone = new GSM("HTC Mozart", "HTC");

			//Add few calls.
			myPhone.AddCall(new Call(new DateTime(2012, 3, 27, 9, 30 , 10), "0883448036", 140));
			myPhone.AddCall(new Call(new DateTime(2012, 3, 27, 10, 12, 53), "0883428135", 230));
			myPhone.AddCall(new Call(new DateTime(2012, 3, 27, 19, 3 , 32), "0883451438", 423));

			//Print call information
			myPhone.PrintCallHistory();
			Console.WriteLine();

			//Print the total price of the calls in the history for 0.37 per minute
			Console.WriteLine("Total calls price: ${0:0.##}", myPhone.GetCallsTotalPrise(0.37M));

			//Remove the longest call from the history and calculate the total price again
			var longestCall = myPhone.CallHistory.OrderByDescending(x => x.Duration).First();
			myPhone.DeleteCall(longestCall);
			Console.WriteLine("Longest call removed!");
			Console.WriteLine("Total calls price: ${0:0.##}", myPhone.GetCallsTotalPrise(0.37M));
			Console.WriteLine();
			myPhone.PrintCallHistory();

			//Finally clear the call history and print it.
			myPhone.ClearHistory();
			Console.WriteLine("History cleared!");
			myPhone.PrintCallHistory();
		}
	}
}