using System;
using System.IO;

namespace ArkCleanMod.Mods.Factories
{
    /// <summary>
    ///     An implementation of <see cref="IDownloadedModFactory" /> that creates <see cref="DirectoryInfoDownloadedMod" />
    ///     instances of <see cref="IDownloadedMod" />.
    /// </summary>
    public class DirectoryInfoDownloadedModFactory : IDownloadedModFactory
    {
        private readonly string _downloadPath;

        /// <summary>
        ///     Creates a new instance of <see cref="DirectoryInfoDownloadedModFactory" /> with the given
        ///     <paramref name="downloadPath">download path</paramref>
        /// </summary>
        /// <param name="downloadPath">Path to downloaded mods.</param>
        /// <exception cref="ArgumentException">When <paramref name="downloadPath" /> does not point to an existing directory.</exception>
        public DirectoryInfoDownloadedModFactory(string downloadPath)
        {
            _downloadPath = downloadPath;

            var downloadsFolder = new DirectoryInfo(_downloadPath);

            if (!downloadsFolder.Exists)
            {
                throw new ArgumentException("Download path does not exist.");
            }
        }

        /// <inheritdoc />
        public IDownloadedMod GetDownloadedMod(long modId)
        {
            return new DirectoryInfoDownloadedMod(_downloadPath, modId);
        }
    }
}