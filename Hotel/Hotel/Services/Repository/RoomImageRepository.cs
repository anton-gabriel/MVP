using System.Collections.Generic;
using System.Linq;
using Hotel.Models.Entity;

namespace Hotel.Services.Repository
{
    internal class RoomImageRepository : Repository<RoomImage>, IRoomImageRepository
    {
        #region Constructors
        public RoomImageRepository(HotelContext context) :
            base(context)
        {

        }
        #endregion

        #region Properties
        public HotelContext HotelContext => Context as HotelContext;
        #endregion

        #region IRoomImageRepository
        public IEnumerable<RoomImage> GetImages(int roomId)
        {
            return HotelContext.RoomImages.Where(value => value.RoomId == roomId).ToList();
        }
        #endregion
    }
}
