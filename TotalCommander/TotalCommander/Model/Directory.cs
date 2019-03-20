using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace TotalCommander.Model
{
    public class Directory : MemoryItem
    {
        public Directory(in string name, in string type, in string path)
            : base(name, type, path, double.NaN)
        {

        }

        protected override BitmapSource GetImage(in string path)
        {
            try
            {
                string fullPath = System.IO.Path.GetFullPath(@"..\..\..\Images\folder.png");
                return new BitmapImage(new System.Uri(fullPath));
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
