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
        private readonly int _scanInterval;


        private readonly DirectoryInfo _installDir, _downloadDir;
        private readonly Dictionary<long, ModInfo> _mods = new Dictionary<long, ModInfo>();

        public Inspector(int scanInterval, string downloadPath, string installPath)
        {
            _scanInterval = scanInterval;
            _downloadDir = new DirectoryInfo(downloadPath);
            _installDir = new DirectoryInfo(installPath);

            if(!_installDir.Exists) throw new ArgumentException("The given mod installation path cannot be found.", nameof(installPath));
            if(!_downloadDir.Exists) throw new ArgumentException("The given mod download path cannot be found.", nameof(downloadPath));
        }

        public void Start()
        {
            //while (!stopCalled)
            //{
                
            //}
        }

        public void Stop()
        {
            
        }

        private Task ScanAsync(CancellationToken cancel)
        {
            var tasks = new List<Task>();

            foreach (DirectoryInfo modDownload in _downloadDir.EnumerateDirectories())
            {
                tasks.Add(Task.Run(() => AddMod(modDownload, _installDir, _downloadDir), cancel));
            }

            return Task.WhenAll(tasks.ToArray());
        }

        private void AddMod(DirectoryInfo modDownload, DirectoryInfo gameDir, DirectoryInfo downloads)
        {
            if (!long.TryParse(modDownload.Name, out long modId))
                return;

            var mod = new ModInfo(gameDir, downloads, modId);
            _mods.Add(modId, mod);
        }
    }
}
