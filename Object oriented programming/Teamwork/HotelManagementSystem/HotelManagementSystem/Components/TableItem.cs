using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelManagementSystem.Components
{
	public class TableItem
	{
		private readonly List<string> items;

		public TableItem(List<string> items) 
		{
			this.items = items;
		}

		public List<string> Items 
		{
			get { return this.items; }
		}
	}
}
