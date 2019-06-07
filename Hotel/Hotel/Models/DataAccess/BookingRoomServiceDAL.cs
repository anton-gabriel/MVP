using Hotel.Models.Entity;
using Hotel.Services;
using Hotel.Services.UnitOfWork;

namespace Hotel.Models.DataAccess
{
    internal class BookingRoomServiceDAL
    {
        #region Public methods
        public void AddBookingRoomService(BookingRoomService bookingRoomService)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                unitOfWork.BookingRoomServices.Add(bookingRoomService);
                unitOfWork.Complete();
            }
        }
        public void RemoveBookingRoomService(BookingRoomService bookingRoomService)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                bookingRoomService.Deleted = true;
                unitOfWork.Complete();
            }
        }
        public void UpdateBookingRoomService(BookingRoomService bookingRoomService)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.BookingRoomServices.Get(bookingRoomService.Id);
                result = bookingRoomService;
                unitOfWork.Complete();
            }
        }
        public BookingRoomService GetBookingRoomService(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.BookingRoomServices.Get(id);
                return result?.Deleted == false ? result : null;
            }
        }
        #endregion
    }
}
