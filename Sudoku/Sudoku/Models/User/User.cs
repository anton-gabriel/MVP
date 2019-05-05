using System;
using System.Runtime.Serialization;

namespace Sudoku.Models.User
{
    [Serializable]
    internal class User : Utils.NotifyPropertyChanged, ISerializable
    {
        #region Constructors
        public User() { }
        public User(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            FirstName = (string)info.GetValue(name: nameof(FirstName), type: typeof(string));
            LastName = (string)info.GetValue(name: nameof(LastName), type: typeof(string));
            Stats = (Statistics)info.GetValue(name: nameof(Stats), type: typeof(Statistics));
            Image = (Image)info.GetValue(name: nameof(Image), type: typeof(Image));
        }
        #endregion

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
        public Image Image { get; set; }
        public Statistics Stats { get; set; }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(name: nameof(FirstName), value: FirstName);
            info.AddValue(name: nameof(LastName), value: LastName);
            info.AddValue(name: nameof(Stats), value: Stats);
            info.AddValue(name: nameof(Image), value: Image);
        }
        #endregion
    }
}
