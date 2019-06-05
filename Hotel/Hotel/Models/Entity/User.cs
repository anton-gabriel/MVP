using Hotel.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Entity
{
    internal enum UserType : byte
    {
        Invalid = 0,
        Client,
        Employee,
        Admin
    }
    internal class User : NotifyPropertyChanged
    {
        #region Private Fields
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private UserType userType;
        #endregion

        #region Properties
        public int Id { get; set; }
        public UserType UserType
        {
            get => this.userType;
            set
            {
                this.userType = value;
                OnPropertyChanged(propertyName: nameof(UserType));
            }
        }
        public string FirstName
        {
            get => this.firstName;
            set
            {
                this.firstName = value;
                OnPropertyChanged(propertyName: nameof(FirstName));
                OnPropertyChanged(propertyName: nameof(FullName));
            }
        }
        public string LastName
        {
            get => this.lastName;
            set
            {
                this.lastName = value;
                OnPropertyChanged(propertyName: nameof(LastName));
                OnPropertyChanged(propertyName: nameof(FullName));
            }
        }

        [Index(IsUnique = true)]
        [Required]
        [StringLength(200)]
        public string Email
        {
            get => this.email;
            set
            {
                this.email = value;
                OnPropertyChanged(propertyName: nameof(Email));
            }
        }

        [Required]
        [StringLength(200)]
        public string Password
        {
            get => this.password;
            set
            {
                this.password = value;
                OnPropertyChanged(propertyName: nameof(Password));
            }
        }

        [NotMapped]
        public string FullName => FirstName + LastName;
        #endregion
    }
}
