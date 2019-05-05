using Sudoku.Models.User;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sudoku.Services.ReaderServices
{
    internal static class ImagesReader
    {
        #region Public methods
        public static List<Image> Read(string path)
        {
            List<Image> images = new List<Image>();
            string[] extensions = new string[] { ".jpg", ".png", ".gif" };
            var files = new DirectoryInfo(path).GetFiles().Where(file => extensions.Contains(file.Extension));
            foreach (var file in files)
            {
                images.Add(new Image() { Path = file.FullName });
            }
            return images;
        }
        #endregion
    }
}
