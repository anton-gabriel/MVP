using Hotel.Models.Extended;
using Hotel.Utils;

namespace Hotel.ViewModels
{
    internal class OfferViewModel : NotifyPropertyChanged
    {
        #region Private fields
        private OfferData offerData;
        #endregion
        #region Properties
        public OfferData OfferData
        {
            get => this.offerData;
            set
            {
                this.offerData = value;
                OnPropertyChanged(propertyName: nameof(OfferData));
            }
        }
        #endregion
    }
}
