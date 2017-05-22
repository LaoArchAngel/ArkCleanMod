using System;
using System.IO;

namespace ArkCleanMod.Mods.Factories
{
    public class DirectoryInfoDownloadedModFactory : IDownloadedModFactory
    {
        private readonly string _downloadPath;

        public DirectoryInfoDownloadedModFactory(string downloadPath)
        {
            _downloadPath = downloadPath;

            var downloadsFolder = new DirectoryInfo(_downloadPath);

            if (!downloadsFolder.Exists)
            {
                throw new ArgumentException("Download path does not exist.");
            }
        }

        public IDownloadedMod GetDownloadedMod(long modId)
        {
            return new DirectoryInfoDownloadedMod(_downloadPath, modId);
        }
    }
}