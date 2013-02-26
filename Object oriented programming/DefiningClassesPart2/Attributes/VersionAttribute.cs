using System;

namespace Attributes
{
	[AttributeUsage(AttributeTargets.Struct |
		AttributeTargets.Class |
		AttributeTargets.Interface |
		AttributeTargets.Enum |
		AttributeTargets.Method)]
	internal class VersionAttribute : Attribute
	{
		public Version Version { get; private set; }

		public VersionAttribute(string version)
		{
			try
			{
				Version = Version.Parse(version);
			}
			catch (Exception)
			{
				throw new ArgumentException("Invalid version format");
			}
		}
	}
}