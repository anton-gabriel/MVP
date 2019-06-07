using Hotel.Models.Entity;
using Hotel.Services;
using Hotel.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.DataAccess
{
    internal class ServiceDAL
    {
        #region Public methods
        public void AddService(Service service)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                unitOfWork.Services.Add(service);
                unitOfWork.Complete();
            }
        }
        public void RemoveService(Service service)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                service.Deleted = true;
                unitOfWork.Complete();
            }
        }
        public void UpdateService(Service service)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Services.Get(service.Id);
                result.Price = service.Price;
                result.ServiceType = service.ServiceType;
                result.Deleted = service.Deleted;
                unitOfWork.Complete();
            }
        }
        public Service GetService(int id)
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                var result = unitOfWork.Services.Get(id);
                return result?.Deleted == false ? result : null;
            }
        }
        public IEnumerable<Service> GetAllServices()
        {
            using (var unitOfWork = new UnitOfWork(new HotelContext()))
            {
                return unitOfWork.Services.GetAll().Where(value => value.Deleted == false).ToList();
            }
        }
        #endregion
    }
}
