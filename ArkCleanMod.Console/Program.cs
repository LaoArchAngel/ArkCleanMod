using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ArkCleanMod.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var installed = new DirectoryInfo(@"C:\Program Files (x86)\Steam\steamapps\common\ARK\ShooterGame\Content\Mods");
            var downloaded = new DirectoryInfo(@"C:\Program Files (x86)\Steam\steamapps\workshop\content\346110");
            long modId = 775049557;
            var mod = new ModInfo(installed, downloaded, modId);
            var mods = new Dictionary<long, ModInfo>
            {
                {modId, mod}
            };
            var cleaner = new Processors.InstalledCleaner();
            //Task.Run(() => cleaner.ProcessModsAsync(mods)).GetAwaiter().GetResult();
            Task.Run(async () => await cleaner.ProcessModsAsync(mods).ConfigureAwait(false)).GetAwaiter().GetResult();
        }
    }
}