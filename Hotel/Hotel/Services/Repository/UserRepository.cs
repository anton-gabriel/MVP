using Hotel.Models.Entity;

namespace Hotel.Services.Repository
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        #region Constructors
        public UserRepository(HotelContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public HotelContext HotelContext => Context as HotelContext;
        #endregion
    }
}
