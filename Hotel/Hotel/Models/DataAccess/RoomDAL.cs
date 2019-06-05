using Hotel.Models.Entity;
using Hotel.Models.Extended;
using Hotel.Services;
using Hotel.Services.UnitOfWork;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Models.DataAccess
{
    internal class RoomDAL
    {
        #region Public methods
        public void AddRoom(Room room)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                unitOfWork.Rooms.Add(room);
                unitOfWork.Complete();
            }
        }
        public void RemoveRoom(Room room)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                room.Deleted = true;
                unitOfWork.Complete();
            }
        }
        public void UpdateRoom(Room room)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Rooms.Get(room.Id);
                result = room;
                unitOfWork.Complete();
            }
        }
        public Room GetRoom(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.Rooms.Get(id);
            }
        }

        public RoomData GetRoomData(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                IEnumerable<Feature> features = unitOfWork.RoomFeatures.GetFeatures(roomId: id);
                IEnumerable<RoomImage> images = unitOfWork.RoomImages.GetImages(roomId: id);
                Room room = unitOfWork.Rooms.Get(id);
                return room.ToData(features, images);
            }
        }

        public IEnumerable<RoomData> GetAvailableRoomsData(DateTime start, DateTime end)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.BookingRooms.GetAvailableRooms(start, end).Select(value => GetRoomData(value.Id));
            }
        }
        #endregion
    }
}
