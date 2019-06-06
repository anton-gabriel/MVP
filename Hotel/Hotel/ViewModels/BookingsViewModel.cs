using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Models.Extended;
using Hotel.Utils;
using Hotel.Views;
using System.Collections.ObjectModel;

namespace Hotel.ViewModels
{
    internal class BookingsViewModel : NotifyPropertyChanged
    {
        #region Private fields
        private ObservableCollection<BookingRoom> bookingRooms;
        private ObservableCollection<BookingOffer> bookingOffers;
        #endregion

        #region Properties
        public ObservableCollection<BookingRoom> BookingRooms
        {
            get => this.bookingRooms;
            set
            {
                this.bookingRooms = value;
                OnPropertyChanged(propertyName: nameof(BookingRooms));
            }
        }
        public ObservableCollection<BookingOffer> BookingOffers
        {
            get => this.bookingOffers;
            set
            {
                this.bookingOffers = value;
                OnPropertyChanged(propertyName: nameof(BookingOffers));
            }
        }
        #endregion


        #region Commands
        private RelayCommand<Room> viewRoomCommand;
        public RelayCommand<Room> ViewRoomCommand
        {
            get
            {
                if (this.viewRoomCommand == null)
                {
                    this.viewRoomCommand = new RelayCommand<Room>(OpenRoomView);
                }
                return this.viewRoomCommand;
            }
        }

        private RelayCommand<Offer> viewOfferCommand;
        public RelayCommand<Offer> ViewOfferCommand
        {
            get
            {
                if (this.viewOfferCommand == null)
                {
                    this.viewOfferCommand = new RelayCommand<Offer>(OpenOfferView);
                }
                return this.viewOfferCommand;
            }
        }
        #endregion

        #region Private fields
        private void OpenRoomView(Room room)
        {
            RoomData roomData = new RoomDAL().GetRoomData(room.Id);

            RoomView roomView = new RoomView();
            (roomView.DataContext as RoomViewModel).RoomData = roomData;
            roomView.Show();
        }
        private void OpenOfferView(Offer offer)
        {
            OfferData offerData = new OfferDAL().GetOfferData(offer.Id);

            OfferView offerView = new OfferView();
            (offerView.DataContext as OfferViewModel).OfferData = offerData;
            offerView.Show();
        }
        #endregion
    }
}
