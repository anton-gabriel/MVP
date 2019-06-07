using Hotel.Models.Entity;
using Hotel.Services;
using Hotel.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccess
{
    internal class BookingRoomDAL
    {
        #region Public methods
        public void AddBookingRoom(BookingRoom bookingRoom)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                unitOfWork.BookingRooms.Add(bookingRoom);
                unitOfWork.Complete();
            }
        }
        public void RemoveBookingRoom(BookingRoom bookingRoom)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                bookingRoom.Deleted = true;
                unitOfWork.Complete();
            }
        }
        public void UpdateBookingRoom(BookingRoom bookingRoom)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.BookingRooms.Get(bookingRoom.Id);
                result = bookingRoom;
                unitOfWork.Complete();
            }
        }
        public BookingRoom GetBookingRoom(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.BookingRooms.Get(id);
                return result?.Deleted == false ? result : null;
            }
        }
        public IEnumerable<BookingRoom> GetAllBookingRoomsForUser(int userId)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.BookingRooms.GetAllBookingRoomsForUser(userId);
            }
        }
        public IEnumerable<BookingRoom> GetAllBookingRooms()
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.BookingRooms.GetAll();
            }
        }
        #endregion
    }
}
