using Hotel.Models.Entity;

namespace Hotel.Services.Repository
{
    internal class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        #region Constructors
        public FeatureRepository(HotelContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public HotelContext HotelContext => Context as HotelContext;
        #endregion
    }
}
