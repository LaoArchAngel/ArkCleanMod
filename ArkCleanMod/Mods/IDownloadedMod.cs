using System;

namespace ArkCleanMod.Mods
{
    /// <summary>
    ///     Represents a downloaded mod.
    /// </summary>
    public interface IDownloadedMod
    {
        /// <summary>
        ///     The UTC date/time a mod was last downloaded.  Includes re-downloads and updates.
        /// </summary>
        DateTime DownloadUpdate { get; }

        /// <summary>
        ///     Whether or not the download folder contains any non-essential files.
        /// </summary>
        bool DownloadHasFiles { get; }
    }
}