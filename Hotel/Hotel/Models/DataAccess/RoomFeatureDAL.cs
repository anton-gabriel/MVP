using Hotel.Models.Entity;
using Hotel.Services.UnitOfWork;
using Hotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Hotel.Utils;

namespace Hotel.Models.DataAccess
{
    internal class RoomFeatureDAL
    {
        //#region Public methods
        //public void AddRoomFeature(RoomFeature roomFeature)
        //{
        //    using (var unitOfWork = new UnitOfWork(new HotelContext()))
        //    {
        //        unitOfWork.Services.Add(service);
        //        unitOfWork.Complete();
        //    }

        //    using (SqlConnection con = Connections.HotelConnection)
        //    {
        //        SqlCommand cmd = new SqlCommand("ModifyBookingRoom", con);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        SqlParameter paramId = new SqlParameter("@roomBookingId", SqlDbType.Int);
        //        SqlParameter paramBId = new SqlParameter("@roomId", ext.RoomId);
        //        SqlParameter paramESId = new SqlParameter("@bookingId", ext.BookingId);

        //        cmd.Parameters.Add(paramId);
        //        cmd.Parameters.Add(paramBId);
        //        cmd.Parameters.Add(paramESId);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
        //public void RemoveRoomFeature(RoomFeature roomFeature)
        //{
        //    using (var unitOfWork = new UnitOfWork(new HotelContext()))
        //    {
        //        service.Deleted = true;
        //        unitOfWork.Complete();
        //    }
        //}
        //public void UpdateRoomFeature(RoomFeature roomFeature)
        //{
        //    using (var unitOfWork = new UnitOfWork(new HotelContext()))
        //    {
        //        var result = unitOfWork.Services.Get(service.Id);
        //        result.Price = service.Price;
        //        result.ServiceType = service.ServiceType;
        //        result.Deleted = service.Deleted;
        //        unitOfWork.Complete();
        //    }
        //}
        //public RoomFeature GetRoomFeature(int id)
        //{
        //    using (var unitOfWork = new UnitOfWork(new HotelContext()))
        //    {
        //        var result = unitOfWork.Services.Get(id);
        //        return result?.Deleted == false ? result : null;
        //    }
        //}
        ////public IEnumerable<Service> GetAllServices()
        ////{
        ////    using (var unitOfWork = new UnitOfWork(new HotelContext()))
        ////    {
        ////        return unitOfWork.Services.GetAll().Where(value => value.Deleted == false).ToList();
        ////    }
        ////}
        //#endregion
    }
}
