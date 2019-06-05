using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Models.Extended;
using Hotel.Utils;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Hotel.ViewModels
{
    internal class UserViewModel : NotifyPropertyChanged
    {
        #region Private fields
        private DateTime startPeriod;
        private DateTime endPeriod;
        #endregion

        #region Properties
        public User User { get; private set; }
        public ObservableCollection<RoomData> Rooms { get; set; } =
            new ObservableCollection<RoomData>(new RoomDAL().GetAvailableRoomsData(DateTime.Today, DateTime.Today.AddDays(1)));
        public DateTime StartPeriod
        {
            get => startPeriod;
            set
            {
                startPeriod = value;
                OnPropertyChanged(propertyName: nameof(StartPeriod));
            }
        }
        public DateTime EndPeriod
        {
            get => endPeriod;
            set
            {
                this.endPeriod = value;
                OnPropertyChanged(propertyName: nameof(EndPeriod));
            }
        }
        #endregion

        #region Commands
        private RelayCommand<object> viewRoomCommand;
        public RelayCommand<object> ViewRoomCommand
        {
            get
            {
                if (this.viewRoomCommand == null)
                {
                    this.viewRoomCommand = new RelayCommand<object>(OpenRoomView);
                }
                return this.viewRoomCommand;
            }
        }
        #endregion


        #region Private fields
        private void OpenRoomView(object room)
        {
            var result = room as RoomData;
            MessageBox.Show($"Result {result.Room.RoomType}");
        }
        #endregion
    }
}
