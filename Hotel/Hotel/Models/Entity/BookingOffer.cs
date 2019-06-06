using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models.Entity
{
    internal class BookingOffer : NotifyPropertyChanged
    {
        #region Private fields
        private bool deleted;
        private int userId;
        private int offerId;
        private Status status;
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

        public int OfferId
        {
            get => offerId;
            set
            {
                this.offerId = value;
                OnPropertyChanged(propertyName: nameof(OfferId));
            }
        }
        [ForeignKey(nameof(OfferId))]
        public Offer Offer { get; set; }

        public Status Status
        {
            get
            {
                if (Offer.StartPeriod >= DateTime.Today)
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
        public bool Deleted
        {
            get => deleted;
            set
            {
                deleted = value;
                OnPropertyChanged(propertyName: nameof(Deleted));
            }
        }
        #endregion
    }
}
