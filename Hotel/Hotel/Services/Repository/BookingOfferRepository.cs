using Hotel.Models.Entity;

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
    }
}
