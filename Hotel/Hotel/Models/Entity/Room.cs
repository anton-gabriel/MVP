using Hotel.Utils;

namespace Hotel.Models.Entity
{
    internal enum RoomType : byte
    {
        Invalid = 0,
        Single,
        Double,
        Triple,
        Quad,
        Queen,
        King,
        Twin,
        Studio,
        Cabana,
        Villa
    }
    internal class Room : NotifyPropertyChanged
    {
        #region Private fields
        private RoomType roomType;
        private decimal price;
        private bool deleted;
        #endregion

        #region Properties
        public int Id { get; set; }
        public RoomType RoomType
        {
            get => this.roomType;
            set
            {
                this.roomType = value;
                OnPropertyChanged(propertyName: nameof(RoomType));
            }
        }
        public decimal Price
        {
            get => this.price;
            set
            {
                this.price = value;
                OnPropertyChanged(propertyName: nameof(Price));
            }
        }
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
