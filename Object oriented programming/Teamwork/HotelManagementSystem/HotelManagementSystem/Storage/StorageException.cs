using System;
using System.Linq;

namespace HotelManagementSystem.Storage
{
	public class StorageException : Exception
	{
        public string FilePath { get; set; }

        public StorageException() 
            : this(string.Empty)
        {
        }

        public StorageException(string message) 
            : this(message, null)
        {
        }

        public StorageException(string message, Exception ex) 
            : this(message, string.Empty, ex)
        {
        }

		public StorageException(string message, string filePath, Exception ex) 
            : base(message, ex)
		{
            this.FilePath = filePath;
		}
	}
}
