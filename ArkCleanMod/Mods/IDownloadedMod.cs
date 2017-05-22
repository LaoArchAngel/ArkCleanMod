using System;

namespace ArkCleanMod.Mods
{
    public interface IDownloadedMod
    {
        DateTime DownloadUpdate { get; }
        bool DownloadHasFiles { get; }
    }
}