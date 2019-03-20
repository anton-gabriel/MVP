using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TotalCommander
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
