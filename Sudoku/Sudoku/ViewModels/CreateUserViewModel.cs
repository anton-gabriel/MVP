using Sudoku.Commands;
using Sudoku.Models.User;
using Sudoku.Models.Utils;
using Sudoku.Services;
using Sudoku.Services.ReaderServices;
using Sudoku.Services.SerializationServices;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Sudoku.ViewModels
{
    internal class CreateUserViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public CreateUserViewModel()
        {
            LoadImages();
        }
        #endregion

        #region Private fields
        #endregion

        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserList UserList { get; set; }
        public List<Image> Images { get; private set; }
        public Image CurrentImage
        {
            get => this.currentImage;
            private set
            {
                this.currentImage = value;
                OnPropertyChanged(propertyName: nameof(CurrentImage));
            }
        }

        private bool CanAddUser => FirstName?.Length != 0 && LastName?.Length != 0;
        #endregion

        #region Commands
        private ICommand addUserCommand;
        public ICommand AddUserCommand
        {
            get
            {
                if (this.addUserCommand == null)
                {
                    this.addUserCommand = new RelayCommand(param => CanAddUser, param => AddUser());
                }
                return this.addUserCommand;
            }
        }
        private ICommand moveToLeftCommand;
        public ICommand MoveToLeftCommand
        {
            get
            {
                if (this.moveToLeftCommand == null)
                {
                    this.moveToLeftCommand = new RelayCommand(param => MoveImageToLeft());
                }
                return this.moveToLeftCommand;
            }
        }
        private ICommand moveToRightCommand;
        private Image currentImage;

        public ICommand MoveToRightCommand
        {
            get
            {
                if (this.moveToRightCommand == null)
                {
                    this.moveToRightCommand = new RelayCommand(param => MoveImageToRight());
                }
                return this.moveToRightCommand;
            }
        }
        #endregion

        #region Private methods
        private void LoadImages()
        {
            Images = ImagesReader.Read(path: Paths.Images);
            CurrentImage = Images.First();
        }


        private void AddUser()
        {
            UserList.Users.Add(new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Image = CurrentImage
            });
            Serializer.SerializeJsonObject(fileName: Paths.Users, objectToSerialize: UserList);
        }
        private void MoveImageToLeft()
        {
            int currentIndex = Images.IndexOf(CurrentImage);
            if (currentIndex - 1 >= 0)
            {
                CurrentImage = Images.ElementAtOrDefault(Images.IndexOf(CurrentImage) - 1);
            }
        }
        private void MoveImageToRight()
        {
            int currentIndex = Images.IndexOf(CurrentImage);
            if (currentIndex + 1 < Images.Count)
            {
                CurrentImage = Images.ElementAtOrDefault(Images.IndexOf(CurrentImage) + 1);
            }
        }
        #endregion
    }
}
