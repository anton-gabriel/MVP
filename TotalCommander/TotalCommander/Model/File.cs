using System.Windows.Media.Imaging;

namespace TotalCommander.Model
{
    public class File : MemoryItem
    {
        public File(in string name, in string type, in string path, double size, in System.DateTime date)
            : base(name, type, path, size, date)
        {

        }

        protected override BitmapSource GetImage(in string path)
        {
            using (System.Drawing.Icon sysicon = System.Drawing.Icon.ExtractAssociatedIcon(path))
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(
                    sysicon.Handle,
                    System.Windows.Int32Rect.Empty,
                    System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            }
        }
    }
}
