using System;
using System.IO;
using System.Linq;

namespace ArkCleanMod.Mods
{
    public class DirectoryInfoDownloadedMod : IDownloadedMod
    {
        private readonly DirectoryInfo _modDir;

        /// <summary>
        /// Creates a new <see cref="IDownloadedMod"/> instance based on folders data.
        /// </summary>
        /// <param name="downloadPath">Path to mod downloads.  Normally under steamapps\workshop\content\36114</param>
        /// <param name="modId"></param>
        internal DirectoryInfoDownloadedMod(string downloadPath, long modId)
        {
            _modDir = new DirectoryInfo(Path.Combine(downloadPath, modId.ToString()));

            if(!_modDir.Exists)
                throw new ArgumentException("The downloaded mod could not be found.");
        }

        /// <inheritdoc />
        public DateTime DownloadUpdate => _modDir.LastWriteTimeUtc;

        /// <inheritdoc />
        public bool DownloadHasFiles => _modDir.GetDirectories().Any();
    }
}