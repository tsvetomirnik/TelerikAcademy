using System;
using System.Linq;

namespace Attributes
{
	class Program
	{
		static void Main()
		{
			Type objectType = typeof (ExampleClass);
			Version version = AttributesReader.Read<VersionAttribute>(objectType).First().Version;
			Console.WriteLine("Class [{0}] has version [{1}].", objectType, version);
		}
	}
}