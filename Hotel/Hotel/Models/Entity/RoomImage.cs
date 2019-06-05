using Hotel.Utils;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Media.Imaging;

namespace Hotel.Models.Entity
{
    internal class RoomImage : NotifyPropertyChanged
    {
        #region Private fields
        private bool deleted;
        private int roomId;
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

        public byte[] Image { get; set; }
        public bool Deleted
        {
            get => this.deleted;
            set
            {
                this.deleted = value;
                OnPropertyChanged(propertyName: nameof(Deleted));
            }
        }

        [NotMapped]
        public BitmapImage BitmapImage
        {
            get
            {
                using (var ms = new System.IO.MemoryStream(Image))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
        }
        #endregion
    }
}
