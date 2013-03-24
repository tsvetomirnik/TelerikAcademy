using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
    public class Food : ExpirableItemBase
    {
		private int quantity;

        public Food(string name, int quantity, DateTime manufactureDate, DateTime dateOfExpire)
			: base(manufactureDate, dateOfExpire)
        {
            this.Name = name;
			this.Quantity = quantity;
        }

		public string Name { get; private set; }

		public int Quantity
		{
			get { return this.quantity; }
			set 
			{
				if (value < 0) 
				{
					throw new ArgumentOutOfRangeException("Quantity", "Invalid negative value.");
				}

				this.quantity = value;
			}
		}

        public override int CheckQuantity()
        {
            return this.quantity;
        }

		/// <summary>
		/// Decrease quantity of the item
		/// </summary>
        public void Consume(int someFood)
        {
            if (this.quantity - someFood >= 0)
            {
                this.quantity -= someFood;
            }
            else
            {
                this.quantity = 0;
                throw new ArgumentOutOfRangeException("You can not eat more than there is!!!");
            }
        }

		/// <summary>
		/// Adds additional items quantity
		/// </summary>
        public override void Replace(int quantity) 
        {
            this.quantity += quantity;
        }
    }
}
