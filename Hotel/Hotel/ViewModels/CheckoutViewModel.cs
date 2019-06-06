using Hotel.Commands;
using Hotel.Models.Entity;
using Hotel.Models.Extended;
using Hotel.Utils;
using System.Linq;
using System.Collections.ObjectModel;

namespace Hotel.ViewModels
{
    internal class CheckoutViewModel: NotifyPropertyChanged
    {
        #region Private fields
        private ObservableCollection<RoomData> rooms;
        private ObservableCollection<OfferData> offers;
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

        public decimal TotalPrice => Offers.ToList().Sum(value => value.Price) + Rooms.ToList().Sum(value => value.Price);
        #endregion

        #region Private methods
        private void Pay()
        {

        }
        #endregion
    }
}
