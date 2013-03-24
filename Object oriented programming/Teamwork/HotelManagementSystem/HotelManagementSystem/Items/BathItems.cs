using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
	public class BathItems : ReplaceableItemBase
	{
		public string Name { get; set; }

		public int Quantity { get; set; }
        
		public DateTime LastReplacedDate { get; set; }

		public TimeSpan ReplacePeriod { get; set; }

		public BathItems(string name, TimeSpan replacePeriod)
		{
			this.Name = name;
			this.ReplacePeriod = replacePeriod;
		}
		
		public override int CheckQuantity()
		{
			return this.Quantity;
		}

		// TODO: Fix not used argument
		public override void Replace(int quantity)
		{
			this.LastReplacedDate = DateTime.Now;
		}

		public bool HasReplace()
		{
			bool hasToReplace = DateTime.Now - this.LastReplacedDate > ReplacePeriod;
			return hasToReplace;
		}
	}
}