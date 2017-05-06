using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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

            bool foundWorkshop = BaseDir.GetDirectories("workshop").Any();
            bool foundCommon = BaseDir.GetDirectories("common").Any();

            if (!(foundWorkshop && foundCommon))
            {
                throw new ArgumentException(
                    "The base directory does not appear to be the correct path.  Please find your steamapps folder and try again.  The steamapps folder is generally located directly inside the steam install directory (eg. C:\\Program Files (x86)\\Steam\\steamapps)");
            }
        }

        public void Start()
        {
            while (!stopCalled)
            {
                
            }
        }

        Task Scan(CancellationToken cancel)
        {
            DirectoryInfo downloads = new DirectoryInfo(Path.Combine(BaseDir.FullName, @"workshop\content\346110"));

            if (!downloads.Exists)
                return null;

            foreach (DirectoryInfo modDownload in downloads.EnumerateDirectories())
            {
                DirectoryInfo modInstall = FindInstallFolder(modDownload.Name);

                if (modInstall != null)
                {
                    
                }
            }
        }

        private DirectoryInfo FindInstallFolder(string modId)
        {
            DirectoryInfo installFolder = new DirectoryInfo(Path.Combine(BaseDir.FullName, @""));
        }
    }
}
