using System;

namespace ArkCleanMod.Mods
{
    /// <summary>
    ///     Represents an installed mod
    /// </summary>
    public interface IInstalledMod
    {
        /// <summary>
        ///     The UTC date/time when the mod was last updated.
        /// </summary>
        DateTime? InstallUpdate { get; }

        /// <summary>
        ///     Gets whether or not the mod is installed.
        /// </summary>
        bool IsInstalled { get; }
    }
}