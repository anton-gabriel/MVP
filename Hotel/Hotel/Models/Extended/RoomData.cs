using Hotel.Models.Entity;
using Hotel.Utils;
using System.Collections.ObjectModel;

namespace Hotel.Models.Extended
{
    internal class RoomData
    {
        #region Properties
        public Room Room { get; set; }
        public ObservableCollection<Feature> Features { get; set; }
        public ObservableCollection<RoomImage> Images { get; set; }
        #endregion
    }
}
