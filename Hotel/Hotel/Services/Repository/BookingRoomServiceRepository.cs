using Hotel.Models.Entity;

namespace Hotel.Services.Repository
{
    internal class BookingRoomServiceRepository : Repository<BookingRoomService>, IBookingRoomServiceRepository
    {
        #region Constructors
        public BookingRoomServiceRepository(HotelContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public HotelContext HotelContext => Context as HotelContext;
        #endregion
    }
}
