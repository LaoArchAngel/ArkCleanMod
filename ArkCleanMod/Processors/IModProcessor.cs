using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArkCleanMod.Processors
{
    public interface IModProcessor
    {
        Task ProcessModsAsync(IDictionary<long, ModInfo> mods);
    }
}