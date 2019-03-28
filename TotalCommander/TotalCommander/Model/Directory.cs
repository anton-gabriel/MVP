using System.Windows.Media.Imaging;

namespace TotalCommander.Model
{
    public class Directory : MemoryItem
    {
        public Directory(in string name, in string type, in string path, in System.DateTime date)
            : base(name, "Folder", path, double.NaN, date)
        {

        }

        protected override BitmapSource GetImage(in string path)
        {
            try
            {
                string fullPath = System.IO.Path.GetFullPath(@"..\..\Images\folder.png");
                return new BitmapImage(new System.Uri(fullPath));
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
