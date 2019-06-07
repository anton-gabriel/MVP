using Hotel.Models.Entity;
using System.Collections.Generic;

namespace Hotel.Services.Repository
{
    internal interface IRoomFeatureRepository : IRepository<RoomFeature>
    {
        IEnumerable<Feature> GetFeatures(int roomId);
        IEnumerable<RoomFeature> GetRoomFeatures(int roomId);
    }
}
