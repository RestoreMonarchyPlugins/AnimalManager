using HarmonyLib;
using SDG.Unturned;

namespace RestoreMonarchy.AnimalManager.Patches
{
    [HarmonyPatch(typeof(SDG.Unturned.AnimalManager))]
    class AnimalManagerPatches
    {
        [HarmonyPatch("dropLoot")]
        [HarmonyPrefix]
        static bool dropLoot_Prefix(Animal animal)
        {
            return true;
        }

        [HarmonyPatch("respawnAnimals")]
        static bool respawnAnimals_Prefix()
        {
            return false;
        }
    }
}
