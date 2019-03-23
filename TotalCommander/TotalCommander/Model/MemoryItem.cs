using System.Windows.Media.Imaging;

namespace TotalCommander.Model
{
    public abstract class MemoryItem : System.Object
    {
        public enum SizeRepresentation : byte
        {
            Invalid = 0,
            B,
            KB,
            MB,
            GB,
            TB
        }
        public static SizeRepresentation sizeRepresentation;

        #region Constructors
        static MemoryItem()
        {
            sizeRepresentation = SizeRepresentation.B;
        }
        public MemoryItem(in string name, in string type, in string path, double size)
        {
            Name = name;
            Type = type;
            Size = size;
            Path = path;
            Image = GetImage(Path);
        }
        #endregion

        #region Private Fields
        private double size;
        #endregion

        #region Public Fields
        public BitmapSource Image { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Size
        {
            get { return this.size / System.Math.Pow(1024, (uint)sizeRepresentation); }
            set { this.size = value; }
        }
        public MemoryItem Parent { get; set; }

        #endregion

        #region Private methods
        protected abstract BitmapSource GetImage(in string path);
        #endregion
    }
}
