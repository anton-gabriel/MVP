using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Utils;

namespace Hotel.ViewModels
{
    internal class RegisterViewModel : NotifyPropertyChanged
    {

        #region Properties
        public User User { get; set; } = new User();
        #endregion

        #region Commands
        private RelayCommand registerCommand;
        public RelayCommand RegisterCommand
        {
            get
            {
                if (this.registerCommand == null)
                {
                    this.registerCommand = new RelayCommand(param => CanRegister(), param => Register());
                }
                return this.registerCommand;
            }
        }
        #endregion

        #region Private methods
        private bool CanRegister()
        {
            return User.HasDataForRegister();
        }
        private void Register()
        {
            if (Validators.ValidateEmail(User.Email) && Validators.ValidatePassword(User.Password))
            {
                UserDAL userDAL = new UserDAL();
                User registeredUser = userDAL.Register(User);
                if (registeredUser != null)
                {
                    //open new window in function of user type, and give the user forward
                }
                else
                {
                    UserDialog.MessageDialog(message: "Register failed!", type: DialogType.Alert);
                }
            }
        }
        #endregion
    }
}
