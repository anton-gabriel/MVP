using Hotel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var booked =  HotelContext.BookingRooms.Where(value => value.EndPeriod < start).Select(value => value.Room).ToList();
            var nonBooked = HotelContext.Rooms.ToList().Except(booked);
            return booked.Union(nonBooked);
        }
        #endregion
    }
}
