using Hotel.Utils;

namespace Hotel.Models.Entity
{
    internal enum ServiceType : byte
    {
        Invalid = 0,
        TableService,
        EnglishService,
        FrenchService,
        SilverService,
        AmericanService,
        SnakBarService,
        BuffetService,
        RoomService
    }

    internal class Service : NotifyPropertyChanged
    {
        #region Private fields

        private bool deleted;
        private ServiceType serviceType;
        private decimal price;
        #endregion

        #region Properties
        public int Id { get; set; }
        public ServiceType ServiceType
        {
            get => this.serviceType;
            set
            {
                this.serviceType = value;
                OnPropertyChanged(propertyName: nameof(ServiceType));
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
