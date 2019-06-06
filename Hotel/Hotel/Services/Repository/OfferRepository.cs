using Hotel.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Services.Repository
{
    internal class OfferRepository : Repository<Offer>, IOfferRepository
    {
        #region Constructors
        public OfferRepository(HotelContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public HotelContext HotelContext => Context as HotelContext;
        #endregion

        #region IOfferRepository
        public IEnumerable<Offer> GetAvailableOffers(DateTime start, DateTime end)
        {
            var offers = HotelContext.Offers.Where(value => (value.StartPeriod >= start) && (value.EndPeriod <= end)).ToList();
            var booked = HotelContext.BookingOffers.Select(value => value.Offer).ToList();
            return offers.Except(booked);
        }
        #endregion
    }
}
