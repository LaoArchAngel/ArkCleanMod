using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArkCleanMod
{
    public interface IModProcessor
    {
        Task ProcessModsAsync(IDictionary<long, ModInfo> mods);
    }
}