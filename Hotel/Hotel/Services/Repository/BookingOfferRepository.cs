﻿using Hotel.Models.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Hotel.Services.Repository
{
    internal class BookingOfferRepository : Repository<BookingOffer>, IBookingOfferRepository
    {
        #region Constructors
        public BookingOfferRepository(HotelContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public HotelContext HotelContext => Context as HotelContext;

        #endregion

        #region IBookingOfferRepository
        public IEnumerable<BookingOffer> GetAllBookingOffersForUser(int userId)
        {
            return HotelContext.BookingOffers
                .Include(value => value.User)
                .Include(value => value.Offer)
                .Where(value => (value.UserId == userId) && (value.Deleted == false))
                .ToList();
        }
        #endregion
    }
}
