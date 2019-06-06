
using Hotel.Models.Extended;
using Hotel.Utils;

namespace Hotel.ViewModels
{
    internal class RoomViewModel : NotifyPropertyChanged
    {
        private RoomData roomData;
        #region Properties
        public RoomData RoomData
        {
            get => this.roomData;
            set
            {
                this.roomData = value;
                OnPropertyChanged(propertyName: nameof(RoomData));
            }
        }
        #endregion
    }
}
