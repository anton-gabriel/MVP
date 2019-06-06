using Hotel.Models.Entity;

namespace Hotel.Models.Extended
{
    internal class OfferData
    {
        #region Properties
        public RoomData RoomData { get; set; }
        public Offer Offer { get; set; }
        public decimal Price => RoomData.Price * NumberOfDays;
        public int NumberOfDays => (Offer.EndPeriod - Offer.StartPeriod).Days;
        #endregion
    }
}
