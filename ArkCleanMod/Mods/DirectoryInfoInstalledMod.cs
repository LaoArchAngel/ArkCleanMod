using System;
using System.IO;

namespace ArkCleanMod.Mods
{
    /// <inheritdoc />
    public class DirectoryInfoInstalledMod : IInstalledMod
    {
        private readonly FileInfo _dotModFile;
        private readonly DirectoryInfo _installDir;

        internal DirectoryInfoInstalledMod(string installPath, long modId)
        {
            _installDir = new DirectoryInfo(Path.Combine(installPath, modId.ToString()));
            _dotModFile = new FileInfo(Path.Combine(installPath, $"{modId}.info"));
        }

        /// <inheritdoc />
        public bool IsInstalled
        {
            get { return _installDir.Exists }
        }

        /// <inheritdoc />
        public DateTime? InstallUpdate
        {
            get
            {
                if (!(_installDir.Exists && _dotModFile.Exists))
                {
                    return null;
                }

                return _installDir.LastWriteTimeUtc;
            }
        }
    }
}