using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace TotalCommander.Model
{
    class DataGridManager
    {
        #region Constructors
        public DataGridManager()
        {
            Initialize();
        }
        #endregion

        #region Public Fields
        public ObservableCollection<MemoryItem> Data { get; private set; }
        public MemoryItem CurrentDirectory { get; private set; }
        #endregion

        #region Private Fields
        private Stack<MemoryItem> backward;
        private Stack<MemoryItem> forward;
        #endregion

        #region Public methods
        public static MemoryItem CreateChild(object obj)
        {
            MemoryItem item = null;
            if (obj is FileInfo)
            {
                FileInfo fileInfo = obj as FileInfo;
                item = new Model.File(fileInfo.Name, fileInfo.Extension, fileInfo.FullName, fileInfo.Length, fileInfo.CreationTime);
            }
            if (obj is DirectoryInfo)
            {
                DirectoryInfo directoryInfo = obj as DirectoryInfo;
                item = new Model.Directory(directoryInfo.Name, directoryInfo.Extension, directoryInfo.FullName, directoryInfo.CreationTime);
            }
            if (obj is DriveInfo)
            {
                DriveInfo driveInfo = obj as DriveInfo;
                item = new Model.Drive(driveInfo.Name, driveInfo.Name, driveInfo.TotalSize - driveInfo.TotalFreeSpace);
            }
            return item;
        }


        public void Open(in MemoryItem item)
        {
            if (this.forward.Count != 0)
            {
                if (item.Path != this.forward.Peek().Path)
                {
                    this.forward.Clear();
                }
            }
            OpenMemoryItem(item);
        }

        private void OpenMemoryItem(in MemoryItem item)
        {
            try
            {
                if (!(item is Drive))
                {
                    this.backward.Push(item);
                }
                FileAttributes attr = System.IO.File.GetAttributes(item.Path);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    CurrentDirectory = item as MemoryItem;
                    DirectoryInfo directoryInfo = new DirectoryInfo(item.Path);
                    List<MemoryItem> items = new List<MemoryItem>();

                    foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                    {
                        MemoryItem child = CreateChild(dir);
                        child.Parent = item;
                        items.Add(child);
                    }
                    foreach (FileInfo file in directoryInfo.GetFiles())
                    {

                        MemoryItem child = CreateChild(file);
                        child.Parent = item;
                        items.Add(child);
                    }
                    LoadNewData(items);
                }
            }
            catch (System.UnauthorizedAccessException)
            {
                System.Windows.MessageBox.Show("Access denied");
            }

        }

        public void Back()
        {
            if (this.backward.Count != 0)
            {
                this.forward.Push(this.backward.Peek());
                OpenMemoryItem(this.backward.Pop().Parent);
            }
        }

        public void Next()
        {
            if (this.forward.Count != 0)
            {
                OpenMemoryItem(this.forward.Pop());
            }
        }
        public void Refresh()
        {
            if (CurrentDirectory != null)
            {
                Open(CurrentDirectory);
            }
        }
        #endregion

        #region Private methods
        private void Initialize()
        {
            Data = new ObservableCollection<MemoryItem>();
            this.backward = new Stack<MemoryItem>();
            this.forward = new Stack<MemoryItem>();
        }
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