using System.Configuration;
using System.Data.SqlClient;

namespace Hotel.Utils
{
    internal static class Connections
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["HotelContext"].ConnectionString;

        internal static SqlConnection HotelConnection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
