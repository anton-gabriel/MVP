using Hotel.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Entity
{
    internal class BookingRoomService : NotifyPropertyChanged
    {
        #region Private fields

        private bool deleted;
        private int bookingRoomId;
        private int serviceId;
        #endregion

        #region Properties
        public int Id { get; set; }
        public int BookingRoomId
        {
            get => this.bookingRoomId;
            set
            {
                this.bookingRoomId = value;
                OnPropertyChanged(propertyName: nameof(BookingRoomId));
            }
        }
        [ForeignKey(nameof(BookingRoomId))]
        public BookingRoom BookingRoom { get; set; }

        public int ServiceId
        {
            get => this.serviceId;
            set
            {
                this.serviceId = value;
                OnPropertyChanged(propertyName: nameof(ServiceId));
            }
        }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }

        public bool Deleted
        {
            get => this.deleted;
            set
            {
                this.deleted = value;
                OnPropertyChanged(propertyName: nameof(Deleted));
            }
        }
        #endregion
    }
}
