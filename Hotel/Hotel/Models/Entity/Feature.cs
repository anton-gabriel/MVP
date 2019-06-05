using Hotel.Utils;

namespace Hotel.Models.Entity
{
    internal class Feature : NotifyPropertyChanged
    {
        private string name;
        private decimal price;
        private bool deleted;
        #region Private fields

        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(propertyName: nameof(Name));
            }
        }
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(propertyName: nameof(Price));
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
