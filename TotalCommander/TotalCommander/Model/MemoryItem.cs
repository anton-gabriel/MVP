﻿using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
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


        #region Static methods
        public static void ViewItems(in List<MemoryItem> items)
        {
            foreach (MemoryItem memoryItem in items)
            {
                try
                {
                    Process.Start(memoryItem.Path);
                }
                catch (System.Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }
        }
        public static void CopyItems(in List<MemoryItem> items, in MemoryItem destination)
        {
            if (destination == null)
            {
                Utils.UserDialog.MessageDialog("Please open a destination directory.");
                return;
            }
            foreach (MemoryItem memoryItem in items)
            {
                try
                {
                    string path = destination.Path + "\\" + memoryItem.Name;
                    if (System.IO.Directory.Exists(path))
                    {
                        Utils.UserDialog.MessageDialog($"Path {path} exists already", type: Utils.DialogType.Alert);
                        return;
                    }
                    if (memoryItem is File)
                    {
                        System.IO.File.Copy(memoryItem.Path, destination.Path + "\\" + memoryItem.Name);
                    }
                    else if (memoryItem is Directory)
                    {
                        new Microsoft.VisualBasic.Devices.Computer().
                            FileSystem.CopyDirectory(memoryItem.Path, destination.Path);
                    }
                }
                catch (System.Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }

            }
        }
        public static void MoveItems(in List<MemoryItem> items, in MemoryItem destination)
        {
            if (destination == null)
            {
                Utils.UserDialog.MessageDialog("Please open a destination directory.");
                return;
            }
            foreach (MemoryItem memoryItem in items)
            {
                try
                {
                    string path = destination.Path + "\\" + memoryItem.Name;
                    if (System.IO.Directory.Exists(path))
                    {
                        Utils.UserDialog.MessageDialog($"Path {path} exists already", type: Utils.DialogType.Alert);
                        return;
                    }
                    if (memoryItem is File)
                    {
                        System.IO.File.Move(memoryItem.Path, path);
                    }
                    else if (memoryItem is Directory)
                    {
                        System.IO.Directory.Move(memoryItem.Path, path);
                    }
                }
                catch (System.Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }
        }
        public static void CreateDirectory(in MemoryItem destination)
        {
            if (destination == null)
            {
                Utils.UserDialog.MessageDialog("Please open a destination directory.");
                return;
            }
            try
            {
                string name = Utils.UserDialog.GetInputDialog(message: "Enter directory name", defaultResponse: "New Folder");
                string path = destination.Path + "\\" + name;
                if (System.IO.Directory.Exists(path))
                {
                    Utils.UserDialog.MessageDialog($"Path {path} exists already", type: Utils.DialogType.Alert);
                    return;
                }
                System.IO.Directory.CreateDirectory(path);
            }
            catch (System.Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }
        public static void DeleteItems(in List<MemoryItem> items)
        {
            foreach (MemoryItem memoryItem in items)
            {
                try
                {
                    if (memoryItem is File)
                    {
                        System.IO.File.Delete(memoryItem.Path);
                    }
                    else if (memoryItem is Directory)
                    {
                        bool isNotEmpty = System.IO.Directory.EnumerateDirectories(memoryItem.Path).Any() ||
                            System.IO.Directory.EnumerateFiles(memoryItem.Path).Any();
                        if (isNotEmpty)
                        {
                            if (Utils.UserDialog.GetResponseDialog(message: $"Selected folder {memoryItem.Name} is not empty! " +
                                $"Are you sure you want to delete it?", type: Utils.DialogType.Alert))
                            {
                                System.IO.Directory.Delete(memoryItem.Path, true);
                            }
                        }
                        else
                        {
                            System.IO.Directory.Delete(memoryItem.Path, true);
                        }
                    }
                }
                catch (System.Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }
        }

        public static void PackItems(in List<MemoryItem> items, in MemoryItem destination)
        {
            string name = Utils.UserDialog.GetInputDialog(message: "Enter directory name", defaultResponse: items[0]?.Name + ".zip");
            string path = destination.Path + "\\" + name;
            if (System.IO.Directory.Exists(path))
            {
                Utils.UserDialog.MessageDialog($"Path {path} exists already", type: Utils.DialogType.Alert);
                return;
            }
            using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Create))
            {
                foreach (MemoryItem memoryItem in items)
                {
                    try
                    {
                        archive.CreateEntryFromFile(memoryItem.Path, memoryItem.Name);
                    }
                    catch (System.Exception exception)
                    {
                        System.Console.WriteLine(exception.Message);
                    }
                }
            }
        }

        public static void UnpackItems(in List<MemoryItem> items, in MemoryItem destination)
        {
            foreach (MemoryItem memoryItem in items)
            {
                try
                {
                    ZipFile.ExtractToDirectory(memoryItem.Path, destination.Path);
                }
                catch (System.Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }
        }
        #endregion

    }
}
