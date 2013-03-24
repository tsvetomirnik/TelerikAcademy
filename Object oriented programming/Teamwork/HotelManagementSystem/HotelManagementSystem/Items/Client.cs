using System;
using System.Linq;
using System.Runtime.Serialization;

namespace HotelManagementSystem.Items
{
	[DataContract]
	public class Client
	{
		[DataMember]
		private char[] ssn;

		[DataMember]
		private readonly DateTime dateRegistered;

		/// <summary>
		/// Initializes new Client object with specific firstName, lastName and phoneNumber
		/// </summary>
		public Client(string firstName, string lastName, string ssn)
		{
			dateRegistered = DateTime.Now;

			this.FirstName = firstName;
			this.LastName = lastName;
			this.SSN = ssn;
		}

		[DataMember]
		public string FirstName { get; private set; }
		
		[DataMember]
		public string LastName { get; private set; }
		
		[DataMember]
		public string PhoneNumber { get; set; }

		public string SSN 
		{
			get
			{
				return new string(ssn);
			}
			private set 
			{
				if (value == null)
				{
					throw new ArgumentNullException("SSN", "Invalid null value.");
				}

				this.ssn = value.GetSSN();
			}
		}
		
		public DateTime DateRegistered 
		{
			get
			{
				return this.dateRegistered;
			}
		}

		/// <summary>
		/// Tries to rent a IRentable objects if is not rented
		/// </summary>
		/// <returns>Returns True if the room was successfully rented, otherwise returns False</returns>
		public bool TryRentObject(IRentable rentableObject)
		{
			if (!rentableObject.IsRented)
			{
				rentableObject.Owner = this;
				rentableObject.DateTimeRented = DateTime.Now;
				return true;
			}

			return false;
		}

		/// <summary>
		/// Returns a IRentable objects if is rented by the current client
		/// </summary>
		public void ReturnRentedObject(IRentable rentableObject) 
		{
			if (rentableObject.Owner != this)
			{
				return;
			}

			rentableObject.Owner = null;
		}
	}
}