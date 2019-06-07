using Hotel.Commands;
using Hotel.Models.DataAccess;
using Hotel.Models.Entity;
using Hotel.Utils;

namespace Hotel.ViewModels
{
    internal class FeatureCRUDViewModel : NotifyPropertyChanged
    {
        #region Constructors
        public FeatureCRUDViewModel()
        {
            Feature = new Feature();
        }
        #endregion

        #region Private fields
        private int id;
        private Feature feature;
        #endregion

        #region Properties
        public Feature Feature
        {
            get => this.feature;
            set
            {
                this.feature = value;
                OnPropertyChanged(propertyName: nameof(Feature));
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
            return Feature != null;
        }
        private bool CanUpdate()
        {
            return Feature != null;
        }
        private bool CanDelete()
        {
            return Feature != null;
        }
        private void Create()
        {
            FeatureDAL featureDAL = new FeatureDAL();
            featureDAL.AddFeature(Feature);
        }
        private void Update()
        {
            FeatureDAL featureDAL = new FeatureDAL();
            featureDAL.UpdateFeature(Feature);
        }
        private void Get()
        {
            FeatureDAL featureDAL = new FeatureDAL();
            Feature = featureDAL.GetFeature(Id);
        }
        private void Delete()
        {
            FeatureDAL featureDAL = new FeatureDAL();
            featureDAL.RemoveFeature(Feature);
        }
        #endregion
    }
}
