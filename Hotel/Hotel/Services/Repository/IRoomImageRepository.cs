using Hotel.Models.Entity;
using System.Collections.Generic;

namespace Hotel.Services.Repository
{
    internal interface IRoomImageRepository : IRepository<RoomImage>
    {
        IEnumerable<RoomImage> GetImages(int roomId);
    }
}
