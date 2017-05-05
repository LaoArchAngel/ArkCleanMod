using System;
using System.IO;
using System.Linq;

namespace ArkCleanMod
{
    public class Inspector
    {
        private readonly int ScanInterval;
        private readonly string BasePath;
        private readonly DirectoryInfo BaseDir;

        public Inspector(int scanInterval, string basePath)
        {
            ScanInterval = scanInterval;
            BasePath = basePath;

            BaseDir = new DirectoryInfo(BasePath);

            if(!BaseDir.Exists)
                throw new ArgumentException("The base directory does for steam mods does not exist.  Please supply a valid path.", basePath);

            if (!BaseDir.GetDirectories("workshop").Any() || !BaseDir.GetDirectories("common").Any())
            {
                throw new ArgumentException(
                    "The base directory does not appear to be the correct path.  Please find your steamapps folder and try again.  The steamapps folder is generally located directly inside the steam install directory (eg. C:\\Program Files (x86)\\Steam\\steamapps)");
            }
        }
    }
}
