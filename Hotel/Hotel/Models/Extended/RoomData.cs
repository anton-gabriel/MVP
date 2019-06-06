using Hotel.Models.Entity;
using Hotel.Utils;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hotel.Models.Extended
{
    internal class RoomData
    {
        #region Properties
        public Room Room { get; set; }
        public ObservableCollection<Feature> Features { get; set; }
        public ObservableCollection<RoomImage> Images { get; set; }
        public decimal Price => Room.Price + Features.Select(value => value.Price).Sum();
        #endregion
    }
}
