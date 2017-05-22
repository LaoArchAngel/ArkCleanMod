using System;
using System.IO;

namespace ArkCleanMod.Mods.Factories
{
    /// <inheritdoc />
    public class DirectoryInfoInstalledModFactory : IInstalledModFactory
    {
        private readonly string _installPath;

        /// <summary>
        /// Creates a new instance of <see cref="DirectoryInfoInstalledModFactory"/> with the given <paramref name="installPath">mod install path</paramref>
        /// </summary>
        /// <param name="installPath">Path to where mods are installed.  Typically found under steamapps/common/Ark/ShooterGame/Content/Mods</param>
        private DirectoryInfoInstalledModFactory(string installPath)
        {
            _installPath = installPath;
            
            var installDir = new DirectoryInfo(installPath);

            if (!installDir.Exists) { throw new ArgumentException("Install path does not exist");}
        }

        /// <inheritdoc />
        public IInstalledMod GetInstalledMod(long modId)
        {
            return new DirectoryInfoInstalledMod(_installPath, modId);
        }
    }
}