using Hotel.Models.Entity;
using Hotel.Services;
using Hotel.Services.UnitOfWork;

namespace Hotel.Models.DataAccess
{
    internal class FeatureDAL
    {
        #region Public methods
        public void AddFeature(Feature feature)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                unitOfWork.Features.Add(feature);
                unitOfWork.Complete();
            }
        }
        public void RemoveFeature(Feature feature)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                feature.Deleted = true;
                unitOfWork.Complete();
            }
        }
        public void UpdateFeature(Feature feature)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Features.Get(feature.Id);
                result.Name = feature.Name;
                result.Price = feature.Price;
                result.Deleted = feature.Deleted;
                unitOfWork.Complete();
            }
        }
        public Feature GetFeature(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Features.Get(id);
                return result?.Deleted == false ? result : null;
            }
        }
        #endregion
    }
}
