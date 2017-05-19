using System;
using System.IO;
using System.Linq;

namespace ArkCleanMod
{
    internal class ModInfo
    {
        public ModInfo(DirectoryInfo installDir, DirectoryInfo downloadDir, long modId)
        {
            ModId = modId;
            DownloadDir = new DirectoryInfo(Path.Combine(downloadDir.FullName, modId.ToString()));
            InstallDir = new DirectoryInfo(Path.Combine(installDir.FullName, modId.ToString()));
            DotModFile = new FileInfo(Path.Combine(installDir.FullName, $"{modId}.mod"));
        }

        public long ModId { get; }

        public DateTime DownloadUpdate => DownloadDir.LastWriteTimeUtc;

        public DateTime? InstallUpdate
        {
            get
            {
                if (!(InstallDir.Exists && DotModFile.Exists))
                {
                    return null;
                }

                return InstallDir.LastWriteTimeUtc;
            }
        }

        internal DirectoryInfo DownloadDir { get; }

        internal DirectoryInfo InstallDir { get; }

        internal FileInfo DotModFile { get; }

        public bool DownloadHasFiles => DownloadDir.GetDirectories().Any();
    }
}