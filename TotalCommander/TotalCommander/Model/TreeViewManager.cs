using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace TotalCommander.Model
{
    sealed class TreeViewManager
    {
        #region Constructors
        public TreeViewManager()
        {
            Initialize();
        }
        #endregion

        #region Public fields
        public List<TreeViewItem> Data { get; private set; }
        #endregion

        #region Private methods
        private void Initialize()
        {
            Data = new List<TreeViewItem>();
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                Data.Add(CreateChild(driveInfo));
            }
        }
        #endregion

        #region Public methods
        private TreeViewItem CreateChild(object obj)
        {
            TreeViewItem item = new TreeViewItem()
            {
                Header = obj.ToString(),
                Tag = obj
            };
            if (!(obj is FileInfo))
            {
                item.Items.Add(null);
            }
            return item;
        }

        public void Expand(TreeViewItem item)
        {
            item.Items.Clear();
            DirectoryInfo expanded = null;
            if (item.Tag is DriveInfo)
            {
                expanded = (item.Tag as DriveInfo).RootDirectory;
            }
            if (item.Tag is DirectoryInfo)
            {
                expanded = (item.Tag as DirectoryInfo);
            }
            try
            {
                foreach (DirectoryInfo dir in expanded.GetDirectories())
                {
                    item.Items.Add(CreateChild(dir));
                }
                foreach (FileInfo file in expanded.GetFiles())
                {
                    item.Items.Add(CreateChild(file));
                }
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }
        #endregion
    }
}
