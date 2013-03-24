using System;
using System.Linq;

namespace HotelManagementSystem.Items
{
    public interface IExpirable
    {
        DateTime ManufactureDate { get; set; }
        DateTime DateOfExpire { get; set; }

        bool IsExpired();
    }
}
