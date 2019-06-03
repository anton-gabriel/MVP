using Hotel.Models.Entity;
using System.Data.Entity;

namespace Hotel.Services
{
    internal class HotelContext : DbContext
    {
        #region Properties
        public DbSet<User> Users { get; set; }
        #endregion
    }
}
