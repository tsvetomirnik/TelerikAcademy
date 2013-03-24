using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
	public abstract class ExpirableItemBase : ReplaceableItemBase, IExpirable
	{
		public DateTime ManufactureDate { get; set; }

		public DateTime DateOfExpire { get; set; }

		public ExpirableItemBase(DateTime manufactureDate, DateTime dateOfExpire) 
		{
			this.ManufactureDate = manufactureDate;
			this.DateOfExpire = dateOfExpire;
		}

		public virtual bool IsExpired()
		{
			if (DateTime.Now >= this.DateOfExpire)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}