using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
    public abstract class ReplaceableItemBase : IReplaceable
    {
        public abstract int CheckQuantity();

        public abstract void Replace(int quantity);
    }
}
