using Hotel.Models.Entity;
using System.Collections.Generic;

namespace Hotel.Services.Repository
{
    internal interface IBookingOfferRepository : IRepository<BookingOffer>
    {
        IEnumerable<BookingOffer> GetAllBookingOffersForUser(int userId);
    }
}
