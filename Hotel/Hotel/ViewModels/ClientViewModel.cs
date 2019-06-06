using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Models.Extended;
using Hotel.Utils;
using Hotel.Views;
using System;
using System.Collections.ObjectModel;


namespace Hotel.ViewModels
{
    internal class ClientViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public ClientViewModel()
        {
            EndPeriod = DateTime.Today.AddDays(1);
            StartPeriod = DateTime.Today;
        }
        #endregion

        #region Private fields
        private User user;
        private DateTime startPeriod;
        private DateTime endPeriod;
        private ObservableCollection<RoomData> rooms;
        private ObservableCollection<OfferData> offers;
        #endregion

        #region Properties
        public User User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged(propertyName: nameof(User));
            }
        }
        public ObservableCollection<RoomData> Rooms
        {
            get => this.rooms;
            set
            {
                this.rooms = value;
                OnPropertyChanged(propertyName: nameof(Rooms));
            }
        }
        public ObservableCollection<OfferData> Offers
        {
            get => this.offers;
            set
            {
                this.offers = value;
                OnPropertyChanged(propertyName: nameof(Offers));
            }
        }

        public DateTime StartPeriod
        {
            get => this.startPeriod;
            set
            {
                if ((value >= DateTime.Today) && (value < EndPeriod))
                {
                    this.startPeriod = value;
                    OnPropertyChanged(propertyName: nameof(StartPeriod));
                }
            }
        }
        public DateTime EndPeriod
        {
            get => this.endPeriod;
            set
            {
                if (value > StartPeriod)
                {
                    this.endPeriod = value;
                    OnPropertyChanged(propertyName: nameof(EndPeriod));
                }
            }
        }
        #endregion

        #region Commands
        private RelayCommand<RoomData> viewRoomCommand;
        public RelayCommand<RoomData> ViewRoomCommand
        {
            get
            {
                if (this.viewRoomCommand == null)
                {
                    this.viewRoomCommand = new RelayCommand<RoomData>(OpenRoomView);
                }
                return this.viewRoomCommand;
            }
        }

        private RelayCommand<OfferData> viewOfferCommand;
        public RelayCommand<OfferData> ViewOfferCommand
        {
            get
            {
                if (this.viewOfferCommand == null)
                {
                    this.viewOfferCommand = new RelayCommand<OfferData>(OpenOfferView);
                }
                return this.viewOfferCommand;
            }
        }

        private RelayCommand searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                if (this.searchCommand == null)
                {
                    this.searchCommand = new RelayCommand(param => Search());
                }
                return this.searchCommand;
            }
        }

        private RelayCommand viewBookingsCommand;
        public RelayCommand ViewBookingsCommand
        {
            get
            {
                if (this.viewBookingsCommand == null)
                {
                    this.viewBookingsCommand = new RelayCommand(param => OpenBookingsView());
                }
                return this.viewBookingsCommand;
            }
        }
        #endregion


        #region Private fields
        private void OpenRoomView(RoomData room)
        {
            RoomView roomView = new RoomView();
            (roomView.DataContext as RoomViewModel).RoomData = room;
            roomView.Show();
        }
        private void OpenOfferView(OfferData offer)
        {
            OfferView offerView = new OfferView();
            (offerView.DataContext as OfferViewModel).OfferData = offer;
            offerView.Show();
        }
        private void OpenBookingsView()
        {
            BookingsView bookingsView = new BookingsView();

            var bookingOffers = new BookingOfferDAL().GetAllBookingOffersForUser(User.Id);
            var bookingRooms = new BookingRoomDAL().GetAllBookingRoomsForUser(User.Id);
            if (bookingRooms != null)
            {
                (bookingsView.DataContext as BookingsViewModel).BookingRooms = new ObservableCollection<BookingRoom>(bookingRooms);
            }
            if (bookingOffers != null)
            {
                (bookingsView.DataContext as BookingsViewModel).BookingOffers = new ObservableCollection<BookingOffer>(bookingOffers);
            }
            bookingsView.Show();
        }

        private void Search()
        {
            var roomResults = new RoomDAL().GetAvailableRoomsData(StartPeriod, EndPeriod);
            var offersResult = new OfferDAL().GetAvailableOffersData(StartPeriod, EndPeriod);
            if (offersResult != null)
            {
                Offers = new ObservableCollection<OfferData>(offersResult);
            }
            if (roomResults != null)
            {
                Rooms = new ObservableCollection<RoomData>(roomResults);
            }
        }
        #endregion
    }
}
