using System.Windows.Media.Imaging;

namespace TotalCommander.Model
{
    public class Drive : MemoryItem
    {
        public Drive(in string name, in string path, double size)
            : base(name, "<DIR>", path, size)
        {

        }

        protected override BitmapSource GetImage(in string path)
        {
            try
            {
                string fullPath = System.IO.Path.GetFullPath(@"..\..\..\Images\drive.png");
                return new BitmapImage(new System.Uri(fullPath));
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
