namespace ArkCleanMod.Mods.Factories
{
    /// <summary>
    ///     Creates instances of <see cref="IInstalledMod" /> based on implementation preferences.
    /// </summary>
    public interface IInstalledModFactory
    {
        /// <summary>
        ///     Creates and returns an instance of <see cref="IInstalledMod" />
        /// </summary>
        /// <param name="modId">Numeric ID of the mod.</param>
        /// <returns>Instance of an <see cref="IInstalledMod" /> implementation.</returns>
        IInstalledMod GetInstalledMod(long modId);
    }
}