using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace TotalCommander.Model
{
    class ListViewManager
    {
        #region Singleton instance
        private static ListViewManager instance;
        public static ListViewManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ListViewManager();
                    instance.Initialize();
                }
                return instance;
            }
        }
        #endregion

        #region Public Fields
        public ObservableCollection<MemoryItem> Data { get; private set; }
        #endregion

        #region Private Fields
        private Stack<MemoryItem> backward;
        private Stack<MemoryItem> forward;
        #endregion

        #region Private methods
        private void Initialize()
        {
            Data = new ObservableCollection<MemoryItem>();
            this.backward = new Stack<MemoryItem>();
            this.forward = new Stack<MemoryItem>();
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                Data.Add(CreateChild(driveInfo));
            }
        }
        #endregion

        #region Public methods
        public MemoryItem CreateChild(object obj)
        {
            MemoryItem item = null;
            if (obj is FileInfo)
            {
                FileInfo fileInfo = obj as FileInfo;
                item = new Model.File(fileInfo.Name, fileInfo.Extension, fileInfo.FullName, fileInfo.Length);
            }
            if (obj is DirectoryInfo)
            {
                DirectoryInfo directoryInfo = obj as DirectoryInfo;
                item = new Model.Directory(directoryInfo.Name, directoryInfo.Extension, directoryInfo.FullName);
            }
            if (obj is DriveInfo)
            {
                DriveInfo driveInfo = obj as DriveInfo;
                item = new Model.Drive(driveInfo.Name, driveInfo.Name, driveInfo.TotalSize - driveInfo.TotalFreeSpace);
            }
            return item;
        }

        public void Open(in string path)
        {
            try
            {
                FileAttributes attr = System.IO.File.GetAttributes(path);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    this.backward.Push(CreateChild(directoryInfo));
                    List<MemoryItem> items = new List<MemoryItem>();
                    foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                    {
                        items.Add(CreateChild(dir));
                    }
                    foreach (FileInfo file in directoryInfo.GetFiles())
                    {
                        items.Add(CreateChild(file));
                    }
                    LoadNewData(items);
                }
            }
            catch (System.UnauthorizedAccessException)
            {
                System.Windows.MessageBox.Show("Access denied");
            }

        }
        #endregion

        #region Private methods
        private void LoadNewData(in List<MemoryItem> items)
        {
            Data.Clear();
            foreach (MemoryItem item in items)
            {
                Data.Add(item);
            }
        }
        #endregion
    }
}