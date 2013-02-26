using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace DefiningClassesPart2.Items
{
	internal static class PathStorage
	{
		private const string PathFileName = @"pathData.xml";

		public static void Save(Path path)
		{
			if(path == null)
			{
				throw new ArgumentNullException();
			}

			var serializer = new XmlSerializer(typeof(Path));
			using(var textWriter = new StreamWriter(PathFileName))
			{
				serializer.Serialize(textWriter, path);
			}
		}

		public static Path Load()
		{
			if(!File.Exists(PathFileName))
			{
				throw new FileNotFoundException();
			}

			Path path;
			var serializer = new XmlSerializer(typeof(Path));
			using(var textReader = new StreamReader(PathFileName))
			{
				path = (Path)serializer.Deserialize(textReader);
			}

			return path;
		}
	}
}
