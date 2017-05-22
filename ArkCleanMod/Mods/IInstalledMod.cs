using System;

namespace ArkCleanMod.Mods {
    public interface IInstalledMod {
        DateTime? InstallUpdate { get; }
    }
}