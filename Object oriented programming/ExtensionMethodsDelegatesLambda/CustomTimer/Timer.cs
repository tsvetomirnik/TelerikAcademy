using System;
using System.Threading;

namespace CustomTimer
{
	class Timer
	{
		public delegate void CallbackDelegate();
		public CallbackDelegate Callback;
		private int _secondsUpdateInterval;
		private Thread _timerThread;

		public Timer(int secondsUpdateInterval)
		{
			SecondsUpdateInterval = secondsUpdateInterval;
		}

		public void Start()
		{
			_timerThread = new Thread(DoWork);
			_timerThread.Start();
		}

		private void DoWork()
		{
			Callback();
			Thread.Sleep(SecondsUpdateInterval * 1000);

			if(_timerThread.IsAlive)
			{
				DoWork();
			}
		}

		public void Stop()
		{
			_timerThread.Abort();
		}

		public int SecondsUpdateInterval
		{
			get { return _secondsUpdateInterval; }
			private set
			{
				if(value <= 0)
				{
					throw new ArgumentNullException("value", "Cannot set negative or zero value as update interval.");
				}

				_secondsUpdateInterval = value;
			}
		}
	}
}
