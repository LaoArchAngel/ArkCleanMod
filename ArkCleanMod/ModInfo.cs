using System;
using System.IO;
using System.Linq;

namespace ArkCleanMod
{
    internal class ModInfo
    {
        public ModInfo(DirectoryInfo gameDir, DirectoryInfo workshopDir, long modId)
        {
            ModId = modId;
            DownloadDir = new DirectoryInfo(Path.Combine(workshopDir.FullName, $"workshop\\content\\{modId}"));
            InstallDir = new DirectoryInfo(Path.Combine(gameDir.FullName, $"ShooterGame\\Content\\Mods\\{modId}"));
            DotModFile = new FileInfo(Path.Combine(gameDir.FullName, $"ShooterGame\\Content\\Mods\\{modId}.mod"));
        }

        public long ModId { get; }

        public DateTime DownloadUpdate => DownloadDir.LastWriteTimeUtc;

        public DateTime? InstallUpdate
        {
            get
            {
                if (!InstallDir.Exists || !DotModFile.Exists)
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