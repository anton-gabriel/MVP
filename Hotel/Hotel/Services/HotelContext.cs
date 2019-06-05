using Hotel.Models.Entity;
using System.Data.Entity;

namespace Hotel.Services
{
    internal class HotelContext : DbContext
    {
        #region Properties
        public DbSet<User> Users { get; set; }
        public DbSet<BookingOffer> BookingOffers { get; set; }
        public DbSet<BookingRoom> BookingRooms { get; set; }
        public DbSet<BookingRoomService> BookingRoomServices { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomFeature> RoomFeatures { get; set; }
        public DbSet<RoomImage> RoomImages { get; set; }
        public DbSet<Service> Services { get; set; }
        #endregion
    }
}
