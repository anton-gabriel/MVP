using System.Collections.Generic;
using System.IO;

namespace TotalCommander.Model
{
    class Driver
    {
        public List<Drive> Drives { get; set; }
        public Driver()
        {
            Drives = new List<Drive>();
            foreach (DriveInfo driveInfo in DriveInfo.GetDrives())
            {
                Drives.Add(new Drive(driveInfo.Name, driveInfo.Name, driveInfo.TotalSize - driveInfo.TotalFreeSpace));
            }
        }
    }
}
