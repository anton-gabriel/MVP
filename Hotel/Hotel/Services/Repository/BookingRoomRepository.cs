using Hotel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Hotel.Services.Repository
{
    internal class BookingRoomRepository : Repository<BookingRoom>, IBookingRoomRepository
    {
        #region Constructors
        public BookingRoomRepository(HotelContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public HotelContext HotelContext => Context as HotelContext;
        #endregion

        #region IBookingRoomRepository
        public IEnumerable<Room> GetAvailableRooms(DateTime start, DateTime end)
        {
            var available = HotelContext.BookingRooms.Where(value => (value.EndPeriod < start) && (value.Deleted == false)).Select(value => value.Room).ToList();
            var booked = HotelContext.BookingRooms.Where(value => value.Deleted == false).Select((value => value.Room)).ToList().Except(available);
            var nonBooked = HotelContext.Rooms.Where(value => value.Deleted == false).ToList().Except(booked);
            return booked.Union(nonBooked);
        }

        public IEnumerable<BookingRoom> GetAllBookingRoomsForUser(int userId)
        {
            return HotelContext.BookingRooms
                .Include(value => value.User)
                .Include(value => value.Room)
                .Where(value => (value.UserId == userId) && (value.Deleted == false)).ToList();
        }
        #endregion
    }
}
