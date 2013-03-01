using System;

namespace CustomTimer
{
	class Program
	{
		private static Timer _dateUpdateTimer;
		private static int _stopCounter;

		static void Main()
		{
			_dateUpdateTimer = new Timer(5);
			_dateUpdateTimer.Callback += PrintHello;
			_dateUpdateTimer.Start();
			Console.WriteLine("Timer started!");
			Console.WriteLine("Do some operations while waiting to be called...");
		}
		
		private static void PrintHello()
		{
			if(_stopCounter < 3)
			{
				_stopCounter++;
			}
			else
			{
				PrintCloseMessage();
				_dateUpdateTimer.Stop();
			}
			
			Console.WriteLine("Current time is {0}", DateTime.Now.ToLongTimeString());
		}

		private static void PrintCloseMessage()
		{
			Console.WriteLine("Good Bye!");
		}
	}
}
