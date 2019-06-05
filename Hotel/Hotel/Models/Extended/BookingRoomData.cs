using Hotel.Models.Entity;
using System.Collections.ObjectModel;

namespace Hotel.Models.Extended
{
    internal class BookingRoomData
    {
        #region Properties
        public BookingRoom BookingRoom { get; set; }
        public ObservableCollection<Service> Services { get; set; }
        #endregion
    }
}