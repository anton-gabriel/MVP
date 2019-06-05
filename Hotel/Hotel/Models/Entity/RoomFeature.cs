using Hotel.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models.Entity
{
    internal class RoomFeature : NotifyPropertyChanged
    {
        #region Private fields
        private bool deleted;
        private int roomId;
        private int featureId;
        #endregion

        #region Properties
        public int Id { get; set; }
        public int RoomId
        {
            get => this.roomId;
            set
            {
                this.roomId = value;
                OnPropertyChanged(propertyName: nameof(RoomId));
            }
        }
        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; }

        public int FeatureId
        {
            get => this.featureId;
            set
            {
                this.featureId = value;
                OnPropertyChanged(propertyName: nameof(FeatureId));
            }

        }
        [ForeignKey(nameof(FeatureId))]
        public Feature Feature { get; set; }

        public bool Deleted
        {
            get => this.deleted;
            set
            {
                this.deleted = value;
                OnPropertyChanged(propertyName: nameof(Deleted));
            }
        }
        #endregion
    }
}
