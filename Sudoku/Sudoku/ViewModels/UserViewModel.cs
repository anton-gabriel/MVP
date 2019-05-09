using Sudoku.Commands;
using Sudoku.Models.User;
using Sudoku.Services;
using Sudoku.Services.SerializationServices;
using Sudoku.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Sudoku.ViewModels
{
    internal class UserViewModel : Models.Utils.NotifyPropertyChanged
    {
        #region Constructors
        public UserViewModel()
        {
            LoadUsers();
        }
        #endregion
        #region Private fields
        private UserList userList;
        private User selectedUser;
        #endregion

        #region Properties
        public ObservableCollection<User> Users
        {
            get => this.userList?.Users;
            set
            {
                this.userList.Users = value;
                OnPropertyChanged(propertyName: nameof(Users));
            }
        }


        public User SelectedUser
        {
            get => this.selectedUser;
            set
            {
                this.selectedUser = value;
                OnPropertyChanged(propertyName: nameof(SelectedUser));
            }
        }

        public bool CanDeleteUser => SelectedUser != null;
        public bool CanPlay => SelectedUser != null;
        #endregion

        #region Commands
        private ICommand createUserCommand;
        public ICommand CreateUserCommand
        {
            get
            {
                if (this.createUserCommand == null)
                {
                    this.createUserCommand = new RelayCommand(param => AddUser());
                }
                return this.createUserCommand;
            }
        }
        private ICommand deleteUserCommand;
        public ICommand DeleteUserCommand
        {
            get
            {
                if (this.deleteUserCommand == null)
                {
                    this.deleteUserCommand = new RelayCommand(param => CanDeleteUser, param => DeleteUser());
                }
                return this.deleteUserCommand;
            }
        }
        private ICommand playCommand;
        public ICommand PlayCommand
        {
            get
            {
                if (this.playCommand == null)
                {
                    this.playCommand = new RelayCommand(param => CanPlay, param => Play());
                }
                return this.playCommand;
            }
        }
        private ICommand exitCommand;
        public ICommand ExitCommand
        {
            get
            {
                if (this.exitCommand == null)
                {
                    this.exitCommand = new RelayCommand<Window>(CloseWindow);
                }
                return this.exitCommand;
            }
        }
        #endregion

        #region Private methods
        private void LoadUsers()
        {
            try
            {
                this.userList = Serializer.DeserializeJsonObject<UserList>(Paths.Users);
            }
            catch (System.Exception)
            {
                this.userList = new UserList();
            }
        }

        private void AddUser()
        {
            CreateUserView createUserView = new CreateUserView();
            (createUserView.DataContext as CreateUserViewModel).UserList = this.userList;
            createUserView.Show();
        }
        private void DeleteUser()
        {
            Users.Remove(SelectedUser);
            Serializer.SerializeJsonObject(fileName: Paths.Users, objectToSerialize: this.userList);
        }
        private void Play()
        {
            GameView gameView = new GameView();
            (gameView.DataContext as GameViewModel).User = SelectedUser;
            gameView.Show();
        }
        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        #endregion
    }
}
