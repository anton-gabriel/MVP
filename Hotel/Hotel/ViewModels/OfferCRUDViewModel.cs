using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Utils;

namespace Hotel.ViewModels
{
    internal class OfferCRUDViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public OfferCRUDViewModel()
        {
            Offer = new Offer();
        }
        #endregion

        #region Private fields
        private int id;
        private Offer offer;
        #endregion

        #region Properties
        public Offer Offer
        {
            get => this.offer;
            set
            {
                this.offer = value;
                OnPropertyChanged(propertyName: nameof(Offer));
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
            return Offer != null;
        }
        private bool CanUpdate()
        {
            return Offer != null;
        }
        private bool CanDelete()
        {
            return Offer != null;
        }
        private void Create()
        {
            OfferDAL offerDAL = new OfferDAL();
            offerDAL.AddOffer(Offer);
        }
        private void Update()
        {
            OfferDAL offerDAL = new OfferDAL();
            offerDAL.UpdateOffer(Offer);
        }
        private void Get()
        {
            OfferDAL offerDAL = new OfferDAL();
            Offer = offerDAL.GetOffer(Id);
        }
        private void Delete()
        {
            OfferDAL offerDAL = new OfferDAL();
            offerDAL.RemoveOffer(Offer);
        }
        #endregion
    }
}
