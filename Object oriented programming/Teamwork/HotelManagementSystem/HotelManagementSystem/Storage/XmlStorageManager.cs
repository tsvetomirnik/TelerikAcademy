using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;

namespace HotelManagementSystem.Storage
{
	public class XmlStorageManager
	{
		/// <summary>Writes object to xml file in a specific path</summary>
		/// <param name="filePath">Path where the xml file will be stored</param>
		/// <param name="obj">The object to be written in the xml file</param>
		/// <exception cref="StorageException"/>
		public static void WriteObject(string filePath, object obj)
		{
			var settings = new XmlWriterSettings { Indent = true };

			try
			{
				using (var xmlWriter = XmlWriter.Create(filePath, settings))
				{
					var serializer = new DataContractSerializer(obj.GetType());
					serializer.WriteObject(xmlWriter, obj);
				}
			}
			catch (Exception ex)
			{
				throw new StorageException("Error while trying to write object to file.", filePath, ex);
			}
		}

		/// <summary>Reads object from stored xml file</summary>
		/// <param name="filePath">Path where the xml file will be stored</param>
		/// <exception cref="StorageException"/>
		public static T ReadObject<T>(string filePath)
		{
			try
			{
				using (FileStream fileStream = File.Open(filePath, FileMode.Open))
				{
					var serializer = new DataContractSerializer(typeof(T));
					var data = (T)serializer.ReadObject(fileStream);
					return data;
				}
			}
			catch (Exception ex)
			{
				throw new StorageException("Error while trying to read object from file.", filePath, ex);
			}
		}

		/// <summary>Deletes file from the local storage</summary>
		/// <param name="filePath">Path where the xml file will be stored</param>
		/// <exception cref="StorageException"/>
		public static void DeleteFile(string filePath)
		{
			if (!FileExists(filePath))
			{
				return;
			}

			try
			{
				File.Delete(filePath);
			}
			catch (Exception ex)
			{
				throw new StorageException("Error while trying to delete file.", filePath, ex);
			}
		}

		/// <summary>Check is file with specific filename exists</summary>
		/// <param name="filePath">Path where the xml file will be stored</param>
		/// <returns>True if file exists</returns>
		/// <exception cref="StorageException"/>
		public static bool FileExists(string filePath)
		{
			try
			{
				return File.Exists(filePath);
			}
			catch (Exception ex)
			{
				throw new StorageException("Error while tring to check if file exists.", filePath, ex);
			}
		}
	}
}
