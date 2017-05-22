namespace ArkCleanMod.Mods.Factories
{
    public interface IDownloadedModFactory
    {
        IDownloadedMod GetDownloadedMod(long modId);
    }
}