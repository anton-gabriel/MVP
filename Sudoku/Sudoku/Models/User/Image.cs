using System;
using System.Runtime.Serialization;
using System.Windows.Media.Imaging;

namespace Sudoku.Models.User
{
    [Serializable]
    internal class Image : ISerializable
    {
        #region Constructors
        public Image() { }
        public Image(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }
            Path = (string)info.GetValue(name: nameof(Path), type: typeof(string));
        }
        #endregion

        #region Private fields
        private string path;
        #endregion

        #region Properties
        public string Path
        {
            get
            {
                return this.path;
            }
            set
            {
                this.path = value;
                string fullPath = System.IO.Path.GetFullPath(Path);
                BitmapImage = new BitmapImage(new Uri(fullPath));
            }
        }
        public BitmapImage BitmapImage { get; private set; }
        #endregion

        #region ISerializable
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(name: nameof(Path), value: Path);
        }
        #endregion
    }
}
