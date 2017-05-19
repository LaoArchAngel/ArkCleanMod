using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ArkCleanMod.Specifications.ModUpdateTimes;

namespace ArkCleanMod.Processors
{
    public class InstalledCleaner : IModProcessor
    {
        /// <summary>
        ///   Deletes the files from mod folders that were already installed.
        /// </summary>
        /// <param name="mods">List of all mods found</param>
        /// <returns>A task cleaning all mod folders that have been installed.</returns>
        public Task ProcessModsAsync(IDictionary<long, ModInfo> mods)
        {
            var spec = new DownloadedNeedsCleanup();
            IEnumerable<ModInfo> toClean = mods.Values.Where(spec.IsSatisfiedBy);
            var tasks = new List<Task>();

            foreach (ModInfo mod in toClean)
            {
                tasks.Add(Task.Run(() => CleanMod(mod)));
            }

            return Task.WhenAll(tasks);
        }

        private void CleanMod(ModInfo toClean)
        {
            DirectoryInfo downloadDir = toClean.DownloadDir;

            foreach (FileSystemInfo fileSystemInfo in downloadDir.EnumerateFileSystemInfos())
            {
                if (!IsKeyFile(fileSystemInfo))
                {
                    fileSystemInfo.Delete();
                }
            }
        }

        private bool IsKeyFile(FileSystemInfo file)
        {
            if (!(file is FileInfo))
                return false;

            if (file.Extension != "info")
                return false;

            return file.Name == "mod" || file.Name == "modmeta";
        }
    }
}