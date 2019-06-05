using Hotel.Services.Repository;
using System;

namespace Hotel.Services.UnitOfWork
{
    internal interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IBookingOfferRepository BookingOffers { get; }
        IBookingRoomRepository BookingRooms { get; }
        IBookingRoomServiceRepository BookingRoomServices { get; }
        IFeatureRepository Features { get; }
        IOfferRepository Offers { get; }
        IRoomFeatureRepository RoomFeatures { get; }
        IRoomImageRepository RoomImages { get; }
        IRoomRepository Rooms { get; }
        IServiceRepository Services { get; }
        int Complete();
    }
}