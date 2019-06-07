using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Models.Extended;
using Hotel.Utils;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hotel.ViewModels
{
    internal class CheckoutViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public CheckoutViewModel()
        {
            Services = new ObservableCollection<Service>(new ServiceDAL().GetAllServices());
        }
        #endregion

        #region Private fields
        private ObservableCollection<RoomData> rooms;
        private ObservableCollection<OfferData> offers;
        private ObservableCollection<Service> services;
        #endregion

        #region Properties
        public User User { get; set; }
        public ObservableCollection<RoomData> Rooms
        {
            get => this.rooms;
            set
            {
                this.rooms = value;
                OnPropertyChanged(propertyName: nameof(Rooms));
                OnPropertyChanged(propertyName: nameof(TotalPrice));
            }
        }
        public ObservableCollection<OfferData> Offers
        {
            get => this.offers;
            set
            {
                this.offers = value;
                OnPropertyChanged(propertyName: nameof(Offers));
                OnPropertyChanged(propertyName: nameof(TotalPrice));
            }
        }
        public ObservableCollection<Service> Services
        {
            get => this.services;
            set
            {
                this.services = value;
                OnPropertyChanged(propertyName: nameof(Services));
                OnPropertyChanged(propertyName: nameof(TotalPrice));
            }
        }
        public DateTime StartPeriod { get; set; }
        public DateTime EndPeriod { get; set; }
        public decimal TotalPrice => Offers.ToList().Sum(value => value.Price) + Rooms.ToList().Sum(value => value.Price) + Services.ToList().Sum(value => value.Price);
        #endregion

        #region Commands
        private RelayCommand payCommand;
        public RelayCommand PayCommand
        {
            get
            {
                if (this.payCommand == null)
                {
                    this.payCommand = new RelayCommand(param => Pay());
                }
                return this.payCommand;
            }
        }
        private RelayCommand<Service> addServiceCommand;
        public RelayCommand<Service> AddServiceCommand
        {
            get
            {
                if (this.addServiceCommand == null)
                {
                    this.addServiceCommand = new RelayCommand<Service>(AddService);
                }
                return this.addServiceCommand;
            }
        }

        #endregion

        #region Private methods
        private void Pay()
        {
            BookingRoomDAL bookingRoomDAL = new BookingRoomDAL();
            BookingOfferDAL bookingOfferDAL = new BookingOfferDAL();
            BookingRoomServiceDAL bookingRoomServiceDAL = new BookingRoomServiceDAL();
            Rooms.ToList().ForEach(value =>
            bookingRoomDAL.AddBookingRoom(new BookingRoom
            {
                Status = Status.Active,
                UserId = User.Id,
                RoomId = value.Room.Id,
                NumberOfRooms = 1,
                StartPeriod = StartPeriod,
                EndPeriod = EndPeriod,
                Deleted = false
            }));
            Services.ToList().ForEach(value =>
            bookingRoomServiceDAL.AddBookingRoomService(new BookingRoomService
            {

            }));
            Offers.ToList().ForEach(value =>
            bookingOfferDAL.AddBookingOffer(new BookingOffer
            {
                Status = Status.Active,
                UserId = User.Id,
                OfferId = value.Offer.Id,
                Deleted = false
            }));

        }
        private void AddService(Service service)
        {
            if (!Services.Contains(service))
            {
                Services.Add(service);
                OnPropertyChanged(propertyName: nameof(TotalPrice));
            }
        }
        #endregion
    }
}
