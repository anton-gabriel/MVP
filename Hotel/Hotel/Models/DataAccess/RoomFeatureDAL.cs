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
        #region Public methods
        public void AddRoomFeature(RoomFeature roomFeature)
        {
            using (SqlConnection con = Connections.HotelConnection)
            {
                SqlCommand cmd = new SqlCommand("AddRoomFeature", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter roomId = new SqlParameter("@roomId", roomFeature.RoomId);
                SqlParameter featureId = new SqlParameter("@featureId", roomFeature.FeatureId);
                SqlParameter deleted = new SqlParameter("@deleted", roomFeature.Deleted);

                cmd.Parameters.Add(roomId);
                cmd.Parameters.Add(featureId);
                cmd.Parameters.Add(deleted);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void RemoveRoomFeature(RoomFeature roomFeature)
        {
            using (SqlConnection con = Connections.HotelConnection)
            {
                SqlCommand cmd = new SqlCommand("RemoveRoomFeature", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter roomId = new SqlParameter("@roomId", roomFeature.RoomId);
                SqlParameter featureId = new SqlParameter("@featureId", roomFeature.FeatureId);
                SqlParameter deleted = new SqlParameter("@deleted", roomFeature.Deleted);

                cmd.Parameters.Add(roomId);
                cmd.Parameters.Add(featureId);
                cmd.Parameters.Add(deleted);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateRoomFeature(RoomFeature roomFeature)
        {
            using (SqlConnection con = Connections.HotelConnection)
            {
             
                SqlCommand cmd = new SqlCommand("UpdateRoomFeature", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter roomFeatureId = new SqlParameter("@roomFeatureId", roomFeature.Id);
                SqlParameter roomId = new SqlParameter("@roomId", roomFeature.RoomId);
                SqlParameter featureId = new SqlParameter("@featureId", roomFeature.FeatureId);
                SqlParameter deleted = new SqlParameter("@deleted", roomFeature.Deleted);

                cmd.Parameters.Add(roomFeatureId);
                cmd.Parameters.Add(roomId);
                cmd.Parameters.Add(featureId);
                cmd.Parameters.Add(deleted);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Feature> GetAllFeaturesForRoom(int id)
        {
            using (SqlConnection con = Connections.HotelConnection)
            {

                SqlCommand cmd = new SqlCommand("GetAllFeaturesForRoom", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter roomId = new SqlParameter("@roomId", id);

                cmd.Parameters.Add(roomId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                List<Feature> features = new List<Feature>();

                while (reader.Read())
                {
                    Feature feature = new Feature();
                    feature.Id = reader.GetInt32(0);
                    feature.Name = reader.GetString(1);
                    feature.Price = reader.GetDecimal(2);
                    feature.Deleted = reader.GetBoolean(3);
                    features.Add(feature);
                }
                return features;

            }
        }
        public IEnumerable<RoomFeature> GetAllRoomFeaturesForRoom(int id)
        {
            using (SqlConnection con = Connections.HotelConnection)
            {

                SqlCommand cmd = new SqlCommand("GetAllRoomFeaturesForRoom", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter roomId = new SqlParameter("@roomId", id);

                cmd.Parameters.Add(roomId);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                List<RoomFeature> roomFeatures = new List<RoomFeature>();

                while (reader.Read())
                {
                    RoomFeature roomFeature = new RoomFeature();
                    roomFeature.Id = reader.GetInt32(0);
                    roomFeature.RoomId = reader.GetInt32(1);
                    roomFeature.FeatureId = reader.GetInt32(2);

                    roomFeatures.Add(roomFeature);
                }
                using (var unitOfWork = new UnitOfWork(new HotelContext()))
                {
                    var result = unitOfWork.RoomFeatures.GetRoomFeatures(roomId: id);
                    unitOfWork.Complete();
                    return result;
                }


            }
        }
        #endregion
    }
}
