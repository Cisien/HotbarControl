using System.Collections.Generic;
using Harmony;

namespace HotbarControl
{
    public class Mod : FortressCraftMod
    {
        private readonly HarmonyInstance _harmony;

        public Mod() 
        {
            _harmony = HarmonyInstance.Create("com.cisien.fc.hotbarcontrol");
            var originalAddToHotbarUshortUshort = AccessTools.Method(typeof(PlayerInventory), nameof(PlayerInventory.AddToHotbar), new[] { typeof(ushort), typeof(ushort) });
            var originalAddToHotbarInt = AccessTools.Method(typeof(PlayerInventory), nameof(PlayerInventory.AddToHotbar), new[] { typeof(int) });

            var patchMethod = new HarmonyMethod(typeof(Mod), nameof(NoOpPatch));

            _harmony.Patch(originalAddToHotbarUshortUshort, null, null, patchMethod);
            _harmony.Patch(originalAddToHotbarInt, null, null, patchMethod);
           
        }

        public override ModRegistrationData Register()
        {
            var regData = new ModRegistrationData();
            return regData;
        }

        private static IEnumerable<CodeInstruction> NoOpPatch(IEnumerable<CodeInstruction> instructions)
        {
            yield break;
        }

    }
}
