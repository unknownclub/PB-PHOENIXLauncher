using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management; //Need to manually add to the References
using System.IO;
using System.Collections;

namespace PointBlank.Launcher
{
    class cHWID
    {
        public static String getUniqueID()
        {
            string drive = "C";
            if (drive == string.Empty)
            {
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                drive = drive.Substring(0, drive.Length - 2);
            }

            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            string volumeSerial = "";
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();
            foreach (ManagementObject managObj in managCollec)
            {
                volumeSerial = disk["VolumeSerialNumber"].ToString();
                disk.Dispose();
            }
            return cpuInfo.Substring(13) + cpuInfo.Substring(1, 4) + volumeSerial + cpuInfo.Substring(4, 4);
        }
    }
}