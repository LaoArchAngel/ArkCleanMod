using System;

namespace ArkCleanMod
{
    internal class ModUpdateTimes
    {
        public ModUpdateTimes(long modId)
        {
            ModId = modId;
        }

        public long ModId { get; }

        public DateTime DownloadUpdate { get; set; }

        public DateTime InstallUpdate { get; set; }
    }
}