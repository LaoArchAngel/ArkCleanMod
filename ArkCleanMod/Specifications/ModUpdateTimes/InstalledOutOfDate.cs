namespace ArkCleanMod.Specifications.ModUpdateTimes
{
    internal class InstalledOutOfDate : ISpecifcation<ModInfo>
    {
        /// <summary>
        ///     Determins if a mod's installation is out of date.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns <c>true</c> if the mod's download version is newer than the installed version.</returns>
        public bool IsSatisfiedBy(ModInfo entity)
        {
            // We do not need to "clean" the install dir if it doesn not exist.
            if (!entity.InstallUpdate.HasValue)
                return false;

            return entity.DownloadUpdate > entity.InstallUpdate;
        }
    }
}