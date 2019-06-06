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
    internal class OfferDAL
    {
        #region Public methods
        public void AddOffer(Offer room)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                unitOfWork.Offers.Add(room);
                unitOfWork.Complete();
            }
        }
        public void RemoveOffer(Offer offer)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                offer.Deleted = true;
                unitOfWork.Complete();
            }
        }
        public void UpdateOffer(Offer offer)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Offers.Get(offer.Id);
                result = offer;
                unitOfWork.Complete();
            }
        }
        public Offer GetOffer(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Offers.Get(id);
                return result?.Deleted == false ? result : null;
            }
        }
        public OfferData GetOfferData(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                IEnumerable<Feature> features = unitOfWork.RoomFeatures.GetFeatures(roomId: id);
                IEnumerable<RoomImage> images = unitOfWork.RoomImages.GetImages(roomId: id);
                Room room = unitOfWork.Rooms.Get(id);
                Offer offer = unitOfWork.Offers.Get(id);
                return room.ToData(features, images).ToOfferData(offer);
            }
        }

        public IEnumerable<OfferData> GetAvailableOffersData(DateTime start, DateTime end)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.Offers.GetAvailableOffers(start, end).Select(value => GetOfferData(value.Id));
            }
        }
        #endregion
    }
}
