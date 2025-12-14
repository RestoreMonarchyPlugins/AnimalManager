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
            AnimalManagerPlugin pluginInstance = AnimalManagerPlugin.Instance;

            // If custom loot was dropped, skip the original method
            return !pluginInstance.DropLoot(animal);
        }

        [HarmonyPatch("respawnAnimals")]
        [HarmonyPrefix]
        static bool respawnAnimals_Prefix()
        {
            AnimalManagerPlugin pluginInstance = AnimalManagerPlugin.Instance;

            return pluginInstance.AnimalSpawnService == null;
        }
    }
}
