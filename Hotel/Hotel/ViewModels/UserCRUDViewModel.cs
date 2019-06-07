using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    internal class UserCRUDViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public UserCRUDViewModel()
        {
            User = new User();
        }
        #endregion

        #region Private fields
        private int id;
        private User user;
        #endregion

        #region Properties
        public User User
        {
            get => user;
            set
            {
                this.user = value;
                OnPropertyChanged(propertyName: nameof(User));
            }
        }
        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged(propertyName: nameof(Id));
            }
        }
        #endregion

        #region Commands
        private RelayCommand createCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                if (this.createCommand == null)
                {
                    this.createCommand = new RelayCommand(param => CanCreate(), param => Create());
                }
                return this.createCommand;
            }
        }
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                if (this.updateCommand == null)
                {
                    this.updateCommand = new RelayCommand(param => CanUpdate(), param => Update());
                }
                return this.updateCommand;
            }
        }
        private RelayCommand getCommand;
        public RelayCommand GetCommand
        {
            get
            {
                if (this.getCommand == null)
                {
                    this.getCommand = new RelayCommand(param => Get());
                }
                return this.getCommand;
            }
        }
        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get
            {
                if (this.deleteCommand == null)
                {
                    this.deleteCommand = new RelayCommand(param => CanDelete(), param => Delete());
                }
                return this.deleteCommand;
            }
        }
        #endregion

        #region Private fields
        private bool CanCreate()
        {
            return User != null;
        }
        private bool CanUpdate()
        {
            return User != null;
        }
        private bool CanDelete()
        {
            return User != null;
        }
        private void Create()
        {
            UserDAL userDAL = new UserDAL();
            userDAL.AddUser(User);
        }
        private void Update()
        {
            UserDAL userDAL = new UserDAL();
            userDAL.UpdateUser(User);
        }
        private void Get()
        {
            UserDAL userDAL = new UserDAL();
            User = userDAL.GetUser(Id);
        }
        private void Delete()
        {
            UserDAL userDAL = new UserDAL();
            userDAL.RemoveUser(User);
        }
        #endregion
    }
}
