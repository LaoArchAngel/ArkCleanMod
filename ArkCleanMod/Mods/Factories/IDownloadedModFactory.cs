namespace ArkCleanMod.Mods.Factories
{
    /// <summary>
    ///     Creates instances of <see cref="IDownloadedMod" /> based on implementation preferences.
    /// </summary>
    public interface IDownloadedModFactory
    {
        /// <summary>
        ///     Creates and returns an instance of <see cref="IDownloadedMod" />.
        /// </summary>
        /// <param name="modId">Numeric ID of the mod.</param>
        /// <returns>Implementation of <see cref="IDownloadedMod" /></returns>
        IDownloadedMod GetDownloadedMod(long modId);
    }
}