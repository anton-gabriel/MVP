using Hotel.Services.Repository;

namespace Hotel.Services.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        #region Constructors
        public UnitOfWork(HotelContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            Users = new UserRepository(context);
            BookingOffers = new BookingOfferRepository(context);
            Offers = new OfferRepository(context);
            BookingRoomServices = new BookingRoomServiceRepository(context);
            BookingRooms = new BookingRoomRepository(context);
            Services = new ServiceRepository(context);
            RoomFeatures = new RoomFeatureRepository(context);
            Features = new FeatureRepository(context);
            RoomImages = new RoomImageRepository(context);
            Rooms = new RoomRepository(context);
        }
        #endregion

        #region Private fields
        private readonly HotelContext context;
        #endregion

        #region Properties
        public IUserRepository Users { get; private set; }
        public IBookingOfferRepository BookingOffers { get; private set; }
        public IBookingRoomRepository BookingRooms { get; private set; }
        public IBookingRoomServiceRepository BookingRoomServices { get; private set; }
        public IFeatureRepository Features { get; private set; }
        public IOfferRepository Offers { get; private set; }
        public IRoomFeatureRepository RoomFeatures { get; private set; }
        public IRoomImageRepository RoomImages { get; private set; }
        public IRoomRepository Rooms { get; private set; }
        public IServiceRepository Services { get; private set; }
        #endregion

        #region IUnitOfWork
        public int Complete()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
        #endregion
    }
}
