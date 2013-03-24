using System;
using System.Linq;

namespace HotelManagementSystem.Storage
{
	public class GenericStorage<T>
	{
		private string filePath;

		/// <summary>
		/// Initialize new storage for file with specific path
		/// </summary>
		/// <param name="filePath">Path of the file to store the data</param>
		public GenericStorage(string filePath) 
		{
			this.FilePath = filePath;
		}

		/// <summary>
		/// Path location where the data will be stored
		/// </summary>
		public string FilePath 
		{
			get { return this.filePath; }
			private set 
			{
				if (value == null) 
				{
					throw new ArgumentNullException("FilePath", "Invalid null value.");
				}

				if(!Uri.IsWellFormedUriString(value, UriKind.Relative))
				{
					throw new FormatException("Invalid absolute path.");
				}

				this.filePath = value;
			}
		}

		/// <summary>
		/// Loads a object of type T from the stored file
		/// </summary>
		/// <returns></returns>
		public T Load()
		{
			try
			{
				if (!XmlStorageManager.FileExists(this.FilePath)) 
				{
					return default(T);
				}

				return XmlStorageManager.ReadObject<T>(this.FilePath);
			}
			catch (StorageException ex)
			{
				XmlStorageManager.DeleteFile(this.FilePath);
				throw new StorageException("Unable to load data.", this.filePath, ex);
			}
		}

		/// <summary>
		/// Save a object to the stored file
		/// </summary>
		/// <param name="obj">Object to be stored</param>
		public void Save(T obj)
		{
			try
            {
                XmlStorageManager.WriteObject(this.FilePath, obj);
            }
            catch (StorageException ex)
            {
                XmlStorageManager.DeleteFile(this.FilePath);
				throw new StorageException("Unable to save changes.", this.filePath, ex);
            }
		}
	}
}
