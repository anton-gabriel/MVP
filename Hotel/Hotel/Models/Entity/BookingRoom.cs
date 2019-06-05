using Hotel.Utils;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Entity
{
    internal enum Status
    {
        Invalid = 0,
        Active,
        Canceled,
        Paid
    }
    internal class BookingRoom : NotifyPropertyChanged
    {
        #region Private fields
        private bool deleted;
        private int roomId;
        private int userId;
        private uint numberOfRooms;
        private uint numberOfPersons;
        private Status status;
        private DateTime startPeriod;
        private DateTime endPeriod;
        #endregion

        #region Properties
        public int Id { get; set; }
        public int UserId
        {
            get => this.userId;
            set
            {
                this.userId = value;
                OnPropertyChanged(propertyName: nameof(UserId));
            }
        }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        public int RoomId
        {
            get => this.roomId;
            set
            {
                this.roomId = value;
                OnPropertyChanged(propertyName: nameof(RoomId));
            }
        }
        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }

        public uint NumberOfRooms
        {
            get => this.numberOfRooms;
            set
            {
                this.numberOfRooms = value;
                OnPropertyChanged(propertyName: nameof(NumberOfRooms));
            }
        }
        public uint NumberOfPersons
        {
            get => this.numberOfPersons;
            set
            {
                this.numberOfPersons = value;
                OnPropertyChanged(propertyName: nameof(NumberOfPersons));
            }
        }
        public Status Status
        {
            get
            {
                if (StartPeriod >= DateTime.Today)
                {
                    this.status = Status.Canceled;
                }
                return this.status;
            }
            set
            {
                this.status = value;
                OnPropertyChanged(propertyName: nameof(Status));
            }
        }
        public DateTime StartPeriod
        {
            get => this.startPeriod;
            set
            {
                this.startPeriod = value;
                OnPropertyChanged(propertyName: nameof(StartPeriod));
            }
        }
        public DateTime EndPeriod
        {
            get => this.endPeriod;
            set
            {
                this.endPeriod = value;
                OnPropertyChanged(propertyName: nameof(EndPeriod));
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
