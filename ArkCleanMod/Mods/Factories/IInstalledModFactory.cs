namespace ArkCleanMod.Mods.Factories
{
    public interface IInstalledModFactory
    {
        IInstalledMod GetInstalledMod(long modId);
    }
}