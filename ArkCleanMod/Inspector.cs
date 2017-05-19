using System;
using System.Collections.Generic;
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
        private readonly Dictionary<long, ModInfo> Mods = new Dictionary<long, ModInfo>();

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

        private async Task ScanAsync(CancellationToken cancel)
        {
            DirectoryInfo downloads = new DirectoryInfo(Path.Combine(BaseDir.FullName, @"content\346110"));
            DirectoryInfo gameDir = new DirectoryInfo(Path.Combine(BaseDir.FullName, @"common\ARK"));

            if (!downloads.Exists)
                await Task.CompletedTask.ConfigureAwait(false);

            var tasks = new List<Task>();

            foreach (DirectoryInfo modDownload in downloads.EnumerateDirectories())
            {
                tasks.Add(Task.Run(() => AddMod(modDownload, gameDir, downloads), cancel));
            }

            await Task.WhenAll(tasks.ToArray()).ConfigureAwait(false);
        }

        private void AddMod(DirectoryInfo modDownload, DirectoryInfo gameDir, DirectoryInfo downloads)
        {
            if (!long.TryParse(modDownload.Name, out long modId))
                return;

            var mod = new ModInfo(gameDir, downloads, modId);
            Mods.Add(modId, mod);
        }
    }
}
