using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PointBlank.Launcher
{
    [Obfuscation(Feature = "virtualization", Exclude = false)]
    public class Modul
    {
        public static string LOGIN = "http://pb-indy.com/api_launcher/PhoenixLauncher/";
        public static string WEB = "http://pb-indy.com/api_launcher/PhoenixLauncher/";
        public static string UPDATEPATCH = "http://pb-indy.com/api_launcher/PhoenixLauncher/";
        public static string Name = "PBINDYLauncher";
    }
}
