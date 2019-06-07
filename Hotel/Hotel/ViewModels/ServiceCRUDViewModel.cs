using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Utils;

namespace Hotel.ViewModels
{
    internal class ServiceCRUDViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public ServiceCRUDViewModel()
        {
            Service = new Service();
        }
        #endregion

        #region Private fields
        private int id;
        private Service service;
        #endregion

        #region Properties
        public Service Service
        {
            get => this.service;
            set
            {
                this.service = value;
                OnPropertyChanged(propertyName: nameof(Service));
            }
        }
        public int Id
        {
            get => this.id;
            set
            {
                this.id = value;
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
            return Service != null;
        }
        private bool CanUpdate()
        {
            return Service != null;
        }
        private bool CanDelete()
        {
            return Service != null;
        }
        private void Create()
        {
            ServiceDAL serviceDAL = new ServiceDAL();
            serviceDAL.AddService(Service);
        }
        private void Update()
        {
            ServiceDAL serviceDAL = new ServiceDAL();
            serviceDAL.UpdateService(Service);
        }
        private void Get()
        {
            ServiceDAL serviceDAL = new ServiceDAL();
            Service = serviceDAL.GetService(Id);
        }
        private void Delete()
        {
            ServiceDAL serviceDAL = new ServiceDAL();
            serviceDAL.RemoveService(Service);
        }
        #endregion
    }
}
