using Hotel.Models.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Hotel.Services.Repository
{
    internal class RoomFeatureRepository : Repository<RoomFeature>, IRoomFeatureRepository
    {
        #region Constructors
        public RoomFeatureRepository(HotelContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public HotelContext HotelContext => Context as HotelContext;

        #endregion

        #region IRoomFeatureRepository
        public IEnumerable<Feature> GetFeatures(int roomId)
        {
            return HotelContext.RoomFeatures.Where(value => (value.RoomId == roomId) && (value.Deleted == false)).Select(value => value.Feature).ToList();
        }

        public IEnumerable<RoomFeature> GetRoomFeatures(int roomId)
        {
            return HotelContext.RoomFeatures
                .Include(value => value.Feature)
                .Include(value => value.Room)
                .Where(value => (value.RoomId == roomId) && (value.Deleted == false)).ToList();
        }
        #endregion
    }
}
