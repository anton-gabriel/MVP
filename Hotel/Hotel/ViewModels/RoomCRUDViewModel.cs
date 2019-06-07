using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModels
{
    internal class RoomCRUDViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public RoomCRUDViewModel()
        {
            Room = new Room();
        }
        #endregion

        #region Private fields
        private int id;
        private Room room;
        private ObservableCollection<RoomFeature> roomFeatures;
        #endregion

        #region Properties
        public Room Room
        {
            get => this.room;
            set
            {
                this.room = value;
                OnPropertyChanged(propertyName: nameof(Room));
            }
        }
        public ObservableCollection<RoomFeature> RoomFeatures
        {
            get => roomFeatures;
            set
            {
                this.roomFeatures = value;
                OnPropertyChanged(propertyName: nameof(RoomFeatures));
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
            return Room != null;
        }
        private bool CanUpdate()
        {
            return Room != null;
        }
        private bool CanDelete()
        {
            return Room != null;
        }
        private bool CanAddFeature()
        {
            return Room != null;
        }
        private void Create()
        {
            RoomDAL roomDAL = new RoomDAL();
            roomDAL.AddRoom(Room);
        }
        private void Update()
        {
            RoomDAL roomDAL = new RoomDAL();
            roomDAL.UpdateRoom(Room);
        }
        private void Get()
        {
            RoomDAL roomDAL = new RoomDAL();
            Room = roomDAL.GetRoom(Id);
        }
        private void Delete()
        {
            RoomDAL roomDAL = new RoomDAL();
            roomDAL.RemoveRoom(Room);
        }
        private void AddFeature()
        {
           
        }
        #endregion
    }
}
