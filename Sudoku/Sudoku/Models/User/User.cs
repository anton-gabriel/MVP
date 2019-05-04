namespace Sudoku.Models.User
{
    internal class User : Utils.NotifyPropertyChanged
    {
        #region Private fields
        private string firstName;
        private string lastName;
        #endregion

        #region Properties
        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
                OnPropertyChanged(propertyName: nameof(FirstName));
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                this.lastName = value;
                OnPropertyChanged(propertyName: nameof(LastName));
            }
        }
        public Statistics Stats { get; set; }
        #endregion
    }
}
