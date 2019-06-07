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
    internal class BookingOfferDAL
    {
        #region Public methods
        public void AddBookingOffer(BookingOffer bookingOffer)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                unitOfWork.BookingOffers.Add(bookingOffer);
                unitOfWork.Complete();
            }
        }
        public void RemoveBookingOffer(BookingOffer bookingOffer)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                bookingOffer.Deleted = true;
                unitOfWork.Complete();
            }
        }
        public void UpdateBookingOffer(BookingOffer bookingOffer)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.BookingOffers.Get(bookingOffer.Id);
                result = bookingOffer;
                unitOfWork.Complete();
            }
        }
        public BookingOffer GetBookingOffer(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.BookingOffers.Get(id);
                return result?.Deleted == false ? result : null;
            }
        }

        public IEnumerable<BookingOffer> GetAllBookingOffersForUser(int userId)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.BookingOffers.GetAllBookingOffersForUser(userId);
            }
        }
        public IEnumerable<BookingOffer> GetAllBookingOffers()
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.BookingOffers.GetAll();
            }
        }
        #endregion
    }
}
