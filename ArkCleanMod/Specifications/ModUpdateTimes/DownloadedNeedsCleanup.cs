namespace ArkCleanMod.Specifications.ModUpdateTimes
{
    internal class DownloadedNeedsCleanup : ISpecifcation<ModInfo>
    {
        /// <summary>
        ///     Determines whether the download directory of a mod needs cleaning.
        /// </summary>
        /// <param name="entity">The mod to check</param>
        /// <returns>Returns <c>true</c> if the installation is up-to-date and the download folder still has mod files.</returns>
        public bool IsSatisfiedBy(ModInfo entity)
        {
            if (!entity.InstallUpdate.HasValue)
            {
                return false;
            }

            return !(entity.DownloadUpdate > entity.InstallUpdate) && entity.DownloadHasFiles;
        }
    }
}