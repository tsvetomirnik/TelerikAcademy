using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
    public interface  IReplaceable
    {
        int CheckQuantity();

        void Replace(int quantity);
    }
}
