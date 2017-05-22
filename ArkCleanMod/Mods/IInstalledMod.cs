using System;

namespace ArkCleanMod.Mods {
    public interface IInstalledMod {
        DateTime? InstallUpdate { get; }

        /// <summary>
        ///     Gets whether or not the mod is installed.
        /// </summary>
        bool IsInstalled { get; }
    }
}