using Hotel.Utils;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Entity
{
    internal class Offer : NotifyPropertyChanged
    {
        #region Private fields
        private bool deleted;
        private string name;
        private int roomId;
        private DateTime startPeriod;
        private DateTime endPeriod;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
                OnPropertyChanged(propertyName: nameof(Name));
            }
        }
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
