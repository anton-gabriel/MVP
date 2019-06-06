using Hotel.Models.Entity;
using System;
using System.Collections.Generic;

namespace Hotel.Services.Repository
{
    internal interface IBookingRoomRepository : IRepository<BookingRoom>
    {
        IEnumerable<Room> GetAvailableRooms(DateTime start, DateTime end);
        IEnumerable<BookingRoom> GetAllBookingRoomsForUser(int userId);
    }
}
