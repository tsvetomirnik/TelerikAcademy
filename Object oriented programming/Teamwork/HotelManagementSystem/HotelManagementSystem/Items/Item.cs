using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
	public abstract class Item
	{
		private readonly string type;
		private string name;	

		public Item(string name) 
			: this(name, "item")
		{
		}

		protected Item(string name, string type)
		{
			this.name = name;
			this.type = type;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				if (String.IsNullOrEmpty(value)) 
				{
					throw new ArgumentException("Name", "Invalid null or empty value.");
				}
                    
				this.name = value;
			}
		}

		public string Type 
		{
			get
			{
				return type;
			}
		}
	}
}