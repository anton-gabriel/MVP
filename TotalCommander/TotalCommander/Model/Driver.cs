using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TotalCommander.Model
{
    class Driver
    {
        public List<DriveInfo> Drives { get; set; }
        public Driver()
        {
            Drives = DriveInfo.GetDrives().ToList();
        }
    }
}
