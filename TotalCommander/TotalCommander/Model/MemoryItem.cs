using System.Windows.Media.Imaging;

namespace TotalCommander.Model
{
    public abstract class MemoryItem : System.Object
    {
        public enum SizeRepresentation : byte
        {
            B = 0,
            KB,
            MB,
            GB,
            TB
        }

        private const string separator = " ";
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
            Path = path;
            Image = GetImage(Path);
            this.size = size;
        }
        #endregion

        #region Private Fields
        private readonly double size;
        #endregion

        #region Public Fields
        public BitmapSource Image { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Size => (this.size / System.Math.Pow(1024, (uint)sizeRepresentation)).ToString() +
                    separator + sizeRepresentation.ToString();
        public MemoryItem Parent { get; set; }
        #endregion

        #region Private methods
        protected abstract BitmapSource GetImage(in string path);
        #endregion
    }
}
