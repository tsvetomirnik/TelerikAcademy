using System;

namespace CustomException
{
	public class InvalidRangeException<T> : Exception
	{
		public T OutrangeValue { get; private set; }

		public T MinValue { get; private set; }

		public T MaxValue { get; private set; }

		public InvalidRangeException()
		{
		}

		public InvalidRangeException(string message, Exception innerException = null) 
			: this(message, default(T), innerException)
		{
		}

		public InvalidRangeException(string message, T outrangeValue, Exception innerException = null) 
			: this(message, outrangeValue, default(T), default(T), innerException)
		{
		}

		public InvalidRangeException(string message, T outrangeValue, T minValue, T maxValue, Exception innerException = null) 
			: base(message, innerException)
		{
			OutrangeValue = outrangeValue;
			MinValue = minValue;
			MaxValue = maxValue;
		}
	}
}