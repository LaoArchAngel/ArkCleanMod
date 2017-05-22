using System;

namespace ArkCleanMod.Mods
{
    public class ModInfo
    {
        private readonly IInstalledMod _installedMod;

        private readonly IDownloadedMod _downloadedMod;

        public ModInfo(long modId, IDownloadedMod downloaded, IInstalledMod installed)
        {
            _downloadedMod = downloaded;
            _installedMod = installed;
            ModId = modId;
        }

        public long ModId { get; }

        public DateTime DownloadUpdate => _downloadedMod.DownloadUpdate;

        public DateTime? InstallUpdate => _installedMod?.InstallUpdate;

        public bool DownloadHasFiles => _downloadedMod.DownloadHasFiles;
    }
}