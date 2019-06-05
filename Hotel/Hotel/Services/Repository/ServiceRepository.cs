using Hotel.Models.Entity;

namespace Hotel.Services.Repository
{
    internal class ServiceRepository : Repository<Service>, IServiceRepository
    {
        #region Constructors
        public ServiceRepository(HotelContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public HotelContext HotelContext => Context as HotelContext;
        #endregion
    }
}
