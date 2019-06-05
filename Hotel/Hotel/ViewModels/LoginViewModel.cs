using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Utils;

namespace Hotel.ViewModels
{
    internal class LoginViewModel : NotifyPropertyChanged
    {
        #region Properties
        public User User { get; set; } = new User();
        #endregion

        #region Commands
        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                if (this.loginCommand == null)
                {
                    this.loginCommand = new RelayCommand(param => CanLogin(), param => Login());
                }
                return this.loginCommand;
            }
        }
        #endregion

        #region Private methods
        private bool CanLogin()
        {
            return User.HasDataForLogin();
        }
        private void Login()
        {
            if (Validators.ValidateEmail(User.Email) && Validators.ValidatePassword(User.Password))
            {
                UserDAL userDAL = new UserDAL();
                User loggedUser = userDAL.Login(User);
                if (loggedUser != null)
                {
                    //open new window in function of user type, and give the user forward
                }
                else
                {
                    UserDialog.MessageDialog(message: "Login failed!", type: DialogType.Alert);
                }
            }
        }
        #endregion
    }
}
