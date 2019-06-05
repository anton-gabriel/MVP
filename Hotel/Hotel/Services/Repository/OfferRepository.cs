using Hotel.Models.Entity;

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
    }
}
